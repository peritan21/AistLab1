using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace AistLab.ReportDDL
{
    public class ReportServer : Form
    {
        public ReportServer(string strReport,string strAnaliz)
        {
            Text = strAnaliz;
            ClientSize = new System.Drawing.Size(950, 600);

            var reportViewer = new ReportViewer {ProcessingMode = ProcessingMode.Remote};

            //reportViewer.ServerReport.ReportServerUrl = new Uri("http://ivan-ppc/ReportServer");  //http://IVAN-PPC:8080/ReportServer
            //reportViewer.ServerReport.ReportServerUrl = new Uri("http://IVAN-PPC:8080/ReportServer");
           reportViewer.ServerReport.ReportServerUrl = new Uri("http:/XXX/ReportServer");
            //reportViewer.ServerReport.ReportPath = @"/Цитограмма";
            //reportViewer.ServerReport.ReportPath = @"/АнализнаВИЧ";
            reportViewer.ServerReport.ReportPath = strReport;
            reportViewer.Dock = DockStyle.Fill;
            Controls.Add(reportViewer);
            reportViewer.RefreshReport();
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }
    }
}

