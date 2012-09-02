using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Testu_prochie
{
    public partial class FrmAnSokProstat : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmAnSokProstat(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dateEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));

            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "leikocit1", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "leikocit2", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "leikocit3", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "epitelii1", true));
            tabSpinEdit7.DataBindings.Add(new Binding("Editvalue", dataSource, "epitelii2", true));
            tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", dataSource, "epitelii3", true));
            tabImageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "sliz", true));
            tabImageComboBoxEdit2.DataBindings.Add(new Binding("SelectedIndex", dataSource, "soli", true));
            checkedComboBoxEdit1.DataBindings.Add(new Binding("Text", dataSource, "solitxt", true));
            tabImageComboBoxEdit3.DataBindings.Add(new Binding("SelectedIndex", dataSource, "leticinzerna", true));
            tabImageComboBoxEdit4.DataBindings.Add(new Binding("SelectedIndex", dataSource, "bakterii", true));
            tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "erit1", true));
            tabSpinEdit6.DataBindings.Add(new Binding("Editvalue", dataSource, "erit2", true));
            tabImageComboBoxEdit5.DataBindings.Add(new Binding("SelectedIndex", dataSource, "spermatozoid", true));
            tabImageComboBoxEdit6.DataBindings.Add(new Binding("SelectedIndex", dataSource, "trhomonad", true));
            tabImageComboBoxEdit12.DataBindings.Add(new Binding("SelectedIndex", dataSource, "flora", true));
            tabImageComboBoxEdit7.DataBindings.Add(new Binding("SelectedIndex", dataSource, "mikrofora", true));
            tabImageComboBoxEdit10.DataBindings.Add(new Binding("SelectedIndex", dataSource, "mikroflora1", true));
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }

        private void FrmAnSokProstat_KeyUp(object sender, KeyEventArgs e)
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