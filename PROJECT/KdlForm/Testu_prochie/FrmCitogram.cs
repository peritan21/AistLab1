using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Testu_prochie
{
    public partial class FrmCitogram : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmCitogram(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dateEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            tabImageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "kolvo", true));
            tabImageComboBoxEdit2.DataBindings.Add(new Binding("SelectedIndex", dataSource, "citogram", true));
            tabImageComboBoxEdit3.DataBindings.Add(new Binding("SelectedIndex", dataSource, "citogramdrugie", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "vospalitel", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "vospalitel1", true));
            textBox1.DataBindings.Add(new Binding("Text", dataSource, "drugieform", true));
            tabImageComboBoxEdit30.DataBindings.Add(new Binding("SelectedIndex", dataSource, "vbolshom", true));

        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit2.Properties.DataSource = Llabanaliz;
            lookUpEdit2.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }
        private void TabImageComboBoxEdit2SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bol5 = (tabImageComboBoxEdit2.SelectedIndex == 6);
            tabSpinEdit1.Visible = bol5;
            tabSpinEdit2.Visible = bol5;
            labelControl6.Visible = bol5;
            if (!bol5)
            {
                tabSpinEdit1.EditValue = 0;
                tabSpinEdit2.EditValue = 0;

            }
        }

        private void tabImageComboBoxEdit3_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  textBox1.Text = tabImageComboBoxEdit3.SelectedItem.ToString();
            textBox1.Focus();
        }

        private void FrmCitogram_KeyUp(object sender, KeyEventArgs e)
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