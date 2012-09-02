using System.Windows.Forms;

namespace AistLab.SetOtchet
{
    public partial class XtraReportVUJVRIF : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportVUJVRIF(BindingSource dataSource, string strPeriod)
        {
            InitializeComponent();
            bindingSource1.DataSource = dataSource;

            parameterPeriod.Value = strPeriod;
        }

    }
}
