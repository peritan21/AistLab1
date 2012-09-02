using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.AnalizKala
{
    public partial class FrmCalglist : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmCalglist(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();

            dataDateEdit.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));

            tabImageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "eglist", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "eglistkol", true));
            tabImageComboBoxEdit2.DataBindings.Add(new Binding("SelectedIndex", dataSource, "prosteihie", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "prosteihiekol", true));

        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }private void TabImageComboBoxEdit1SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bol1 = (tabImageComboBoxEdit1.SelectedIndex == 2);
            tabSpinEdit1.Visible = bol1;
            labelControl1.Visible = bol1;
            if (!bol1) tabSpinEdit1.EditValue = 0;
        }

        private void TabImageComboBoxEdit2SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bol2 = (tabImageComboBoxEdit2.SelectedIndex == 2);
            tabSpinEdit2.Visible = bol2;
            labelControl2.Visible = bol2;
            if (!bol2) tabSpinEdit2.EditValue = 0;
        }

        private void FrmCalglist_KeyUp(object sender, KeyEventArgs e)
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