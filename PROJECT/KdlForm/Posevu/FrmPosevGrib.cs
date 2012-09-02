using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Posevu
{
    public partial class FrmPosevGrib : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmPosevGrib(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
  
            dateEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            tabImageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "tr", true));
            tabImageComboBoxEdit3.DataBindings.Add(new Binding("SelectedIndex", dataSource, "gr", true));
            tabImageComboBoxEdit2.DataBindings.Add(new Binding("SelectedIndex", dataSource, "tr_drojgrib", true));
            tabImageComboBoxEdit4.DataBindings.Add(new Binding("SelectedIndex", dataSource, "gr_drojgrib", true));

        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }
    
        private void FrmNechiporKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            else
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

        //private void imageComboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //      bool bol1= (imageComboBoxEdit1.SelectedIndex == 1);
        //      textBox1.Visible = bol1;
        //      textBox1.Text = "+ дрожжевые грибы";

        //}

        //private void imageComboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    bool bol2  = (imageComboBoxEdit2.SelectedIndex == 1);
        //    textBox2.Visible = bol2;
        //    textBox2.Text = "+ дрожжевые грибы";


        //}
    }
}
