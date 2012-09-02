using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraExport;
using DevExpress.XtraGrid.Export;
using DevExpress.XtraPrinting;
using AistLabData;
using CustomControlLib;

namespace AistLab.SetOtchet
{
    public partial class FrmOtchetFull : DevExpress.XtraEditors.XtraForm
    {
        private readonly DataClassesLabDataContext _dt = new DataClassesLabDataContext();
        private readonly List<AccessorLab.FullOtchet> _lanalizotch = new List<AccessorLab.FullOtchet>();
        private readonly List<LABORANT> _labanaliz = new List<LABORANT>();
        private AccessorLab.FullOtchet _otch;
        private int _tablid1;
        private StatusProgresbar _statb;
        private PrintableComponentLink _link;

        public FrmOtchetFull()
        {
            InitializeComponent();
            PselPeriod = 0;
            _labanaliz = _dt.GetTable<LABORANT>().ToList<LABORANT>();
            PparPage = 0;
          
        
        }

        private void SetPrintingMargins()
        {
            var ps = new PrintingSystem();
            // Create a link that will print a control.
            _link = new PrintableComponentLink(ps)
            {
                Component = gridControl3,
                PaperKind = System.Drawing.Printing.PaperKind.Letter,
                Landscape = true
            };
            // Specify the control to be printed.
            // Set the paper format.
            _link.CreateReportHeaderArea += new CreateAreaEventHandler(printableComponentLink1CreateReportHeaderArea);

        }
        private void printableComponentLink1CreateReportHeaderArea(object sender, CreateAreaEventArgs e)
        {
            //string leftColumn = "Pages: [Page # of Pages #]";
            //string middleColumn = "User: [User Name]";
            //string rightColumn = "Date: [Date Printed]";

            // Create a PageHeaderFooter object and initializing it with
            // the link's PageHeaderFooter.


            // Clear the PageHeaderFooter's contents.
            //phf.Header.Content.Clear();

            // Add custom information to the link's header.
            //phf.Header.Content.AddRange(new string[] { leftColumn, middleColumn, rightColumn });
            //phf.Header.LineAlignment = BrickAlignment.Far;

            string strob = datePeriodEdit2.Text;
           string reportHeader =
                 "Выполняемый в КДЛ БУ ЦГБ перечень лабораторных исследований за период:" + strob;
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
            e.Graph.Font = new Font("Tahoma", 10, FontStyle.Bold);
            var rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
            e.Graph.DrawString(reportHeader, Color.Black, rec, BorderSide.None);
        }
        public int PparPage
        {
            set { radioGroup1.SelectedIndex = value; }
            get { return radioGroup1.SelectedIndex; }
        }
        // radioGroup1
        public string Pdatevibstr
        {
            set { datePeriodEdit2.EditValue = value; }
            get { return datePeriodEdit2.EditValue.ToString(); }
        }
        public int PselPeriod
        {
            set { imageComboBoxEdit1.SelectedIndex = value; }
        }
    
        private void SimpleButton1Click(object sender, EventArgs e)
        {
            if (Pdatevibstr.Length == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Вы не выбрали период для формирования отчета ??? ");
                return;
            }

            //Pdatevibstr = " 01/01/2010 00:00:00 - 05/30/2010 23:59:59";
            //int? kol = 0;
            _lanalizotch.Clear();
            _statb = new StatusProgresbar(Bounds) { Text = @"Загрузка данных с сервера" };
            _statb.maxbar = 200;
            _statb.stepbar = 1;
            _statb.StartPosition = FormStartPosition.CenterScreen;
            _statb.Show();
            _dt.CommandTimeout = 10 * 60 * 1000;
            //
            switch (PparPage)
            {
                case 0:
                    {
                        FormOtchetpoANALIZ();
   
                    }
                    break;
                case 1:
                    {
                        FormOtchetpoOTD();
                    }
                    break;
            }
            //
            _statb.maxbar = 0;
            _statb.Close();
            gridControl3.DataSource = null;
            gridControl3.DataSource = _lanalizotch;
            gridView3.BeginSort();
            gridView3.Columns[0].GroupIndex = gridView3.SortInfo.GroupCount;
            gridView3.EndSort();
            gridView3.ExpandAllGroups();
        }

