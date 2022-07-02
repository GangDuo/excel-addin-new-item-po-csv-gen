using NIPO.Components.DataGridViewX;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NIPO.Components
{
    public class UIHintMappings
    {
        public static Dictionary<string, Func<DataGridViewColumn>> DataGridViewColumns
        {
            get;
        }

        static UIHintMappings()
        {
            DataGridViewColumns = new Dictionary<string, Func<DataGridViewColumn>>();
            DataGridViewColumns.Add("TextBox",
                () => new DataGridViewTextBoxColumn());
            DataGridViewColumns.Add("CheckBox",
                () => new DataGridViewCheckBoxColumn(false));
            DataGridViewColumns.Add("TreeStateCheckBox",
                () => new DataGridViewCheckBoxColumn(true));
            DataGridViewColumns.Add("Link",
                () => new DataGridViewLinkColumn());
            DataGridViewColumns.Add("Calendar",
                () => new DataGridViewCalendarColumn());
        }
    }
}
