using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.AnalizMochi
{
    public partial class FrmZimnickgo : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource;
        public FrmZimnickgo(BindingSource dataSource1)
        {
         
            InitializeComponent();
            _dataSource = dataSource1;
            dateEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource, "data", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource, "inter6_9kol", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", _dataSource, "inter6_9udves", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", _dataSource, "inter9_12kol", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", _dataSource, "inter9_12udves", true));
            tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", _dataSource, "inter12_15kol", true));
            tabSpinEdit6.DataBindings.Add(new Binding("Editvalue", _dataSource, "inter12_15udves", true));
            tabSpinEdit7.DataBindings.Add(new Binding("Editvalue", _dataSource, "dnevnoidiurezkol", true));  //, DataSourceUpdateMode.OnPropertyChanged
            //tabSpinEdit7.DataBindings.Add(new Binding("Editvalue", dataSource, "dnevnoidiurezkol", true));
            //tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", dataSource, "dnevnoidiurezudves", true));
            tabSpinEdit9.DataBindings.Add(new Binding("Editvalue", _dataSource, "ibter18_21kol", true));
            tabSpinEdit10.DataBindings.Add(new Binding("Editvalue", _dataSource, "ibter18_21udves", true));
            tabSpinEdit11.DataBindings.Add(new Binding("Editvalue", _dataSource, "inter21_24kol", true));
            tabSpinEdit12.DataBindings.Add(new Binding("Editvalue", _dataSource, "inter21_24udves", true));
            tabSpinEdit13.DataBindings.Add(new Binding("Editvalue", _dataSource, "inter0_3kol", true));
            tabSpinEdit14.DataBindings.Add(new Binding("Editvalue", _dataSource, "inter0_3udves", true));
            tabSpinEdit15.DataBindings.Add(new Binding("Editvalue", _dataSource, "inter3_6kol", true));
            tabSpinEdit16.DataBindings.Add(new Binding("Editvalue", _dataSource, "inter3_6udves", true));
            tabSpinEdit17.DataBindings.Add(new Binding("Editvalue", _dataSource, "nohnoidiurkol", true));
            //tabSpinEdit18.DataBindings.Add(new Binding("Editvalue", dataSource, "nohnoidiurudves", true));
            tabSpinEdit19.DataBindings.Add(new Binding("Editvalue", _dataSource, "obdiurezkol", true));
            //tabSpinEdit20.DataBindings.Add(new Binding("Editvalue", dataSource, "obdiurezudves", true));
            tabSpinEdit21.DataBindings.Add(new Binding("Editvalue", _dataSource, "inter15_18kol", true));
            tabSpinEdit22.DataBindings.Add(new Binding("Editvalue", _dataSource, "inter15_18udves", true));
            ///////
            tabSpinEdit27.DataBindings.Add(new Binding("Editvalue", _dataSource, "belok6_9", true));
            tabSpinEdit26.DataBindings.Add(new Binding("Editvalue", _dataSource, "belok9_12", true));
            tabSpinEdit25.DataBindings.Add(new Binding("Editvalue", _dataSource, "belok12_15", true));
            tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", _dataSource, "belok15_18", true));
            tabSpinEdit24.DataBindings.Add(new Binding("Editvalue", _dataSource, "belok18_21", true));
            tabSpinEdit23.DataBindings.Add(new Binding("Editvalue", _dataSource, "belok21_24", true));
            tabSpinEdit20.DataBindings.Add(new Binding("Editvalue", _dataSource, "belok0_3", true));
            tabSpinEdit18.DataBindings.Add(new Binding("Editvalue", _dataSource, "belok3_6", true));
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource, "labanaliz", true));
        }

        private void FrmZimnickgo_KeyUp(object sender, KeyEventArgs e)
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