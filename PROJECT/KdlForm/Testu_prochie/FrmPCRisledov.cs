using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Testu_prochie
{
    public partial class FrmPCRisledov : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmPCRisledov(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dateEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            tabImageComboBoxEdit8.DataBindings.Add(new Binding("SelectedIndex", dataSource, "material", true));
            tabImageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "hlamidia", true));
            tabImageComboBoxEdit2.DataBindings.Add(new Binding("SelectedIndex", dataSource, "micoplasma", true));
            //==24-5-2012
            tabImageComboBoxEdit12.DataBindings.Add(new Binding("SelectedIndex", dataSource, "micoplasmagenit", true));
            tabImageComboBoxEdit13.DataBindings.Add(new Binding("SelectedIndex", dataSource, "ureaplasmaplus", true));
            tabImageComboBoxEdit14.DataBindings.Add(new Binding("SelectedIndex", dataSource, "ureaplasmaparvum", true));
            //=================
            tabImageComboBoxEdit3.DataBindings.Add(new Binding("SelectedIndex", dataSource, "ureaplasma", true));
            tabImageComboBoxEdit4.DataBindings.Add(new Binding("SelectedIndex", dataSource, "herpes", true));
            tabImageComboBoxEdit5.DataBindings.Add(new Binding("SelectedIndex", dataSource, "cmv", true));
            tabImageComboBoxEdit6.DataBindings.Add(new Binding("SelectedIndex", dataSource, "vpch16", true));
            tabImageComboBoxEdit7.DataBindings.Add(new Binding("SelectedIndex", dataSource, "vpch18", true));
            tabImageComboBoxEdit9.DataBindings.Add(new Binding("SelectedIndex", dataSource, "vpcgrupa9", true));
            tabImageComboBoxEdit10.DataBindings.Add(new Binding("SelectedIndex", dataSource, "vpcgrupa7", true));
            tabImageComboBoxEdit11.DataBindings.Add(new Binding("SelectedIndex", dataSource, "vpcgrupa5a6", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "vpcgrupa9dec", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "vpcgrupa7dec", true));
            tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "vpcgrupa5a6dec", true));
            textEdit1.DataBindings.Add(new Binding("Text", dataSource, "prochee", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "vpch16dec", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "vpch18dec", true));
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }

        private void FrmPCRisledov_KeyUp(object sender, KeyEventArgs e)
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