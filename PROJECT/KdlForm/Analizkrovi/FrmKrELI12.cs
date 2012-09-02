using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Analizkrovi
{
    public partial class FrmKrELI12 : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmKrELI12(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dateEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "atkxgch", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "atkdnk", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "atkb2", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "atkkollagen", true));
            tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "atlfcigg", true));
            tabSpinEdit6.DataBindings.Add(new Binding("Editvalue", dataSource, "atkinsulin", true));
            tabSpinEdit7.DataBindings.Add(new Binding("Editvalue", dataSource, "atktiroglobulin", true));
            tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", dataSource, "atks100", true));
            tabSpinEdit9.DataBindings.Add(new Binding("Editvalue", dataSource, "atkspr06", true));
            tabSpinEdit10.DataBindings.Add(new Binding("Editvalue", dataSource, "atktrm03", true));
            tabSpinEdit13.DataBindings.Add(new Binding("Editvalue", dataSource, "atkanca", true));
            tabSpinEdit12.DataBindings.Add(new Binding("Editvalue", dataSource, "atkkim05", true));
            tabSpinEdit11.DataBindings.Add(new Binding("Editvalue", dataSource, "otklonenie", true));
       
    
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }

        private void FrmKrELI12_KeyUp(object sender, KeyEventArgs e)
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