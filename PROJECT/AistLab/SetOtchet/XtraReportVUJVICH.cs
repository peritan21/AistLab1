using System.Windows.Forms;

namespace AistLab.SetOtchet
{
    public partial class XtraReportVUJVVICH : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportVUJVVICH(BindingSource dataSource, string strPeriod)
        {
            InitializeComponent();
            bindingSource1.DataSource = dataSource;

            parameterPeriod.Value = strPeriod;
        }

    }
}