        private void FormOtchetpoOTD()
        {
            _lanalizotch.Clear();
            var res11 = _dt.OTCHETPERIODSSM0(Pdatevibstr);
            foreach (var t in res11)
            {
                if (t.Analiz_ID != null)
                {
                    if (t.data != null)
                    {
                        if (t.tab_id != null)
                        {
                            var p = new AccessorLab.FullOtchet((int)t.Analiz_ID, "", t.OTDSOKR, (DateTime)t.data, 0, (int)t.tab_id, t.NAME.Trim(), t.ANALIZST.Trim(), t.NAMETABLE);
                            _lanalizotch.Add(p);
                        }
                    }
                }
                //_statb.ProgresBar.PerformStep();
                //_statb.ProgresBar.Update();
            }
        }
        private void FormOtchetpoANALIZ()
        {
            _lanalizotch.Clear();
            var res11 = _dt.OTCHETPERIODSSM01(Pdatevibstr);
            foreach (var t in res11)
            {
                if (t.Analiz_ID != null)
                {
                    if (t.data != null)
                    {
                        if (t.tab_id != null)
                        {
                            var p = new AccessorLab.FullOtchet((int)t.Analiz_ID, "", t.OTDSOKR, (DateTime)t.data, 0, (int)t.tab_id, t.NAME.Trim(), t.ANALIZST.Trim(), t.NAMETABLE);
                            _lanalizotch.Add(p);
                        }
                    }
                }
                //_statb.ProgresBar.PerformStep();
                //_statb.ProgresBar.Update();
            }
        }
        private void ImageComboBoxEdit1SelectedIndexChanged(object sender, EventArgs e)
        {
            // Выбор режима для DateEdit
            switch (imageComboBoxEdit1.SelectedIndex)
            {
                case 0:
                    {
                        datePeriodEdit2.Properties.OptionsSelection.MultiselectBehaviour = MultiselectBehaviour.Disabled;
                        datePeriodEdit2.Properties.OptionsSelection.ShowWeekLevel = false;
                        datePeriodEdit2.Properties.OptionsSelection.LowLevel = ViewLevel.Months;
                        datePeriodEdit2.Properties.OptionsSelection.HightLevel = ViewLevel.Years;
                        datePeriodEdit2.Properties.ShowWeekNumbers = false;
                    }
                    break;
                case 1:
                    {
                        datePeriodEdit2.Properties.OptionsSelection.MultiselectBehaviour = MultiselectBehaviour.Disabled;
                        datePeriodEdit2.Properties.OptionsSelection.ShowWeekLevel = false;
                        datePeriodEdit2.Properties.OptionsSelection.LowLevel = ViewLevel.Days;
                        datePeriodEdit2.Properties.OptionsSelection.HightLevel = ViewLevel.Years;
                        datePeriodEdit2.Properties.ShowWeekNumbers = false;
                    }
                break;
                case 2:
                {
                    datePeriodEdit2.Properties.OptionsSelection.MultiselectBehaviour = MultiselectBehaviour.Intersection;
                    datePeriodEdit2.Properties.OptionsSelection.ShowWeekLevel = false;
                    datePeriodEdit2.Properties.OptionsSelection.LowLevel = ViewLevel.Days;
                    datePeriodEdit2.Properties.OptionsSelection.HightLevel = ViewLevel.Years;
                    datePeriodEdit2.Properties.ShowWeekNumbers = false;
                    break;
                }

            }
    
        }

        private void SimpleButton2Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ToolStripMenuItem2Click(object sender, EventArgs e)
        {
            // Просмотр анализа выбранной строки
            var dataSource1 = new BindingSource();
            _otch = (AccessorLab.FullOtchet)gridView3.GetRow(gridView3.FocusedRowHandle);
            if (_otch != null) _tablid1 = _otch.tab_id;
            else _tablid1 = 0;
            var clshowanaliz = new ClassShowAnalizForm {Labanalizc = _labanaliz};
            clshowanaliz.ShowCaseInFormAnaliz(dataSource1, _tablid1, null, null, _otch,null);
        }

