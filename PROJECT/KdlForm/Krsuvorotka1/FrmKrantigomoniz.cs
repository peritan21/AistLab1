using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Krsuvorotka1
{
    public partial class FrmKrantihominiz : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmKrantihominiz(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dataDateEdit.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            // M.homonis
            tabImageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "hominizigm", true));
            tabImageComboBoxEdit2.DataBindings.Add(new Binding("SelectedIndex", dataSource, "hominizigg", true));
            //ВПГ
            tabImageComboBoxEdit8.DataBindings.Add(new Binding("SelectedIndex", dataSource, "vpgigm", true));
            tabImageComboBoxEdit7.DataBindings.Add(new Binding("SelectedIndex", dataSource, "vpgigg", true));
            tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "vpgiggdec", true));
            //  ЦВМИ
            tabImageComboBoxEdit10.DataBindings.Add(new Binding("SelectedIndex", dataSource, "cvmiigm", true));
            tabImageComboBoxEdit12.DataBindings.Add(new Binding("SelectedIndex", dataSource, "cvmiigg", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "cvmiiggdec", true));
            // Токсоплазмос
            tabImageComboBoxEdit9.DataBindings.Add(new Binding("SelectedIndex", dataSource, "toksoplazmozigm", true));
            tabImageComboBoxEdit13.DataBindings.Add(new Binding("SelectedIndex", dataSource, "toksoplazmozigg", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "toksoplazmoziggdec", true));
            //Краснуха
            tabImageComboBoxEdit11.DataBindings.Add(new Binding("SelectedIndex", dataSource, "krasnuxaigm", true));
            tabImageComboBoxEdit14.DataBindings.Add(new Binding("SelectedIndex", dataSource, "krasnuxaigg", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "krasnuxaiggdec", true));
            // Хламидиоз
            tabImageComboBoxEdit3.DataBindings.Add(new Binding("SelectedIndex", dataSource, "xlamidiozigm", true));
            tabImageComboBoxEdit4.DataBindings.Add(new Binding("SelectedIndex", dataSource, "xlamidioziga", true));
            tabImageComboBoxEdit5.DataBindings.Add(new Binding("SelectedIndex", dataSource, "xlamidiozigg", true));
            // Уреаплазмос
            tabImageComboBoxEdit6.DataBindings.Add(new Binding("SelectedIndex", dataSource, "ureaplazmozigm", true));
            tabImageComboBoxEdit15.DataBindings.Add(new Binding("SelectedIndex", dataSource, "ureaplazmozigg", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "ureaplazmoziggdec", true));

           // tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "igeobschee", true));
   
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }

        private void FrmKrSImmunIgAigMigGigE_KeyUp(object sender, KeyEventArgs e)
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

        private void tabImageComboBoxEdit7_SelectedIndexChanged(object sender, System.EventArgs e)
        {
           bool bol7 = (tabImageComboBoxEdit7.SelectedIndex >1);
           tabSpinEdit5.Visible = bol7;
           labelControl1.Visible = bol7;
        }

        private void tabImageComboBoxEdit12_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            bool bol8 = (tabImageComboBoxEdit12.SelectedIndex > 1);
            tabSpinEdit1.Visible = bol8;
            labelControl2.Visible = bol8;
        }

        private void tabImageComboBoxEdit13_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            bool bol9 = (tabImageComboBoxEdit13.SelectedIndex > 1);
            tabSpinEdit2.Visible = bol9;
            labelControl4.Visible = bol9;
        }

        private void tabImageComboBoxEdit14_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            bool bol10 = (tabImageComboBoxEdit14.SelectedIndex > 1);
            tabSpinEdit3.Visible = bol10;
            labelControl5.Visible = bol10;
        }

        private void tabImageComboBoxEdit15_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            bool bol11 = (tabImageComboBoxEdit15.SelectedIndex > 1);
            tabSpinEdit4.Visible = bol11;
            labelControl6.Visible = bol11;
        }   

    }
}