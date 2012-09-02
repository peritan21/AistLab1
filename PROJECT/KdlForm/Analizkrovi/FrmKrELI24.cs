using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Analizkrovi
{
    public partial class FrmKrELI24 : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmKrELI24(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dateEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "atkdnk", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "atkb2", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "atkfcig", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "atkcom02", true));
            tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "atkbadrenorec", true));
            tabSpinEdit6.DataBindings.Add(new Binding("Editvalue", dataSource, "atktgm03", true));
            tabSpinEdit7.DataBindings.Add(new Binding("Editvalue", dataSource, "atkanca", true));
            tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", dataSource, "atkkim05", true));
            tabSpinEdit9.DataBindings.Add(new Binding("Editvalue", dataSource, "atkkis07", true));
            tabSpinEdit10.DataBindings.Add(new Binding("Editvalue", dataSource, "atklum02", true));
            tabSpinEdit11.DataBindings.Add(new Binding("Editvalue", dataSource, "atklus06", true));
            tabSpinEdit12.DataBindings.Add(new Binding("Editvalue", dataSource, "atkgam02", true));
            tabSpinEdit13.DataBindings.Add(new Binding("Editvalue", dataSource, "atkkitm07", true));
            tabSpinEdit14.DataBindings.Add(new Binding("Editvalue", dataSource, "atkhes08", true));
            tabSpinEdit15.DataBindings.Add(new Binding("Editvalue", dataSource, "atkhmmp", true));
            tabSpinEdit16.DataBindings.Add(new Binding("Editvalue", dataSource, "atkinsulinu", true));
            tabSpinEdit17.DataBindings.Add(new Binding("Editvalue", dataSource, "atkrecepinsulin", true));
            tabSpinEdit18.DataBindings.Add(new Binding("Editvalue", dataSource, "atktiroglobulin", true));
            tabSpinEdit19.DataBindings.Add(new Binding("Editvalue", dataSource, "atkreceptttg", true));
            tabSpinEdit20.DataBindings.Add(new Binding("Editvalue", dataSource, "atkadrmdc0", true));
            tabSpinEdit21.DataBindings.Add(new Binding("Editvalue", dataSource, "atkspr06", true));
            tabSpinEdit22.DataBindings.Add(new Binding("Editvalue", dataSource, "atks100", true));
            tabSpinEdit23.DataBindings.Add(new Binding("Editvalue", dataSource, "atkgfap", true));
            tabSpinEdit24.DataBindings.Add(new Binding("Editvalue", dataSource, "atkobm", true));
            tabSpinEdit25.DataBindings.Add(new Binding("Editvalue", dataSource, "otklonenie", true));
    
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }

        private void FrmKrELI24_KeyUp(object sender, KeyEventArgs e)
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