using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Analizkrovi
{
    public partial class FrmKrTromboex : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmKrTromboex(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dateEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "r", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "k", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "angle", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "ma", true));
            tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "pma", true));
            tabSpinEdit6.DataBindings.Add(new Binding("Editvalue", dataSource, "g", true));
            tabSpinEdit7.DataBindings.Add(new Binding("Editvalue", dataSource, "epl", true));
            tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", dataSource, "a", true));
            tabSpinEdit9.DataBindings.Add(new Binding("Editvalue", dataSource, "ci", true));
            tabSpinEdit10.DataBindings.Add(new Binding("Editvalue", dataSource, "ly30", true));
            tabSpinEdit11.DataBindings.Add(new Binding("Editvalue", dataSource, "lte", true));
            tabSpinEdit18.DataBindings.Add(new Binding("Editvalue", dataSource, "a30", true));
            tabSpinEdit19.DataBindings.Add(new Binding("Editvalue", dataSource, "cl30", true));
            tabSpinEdit20.DataBindings.Add(new Binding("Editvalue", dataSource, "a60", true));
            tabSpinEdit21.DataBindings.Add(new Binding("Editvalue", dataSource, "cl60", true));
            tabSpinEdit22.DataBindings.Add(new Binding("Editvalue", dataSource, "ly60", true));
            tabSpinEdit23.DataBindings.Add(new Binding("Editvalue", dataSource, "clt", true));
            tabSpinEdit24.DataBindings.Add(new Binding("Editvalue", dataSource, "tpi", true));
            tabSpinEdit25.DataBindings.Add(new Binding("Editvalue", dataSource, "tma", true));
            tabSpinEdit26.DataBindings.Add(new Binding("Editvalue", dataSource, "e", true));
            tabSpinEdit27.DataBindings.Add(new Binding("Editvalue", dataSource, "sp", true));
    
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }

        private void FrmKrTromboex_KeyUp(object sender, KeyEventArgs e)
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