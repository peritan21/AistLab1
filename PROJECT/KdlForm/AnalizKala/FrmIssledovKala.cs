using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.AnalizKala
{
    public partial class FrmIssledKala : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmIssledKala(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dataDateEdit.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));

            tabImageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "cvet", true));
            tabTextBox2.DataBindings.Add(new Binding("Text", dataSource, "cvettxt", true));
            tabImageComboBoxEdit2.DataBindings.Add(new Binding("SelectedIndex", dataSource, "reakcia", true));
            tabImageComboBoxEdit16.DataBindings.Add(new Binding("Editvalue", dataSource, "konsistencia", true));
            tabTextBox1.DataBindings.Add(new Binding("Text", dataSource, "konsistenciatxt", true));
            tabImageComboBoxEdit3.DataBindings.Add(new Binding("SelectedIndex", dataSource, "mvoloknaper", true));
            tabImageComboBoxEdit4.DataBindings.Add(new Binding("SelectedIndex", dataSource, "mvolokneper", true));
            tabImageComboBoxEdit5.DataBindings.Add(new Binding("SelectedIndex", dataSource, "soedtkan", true));
            tabImageComboBoxEdit6.DataBindings.Add(new Binding("SelectedIndex", dataSource, "jirneitral", true));
            tabImageComboBoxEdit7.DataBindings.Add(new Binding("SelectedIndex", dataSource, "jirkislota", true));
            tabImageComboBoxEdit8.DataBindings.Add(new Binding("SelectedIndex", dataSource, "mila", true));
            tabImageComboBoxEdit9.DataBindings.Add(new Binding("SelectedIndex", dataSource, "rastklethperev", true));
            tabImageComboBoxEdit10.DataBindings.Add(new Binding("SelectedIndex", dataSource, "rastklethneper", true));
            tabImageComboBoxEdit11.DataBindings.Add(new Binding("SelectedIndex", dataSource, "krahmal", true));
            tabImageComboBoxEdit12.DataBindings.Add(new Binding("SelectedIndex", dataSource, "iodofilflora", true));
            tabImageComboBoxEdit13.DataBindings.Add(new Binding("SelectedIndex", dataSource, "sliz", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "epitelii1", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "epitelii2", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "epiteliido", true));
            tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "leikocit1", true));
            tabSpinEdit6.DataBindings.Add(new Binding("Editvalue", dataSource, "leikocit2", true));
            tabSpinEdit7.DataBindings.Add(new Binding("Editvalue", dataSource, "leikocit3", true));
            tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", dataSource, "eritrocit1", true));
            tabSpinEdit9.DataBindings.Add(new Binding("Editvalue", dataSource, "eritrocit2", true));
            tabSpinEdit10.DataBindings.Add(new Binding("Editvalue", dataSource, "eritrocit3", true));
            tabImageComboBoxEdit14.DataBindings.Add(new Binding("SelectedIndex", dataSource, "bakterii", true));
            tabImageComboBoxEdit15.DataBindings.Add(new Binding("SelectedIndex", dataSource, "droqgribki", true));
            tabImageComboBoxEdit17.DataBindings.Add(new Binding("SelectedIndex", dataSource, "reakskrutkrov", true));

        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }
        private void FrmIssledKalaLoad(object sender, EventArgs e)
        {

        }

        private void TabImageComboBoxEdit16SelectedIndexChanged(object sender, EventArgs e)
        {
          bool bol1 =(tabImageComboBoxEdit16.SelectedIndex==6);
          tabTextBox1.Visible = bol1;
          if (!bol1) tabTextBox1.Text = "";
        }

        private void TabImageComboBoxEdit1SelectedIndexChanged(object sender, EventArgs e)
        {
           bool bol2    = (tabImageComboBoxEdit1.SelectedIndex == 5);
           tabTextBox2.Visible = bol2;
           if (!bol2) tabTextBox2.Text = "";
        }

        private void FrmIssledKala_KeyUp(object sender, KeyEventArgs e)
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
