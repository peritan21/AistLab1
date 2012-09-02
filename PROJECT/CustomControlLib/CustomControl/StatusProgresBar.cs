using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CustomControlLib
{
    public partial class StatusProgresbar : DevExpress.XtraEditors.XtraForm 
    {
          //  this.progressBarControl1.Properties.Step = 1;
          //  this.progressBarControl1.Properties.PercentView = true;
          //  this.progressBarControl1.Properties.Properties.Minimum = 0;
           //this.progressBarControl1.Properties.Maximum = matches.Count;
       DevExpress.XtraEditors.ProgressBarControl rbar=null;
        public DevExpress.XtraEditors.ProgressBarControl ProgresBar
        {
            set { this.progressBarControl1 = rbar; }
            get { return this.progressBarControl1; }
        }
        public StatusProgresbar(Rectangle rec)
        {
    
            InitializeComponent();
            this.Location = new Point(rec.X + (rec.Width - this.Width) / 2, rec.Y + (rec.Height - this.Height) / 2);

        }
       
        public int stepbar
        {
            set { this.progressBarControl1.Properties.Step = value; }
            get { return this.progressBarControl1.Properties.Step; }
        }
        public bool percentbar
        {
            set { this.progressBarControl1.Properties.PercentView = value; }
            get { return this.progressBarControl1.Properties.PercentView; }
        }
        public int minbar
        {
            set { this.progressBarControl1.Properties.Minimum = value; }
            get { return this.progressBarControl1.Properties.Minimum; }
        }
        public int maxbar
        {
            set { this.progressBarControl1.Properties.Maximum = value; }
            get { return this.progressBarControl1.Properties.Maximum; }
        }
        
     }
}
