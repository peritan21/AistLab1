using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.New2202
{
    public partial class FrmOpAgrTrBioleLa : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmOpAgrTrBioleLa(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dataDateEdit.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "spontagr2m", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "spontagrmah", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "ristomic", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "kollagen", true));
            tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "adrenalin", true));
            tabSpinEdit6.DataBindings.Add(new Binding("Editvalue", dataSource, "adf5mkm", true));
            //
            tabSpinEdit7.DataBindings.Add(new Binding("Editvalue", dataSource, "ristomicsvet", true));
            tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", dataSource, "kollagensvet", true));
            tabSpinEdit9.DataBindings.Add(new Binding("Editvalue", dataSource, "adrenalinsvet", true));
            tabSpinEdit10.DataBindings.Add(new Binding("Editvalue", dataSource, "adf5mkmsvet", true));
   
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }

        private void FrmOpAgrTrBioleLa_KeyUp(object sender, KeyEventArgs e)
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