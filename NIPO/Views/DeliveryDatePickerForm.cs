using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NIPO.Views
{
    public partial class DeliveryDatePickerForm : Form
    {
        public DeliveryDatePickerForm(List<Models.DeliveryDatePicker> model)
        {
            InitializeComponent();

            bindingSource1.DataSource = model;
            dataGridView1.DataSource = bindingSource1;
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            var dataGridView = (DataGridView)sender;
            if (dataGridView.IsCurrentCellDirty)
            {
                dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
