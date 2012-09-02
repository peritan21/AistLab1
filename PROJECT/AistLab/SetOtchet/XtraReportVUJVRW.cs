using System.Windows.Forms;

namespace AistLab.SetOtchet
{
    public partial class XtraReportVUJVRW : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportVUJVRW(BindingSource dataSource, string strPeriod)
        {
            InitializeComponent();
            bindingSource1.DataSource = dataSource;

            parameterPeriod.Value = strPeriod;
        }

    }
}
