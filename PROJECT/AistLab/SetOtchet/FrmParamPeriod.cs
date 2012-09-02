using System;

namespace AistLab.SetOtchet
{
    public partial class FormParamPeriod : DevExpress.XtraEditors.XtraForm
    {

        public FormParamPeriod()
        {
            InitializeComponent();
          
        }
        public DateTime Pdate
        {
            set { dateEdit1.EditValue = value; }
            get { return (DateTime)dateEdit1.EditValue; }
        }
        public bool Pmc
        {
            get { return checkEdit1.Checked; }
            set { checkEdit1.Checked = value; } 
        }
        public bool Pday
        {
            get { return checkEdit2.Checked; }
            set { checkEdit2.Checked = value; }
        }
    }
}
