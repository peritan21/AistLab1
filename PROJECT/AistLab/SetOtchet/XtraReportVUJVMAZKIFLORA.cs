using System.Windows.Forms;

namespace AistLab.SetOtchet
{
    public partial class XtraReportVUJVMAZKIFLORA : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportVUJVMAZKIFLORA(BindingSource dataSource, string strPeriod)
        {
            InitializeComponent();
            bindingSource1.DataSource = dataSource;

            parameterPeriod.Value = strPeriod;
        }

    }
}
