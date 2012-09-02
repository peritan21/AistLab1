using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Analizkrovi
{
    public partial class FrmGazuElektro : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmGazuElektro(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dateEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "ph", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "pco2", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "po2", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "na", true));
            tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "k", true));
            tabSpinEdit6.DataBindings.Add(new Binding("Editvalue", dataSource, "ca", true));
            tabSpinEdit7.DataBindings.Add(new Binding("Editvalue", dataSource, "lac", true));
            tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", dataSource, "ce", true));
            tabSpinEdit9.DataBindings.Add(new Binding("Editvalue", dataSource, "saxar", true));
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }

        private void FrmGazuElektro_KeyUp(object sender, KeyEventArgs e)
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