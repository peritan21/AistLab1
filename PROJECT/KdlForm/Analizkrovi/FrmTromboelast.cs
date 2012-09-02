using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Analizkrovi
{
    public partial class FrmTromboelast : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmTromboelast(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dateEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
              //  INTEM
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "intemct", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "intemcft", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "intema", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "intema10", true));
            tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "intema20", true));
            tabSpinEdit6.DataBindings.Add(new Binding("Editvalue", dataSource, "intemmcf", true));
            tabSpinEdit7.DataBindings.Add(new Binding("Editvalue", dataSource, "intemml", true));
            tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", dataSource, "inteml130", true));
            tabSpinEdit9.DataBindings.Add(new Binding("Editvalue", dataSource, "inteml145", true));
            tabSpinEdit10.DataBindings.Add(new Binding("Editvalue", dataSource, "inteml160", true));
            tabSpinEdit11.DataBindings.Add(new Binding("Editvalue", dataSource, "intemmaxv", true));
            tabSpinEdit12.DataBindings.Add(new Binding("Editvalue", dataSource, "intemmaxvt", true));
            tabSpinEdit13.DataBindings.Add(new Binding("Editvalue", dataSource, "intemauc", true));
            tabSpinEdit14.DataBindings.Add(new Binding("Editvalue", dataSource, "intemmce", true));
            tabSpinEdit15.DataBindings.Add(new Binding("Editvalue", dataSource, "intemmcft", true));
            tabSpinEdit16.DataBindings.Add(new Binding("Editvalue", dataSource, "intemcfr", true));
            tabSpinEdit17.DataBindings.Add(new Binding("Editvalue", dataSource, "intemlot", true));
            tabSpinEdit18.DataBindings.Add(new Binding("Editvalue", dataSource, "intemclr", true));
            // EXTEM
            tabSpinEdit36.DataBindings.Add(new Binding("Editvalue", dataSource, "extemct", true));
            tabSpinEdit35.DataBindings.Add(new Binding("Editvalue", dataSource, "extemcft", true));
            tabSpinEdit34.DataBindings.Add(new Binding("Editvalue", dataSource, "extema", true));
            tabSpinEdit33.DataBindings.Add(new Binding("Editvalue", dataSource, "extema10", true));
            tabSpinEdit32.DataBindings.Add(new Binding("Editvalue", dataSource, "extema20", true));
            tabSpinEdit31.DataBindings.Add(new Binding("Editvalue", dataSource, "extemmcf", true));
            tabSpinEdit30.DataBindings.Add(new Binding("Editvalue", dataSource, "extemml", true));
            tabSpinEdit29.DataBindings.Add(new Binding("Editvalue", dataSource, "exteml130", true));
            tabSpinEdit28.DataBindings.Add(new Binding("Editvalue", dataSource, "extem145", true));
            tabSpinEdit27.DataBindings.Add(new Binding("Editvalue", dataSource, "extem160", true));

            tabSpinEdit19.DataBindings.Add(new Binding("Editvalue", dataSource, "extemmaxv", true));
            tabSpinEdit20.DataBindings.Add(new Binding("Editvalue", dataSource, "extemmaxvt", true));
            tabSpinEdit21.DataBindings.Add(new Binding("Editvalue", dataSource, "extemauc", true));
            tabSpinEdit22.DataBindings.Add(new Binding("Editvalue", dataSource, "extemmce", true));
            tabSpinEdit23.DataBindings.Add(new Binding("Editvalue", dataSource, "extemmcft", true));
            tabSpinEdit24.DataBindings.Add(new Binding("Editvalue", dataSource, "extemcfr", true));
            tabSpinEdit25.DataBindings.Add(new Binding("Editvalue", dataSource, "extemlot", true));
            tabSpinEdit26.DataBindings.Add(new Binding("Editvalue", dataSource, "extemclr", true));
             //  FIBTEM
            tabSpinEdit54.DataBindings.Add(new Binding("Editvalue", dataSource, "fibtemct", true));
            tabSpinEdit53.DataBindings.Add(new Binding("Editvalue", dataSource, "fibtemcft", true));
            tabSpinEdit52.DataBindings.Add(new Binding("Editvalue", dataSource, "fibtema", true));
            tabSpinEdit51.DataBindings.Add(new Binding("Editvalue", dataSource, "fibtema10", true));
            tabSpinEdit50.DataBindings.Add(new Binding("Editvalue", dataSource, "fibtema20", true));
            tabSpinEdit49.DataBindings.Add(new Binding("Editvalue", dataSource, "fibtemmcf", true));
            tabSpinEdit48.DataBindings.Add(new Binding("Editvalue", dataSource, "fibtemml", true));
            tabSpinEdit47.DataBindings.Add(new Binding("Editvalue", dataSource, "fibteml130", true));
            tabSpinEdit46.DataBindings.Add(new Binding("Editvalue", dataSource, "fibteml145", true));
            tabSpinEdit45.DataBindings.Add(new Binding("Editvalue", dataSource, "fibteml160", true));

            tabSpinEdit37.DataBindings.Add(new Binding("Editvalue", dataSource, "fibtemmaxv", true));
            tabSpinEdit38.DataBindings.Add(new Binding("Editvalue", dataSource, "fibtemmaxvt", true));
            tabSpinEdit39.DataBindings.Add(new Binding("Editvalue", dataSource, "fibtemauc", true));
            tabSpinEdit40.DataBindings.Add(new Binding("Editvalue", dataSource, "fibtemmce", true));
            tabSpinEdit41.DataBindings.Add(new Binding("Editvalue", dataSource, "fibtemmcft", true));
            tabSpinEdit42.DataBindings.Add(new Binding("Editvalue", dataSource, "fibtemcfr", true));
            tabSpinEdit43.DataBindings.Add(new Binding("Editvalue", dataSource, "fibtemlot", true));
            tabSpinEdit44.DataBindings.Add(new Binding("Editvalue", dataSource, "fibtemclr", true));
            //  APTEM
            tabSpinEdit72.DataBindings.Add(new Binding("Editvalue", dataSource, "aptemct", true));
            tabSpinEdit71.DataBindings.Add(new Binding("Editvalue", dataSource, "aptemcft", true));
            tabSpinEdit70.DataBindings.Add(new Binding("Editvalue", dataSource, "aptema", true));
            tabSpinEdit69.DataBindings.Add(new Binding("Editvalue", dataSource, "aptema10", true));
            tabSpinEdit68.DataBindings.Add(new Binding("Editvalue", dataSource, "aptema20", true));
            tabSpinEdit67.DataBindings.Add(new Binding("Editvalue", dataSource, "aptemmcf", true));
            tabSpinEdit66.DataBindings.Add(new Binding("Editvalue", dataSource, "aptemml", true));
            tabSpinEdit65.DataBindings.Add(new Binding("Editvalue", dataSource, "apteml130", true));
            tabSpinEdit64.DataBindings.Add(new Binding("Editvalue", dataSource, "apteml145", true));
            tabSpinEdit63.DataBindings.Add(new Binding("Editvalue", dataSource, "apteml160", true));

            tabSpinEdit55.DataBindings.Add(new Binding("Editvalue", dataSource, "aptemmaxv", true));
            tabSpinEdit56.DataBindings.Add(new Binding("Editvalue", dataSource, "aptemmaxvt", true));
            tabSpinEdit57.DataBindings.Add(new Binding("Editvalue", dataSource, "aptemauc", true));
            tabSpinEdit58.DataBindings.Add(new Binding("Editvalue", dataSource, "aptemmce", true));
            tabSpinEdit59.DataBindings.Add(new Binding("Editvalue", dataSource, "aptemmcft", true));
            tabSpinEdit60.DataBindings.Add(new Binding("Editvalue", dataSource, "aptemcfr", true));
            tabSpinEdit61.DataBindings.Add(new Binding("Editvalue", dataSource, "aptemlot", true));
            tabSpinEdit62.DataBindings.Add(new Binding("Editvalue", dataSource, "aptemclr", true));

       }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }

        private void FrmTromboelast_KeyUp(object sender, KeyEventArgs e)
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
