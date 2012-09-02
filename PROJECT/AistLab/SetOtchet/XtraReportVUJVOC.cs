using System.Windows.Forms;

namespace AistLab.SetOtchet
{
    public partial class XtraReportVUJVOC : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportVUJVOC(BindingSource dataSource, string strPeriod)
        {
            InitializeComponent();
            bindingSource1.DataSource = dataSource;

            parameterPeriod.Value = strPeriod;
        }

    }
}
