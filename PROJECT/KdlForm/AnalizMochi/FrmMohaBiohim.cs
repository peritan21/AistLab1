using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.AnalizMochi
{
    public partial class FrmMohaBiohim : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmMohaBiohim(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dataDateEdit.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "opkreatinmohe", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "alfaamilmohi", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "klirenskreaten", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "opkanalreabsorb", true));
            tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "opmohevmohe", true));
            tabSpinEdit6.DataBindings.Add(new Binding("Editvalue", dataSource, "opmohevkismohe", true));
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }

        private void FrmMohaBiohim_KeyUp(object sender, KeyEventArgs e)
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