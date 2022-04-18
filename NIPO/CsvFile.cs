using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NIPO
{
    class CsvFile
    {
        public static readonly string Extension = "csv";

        public string Name { get; set; }
        public Encoding Encoding { get; set; } = Encoding.GetEncoding("Shift_JIS");

        private IEnumerable<Order> Records;

        public CsvFile(IEnumerable<Order> records)
        {
            Records = records;
        }

        public void Save()
        {
            using (var writer = new StreamWriter(Name, false, Encoding))
            {
                using (var csv = new CsvHelper.CsvWriter(writer))
                {
                    csv.Configuration.HasHeaderRecord = false;
                    csv.Configuration.RegisterClassMap<OrderMap>();
                    csv.WriteRecords(Records);
                }
            }
        }
    }
}
