﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NIPO
{
    class DataSource
    {
        private const int HEADER_ROW = 11;
        private const int TBODY_ROW = 12;
        private const int JAN_COL = 16;
        private readonly string 納入区分_DC申請 = "03";

        public IEnumerable<Order> ToList()
        {
            var oo = new List<Order>();

            var sheet = Globals.ThisAddIn.Application.ActiveSheet;

            var 納入区分 = sheet.Cells[2, 13].Value;
            string 入力担当者 = sheet.Cells[8, 8].Text;
            string 担当者 = sheet.Cells[4, 8].Text;

            for (int row = TBODY_ROW; ; row++)
            {
                var jan = sheet.Cells[row, JAN_COL].Text;
                if (jan == null || jan == "")
                {
                    break;
                }

                var 店舗入荷予定日付 = sheet.Cells[row, 34].Value;
                if (店舗入荷予定日付 == null )
                {
                    continue;
                }
                var 物流入荷予定日付 = sheet.Cells[row, 33].Value;
                int 伝票月 = (int)sheet.Cells[row, 35].Value;
                int padding = 物流入荷予定日付.Month > 伝票月 ? 1 : 0;
                var 伝票年月日 = new DateTime(物流入荷予定日付.Year + padding, 伝票月, 1);
                var 掛計上日付 = 物流入荷予定日付.Month == 伝票年月日.Month ? 物流入荷予定日付 : 伝票年月日;
                var 展開項目 = sheet.Cells[row, 38].Value;
                uint 出荷確定数 = (uint)sheet.Cells[row, 19].Value;
                oo.Add(new Order()
                {
                    納入区分 = 納入区分,
                    店舗入荷予定日付 = 店舗入荷予定日付,
                    物流入荷予定日付 = 物流入荷予定日付,
                    掛計上日付 = 掛計上日付,
                    入力担当者 = 入力担当者,
                    担当者 = 担当者,
                    店舗 = 納入区分 == 納入区分_DC申請 ? String.Empty : "9998",
                    SKU = jan,
                    数量 = 出荷確定数,
                    展開項目 = 展開項目,

                });

                var clm = 43;
                while (true)
                {
                    string v = sheet.Cells[HEADER_ROW, clm].Value;
                    if (v == null || v == "") break;
                    var xs = v.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    uint howMany = (uint)(sheet.Cells[row, clm].Value ?? 0);

                    if (0 < howMany)
                    {
                        var o = new Order()
                        {
                            納入区分 = 納入区分,
                            店舗入荷予定日付 = 店舗入荷予定日付,
                            物流入荷予定日付 = 物流入荷予定日付,
                            掛計上日付 = 掛計上日付,
                            入力担当者 = 入力担当者,
                            担当者 = 担当者,
                            店舗 = xs[0],
                            SKU = jan,
                            数量 = howMany,
                            展開項目 = 展開項目,

                        };
                        oo.Add(o);
                    }

                    clm++;
                }
            }

            return oo;
        }
    }
}
