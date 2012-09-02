using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.AnalizKala
{
    public partial class FrmAnalKalUgl : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmAnalKalUgl(BindingSource dataSource)
        {
            _dataSource1=dataSource;
            InitializeComponent();
            dataDateEdit.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));

            tabImageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "cvet", true));
        
            //tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "cvetkol", true));
            //tabImageComboBoxEdit2.DataBindings.Add(new Binding("SelectedIndex", dataSource, "zelenbezo", true));
            //tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "zelenbezokol1", true));
            //tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "zelenbezokol2", true));
            //tabImageComboBoxEdit3.DataBindings.Add(new Binding("SelectedIndex", dataSource, "zelenso", true));
            //tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "zelensokol1", true));
            //tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "zelensokol2", true));
            //tabImageComboBoxEdit4.DataBindings.Add(new Binding("SelectedIndex", dataSource, "olovkjelt", true));
            //tabSpinEdit6.DataBindings.Add(new Binding("Editvalue", dataSource, "olovkjeltkol1", true));
            //tabSpinEdit7.DataBindings.Add(new Binding("Editvalue", dataSource, "olovkjeltkol2", true));
            //tabImageComboBoxEdit5.DataBindings.Add(new Binding("SelectedIndex", dataSource, "oranj", true));
            //tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", dataSource, "oranjkol1", true));
            //tabSpinEdit9.DataBindings.Add(new Binding("Editvalue", dataSource, "oranjkol2", true));
            //tabImageComboBoxEdit6.DataBindings.Add(new Binding("SelectedIndex", dataSource, "svkrasn", true));
            //tabSpinEdit10.DataBindings.Add(new Binding("Editvalue", dataSource, "svkrasnkol", true));



   
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
