using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.AnalizKala
{
    public partial class FrmNovGemoglob : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmNovGemoglob(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dataDateEdit.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));

            tabImageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "rezultat", true));
     


   
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }
        private void FrmAnalKalUglKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
                case Keys.F2:  // ОК клавиша
                    simpleButton1.PerformClick();
                    break;
                case Keys.F5:  // ОК клавиша
                    PrintFormkrobch();
                    break;
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
