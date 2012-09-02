using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace ReportsKDL
{
    public partial class Form1 : Form
    {
        private SqlDataAdapter Sluchaiadapter;
        private SqlConnection dpStr = new SqlConnection("Data Source=IVAN-PPC;Initial Catalog=LABARATORIJ;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }
        public DateTime Pdatastart
        { set; get; }
        public DateTime Pdataend
        { set; get; }
         string strd1="2010/01/01";
         string strd2="2010/05/05";
         DateTime date1 = DateTime.Parse("2010/01/01");
         DateTime date2 = DateTime.Parse("2010/05/05");
       
        //Pdataend="2010/05/05";
        private void Form1_Load(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.LocalReport lr = new Microsoft.Reporting.WinForms.LocalReport();
             lr.ReportPath = @"C:\PPC-KDL\ReportsKDL\ReportsKDL\Report1.rdlc";
            ReportParameter p1=new ReportParameter("datastart","2010/01/01");
            ReportParameter p2 = new ReportParameter("dataend", "2010/05/05");
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
            this.VBAKTERIOSBIOMAT_RUTableAdapter.GetDataByPeriod(date1, date2);
            Sluchaiadapter = new SqlDataAdapter("SELECT *  FROM VBAKTERIOSBIOMAT_RU  " , dpStr);
            this.VBAKTERIOSBIOMAT_RUBindingSource.DataSource = this.VBAKTERIOSBIOMAT_RUTableAdapter.GetDataByPeriod(date1, date2);
           //this.VBAKTERIOSBIOMAT_RUTableAdapter.GetDataByPeriod(date1, date2);
            //Sluchaiadapter.Fill(this.LABARATORIJDataSet.VBAKTERIOSBIOMAT_RU);
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("LABARATORIJDataSet_VBAKTERIOSBIOMAT_RU", this.VBAKTERIOSBIOMAT_RUBindingSource.DataSource));
            this.reportViewer1.RefreshReport();
        }
    }
}