        private void SimpleButton3Click(object sender, EventArgs e)
        {
            SetPrintingMargins();
            switch (PparPage)
            {
                case 0:
                    {
                        var dataSource0 = new BindingSource { DataSource = _lanalizotch };  //  
                        var xrp = new XtraReportFulAnal1(dataSource0, datePeriodEdit2.Text)
                                      {RequestParameters = false};
                        xrp.ShowPreview();
                    }
                    break;
                case 1:
                    {
                        var dataSource1 = new BindingSource { DataSource = _lanalizotch };      //
                        var xrp = new XtraReportFulAnal(dataSource1, datePeriodEdit2.Text)
                                   { RequestParameters = false};
                        xrp.ShowPreview();
                    }
                    break;
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
           // printableComponentLink1.ShowPreview();
            SetPrintingMargins();
            _link.CreateDocument();
           _link.ShowPreview();
          //  gridControl3.ShowPrintPreview();
         //   Export_TXT();

        }
        #region Экспорт таблицы в различных форматах
        private void sbExportToHTML_Click(object sender, EventArgs e)
        {
            string fileName = ShowSaveFileDialog("HTML Document", "HTML Documents|*.html");
            if (fileName != "")
            {
                ExportTo(new ExportHtmlProvider(fileName));
                // ExportTo(new ExportPdfProvider (fileName));
                OpenFile(fileName);
            }

        }
        //<sbExportToHTML>
        private void ExportTo(IExportProvider provider)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            this.FindForm().Refresh();
            BaseExportLink link = gridView3.CreateExportLink(provider);
            (link as GridViewExportLink).ExpandAll = false;
            link.Progress += new DevExpress.XtraGrid.Export.ProgressEventHandler(Export_Progress);
            link.ExportTo(true);
            provider.Dispose();
            link.Progress -= new DevExpress.XtraGrid.Export.ProgressEventHandler(Export_Progress);

            Cursor.Current = currentCursor;
        }
        //</sbExportToHTML>

        private string ShowSaveFileDialog(string title, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            string name = Application.ProductName;
            int n = name.LastIndexOf(".") + 1;
            if (n > 0) name = name.Substring(n, name.Length - n);
            dlg.Title = "Экспорт в " + title;
            dlg.FileName = name;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }

        //<sbExportToHTML>
        private void Export_Progress(object sender, DevExpress.XtraGrid.Export.ProgressEventArgs e)
        {
            if (e.Phase == DevExpress.XtraGrid.Export.ExportPhase.Link)
            {
                // progressBarControl1.Position = e.Position;
                this.Update();
            }
        }

        private void sbExportToXML_Click(object sender, EventArgs e)
        {
            Export_HTML();

        }

        private void Export_HTML()
        {
            string fileName = ShowSaveFileDialog("XML Document", "XML Documents|*.xml");
            if (fileName != "")
            {
                ExportTo(new ExportXmlProvider(fileName));
                OpenFile(fileName);
            }
        }

        private void sbExportToXLS_Click(object sender, EventArgs e)
        {
            Export_XLS();

        }

        private void Export_XLS()
        {
            string fileName = ShowSaveFileDialog("Microsoft Excel Document", "Microsoft Excel|*.xls");
            if (fileName != "")
            {
                ExportTo(new ExportXlsProvider(fileName));
                OpenFile(fileName);
            }
        }

        private void sbExportToTXT_Click(object sender, EventArgs e)
        {
            Export_TXT();

        }

        private void Export_TXT()
        {
            string fileName = ShowSaveFileDialog("Text Document", "Text Files|*.txt");
            if (fileName != "")
            {
                ExportTo(new ExportTxtProvider(fileName));
                OpenFile(fileName);
            }
        }
        private void OpenFile(string fileName)
        {
            if (XtraMessageBox.Show("Вы хотите открыть этот файл ?", "Экспорт в...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    process.Start();
                }
                catch
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(this, "Нет приложения для открытия  экспортного файла.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //progressBarControl1.Position = 0;
        }
        #endregion

      
    }
}