using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Analizkrovi
{
    public partial class FrmRekvLaborant : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmRekvLaborant(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dateEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            tabImageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "gruppakr", true));
            tabImageComboBoxEdit2.DataBindings.Add(new Binding("SelectedIndex", dataSource, "rezusfaktor", true));
            tabImageComboBoxEdit3.DataBindings.Add(new Binding("SelectedIndex", dataSource, "antitela", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "titrantitel",true));
             tabImageComboBoxEdit4.DataBindings.Add(new Binding("SelectedIndex", dataSource, "probakumbsa", true));
             textEdit1.DataBindings.Add(new Binding("Text", dataSource, "prohee", true));
             checkedComboBoxEdit1.DataBindings.Add(new Binding("Text", dataSource, "antigenustr", true));
             tabImageComboBoxEdit30.DataBindings.Add(new Binding("SelectedIndex", dataSource, "rekc", true));
             tabImageComboBoxEdit6.DataBindings.Add(new Binding("SelectedIndex", dataSource, "reke", true));
             tabImageComboBoxEdit7.DataBindings.Add(new Binding("SelectedIndex", dataSource, "rekcsmoll", true));
             tabImageComboBoxEdit8.DataBindings.Add(new Binding("SelectedIndex", dataSource, "rekesmoll", true));
             tabImageComboBoxEdit9.DataBindings.Add(new Binding("SelectedIndex", dataSource, "rekkell", true));
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }

        private void TabImageComboBoxEdit3SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bol1 = (tabImageComboBoxEdit3.SelectedIndex == 2);
            tabSpinEdit2.Visible = bol1;
            labelControl5.Visible = bol1;
            labelControl4.Visible = bol1;
        }

        private void FrmRekvLaborant_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                PrintFormkrobch();
            }
        }

        private void PrintFormkrobch()
        {
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
