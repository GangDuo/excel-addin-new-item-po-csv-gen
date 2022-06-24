using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace NIPO
{
    public partial class Ribbon1
    {

        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button3_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                var ds = new DataSource();
                var records = ds.ToList();
                if (records.Count() == 0)
                {
                    throw new Exception("データなし！");
                }

                var model = records.Select(record => record.店舗入荷予定日付)
                    .Distinct()
                    .OrderBy(x => x.Value)
                    .Select(x => new Models.DeliveryDatePicker(x, false))
                    .ToList();

                var v = new Views.DeliveryDatePickerForm(model);
                if(DialogResult.Cancel == v.ShowDialog())
                {
                    return;
                }
                var tasks = model.Where(x => x.IsEnabled).Select(x => x.Value).ToList();
                if (tasks.Count() == 0)
                {
                    throw new Exception("納期を選択してください。");
                }
                var orders = records.Where(o => tasks.Contains(o.店舗入荷予定日付));

                var file = Path.Combine(DesktopDirectory(), FileNameToSave());
                var csv = new CsvFile(orders)
                {
                    Name = file
                };
                csv.Save();

                MessageBox.Show(String.Format("完了！\n{0}", file));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string FileNameToSave()
        {
            var wb = Globals.ThisAddIn.Application.ActiveWorkbook;
            return String.Format("{0}.{1}", wb.Name.Split(new char[] { '.' }).First(), CsvFile.Extension);
        }

        private static string DesktopDirectory()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }
    }
}
