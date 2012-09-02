using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace AistLab.SetOtchet
{
    public partial class XtraReportFpvmp : XtraReport
    {
        public XtraReportFpvmp(BindingSource dataSource, string strPeriod)
        {
            InitializeComponent();
            bindingSource1.DataSource = dataSource;

            parameterPeriod.Value = strPeriod;
        }

    }
}
