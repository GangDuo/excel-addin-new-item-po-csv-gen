using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NIPO
{
    class Order
    {
        //：01 or 02（01=仮保存、02=確定）
        public string 確定区分 { get { return "01"; } }

        //：01 or 02 or 03（01=通常、02=直送、03=DC申請）
        public string 納入区分 { get; set; }

        public DateTime? 店舗入荷予定日付 { get; set; }
        public DateTime 物流入荷予定日付 { get; set; }
        public DateTime 掛計上日付 { get; set; }

        //：担当者CD（省略可、省略した場合はログイン担当者）
        public string 入力担当者 { get; set; }
        
        //：担当者CD（省略可、省略した場合はログイン担当者）
        public string 担当者 { get; set; }

        public string 出荷元 { get { return "9998"; } }
        public string 店舗 { get; set; }
        public string SKU { get; set; }
        public uint 数量 { get; set; }
        public string 展開項目 { get; set; }

    }
}
