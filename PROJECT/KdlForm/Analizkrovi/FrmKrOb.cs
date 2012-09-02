using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Analizkrovi
{
    public partial class FrmKrOb : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        private string _strZagolovok;
        //private KROBANALIZ _krobanaliz;
        //private string HELLO_WORLD;
        public FrmKrOb(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dateEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data",true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data",true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "leikocit", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "leikoform", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "eozin", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "paloh", true));
            tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "segment", true));
            tabSpinEdit6.DataBindings.Add(new Binding("Editvalue", dataSource, "limfoc", true));
            tabSpinEdit7.DataBindings.Add(new Binding("Editvalue", dataSource, "monocitu", true));
            tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", dataSource, "plazmakl", true));
            tabSpinEdit9.DataBindings.Add(new Binding("Editvalue", dataSource, "mieloc", true));
            tabSpinEdit10.DataBindings.Add(new Binding("Editvalue", dataSource, "unue", true));
            tabSpinEdit11.DataBindings.Add(new Binding("Editvalue", dataSource, "eritr", true));
            tabSpinEdit12.DataBindings.Add(new Binding("Editvalue", dataSource, "gemoglob", true));
            tabSpinEdit13.DataBindings.Add(new Binding("Editvalue", dataSource, "gematokr", true));
            tabSpinEdit14.DataBindings.Add(new Binding("Editvalue", dataSource, "sroberit", true));
            tabSpinEdit15.DataBindings.Add(new Binding("Editvalue", dataSource, "srsodgemagerit", true));
            tabSpinEdit16.DataBindings.Add(new Binding("Editvalue", dataSource, "srkoncgemagerit", true));
            tabSpinEdit17.DataBindings.Add(new Binding("Editvalue", dataSource, "stotkloberit", true));
            tabSpinEdit19.DataBindings.Add(new Binding("Editvalue", dataSource, "koefvarerit", true));
            tabSpinEdit20.DataBindings.Add(new Binding("Editvalue", dataSource, "tromboc", true));
            tabSpinEdit21.DataBindings.Add(new Binding("Editvalue", dataSource, "hirrastromob", true));
            tabSpinEdit22.DataBindings.Add(new Binding("Editvalue", dataSource, "srobtromkr", true));
            tabSpinEdit23.DataBindings.Add(new Binding("Editvalue", dataSource, "moltrom", true));
            tabSpinEdit24.DataBindings.Add(new Binding("Editvalue", dataSource, "cvetpok", true));
            tabSpinEdit25.DataBindings.Add(new Binding("Editvalue", dataSource, "retikoluc", true));
            tabSpinEdit26.DataBindings.Add(new Binding("Editvalue", dataSource, "svertkr", true));
            tabSpinEdit27.DataBindings.Add(new Binding("Editvalue", dataSource, "svertkrk", true));
            tabSpinEdit28.DataBindings.Add(new Binding("Editvalue", dataSource, "dlitkr", true));
            tabSpinEdit29.DataBindings.Add(new Binding("Editvalue", dataSource, "normoblast", true));
            tabSpinEdit30.DataBindings.Add(new Binding("Editvalue", dataSource, "anizocitoz", true));
            tabSpinEdit31.DataBindings.Add(new Binding("Editvalue", dataSource, "poikilocitoz", true));
            tabSpinEdit32.DataBindings.Add(new Binding("Editvalue", dataSource, "gipohromia", true));
            tabSpinEdit33.DataBindings.Add(new Binding("Editvalue", dataSource, "tokszern", true));
            tabSpinEdit36.DataBindings.Add(new Binding("Editvalue", dataSource, "soe", true));
            tabSpinEdit34.DataBindings.Add(new Binding("Editvalue", dataSource, "polihromatof", true));
            tabSpinEdit35.DataBindings.Add(new Binding("Editvalue", dataSource, "polihromatof1", true));
            //tabSpinEdit37.DataBindings.Add(new Binding("Editvalue", dataSource, "monocitu", true));
            //tabSpinEdit18.DataBindings.Add(new Binding("Editvalue", dataSource, "saxar", true));
            //tabSpinEdit37.DataBindings.Add(new Binding("Editvalue", dataSource, "bilirubin", true));
            textEdit1.DataBindings.Add(new Binding("Text", dataSource, "prochee", true));
            tabSpinEdit18.DataBindings.Add(new Binding("Editvalue", dataSource, "blastu", true));
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
            _strZagolovok = Text;
        }

        private void FrmKrObKeyUp(object sender, KeyEventArgs e)
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
            simpleButton3.Visible = false;
            simpleButton4.Visible = false;
            string strText = Text;
            //printDialog1.Document = _pd;
            //printPreviewDialog1.Show();
            //var result=printDialog1.ShowDialog();
            //if (result!=null) printDocument1.Print();
            //string strText0 = Text;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
            simpleButton3.Visible = true; 
            simpleButton4.Visible = true;
            Text = strText;
        }
        private void OnDrawPage(object sender, PrintPageEventArgs e)
        {
            ClassGrafiksReport.PrintToGraphics(e.Graphics, e.MarginBounds, PZAGOLOVOK0, this, 10);
        }
     
    }
}