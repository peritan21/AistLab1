namespace AistLab.SetOtchet
{
    public partial class FrmViewUsl : DevExpress.XtraEditors.XtraForm
    {

        public FrmViewUsl()
        {
            InitializeComponent();
            //txtBoxNameGroup.DataBindings.Add(new Binding("Text", dataSource, "NameStr", true));
            //spinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "NpunktOtchet", true));
            //spinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "kolamb", true));
            //spinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "kolstac", true));
        }
        public string PNameStr
        {
            set { txtBoxNameGroup.Text = value; }
            //get { return this.txtBoxNameGroup.Text; }
        }

        public string PNameStrUsl
        {
            set { richTextBox1.Text = value; }
            //get { return this.richTextBox1.Text; }
        }
   
 
    }
}
