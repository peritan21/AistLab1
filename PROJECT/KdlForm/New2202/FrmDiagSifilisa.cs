using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.New2202
{
    public partial class FrmDiagSifilisa : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmDiagSifilisa(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dataDateEdit.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            rprImageComboBoxEdit.DataBindings.Add(new Binding("SelectedIndex", dataSource, "rpr", true));
            rpgaImageComboBoxEdit.DataBindings.Add(new Binding("SelectedIndex", dataSource, "rpga", true));
            imageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "resultat", true));
            imageComboBoxEdit2.DataBindings.Add(new Binding("SelectedIndex", dataSource, "ixa", true));
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }

        private void FrmDiagSifilisa_KeyUp(object sender, KeyEventArgs e)
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