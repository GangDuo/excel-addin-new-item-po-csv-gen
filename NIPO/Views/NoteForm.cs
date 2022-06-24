using MetroFramework.Forms;
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
    public partial class NoteForm : MetroForm
    {
        public NoteForm(DataTable model)
        {
            InitializeComponent();

            bindingSource1.DataSource = model;
            dataGridView1.DataSource = bindingSource1;
        }
    }
}
