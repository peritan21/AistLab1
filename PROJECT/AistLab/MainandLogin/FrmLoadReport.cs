using System;
using System.Linq;
using System.Windows.Forms;
using AistLabData;

namespace AistLab.MainandLogin
{
    public partial class FrmLoadReport : DevExpress.XtraEditors.XtraForm
    {
        DataClassesLabReportDataContext _dt;
        public FrmLoadReport()
        {
            InitializeComponent();
            RepLoad();
        }
        private void RepLoad()
        {
            _dt = new DataClassesLabReportDataContext();
            var res = (from c in _dt.Files orderby c.FileName  select c);
            gridControl1.DataSource = res;
        }

        private void SimpleButton1Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog {Title = @"Выберите файл для сохранения в базе"};
            openDialog.ShowDialog();
            string completeFilePath = openDialog.FileName;
            if (!(completeFilePath.Length > 0))
                return;
           string strfilename = completeFilePath.Substring(completeFilePath.LastIndexOf("\\") + 1);
            _dt = new DataClassesLabReportDataContext();
            _dt.ReportLoad(completeFilePath, strfilename);
            var res1 = (from c in _dt.Files select c);
            gridControl1.DataSource = res1;
        }

        private void SimpleButton2Click(object sender, EventArgs e)
        {
            // сохранить файл
            int sel=gridView1.FocusedRowHandle;
            // DataRow row = gridView1.GetDataRow( sel);
            //if (row == null) return;
            string currentDirName = System.IO.Directory.GetCurrentDirectory();
            string strfile = gridView1.GetRowCellDisplayText(sel, gridColumn1);
            string strfilefull = currentDirName +"\\"+ strfile;
            _dt = new DataClassesLabReportDataContext();
            _dt.ReportSave(@strfilefull, strfile);
        }

        private void SimpleButton3Click(object sender, EventArgs e)
        {
            int sel = gridView1.FocusedRowHandle;
            string strfile = gridView1.GetRowCellDisplayText(sel, gridColumn1);
            _dt = new DataClassesLabReportDataContext();
            _dt.ReportDelete(strfile);
            var res1 = (from c in _dt.Files select c);
            gridControl1.DataSource = res1;
        }
    }
}
