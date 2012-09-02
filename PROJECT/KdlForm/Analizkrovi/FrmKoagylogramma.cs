using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Analizkrovi
{
    public partial class FrmKoagylogramma : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmKoagylogramma(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dateEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "fibrklausu", true));
            tabImageComboBoxEdit4.DataBindings.Add(new Binding("SelectedIndex", dataSource, "fibrklausuvib", true));
            tabImageComboBoxEdit2.DataBindings.Add(new Binding("SelectedIndex", dataSource, "ahtbvib", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "ahtb", true));
            tabImageComboBoxEdit5.DataBindings.Add(new Binding("SelectedIndex", dataSource, "protromvremvib", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "protromvrem", true));
             tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "protrompokkviku", true));
            //tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "protromotnohen", true));
            tabSpinEdit6.DataBindings.Add(new Binding("Editvalue", dataSource, "meqdnormotn", true));
            tabImageComboBoxEdit6.DataBindings.Add(new Binding("SelectedIndex", dataSource, "rfmkvib", true));
            tabSpinEdit7.DataBindings.Add(new Binding("Editvalue", dataSource, "rfmk", true));
            tabImageComboBoxEdit3.DataBindings.Add(new Binding("SelectedIndex", dataSource, "trombinvremvib", true));
            tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", dataSource, "trombinvrem", true));
            tabSpinEdit9.DataBindings.Add(new Binding("Editvalue", dataSource, "antitrombz", true));
            tabSpinEdit10.DataBindings.Add(new Binding("Editvalue", dataSource, "proteinc", true));
            tabSpinEdit11.DataBindings.Add(new Binding("Editvalue", dataSource, "parutestproteinc", true));
            tabSpinEdit12.DataBindings.Add(new Binding("Editvalue", dataSource, "opredrezistent", true));   //  ?? ошибка
            tabImageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "volhankaogul", true));
            tabSpinEdit13.DataBindings.Add(new Binding("Editvalue", dataSource, "retrkrovsgustka", true));
            tabSpinEdit14.DataBindings.Add(new Binding("Editvalue", dataSource, "faktorvilibranda", true));
            tabSpinEdit15.DataBindings.Add(new Binding("Editvalue", dataSource, "faktor8", true));
            tabSpinEdit16.DataBindings.Add(new Binding("Editvalue", dataSource, "faktor9", true));
            tabSpinEdit17.DataBindings.Add(new Binding("Editvalue", dataSource, "faktor5", true));
            //tabSpinEdit18.DataBindings.Add(new Binding("Editvalue", dataSource, "ddimernikokart", true));
            tabImageComboBoxEdit7.DataBindings.Add(new Binding("SelectedIndex", dataSource, "ddimervib", true));
            tabSpinEdit19.DataBindings.Add(new Binding("Editvalue", dataSource, "ddimer", true));
            tabSpinEdit20.DataBindings.Add(new Binding("Editvalue", dataSource, "plazminogen", true));
            tabSpinEdit21.DataBindings.Add(new Binding("Editvalue", dataSource, "volhankaoguldec", true));
            textEdit1.DataBindings.Add(new Binding("Text", dataSource, "prochee", true));
            tabSpinEdit18.DataBindings.Add(new Binding("Editvalue", dataSource, "faktor51", true));
       }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }
     
        private void TabImageComboBoxEdit1SelectedIndexChanged(object sender, EventArgs e)
        {
            tabSpinEdit21.Visible = !(tabImageComboBoxEdit1.SelectedIndex == 0 || tabImageComboBoxEdit1.SelectedIndex == 3);
        }

        private void FrmKoagylogramma_KeyUp(object sender, KeyEventArgs e)
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
            ClassGrafiksReport.PrintToGraphics(e.Graphics, e.MarginBounds, PZAGOLOVOK0, this,12);
        }

    }
}
