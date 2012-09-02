using System.Windows.Forms;

namespace AistLab.SetOtchet
{
    public partial class XtraReportVUJVPCR : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportVUJVPCR(BindingSource dataSource, string strPeriod)
        {
            InitializeComponent();
            bindingSource1.DataSource = dataSource;

            parameterPeriod.Value = strPeriod;
        }

    }
}
