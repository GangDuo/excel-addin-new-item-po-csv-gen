using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NIPO.Components.DataGridViewX;

namespace NIPO.Views
{
    public partial class DeliveryDatePickerForm : MetroForm
    {
        public DeliveryDatePickerForm(IList<Models.DeliveryDatePicker> model)
        {
            InitializeComponent();

            bindingSource1.DataSource = model;
            dataGridView1.Bind(model, true);
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

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
