using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Analizkrovi
{
    public partial class FrmAnalKrGlikemihPr : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmAnalKrGlikemihPr(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dateEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));

            timeEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "data1", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "result1", true));
            timeEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "data2", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "result2", true));
            timeEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "data3", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "result3", true));
            timeEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "data4", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "result4", true));
            timeEdit6.DataBindings.Add(new Binding("Editvalue", dataSource, "data5", true));
            tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "result5", true));
            timeEdit7.DataBindings.Add(new Binding("Editvalue", dataSource, "data6", true));
            tabSpinEdit6.DataBindings.Add(new Binding("Editvalue", dataSource, "result6", true));
            timeEdit8.DataBindings.Add(new Binding("Editvalue", dataSource, "data7", true));
            tabSpinEdit7.DataBindings.Add(new Binding("Editvalue", dataSource, "result7", true));
            timeEdit9.DataBindings.Add(new Binding("Editvalue", dataSource, "data8", true));
            tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", dataSource, "result8", true));
            timeEdit10.DataBindings.Add(new Binding("Editvalue", dataSource, "data9", true));
            tabSpinEdit9.DataBindings.Add(new Binding("Editvalue", dataSource, "result9", true));
            timeEdit11.DataBindings.Add(new Binding("Editvalue", dataSource, "data10", true));
            tabSpinEdit10.DataBindings.Add(new Binding("Editvalue", dataSource, "result10", true));
     
    
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }

        private void FrmAnalKrGlikemihPr_KeyUp(object sender, KeyEventArgs e)
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
