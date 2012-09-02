using System;
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
            //textBox1.DataBindings.Add(new Binding("Text", dataSource, "Uslivie", true));
            //textEdit1.DataBindings.Add(new Binding("Text", dataSource, "TABL_ID", true));
            //textEdit2.DataBindings.Add(new Binding("Text", dataSource, "TABLNAME", true));
        }
        public string PNameStr
        {
            set { txtBoxNameGroup.Text = value; }
            get { return txtBoxNameGroup.Text; }
        }
        public int PNpunktOtchet
        {
            set { spinEdit2.EditValue = value; }
            get { return int.Parse(spinEdit2.EditValue.ToString()); }
        }
        public int Pkolamb
        {
            set { spinEdit1.EditValue = value; }
            get { return int.Parse(spinEdit1.EditValue.ToString()); }
        }
        public int Pkolstac
        {
            set { spinEdit3.EditValue = value; }
            get { return int.Parse(spinEdit3.EditValue.ToString()); }
        }
    }
}
