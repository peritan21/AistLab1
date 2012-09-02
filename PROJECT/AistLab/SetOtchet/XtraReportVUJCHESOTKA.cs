using System.Windows.Forms;

namespace AistLab.SetOtchet
{
    public partial class XtraReportVUJVCHESOTKA : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportVUJVCHESOTKA(BindingSource dataSource, string strPeriod)
        {
            InitializeComponent();
            bindingSource1.DataSource = dataSource;

            parameterPeriod.Value = strPeriod;
        }

    }
}
