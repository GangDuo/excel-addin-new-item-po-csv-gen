using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvHelper.Configuration;

namespace NIPO
{
    class OrderMap : CsvClassMap<Order>
    {
        private readonly string DateTimeFormat = "yyyy-MM-dd";

        public OrderMap()
        {
            Map(m => m.確定区分).Index(0);
            Map(m => m.納入区分).Index(1);
            Map(m => m.店舗入荷予定日付).Index(2).TypeConverterOption(DateTimeFormat);
            Map(m => m.物流入荷予定日付).Index(3).TypeConverterOption(DateTimeFormat);
            Map(m => m.掛計上日付).Index(4).TypeConverterOption(DateTimeFormat);
            Map(m => m.入力担当者).Index(5);
            Map(m => m.担当者).Index(6);
            Map(m => m.出荷元).Index(7);
            Map(m => m.店舗).Index(8);
            Map(m => m.SKU).Index(9);
            Map(m => m.数量).Index(10);
            Map(m => m.展開項目).Index(11);
        }
    }
}
