using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Mielogramma
{
    public partial class FrmMielogramma : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmMielogramma(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dataDateEdit.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));

            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "nedifferencblast", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "mieloblast", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "promielocit", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "mielocitneitrofil", true));
            tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "mielocitbazofil", true));
            tabSpinEdit6.DataBindings.Add(new Binding("Editvalue", dataSource, "mielociteozinofil", true));
            tabSpinEdit7.DataBindings.Add(new Binding("Editvalue", dataSource, "metamielocitneitrofil", true));
            tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", dataSource, "metamielocitbazofil", true));
            tabSpinEdit9.DataBindings.Add(new Binding("Editvalue", dataSource, "metamielociteozinofil", true));
            tabSpinEdit10.DataBindings.Add(new Binding("Editvalue", dataSource, "palohkoidernneitrofil", true));
            tabSpinEdit11.DataBindings.Add(new Binding("Editvalue", dataSource, "palohkoidernbazofil", true));
            tabSpinEdit12.DataBindings.Add(new Binding("Editvalue", dataSource, "palohkoiderneozinofil", true));
            tabSpinEdit13.DataBindings.Add(new Binding("Editvalue", dataSource, "segmentoidernneitrofil", true));
            tabSpinEdit14.DataBindings.Add(new Binding("Editvalue", dataSource, "eozinofil", true));
            tabSpinEdit15.DataBindings.Add(new Binding("Editvalue", dataSource, "bazofil", true));
            tabSpinEdit16.DataBindings.Add(new Binding("Editvalue", dataSource, "limfoblast", true));
            tabSpinEdit17.DataBindings.Add(new Binding("Editvalue", dataSource, "prolimfocit", true));
            tabSpinEdit18.DataBindings.Add(new Binding("Editvalue", dataSource, "limfocit", true));
            tabSpinEdit19.DataBindings.Add(new Binding("Editvalue", dataSource, "monocit", true));
            tabSpinEdit20.DataBindings.Add(new Binding("Editvalue", dataSource, "eritroblast", true));
            tabSpinEdit21.DataBindings.Add(new Binding("Editvalue", dataSource, "normocitbazofil", true));
            tabSpinEdit22.DataBindings.Add(new Binding("Editvalue", dataSource, "normocitpolihromatof", true));
            tabSpinEdit23.DataBindings.Add(new Binding("Editvalue", dataSource, "normocitoksifil", true));
            tabSpinEdit24.DataBindings.Add(new Binding("Editvalue", dataSource, "plazmatihkletki", true));
            tabSpinEdit25.DataBindings.Add(new Binding("Editvalue", dataSource, "megakarioblast", true));
            tabSpinEdit26.DataBindings.Add(new Binding("Editvalue", dataSource, "megakariocitbazofil", true));
            tabSpinEdit27.DataBindings.Add(new Binding("Editvalue", dataSource, "megakarpolihromat", true));
            tabSpinEdit28.DataBindings.Add(new Binding("Editvalue", dataSource, "megakariocitoksifil", true));
            tabSpinEdit29.DataBindings.Add(new Binding("Editvalue", dataSource, "retikulkletki", true));
            tabSpinEdit30.DataBindings.Add(new Binding("Editvalue", dataSource, "goloidernkletki", true));
            tabSpinEdit31.DataBindings.Add(new Binding("Editvalue", dataSource, "kletdeleneritrocitrida", true));
            tabSpinEdit32.DataBindings.Add(new Binding("Editvalue", dataSource, "kletdelenmieloblrida", true));
            tabSpinEdit33.DataBindings.Add(new Binding("Editvalue", dataSource, "kolihmielokariocit", true));
            tabSpinEdit34.DataBindings.Add(new Binding("Editvalue", dataSource, "kolihmegakariocit", true));
            tabSpinEdit35.DataBindings.Add(new Binding("Editvalue", dataSource, "leikoeritrobsootn", true));
            tabSpinEdit36.DataBindings.Add(new Binding("Editvalue", dataSource, "kostmozgincjzneitr", true));
            tabSpinEdit37.DataBindings.Add(new Binding("Editvalue", dataSource, "indsozreveritroblas", true));
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }

        private void FrmMielogramma_KeyUp(object sender, KeyEventArgs e)
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