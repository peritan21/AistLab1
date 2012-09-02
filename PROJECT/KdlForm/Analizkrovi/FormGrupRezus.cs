using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AistLab
{
    public partial class FormGrupRezus : DevExpress.XtraEditors.XtraForm
    {
        public FormGrupRezus(BindingSource dataSource)
        {
            InitializeComponent();
            dataDateEdit.DataBindings.Add(new Binding("Editvalue", dataSource, "data"));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data"));
            gruppakrComboBoxEdit.DataBindings.Add(new Binding("SelectedIndex", dataSource, "gruppakr"));
            rezusfaktorRadioGroup.DataBindings.Add(new Binding("SelectedIndex", dataSource, "rezusfaktor"));
            spinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "titrantitel"));
            proheeTextEdit.DataBindings.Add(new Binding("Text", dataSource, "prohee"));
            antitelaRadioGroup.DataBindings.Add(new Binding("SelectedIndex", dataSource, "antitela"));
            //this.kRGRUPREZBindingSource = dataSource;

        }

        private void antitelaRadioGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            spinEdit1.Visible = (antitelaRadioGroup.SelectedIndex == 1);
            //layoutControlItem1.Control.Visible = bool1;
           // layoutControlItem1.TextVisible = bool1;
           // layoutControlItem1.ShowInCustomizationForm = bool1;
        }
    }
}