using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.AnalizMochi
{
    public partial class FrmMohasaharbelok : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmMohasaharbelok(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dataDateEdit.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "diurez", true));
            radioGroup1.DataBindings.Add(new Binding("Editvalue", dataSource, "saharyes", true));
            radioGroup2.DataBindings.Add(new Binding("Editvalue", dataSource, "belokyes", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "sahar", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "belok", true));
    
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
            bool lbol1 = (radioGroup1.SelectedIndex == 0);
            tabSpinEdit2.Visible = lbol1;
            //if (lbol1) tabSpinEdit2.EditValue = 0;
        }

        private void RadioGroup2SelectedIndexChanged(object sender, EventArgs e)
        {
           bool lbol2 = (radioGroup2.SelectedIndex == 0);
           tabSpinEdit3.Visible = lbol2;
           //if (lbol2) tabSpinEdit3.EditValue = 0;

        }

        private void FrmMohasaharbelok_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                PrintFormkrobch();
            }
        }
        private void PrintFormkrobch()
        {
            printDocument1.PrintPage += OnDrawPage;
            string strText = Text;
            simpleButton1.Visible = false;
            simpleButton2.Visible = false;
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