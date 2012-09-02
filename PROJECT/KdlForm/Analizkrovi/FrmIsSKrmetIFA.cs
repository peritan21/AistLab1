using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Analizkrovi
{
    public partial class FrmIsSKrmetIFA : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        public FrmIsSKrmetIFA(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dateEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "b2glikoigm", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "b2glikoigg", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "protrigm", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "protrigg", true));
            tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "kardioigm", true));
            tabSpinEdit6.DataBindings.Add(new Binding("Editvalue", dataSource, "kardioigg", true));
            tabSpinEdit7.DataBindings.Add(new Binding("Editvalue", dataSource, "anneksigm", true));
            tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", dataSource, "anneksigg", true));
            //
            tabSpinEdit11.DataBindings.Add(new Binding("Editvalue", dataSource, "fosfocideriligg", true));
            tabSpinEdit10.DataBindings.Add(new Binding("Editvalue", dataSource, "fosfocideriligm", true));
            tabSpinEdit13.DataBindings.Add(new Binding("Editvalue", dataSource, "etanolaminigg", true));
            tabSpinEdit12.DataBindings.Add(new Binding("Editvalue", dataSource, "etanolaminigm", true));
            tabSpinEdit15.DataBindings.Add(new Binding("Editvalue", dataSource, "xolinigg", true));
            tabSpinEdit14.DataBindings.Add(new Binding("Editvalue", dataSource, "xolinigm", true));
            //
            tabSpinEdit9.DataBindings.Add(new Binding("Editvalue", dataSource, "gemocestian", true));
            tabImageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "igm", true));
            tabImageComboBoxEdit2.DataBindings.Add(new Binding("SelectedIndex", dataSource, "igg", true));
        
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }

        private void FrmIsSKrmetIFA_KeyUp(object sender, KeyEventArgs e)
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
            PrintToGraphics(e.Graphics, e.MarginBounds);
        }
        public void PrintToGraphics(Graphics graphics, Rectangle bounds)
        {
            //this.Text = "";
            // const  string HELLO_WORLD = "HELLO WORLD ";  // this.Text;
            //HELLO_WORLD = PZAGOLOVOK0;  // this.Text;
            this.Text = "";
            var messageSize = graphics.MeasureString(PZAGOLOVOK0, Font);
            Bitmap bitmap0 = new Bitmap((int)messageSize.Width, (int)messageSize.Height);
            this.DrawToBitmap(bitmap0, new Rectangle(0, 0, bitmap0.Width, bitmap0.Height));

            Rectangle target0 = new Rectangle(0, 0, bitmap0.Width, bitmap0.Height);
            PointF p = new PointF(10, 5);
            //PointF p = new PointF((ClientSize.Width - messageSize.Width) / 2,
            // (ClientSize.Height - messageSize.Height) / 2);
            graphics.DrawString(PZAGOLOVOK0, Font, SystemBrushes.WindowText, p);
            //SettargetRazmer(bounds, target0, bitmap0);
            double xScale0 = (double)bitmap0.Width / bounds.Width;
            double yScale0 = (double)bitmap0.Height / bounds.Height;
            if (xScale0 < yScale0)
                target0.Width = (int)(xScale0 * target0.Width / yScale0);
            else
                target0.Height = (int)(yScale0 * target0.Height / xScale0);
            //==
            graphics.PageUnit = GraphicsUnit.Display;
            graphics.DrawImage(bitmap0, target0);
            //  this.Text = "";
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bitmap, new Rectangle(0, bitmap0.Height + 12, bitmap.Width, bitmap.Height));
            Rectangle target = new Rectangle(0, 0, bounds.Width, bounds.Height + 12);
            // SettargetRazmer(bounds, target, bitmap);
            double xScale = (double)bitmap.Width / bounds.Width;
            double yScale = (double)bitmap.Height / bounds.Height;
            if (xScale < yScale)
                target.Width = (int)(xScale * target.Width / yScale);
            else
                target.Height = (int)(yScale * target.Height / xScale);
            graphics.PageUnit = GraphicsUnit.Display;
            graphics.DrawImage(bitmap, target);

        } 
      
    }
}
