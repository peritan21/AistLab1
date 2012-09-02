using System.Windows.Forms;

namespace AistLab.SetOtchet
{
    public partial class XtraReportFulAnal : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportFulAnal(BindingSource dataSource, string strPeriod)
        {
            InitializeComponent();
            bindingSource1.DataSource = dataSource;

            parameterPeriod.Value = strPeriod;
        }

    }
}
