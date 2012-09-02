using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Maski
{
    public partial class FrmMazkinaFloru : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        private string strZagolovok;
        //private PrintDocument _pd;
        public FrmMazkinaFloru(BindingSource dataSource)
        {
   
            _dataSource1 = dataSource;
            InitializeComponent();
           
            //this.printDialog1.Document =this.printDocument1;

            //_pd = new PrintDocument();
         
            dateEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "leikocitu1", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "leikocitu2", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "leikocitu3", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "leikocitc1", true));
            tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "leikocitc2", true));
            tabSpinEdit6.DataBindings.Add(new Binding("Editvalue", dataSource, "leikocitc3", true));
            tabSpinEdit7.DataBindings.Add(new Binding("Editvalue", dataSource, "leikocitv1", true));
            tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", dataSource, "leikocitv2", true));
            tabSpinEdit9.DataBindings.Add(new Binding("Editvalue", dataSource, "leikocitv3", true));
            tabImageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "epiteliiu", true));
            tabImageComboBoxEdit2.DataBindings.Add(new Binding("SelectedIndex", dataSource, "epiteliic", true));
            tabImageComboBoxEdit3.DataBindings.Add(new Binding("SelectedIndex", dataSource, "epiteliiv", true));
            tabImageComboBoxEdit4.DataBindings.Add(new Binding("SelectedIndex", dataSource, "slizu", true));
            tabImageComboBoxEdit5.DataBindings.Add(new Binding("SelectedIndex", dataSource, "slizc", true));
            tabImageComboBoxEdit6.DataBindings.Add(new Binding("SelectedIndex", dataSource, "slizv", true));
            tabImageComboBoxEdit7.DataBindings.Add(new Binding("SelectedIndex", dataSource, "florau", true));
            tabImageComboBoxEdit10.DataBindings.Add(new Binding("SelectedIndex", dataSource, "florau1", true));
            tabImageComboBoxEdit8.DataBindings.Add(new Binding("SelectedIndex", dataSource, "florac", true));
            tabImageComboBoxEdit11.DataBindings.Add(new Binding("SelectedIndex", dataSource, "florac1", true));
            tabImageComboBoxEdit9.DataBindings.Add(new Binding("SelectedIndex", dataSource, "florav", true));
            tabImageComboBoxEdit12.DataBindings.Add(new Binding("SelectedIndex", dataSource, "florav1", true));
            tabImageComboBoxEdit13.DataBindings.Add(new Binding("SelectedIndex", dataSource, "gonokokiu", true));
            tabImageComboBoxEdit14.DataBindings.Add(new Binding("SelectedIndex", dataSource, "gonokokic", true));
            tabImageComboBoxEdit15.DataBindings.Add(new Binding("SelectedIndex", dataSource, "gonokokiv", true));
            tabImageComboBoxEdit16.DataBindings.Add(new Binding("SelectedIndex", dataSource, "trihomonadau", true));
            tabImageComboBoxEdit17.DataBindings.Add(new Binding("SelectedIndex", dataSource, "trihomonadac", true));
            tabImageComboBoxEdit18.DataBindings.Add(new Binding("SelectedIndex", dataSource, "trihomonadav", true));
            tabImageComboBoxEdit19.DataBindings.Add(new Binding("SelectedIndex", dataSource, "candidau", true));
            tabImageComboBoxEdit20.DataBindings.Add(new Binding("SelectedIndex", dataSource, "candidac", true));
            tabImageComboBoxEdit21.DataBindings.Add(new Binding("SelectedIndex", dataSource, "candidav", true));
            tabImageComboBoxEdit22.DataBindings.Add(new Binding("SelectedIndex", dataSource, "gardnerellu", true));
            tabImageComboBoxEdit23.DataBindings.Add(new Binding("SelectedIndex", dataSource, "gardnerellc", true));
            tabImageComboBoxEdit24.DataBindings.Add(new Binding("SelectedIndex", dataSource, "gardnerellv", true));
            tabImageComboBoxEdit25.DataBindings.Add(new Binding("SelectedIndex", dataSource, "mobilunkusu", true));
            tabImageComboBoxEdit26.DataBindings.Add(new Binding("SelectedIndex", dataSource, "mobilunkusc", true));
            tabImageComboBoxEdit27.DataBindings.Add(new Binding("SelectedIndex", dataSource, "mobilunkusv", true));
            tabImageComboBoxEdit28.DataBindings.Add(new Binding("SelectedIndex", dataSource, "leikocitubol", true));
            tabImageComboBoxEdit29.DataBindings.Add(new Binding("SelectedIndex", dataSource, "leikocitcbol", true));
            tabImageComboBoxEdit30.DataBindings.Add(new Binding("SelectedIndex", dataSource, "leikocitvbol", true)); 

        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
            strZagolovok = Text;
        }

      
   
        private void FrmMazkinaFloru_KeyUp(object sender, KeyEventArgs e)
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
