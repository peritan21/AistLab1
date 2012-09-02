using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using AistLabData;
using CustomControlLib;

namespace AistLab.SetOtchet
{
    public partial class FrmOtchetFpvmp : DevExpress.XtraEditors.XtraForm
    {
        private readonly DataClassesLabDataContext _dt = new DataClassesLabDataContext();
        private readonly List<AccessorLab.AnalizOtchetFMVMP> _lanalizotch = new List<AccessorLab.AnalizOtchetFMVMP>();
        private readonly List<LABORANT> _labanaliz = new List<LABORANT>();
        private AccessorLab.FullOtchet _otch;
        private int _tablid1;
/*
        private ANALIZMENU _kle;
*/
        private PrintableComponentLink _link;
        public FrmOtchetFpvmp()
        {
            InitializeComponent();PselPeriod = 0;
            _labanaliz = _dt.GetTable<LABORANT>().ToList();
             PparPage = 0;
        }

        private void SetPrintingMargins()
        {
            using (var ps = new PrintingSystem())
            {
                _link = new PrintableComponentLink(ps);
            }
            // Specify the control to be printed.
            _link.Component = gridControl3;
            // Set the paper format.
         //   link.CreateReportHeaderArea += new CreateAreaEventHandler(printableComponentLink1_CreateReportHeaderArea);
            _link.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            _link.Landscape = true;
   
        }
        //public int PparPage
        //{
        //    set { radioGroup1.SelectedIndex = value; }
        //    get { return radioGroup1.SelectedIndex; }
        //}
        // radioGroup1
        public int PparPage
        {
            set { tabImageComboBoxEdit2.SelectedIndex = value; }
            get { return tabImageComboBoxEdit2.SelectedIndex; }
        }
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
            if (PparPage == 0)
            {
                _lanalizotch.Clear();
                var res11 = _dt.OTCHETPERIODFPMP(Pdatevibstr);
                foreach (var t in res11)
                {
                    if (t.noomer != null)
                    {
                        if (t.data != null)
                        {
                            if (t.namefldru != null)
                            {
                                var p = new AccessorLab.AnalizOtchetFMVMP((int) t.noomer, t.fio, t.lfio, t.name_otdsokr,
                                                                          (DateTime) t.data, t.analzname.Trim(),
                                                                          t.namefldru);
                                _lanalizotch.Add(p);
                            }
                        }
                    }
                }
            }
            else if (PparPage==1)
            {
                _lanalizotch.Clear();
                var res11 = _dt.OTCHETPERIODFPMP0(Pdatevibstr);
                foreach (var t in res11)
                {
                    if (t.noomer != null)
                    {
                        if (t.data != null)
                        {
                            if (t.namefldru != null)
                            {
                                var p = new AccessorLab.AnalizOtchetFMVMP((int)t.noomer, t.fio, t.lfio, t.name_otdsokr,
                                                                          (DateTime)t.data, t.analzname.Trim(),
                                                                          t.namefldru);
                                _lanalizotch.Add(p);
                            }
                        }
                    }
                }
            }
            gridControl3.DataSource = null;
            gridControl3.DataSource = _lanalizotch;
            gridView3.BeginSort();
            gridView3.Columns[4].GroupIndex = gridView3.SortInfo.GroupCount;
            gridView3.EndSort();
            gridView3.ExpandAllGroups();
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
            ClassShowAnalizForm clshowanaliz = new ClassShowAnalizForm();
            clshowanaliz.Labanalizc = _labanaliz;
            clshowanaliz.ShowCaseInFormAnaliz(dataSource1, _tablid1, null, null, _otch,null);
        }
/*
        private void ShowGridPreview(DevExpress.XtraGrid.GridControl grid)
        {
            // Check whether the XtraGrid control can be previewed.
            if (!grid.IsPrintingAvailable)
            {
                MessageBox.Show("Отсутсвует библиотека для печати ", "Ошибка");
                return;
            }
            // Opens the Preview window.
            grid.ShowPrintPreview();
        }
*/

        private void SimpleButton3Click(object sender, EventArgs e)
        {
            SetPrintingMargins();
            BindingSource dataSource2 = new BindingSource();
            dataSource2.DataSource = _lanalizotch;
            XtraReportFpvmp xrp = new XtraReportFpvmp(dataSource2, datePeriodEdit2.Text);
            xrp.RequestParameters = false;
            xrp.ShowPreview();
    
        }
    }
}