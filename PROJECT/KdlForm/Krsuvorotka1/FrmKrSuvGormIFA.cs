using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Krsuvorotka1
{
    public partial class FrmKrSuvGormIFA : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmKrSuvGormIFA(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dataDateEdit.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "prolakqen", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "kortizol", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "ttgtireotgorm", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "t4tiroksin", true));
            tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "ct4svobod", true));
            tabSpinEdit6.DataBindings.Add(new Binding("Editvalue", dataSource, "t3triiodtironin", true));
            tabSpinEdit7.DataBindings.Add(new Binding("Editvalue", dataSource, "ct3svobod", true));
            tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", dataSource, "atktgantiteltireog", true));
            tabSpinEdit9.DataBindings.Add(new Binding("Editvalue", dataSource, "atktpoantiroidptrok", true));
            tabSpinEdit10.DataBindings.Add(new Binding("Editvalue", dataSource, "testerqen", true));
             tabSpinEdit11.DataBindings.Add(new Binding("Editvalue", dataSource, "svobodtestron1", true));
            tabSpinEdit12.DataBindings.Add(new Binding("Editvalue", dataSource, "follikulostimgorfcg1", true));
            tabSpinEdit13.DataBindings.Add(new Binding("Editvalue", dataSource, "liteinizgormlg1", true));
            tabSpinEdit14.DataBindings.Add(new Binding("Editvalue", dataSource, "estradiole21", true));
            tabSpinEdit15.DataBindings.Add(new Binding("Editvalue", dataSource, "progesteron1", true));
            tabSpinEdit16.DataBindings.Add(new Binding("Editvalue", dataSource, "dgeac1", true));
            tabSpinEdit17.DataBindings.Add(new Binding("Editvalue", dataSource, "aonprog1", true));
            tabSpinEdit18.DataBindings.Add(new Binding("Editvalue", dataSource, "antimilgormonamg1", true));
             tabSpinEdit19.DataBindings.Add(new Binding("Editvalue", dataSource, "ingibinb1", true));
              tabSpinEdit21.DataBindings.Add(new Binding("Editvalue", dataSource, "oprprosantigpcasuvkr", true));
            tabSpinEdit22.DataBindings.Add(new Binding("Editvalue", dataSource, "denmc1", true));
            tabSpinEdit20.DataBindings.Add(new Binding("Editvalue", dataSource, "denmc2", true));
            tabImageComboBoxEdit6.DataBindings.Add(new Binding("SelectedIndex", dataSource, "progesteron1vib", true));
            tabImageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "prolakqenvib", true));
            tabImageComboBoxEdit2.DataBindings.Add(new Binding("SelectedIndex", dataSource, "kortizolvib", true));
            tabImageComboBoxEdit5.DataBindings.Add(new Binding("SelectedIndex", dataSource, "testerqenvib", true));
            tabImageComboBoxEdit4.DataBindings.Add(new Binding("SelectedIndex", dataSource, "svobodtestron1vib", true));
            tabImageComboBoxEdit3.DataBindings.Add(new Binding("SelectedIndex", dataSource, "liteinizgormlg1vib", true));
            tabImageComboBoxEdit9.DataBindings.Add(new Binding("SelectedIndex", dataSource, "follikulostimgorfcg1vib", true));
            tabImageComboBoxEdit8.DataBindings.Add(new Binding("SelectedIndex", dataSource, "estradiole21vib", true));
            tabImageComboBoxEdit7.DataBindings.Add(new Binding("SelectedIndex", dataSource, "ttgtireotgormvib", true));
            tabImageComboBoxEdit12.DataBindings.Add(new Binding("SelectedIndex", dataSource, "t3triiodtironinvib", true));
            tabImageComboBoxEdit11.DataBindings.Add(new Binding("SelectedIndex", dataSource, "ct3svobodvib", true));
            tabImageComboBoxEdit10.DataBindings.Add(new Binding("SelectedIndex", dataSource, "t4tiroksinvib", true));
            tabImageComboBoxEdit15.DataBindings.Add(new Binding("SelectedIndex", dataSource, "ct4svobodvib", true));
            tabImageComboBoxEdit14.DataBindings.Add(new Binding("SelectedIndex", dataSource, "atktpoantiroidptrokvib", true));
            tabImageComboBoxEdit13.DataBindings.Add(new Binding("SelectedIndex", dataSource, "atktgantiteltireogvib", true));
            tabImageComboBoxEdit18.DataBindings.Add(new Binding("SelectedIndex", dataSource, "dgeac1vib", true));
            tabImageComboBoxEdit17.DataBindings.Add(new Binding("SelectedIndex", dataSource, "aonprog1vib", true));
            tabImageComboBoxEdit16.DataBindings.Add(new Binding("SelectedIndex", dataSource, "ingibinb1vib", true));
            tabImageComboBoxEdit20.DataBindings.Add(new Binding("SelectedIndex", dataSource, "antimilgormonamg1vib", true));
            tabImageComboBoxEdit19.DataBindings.Add(new Binding("SelectedIndex", dataSource, "oprprosantigpcasuvkrvib", true));
            tabSpinEdit23.DataBindings.Add(new Binding("Editvalue", dataSource, "insulin", true));
            

        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }

        private void FrmKrSuvGormIFA_KeyUp(object sender, KeyEventArgs e)
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
