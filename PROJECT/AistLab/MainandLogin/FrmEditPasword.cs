namespace AistLab.MainandLogin
{
    public partial class FrmEditPasword : DevExpress.XtraEditors.XtraForm
    {
        public FrmEditPasword()
        {
            InitializeComponent();
        }

        public string POLDPASS
        {
            set { textEdit3.Text = value; }
            get { return textEdit3.Text; }
        }
        public string PNEWPASS
        {
            set { textEdit1.Text = value; }
            get { return textEdit1.Text; }
        }
        public string PDUBLPASS
        {
            set { textEdit2.Text = value; }
            get { return textEdit2.Text; }
        }

    }
}