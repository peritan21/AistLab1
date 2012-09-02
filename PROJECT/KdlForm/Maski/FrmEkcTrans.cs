using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Maski
{
    public partial class FormEksTrans : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FormEksTrans(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dateEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "kolvo", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "udves", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "belok", true));
            tabImageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "revalt", true));
            tabImageComboBoxEdit2.DataBindings.Add(new Binding("SelectedIndex", dataSource, "cvet", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "natpreple1", true));
            tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "natpreple2", true));
            tabSpinEdit6.DataBindings.Add(new Binding("Editvalue", dataSource, "natpreple3", true));
            tabSpinEdit7.DataBindings.Add(new Binding("Editvalue", dataSource, "ep1", true));
            tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", dataSource, "ep2", true));
            tabSpinEdit9.DataBindings.Add(new Binding("Editvalue", dataSource, "ep3", true));
            tabSpinEdit10.DataBindings.Add(new Binding("Editvalue", dataSource, "er1", true));
            tabSpinEdit11.DataBindings.Add(new Binding("Editvalue", dataSource, "er2", true));
            tabSpinEdit12.DataBindings.Add(new Binding("Editvalue", dataSource, "er3", true));
            tabSpinEdit13.DataBindings.Add(new Binding("Editvalue", dataSource, "mezatel1", true));
            tabSpinEdit14.DataBindings.Add(new Binding("Editvalue", dataSource, "mezatel2", true));
            tabSpinEdit15.DataBindings.Add(new Binding("Editvalue", dataSource, "mezatel3", true));
            tabSpinEdit16.DataBindings.Add(new Binding("Editvalue", dataSource, "mikrofag1", true));
            tabSpinEdit17.DataBindings.Add(new Binding("Editvalue", dataSource, "mikrofag2", true));
            tabSpinEdit18.DataBindings.Add(new Binding("Editvalue", dataSource, "mikrofag3", true));
            tabSpinEdit19.DataBindings.Add(new Binding("Editvalue", dataSource, "makrofag1", true));
            tabSpinEdit20.DataBindings.Add(new Binding("Editvalue", dataSource, "makrofag2", true));
            tabSpinEdit21.DataBindings.Add(new Binding("Editvalue", dataSource, "makrofag3", true));
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }

        private void FormEksTrans_KeyUp(object sender, KeyEventArgs e)
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
