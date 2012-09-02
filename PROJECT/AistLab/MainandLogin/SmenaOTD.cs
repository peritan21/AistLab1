using System.Collections.Generic;
using AistLabData;

namespace AistLab.MainandLogin
{
    public partial class SmenaOTD : DevExpress.XtraEditors.XtraForm
    {
        public SmenaOTD()
        {
            InitializeComponent();
        }
        public List<OTD> Lotdvib { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Lotdvib;
        }
        public string PotdIdvib
        {
            set
            {
                lookUpEdit1.EditValue = value;
            }
            get { return lookUpEdit1.EditValue.ToString(); }
        }
    }
}