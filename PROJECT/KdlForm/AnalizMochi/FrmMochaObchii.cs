using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.AnalizMochi
{
    public partial class FrmMochaObchii : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmMochaObchii(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dateEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "kolvo", true));
            tabImageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "cvet", true));
            tabImageComboBoxEdit2.DataBindings.Add(new Binding("SelectedIndex", dataSource, "reakcij", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "udves", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "belok", true));
            tabImageComboBoxEdit3.DataBindings.Add(new Binding("SelectedIndex", dataSource, "sahar", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "saharkol", true));
            tabImageComboBoxEdit4.DataBindings.Add(new Binding("SelectedIndex", dataSource, "prozr", true));
            tabImageComboBoxEdit8.DataBindings.Add(new Binding("SelectedIndex", dataSource, "keton", true));
            tabImageComboBoxEdit13.DataBindings.Add(new Binding("SelectedIndex", dataSource, "bilirub", true));           //
            tabImageComboBoxEdit14.DataBindings.Add(new Binding("SelectedIndex", dataSource, "urobilinoid", true));    //
            tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", dataSource, "epitelipl1", true));
            tabSpinEdit9.DataBindings.Add(new Binding("Editvalue", dataSource, "epitelipl2", true));
            tabSpinEdit10.DataBindings.Add(new Binding("Editvalue", dataSource, "epitelipldo", true));
            tabSpinEdit11.DataBindings.Add(new Binding("Editvalue", dataSource, "perehod1", true));
            tabSpinEdit12.DataBindings.Add(new Binding("Editvalue", dataSource, "perehod2", true));
            tabSpinEdit13.DataBindings.Add(new Binding("Editvalue", dataSource, "pohehn1", true));
            tabSpinEdit14.DataBindings.Add(new Binding("Editvalue", dataSource, "pohehn2", true));
            tabSpinEdit15.DataBindings.Add(new Binding("Editvalue", dataSource, "leico1", true));
            tabSpinEdit16.DataBindings.Add(new Binding("Editvalue", dataSource, "leico2", true));
            tabSpinEdit17.DataBindings.Add(new Binding("Editvalue", dataSource, "leicodo", true));
            tabSpinEdit18.DataBindings.Add(new Binding("Editvalue", dataSource, "eritr1", true));
            tabSpinEdit19.DataBindings.Add(new Binding("Editvalue", dataSource, "eritr2", true));
            tabSpinEdit20.DataBindings.Add(new Binding("Editvalue", dataSource, "eritrdo", true));
            tabSpinEdit21.DataBindings.Add(new Binding("Editvalue", dataSource, "cilindrgeal1", true));
            tabSpinEdit22.DataBindings.Add(new Binding("Editvalue", dataSource, "cilindrgeal2", true));
            tabSpinEdit23.DataBindings.Add(new Binding("Editvalue", dataSource, "zernist1", true));
            tabSpinEdit24.DataBindings.Add(new Binding("Editvalue", dataSource, "zernist2", true));
           tabSpinEdit25.DataBindings.Add(new Binding("Editvalue", dataSource, "voskovid1", true));
            tabSpinEdit26.DataBindings.Add(new Binding("Editvalue", dataSource, "voskovid2", true));
            tabImageComboBoxEdit5.DataBindings.Add(new Binding("SelectedIndex", dataSource, "soli", true));
            tabImageComboBoxEdit6.DataBindings.Add(new Binding("SelectedIndex", dataSource, "sliz", true));
            tabImageComboBoxEdit9.DataBindings.Add(new Binding("SelectedIndex", dataSource, "bacterii", true));
            tabImageComboBoxEdit7.DataBindings.Add(new Binding("SelectedIndex", dataSource, "prohee", true));
            chkCmbSoli.DataBindings.Add(new Binding("Text", dataSource, "solitxt", true));
            checkedComboBoxEdit1.DataBindings.Add(new Binding("Text", dataSource, "proheetxt", true));
            checkEdit1.DataBindings.Add(new Binding("Checked", dataSource, "beloksled", true));
            tabImageComboBoxEdit28.DataBindings.Add(new Binding("SelectedIndex", dataSource, "epiteliplbol", true));
            tabImageComboBoxEdit10.DataBindings.Add(new Binding("SelectedIndex", dataSource, "leicobol", true));
            tabImageComboBoxEdit11.DataBindings.Add(new Binding("SelectedIndex", dataSource, "belokyes", true));
            tabImageComboBoxEdit12.DataBindings.Add(new Binding("SelectedIndex", dataSource, "eritrbol", true));
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }
       

        private void FrmMochaObchiiKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            else if (e.KeyCode == Keys.F5)
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
        private void TabImageComboBoxEdit3SelectedIndexChanged(object sender, EventArgs e)
        {
            tabSpinEdit4.Visible = (tabImageComboBoxEdit3.SelectedIndex > 1);
        }

        private void TabImageComboBoxEdit5SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedComboBoxEdit1.Visible = (tabImageComboBoxEdit5.SelectedIndex >1);
        }

        private void CheckEdit1CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TabImageComboBoxEdit11SelectedIndexChanged(object sender, EventArgs e)
        {
            tabSpinEdit3.Visible = (tabImageComboBoxEdit11.SelectedIndex > 1);
        }
    }
}
