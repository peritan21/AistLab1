using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Krsuvorotka1
{
    public partial class FrmKrSuvIfaXgch : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmKrSuvIfaXgch(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dateEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            dataTimeEdit.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            tabImageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "igm", true));
            tabImageComboBoxEdit2.DataBindings.Add(new Binding("SelectedIndex", dataSource, "igg", true));
            //tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "kardiolipigm", true));
            //tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "kardiolipiga", true));
            //tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "kardiolipigg", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "kardiolipiggsum", true));
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }

        private void FrmKrSuvIfaXgch_KeyUp(object sender, KeyEventArgs e)
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