using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.New2202
{
    public partial class FrmSoskobHMatki : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmSoskobHMatki(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dataDateEdit.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            citogrammasootImageComboBoxEdit.DataBindings.Add(new Binding("SelectedIndex", dataSource, "citogrammasoot", true));
            citogrammasootl1SpinEdit.DataBindings.Add(new Binding("Editvalue", dataSource, "citogrammasootl1", true));
            citogrammasootl2SpinEdit.DataBindings.Add(new Binding("Editvalue", dataSource, "citogrammasootl2", true));
            imageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "isslasppolmat", true));
            spinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "isslasppolmatl1", true));
            spinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "isslasppolmatl2", true));
            imageComboBoxEdit2.DataBindings.Add(new Binding("SelectedIndex", dataSource, "isslpunktatov", true));
            spinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "isslpunktatovl1", true));
            spinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "isslpunktatovl2", true));
 
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }
        private void CitogrammasootImageComboBoxEditSelectedIndexChanged(object sender, EventArgs e)
        {
           bool bol1=(citogrammasootImageComboBoxEdit.SelectedIndex==5);
           labelControl1.Visible = bol1;
           citogrammasootl1SpinEdit.Visible = bol1;
           citogrammasootl2SpinEdit.Visible = bol1;
           if (!bol1)
           {
               citogrammasootl1SpinEdit.EditValue = 0;
               citogrammasootl2SpinEdit.EditValue = 0;
           }
        }

        private void ImageComboBoxEdit1SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bol2 = (imageComboBoxEdit1.SelectedIndex == 5);
            labelControl2.Visible = bol2;
            spinEdit2.Visible = bol2;
            spinEdit1.Visible = bol2;
            if (!bol2)
            {
                spinEdit2.EditValue = 0;
                spinEdit1.EditValue = 0;
            }
        }

        private void ImageComboBoxEdit2SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bol3 = (imageComboBoxEdit2.SelectedIndex == 5);
            labelControl3.Visible = bol3;
            spinEdit3.Visible = bol3;
            spinEdit4.Visible = bol3;
            if (!bol3)
            {
                spinEdit3.EditValue = 0;
                spinEdit4.EditValue = 0;
            }
        }

        private void FrmSoskobHMatki_KeyUp(object sender, KeyEventArgs e)
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