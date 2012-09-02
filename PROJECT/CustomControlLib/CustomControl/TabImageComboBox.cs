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
    [UserRepositoryItem("TabImageComboBoxEdit")]
    [ToolboxItemFilter("System.Windows.Forms")]
    public partial class TabImageComboBoxEdit : DevExpress.XtraEditors.ImageComboBoxEdit 
    {
        private RepositoryItemImageComboBox properties;
    
        public TabImageComboBoxEdit()
        {
            this.EnterMoveNextControl = true;
            
        }
        protected override void OnGotFocus(EventArgs e)
        {
            
            this.EditValue = 0;
            base.OnGotFocus(e);
        }

        private void InitializeComponent()
        {
            this.properties = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.properties)).BeginInit();
            this.SuspendLayout();
            // 
            // fProperties
            // 
            this.properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.properties.Name = "properties";
            ((System.ComponentModel.ISupportInitialize)(this.properties)).EndInit();
            this.ResumeLayout(false);

        }
   
    }

}
