using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Analizkrovi
{
    public partial class FrmGemostazio : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmGemostazio(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dateEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            tabImageComboBoxEdit4.DataBindings.Add(new Binding("SelectedIndex", dataSource, "fibrklausuvib", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "fibrklausu", true));
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
             tabSpinEdit12.DataBindings.Add(new Binding("Editvalue", dataSource, "opredrezistent", true));   //  ?? ошибка
            tabImageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "volhankaogul", true));
            tabSpinEdit21.DataBindings.Add(new Binding("Editvalue", dataSource, "volhankaoguldec", true));
            tabImageComboBoxEdit7.DataBindings.Add(new Binding("SelectedIndex", dataSource, "ddimervib", true));
            tabSpinEdit19.DataBindings.Add(new Binding("Editvalue", dataSource, "ddimer", true));
            tabSpinEdit20.DataBindings.Add(new Binding("Editvalue", dataSource, "tromboc", true));
            ////////
            tabSpinEdit17.DataBindings.Add(new Binding("Editvalue", dataSource, "spontagr2m", true));
            tabSpinEdit16.DataBindings.Add(new Binding("Editvalue", dataSource, "spontagrmah", true));
            tabSpinEdit15.DataBindings.Add(new Binding("Editvalue", dataSource, "ristomic", true));
            tabSpinEdit14.DataBindings.Add(new Binding("Editvalue", dataSource, "kollagen", true));
            tabSpinEdit13.DataBindings.Add(new Binding("Editvalue", dataSource, "adrenalin", true));
            tabSpinEdit11.DataBindings.Add(new Binding("Editvalue", dataSource, "adf5mkm", true));      
            //
            tabSpinEdit35.DataBindings.Add(new Binding("Editvalue", dataSource, "b2glikoigm", true));
            tabSpinEdit34.DataBindings.Add(new Binding("Editvalue", dataSource, "b2glikoigg", true));
            tabSpinEdit33.DataBindings.Add(new Binding("Editvalue", dataSource, "protrigm", true));
            tabSpinEdit32.DataBindings.Add(new Binding("Editvalue", dataSource, "protrigg", true));
            tabSpinEdit31.DataBindings.Add(new Binding("Editvalue", dataSource, "kardioigm", true));
            tabSpinEdit30.DataBindings.Add(new Binding("Editvalue", dataSource, "kardioigg", true));
            tabSpinEdit29.DataBindings.Add(new Binding("Editvalue", dataSource, "anneksigm", true));
            tabSpinEdit28.DataBindings.Add(new Binding("Editvalue", dataSource, "anneksigg", true));   
            // 
            tabSpinEdit26.DataBindings.Add(new Binding("Editvalue", dataSource, "fosfaigm", true));  // fosfaigg
            tabSpinEdit25.DataBindings.Add(new Binding("Editvalue", dataSource, "fosfaigg", true));
            tabSpinEdit24.DataBindings.Add(new Binding("Editvalue", dataSource, "etanoligm", true)); // etanoligm
            tabSpinEdit23.DataBindings.Add(new Binding("Editvalue", dataSource, "etanoligg", true));
            tabSpinEdit22.DataBindings.Add(new Binding("Editvalue", dataSource, "xolinigm", true));  // 
            tabSpinEdit18.DataBindings.Add(new Binding("Editvalue", dataSource, "xolinigg", true));
            tabSpinEdit27.DataBindings.Add(new Binding("Editvalue", dataSource, "gemocestian", true));   
            //
            tabSpinEdit39.DataBindings.Add(new Binding("Editvalue", dataSource, "ristomicsvet", true));
            tabSpinEdit38.DataBindings.Add(new Binding("Editvalue", dataSource, "kollagensvet", true));
            tabSpinEdit37.DataBindings.Add(new Binding("Editvalue", dataSource, "adrenalinsvet", true));
            tabSpinEdit36.DataBindings.Add(new Binding("Editvalue", dataSource, "adf5mkmsvet", true));
            tabSpinEdit40.DataBindings.Add(new Binding("Editvalue", dataSource, "kardioiggsum", true));
            tabSpinEdit41.DataBindings.Add(new Binding("Editvalue", dataSource, "proteincus", true));
            tabSpinEdit42.DataBindings.Add(new Binding("Editvalue", dataSource, "fosfaigmigg", true));
            tabSpinEdit43.DataBindings.Add(new Binding("Editvalue", dataSource, "fosfaigmigg1", true));
            tabSpinEdit44.DataBindings.Add(new Binding("Editvalue", dataSource, "plazminogen", true));   
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

        private void FrmGemostazio_KeyUp(object sender, KeyEventArgs e)
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
