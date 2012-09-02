using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AistLab
{
    public partial class FormEditParOtchet : DevExpress.XtraEditors.XtraForm
    {

        public FormEditParOtchet(BindingSource dataSource)
        {
            InitializeComponent();
            //txtBoxNameGroup.DataBindings.Add(new Binding("Text", dataSource, "NameStr", true));
            //spinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "NpunktOtchet", true));
            //spinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "kolamb", true));
            //spinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "kolstac", true));
            textBox1.DataBindings.Add(new Binding("Text", dataSource, "Uslivie", true));
        }
        public string PNameStr
        {
            set { this.txtBoxNameGroup.Text = value; }
            get { return this.txtBoxNameGroup.Text; }
        }
        public int PNpunktOtchet
        {
            set { this.spinEdit2.EditValue = value; }
            get { return int.Parse(this.spinEdit2.EditValue.ToString()); }
        }
        public int Pkolamb
        {
            set { this.spinEdit1.EditValue = value; }
            get { return int.Parse(this.spinEdit1.EditValue.ToString()); }
        }
        public int Pkolstac
        {
            set { this.spinEdit3.EditValue = value; }
            get { return int.Parse(this.spinEdit3.EditValue.ToString()); }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }
   
 
    }
}
