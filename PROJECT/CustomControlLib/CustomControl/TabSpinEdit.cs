using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.Windows.Forms;

namespace CustomControlLib
{
    [UserRepositoryItem("TabSpinEdit")]
    public partial class TabSpinEdit : DevExpress.XtraEditors.SpinEdit 
    {
        public TabSpinEdit() : base()
        {
          this.EnterMoveNextControl = true;
        }
        protected override void OnClick(EventArgs e)
        {
            
            this.SelectAll();
            base.OnClick(e);
        }
        protected override void OnGotFocus(EventArgs e)
        {
            this.SelectAll();
            base.OnGotFocus(e);
        }
   
    }

}
