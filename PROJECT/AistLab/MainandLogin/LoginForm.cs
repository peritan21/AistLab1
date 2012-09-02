using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AistLabData;

namespace AistLab.MainandLogin
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public LoginForm()
        {
            InitializeComponent();

        }
        public List<LABORANT> Lakusherrmm
        { get; set; }
  
        public bool Pvizibleakusher
        {
            set { lookUpEdit2.Visible = value; }
        }
        public void InitLookup()
        {
            lookUpEdit2.Properties.DataSource = Lakusherrmm;
  
        }
 
        public string StrLoginUservmeds    //
        {
            get { return lookUpEdit2.EditValue.ToString(); }
        }
     
        public string StrLoginPass
        {
            get { return textEdit1.Text; }
        }

        private void CmdOkClick(object sender, EventArgs e)
        {
            // и закрываем форму.
            DialogResult = DialogResult.OK;
            Close();

        }


  
    }
}
