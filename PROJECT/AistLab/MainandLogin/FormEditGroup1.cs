namespace AistLab.MainandLogin
{
    public partial class FormEditGroup1 : DevExpress.XtraEditors.XtraForm
    {

        public FormEditGroup1()
        {
            InitializeComponent();
          
        }
        public string NameGroup
        {
            set { txtBoxNameGroup.Text = value; }
            get { return txtBoxNameGroup.Text; }
        }
        public string   RTabIndex
        {
            get { return textEdit5.Text; }
            set { textEdit5.Text = value; } 
        }
        public string NameTable
        {
            set { textEdit1.Text = value; }
            get { return textEdit1.Text; }
        }
        public string NameKey
        {
            set { textEdit2.Text = value; }
            get { return textEdit2.Text; }
        }
    }
}
