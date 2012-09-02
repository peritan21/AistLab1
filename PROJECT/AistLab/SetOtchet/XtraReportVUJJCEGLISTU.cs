using System.Windows.Forms;

namespace AistLab.SetOtchet
{
    public partial class XtraReportVUJVJECGLISTU : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportVUJVJECGLISTU(BindingSource dataSource, string strPeriod)
        {
            InitializeComponent();
            bindingSource1.DataSource = dataSource;

            parameterPeriod.Value = strPeriod;
        }

    }
}
