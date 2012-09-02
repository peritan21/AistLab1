using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AistLab
{
    public partial class FrmAFP : DevExpress.XtraEditors.XtraForm
    {
        public FrmAFP()
        {
            InitializeComponent();
        }
        public string Plabel10
        {
            set { labelControl10.Text = value; }
        }
        //labelControl10
        private void FrmUni_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
