using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Analizkrovi
{
    public partial class FrmKrasnVolch : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmKrasnVolch(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dateEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            radioGroup1.DataBindings.Add(new Binding("Editvalue", dataSource, "volchanka", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "pol", true));

        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }
        private void RadioGroup1SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bol1 = (radioGroup1.SelectedIndex == 1);
            labelControl1.Visible = bol1;
            tabSpinEdit1.Visible = bol1;
            labelControl4.Visible = bol1;
        }

        private void FrmKrasnVolch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                PrintFormkrobch();
            }
        }
        private void PrintFormkrobch()
        {

            //var printDialog1 = new PrintDialog();simpleButton1.Visible = false;simpleButton2.Visible = false;
            printDocument1.PrintPage += OnDrawPage;
            simpleButton1.Visible = false;
            simpleButton2.Visible = false;
            string strText = Text;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
            simpleButton1.Visible = true;
            simpleButton2.Visible = true;
            Text = strText;
        }
        private void OnDrawPage(object sender, PrintPageEventArgs e)
        {
            ClassGrafiksReport.PrintToGraphics(e.Graphics, e.MarginBounds, PZAGOLOVOK0, this, 12);
        }  
    }
}