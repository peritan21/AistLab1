using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Testu_prochie
{
    public partial class FrmSpermObchii : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmSpermObchii(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dateEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));

            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "kolih", true));
            tabImageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "cvet", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "vyzkost", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "ph", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "vremrazq", true));
            tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "koncspermat", true));
            tabSpinEdit6.DataBindings.Add(new Binding("Editvalue", dataSource, "jiv", true));
            tabSpinEdit7.DataBindings.Add(new Binding("Editvalue", dataSource, "mertv", true));
            tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", dataSource, "normokin", true));
            tabSpinEdit9.DataBindings.Add(new Binding("Editvalue", dataSource, "akinezis", true));
            tabSpinEdit10.DataBindings.Add(new Binding("Editvalue", dataSource, "gipokinezis", true));
            tabSpinEdit11.DataBindings.Add(new Binding("Editvalue", dataSource, "diskinezis", true));
            tabSpinEdit12.DataBindings.Add(new Binding("Editvalue", dataSource, "normalspermat", true));
            tabSpinEdit13.DataBindings.Add(new Binding("Editvalue", dataSource, "pataloggolov", true));
            tabSpinEdit14.DataBindings.Add(new Binding("Editvalue", dataSource, "patalogheiki", true));
            tabSpinEdit15.DataBindings.Add(new Binding("Editvalue", dataSource, "pataloghvosta", true));
            tabSpinEdit16.DataBindings.Add(new Binding("Editvalue", dataSource, "starform", true));
            tabSpinEdit17.DataBindings.Add(new Binding("Editvalue", dataSource, "unform", true));
            tabSpinEdit18.DataBindings.Add(new Binding("Editvalue", dataSource, "spermaglic", true));
            tabSpinEdit19.DataBindings.Add(new Binding("Editvalue", dataSource, "erit1", true));
            tabSpinEdit20.DataBindings.Add(new Binding("Editvalue", dataSource, "erit2", true));
            tabSpinEdit21.DataBindings.Add(new Binding("Editvalue", dataSource, "epit1", true));
            tabSpinEdit22.DataBindings.Add(new Binding("Editvalue", dataSource, "epit2", true));
            tabImageComboBoxEdit2.DataBindings.Add(new Binding("SelectedIndex", dataSource, "leticzerna", true));
            tabSpinEdit26.DataBindings.Add(new Binding("Editvalue", dataSource, "leikocit106", true));
            tabSpinEdit23.DataBindings.Add(new Binding("Editvalue", dataSource, "leikocit", true));
            tabSpinEdit25.DataBindings.Add(new Binding("Editvalue", dataSource, "leikocit1", true));
            tabSpinEdit24.DataBindings.Add(new Binding("Editvalue", dataSource, "martest", true));
            textBox1.DataBindings.Add(new Binding("Text", dataSource, "primech", true));
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit2.Properties.DataSource = Llabanaliz;
            lookUpEdit2.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }

        private void FrmSpermObchii_KeyUp(object sender, KeyEventArgs e)
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
