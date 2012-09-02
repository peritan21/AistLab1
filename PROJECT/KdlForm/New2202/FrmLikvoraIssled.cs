using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.New2202
{
    public partial class FrmLikvoraIssled : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmLikvoraIssled(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dataDateEdit.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "kolihestvo", true));
            tabImageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "prozrahnost", true));
            tabImageComboBoxEdit2.DataBindings.Add(new Binding("SelectedIndex", dataSource, "cvet", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "sahar", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "citoza", true));
            tabImageComboBoxEdit3.DataBindings.Add(new Binding("SelectedIndex", dataSource, "reakcipandi", true));

            tabImageComboBoxEdit4.DataBindings.Add(new Binding("SelectedIndex", dataSource, "cvetposle", true));
            tabImageComboBoxEdit5.DataBindings.Add(new Binding("SelectedIndex", dataSource, "prozrahnostposle", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "belok", true));

            tabSpinEdit6.DataBindings.Add(new Binding("Editvalue", dataSource, "likvorogrammlimf", true));
            tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", dataSource, "likvorogrammeritr", true));
            tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "likvorogrammneitr", true));
            tabSpinEdit7.DataBindings.Add(new Binding("Editvalue", dataSource, "likvorogrammeoz", true));  //
            textBox1.DataBindings.Add(new Binding("Text", dataSource, "likvorprochee", true));
         
           
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }

        private void FrmLikvoraIssled_KeyUp(object sender, KeyEventArgs e)
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