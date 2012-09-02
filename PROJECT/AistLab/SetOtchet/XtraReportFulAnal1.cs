using System.Windows.Forms;

namespace AistLab.SetOtchet
{
    public partial class XtraReportFulAnal1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportFulAnal1(BindingSource dataSource, string strPeriod)
        {
            InitializeComponent();
            bindingSource1.DataSource = dataSource;

            parameterPeriod.Value = strPeriod;
        }

    }
}
