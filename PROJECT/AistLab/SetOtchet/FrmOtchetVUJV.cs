using System;
using System.Collections.Generic;using System.Windows.Forms;
using DevExpress.XtraPrinting;
using AistLabData;
using CustomControlLib;

namespace AistLab.SetOtchet
{
    public partial class FrmOtchetVUJV : DevExpress.XtraEditors.XtraForm
    {
        private readonly DataClassesLabDataContext _dt = new DataClassesLabDataContext();
        private readonly List<AccessorLab.VUJVRIF> _lanalizotch = new List<AccessorLab.VUJVRIF>();

        public FrmOtchetVUJV()
        {
            InitializeComponent();
            PselPeriod = 0;
            //_dt.GetTable<LABORANT>().ToList<LABORANT>();
            PparPage = 0;
        }

        private void SetPrintingMargins()
        {
            var ps = new PrintingSystem();
            new PrintableComponentLink(ps)
                {
                    Component = gridControl3,
                    PaperKind = System.Drawing.Printing.PaperKind.Letter,
                    Landscape = true
                };
      

        }
        public int PparPage
        {
            set { tabImageComboBoxEdit2.SelectedIndex = value; }
            get { return tabImageComboBoxEdit2.SelectedIndex; }
        }
      
        public string Pdatevibstr
        {
            set { datePeriodEdit1.EditValue = value; }
            get { return datePeriodEdit1.EditValue.ToString(); }
        }
        public string _pdateperiodstr
        {
            get { return datePeriodEdit1.Text; }
        }

        public int PselPeriod
        {
            set { imageComboBoxEdit1.SelectedIndex = value; }
        }
    
        private void SimpleButton1Click(object sender, EventArgs e)
        {
            //string _strperiod = _STRperiodMy();

            if (Pdatevibstr.Length == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Вы не выбрали период для формирования отчета ??? ");
                return;
            }

            //Pdatevibstr = " 01/01/2010 00:00:00 - 05/30/2010 23:59:59";
            //int? kol = 0;
            _lanalizotch.Clear();
            if (PparPage == 0)
            {
                var res11 = _dt.VUJVLAEMRIF(Pdatevibstr);
                foreach (var t in res11)
                {
                    if (t.KOL != null)
                    {
                        if (t.KOLPOL != null)
                        {
                            var p = new AccessorLab.VUJVRIF(t.NAME.Trim(), t.name_otdsokr.Trim(), (int)t.KOL, (int)t.KOLPOL);
                            _lanalizotch.Add(p);
                        }
                    }
                }
            }
            else if (PparPage == 1)
            {
                var res11 = _dt.VUJVLAEMMAZKIFLORA0(Pdatevibstr);
                foreach (var t in res11)
                {
                    if (t.KOL != null)
                    {
                        if (t.KOLPOL != null)
                        {
                            var p = new AccessorLab.VUJVRIF(t.NAME.Trim(), t.name_otdsokr.Trim(), (int)t.KOL, (int)t.KOLPOL);
                            _lanalizotch.Add(p);
                        }
                    }
                }
            }
            else if (PparPage == 2)
            {
                var res11 = _dt.VUJVLAEMOC(Pdatevibstr);
                foreach (var t in res11)
                {
                    if (t.KOL != null)
                    {
                        if (t.KOLPOL != null)
                        {
                            var p = new AccessorLab.VUJVRIF(t.NAME.Trim(), t.name_otdsokr.Trim(), (int)t.KOL, (int)t.KOLPOL);
                            _lanalizotch.Add(p);
                        }
                    }
                }
            }
            else if (PparPage == 3)
            {
                var res11 = _dt.VUJVLAEMCHESOTKA(Pdatevibstr);
                foreach (var t in res11)
                {
                    if (t.KOL != null)
                    {
                        if (t.KOLPOL != null)
                        {
                            var p = new AccessorLab.VUJVRIF(t.NAME.Trim(), t.name_otdsokr.Trim(), (int)t.KOL, (int)t.KOLPOL);
                            _lanalizotch.Add(p);
                        }
                    }
                }
            }
            else if (PparPage == 4)
            {
                var res11 = _dt.VUJVLAEMJCEGLISTU(Pdatevibstr);
                foreach (var t in res11)
                {
                    if (t.KOL != null)
                    {
                        if (t.KOLPOL != null)
                        {
                            var p = new AccessorLab.VUJVRIF(t.NAME.Trim(), t.name_otdsokr.Trim(), (int)t.KOL, (int)t.KOLPOL);
                            _lanalizotch.Add(p);
                        }
                    }
                }
            }
            else if (PparPage == 5)
            {
                var res11 = _dt.VUJVLAEMPCR(Pdatevibstr);
                foreach (var t in res11)
                {
                    if (t.KOL != null)
                    {
                        if (t.KOLPOL != null)
                        {
                            var p = new AccessorLab.VUJVRIF(t.NAME.Trim(), t.name_otdsokr.Trim(), (int)t.KOL, (int)t.KOLPOL);
                            _lanalizotch.Add(p);
                        }
                    }
                }
            }
            gridControl3.DataSource = null;
            gridControl3.DataSource = _lanalizotch;
            gridView3.BeginSort();
            gridView3.Columns[0].GroupIndex = gridView3.SortInfo.GroupCount;
            gridView3.EndSort();
            gridView3.ExpandAllGroups();
        }
        private string _STRperiodMy()
        {
            DateTime _begin1, _end1;
            string _S, _N, _strperiod;
            int _begintire;
            int _booltire = _pdateperiodstr.IndexOf("-");

            if (_booltire > 0)
            {
                _begintire = _pdateperiodstr.IndexOf("-");
                _S = _pdateperiodstr.Substring(0, _begintire);
                _N = _pdateperiodstr.Substring(_begintire);
                _begin1 = DateTime.Parse(_S);
                _end1 = DateTime.Parse(_N.Substring(1));
                _strperiod = _begin1.ToString("u") + "-" + _end1.Date.AddDays(1).AddSeconds(-1).ToString("u");  //dd/MM/yyyy hh:mm:ss
            }
            else
            {
                _begin1 = DateTime.Parse(_pdateperiodstr);
                _end1 = _begin1.Date.AddDays(1).AddSeconds(-1);
                _strperiod = _begin1.ToString("u") + "-" + _begin1.Date.AddDays(1).AddSeconds(-1).ToString("u");
            }
            return _strperiod;
        }


        private void ImageComboBoxEdit1SelectedIndexChanged(object sender, EventArgs e)
        {
            // Выбор режима для DateEdit
            switch (imageComboBoxEdit1.SelectedIndex)
            {
                case 0:
                    {
                        datePeriodEdit1.Properties.OptionsSelection.MultiselectBehaviour = MultiselectBehaviour.Disabled;
                        datePeriodEdit1.Properties.OptionsSelection.ShowWeekLevel = false;
                        datePeriodEdit1.Properties.OptionsSelection.LowLevel = ViewLevel.Months;
                        datePeriodEdit1.Properties.OptionsSelection.HightLevel = ViewLevel.Years;
                        datePeriodEdit1.Properties.ShowWeekNumbers = false;
                    }
                    break;
                case 1:
                    {
                        datePeriodEdit1.Properties.OptionsSelection.MultiselectBehaviour = MultiselectBehaviour.Disabled;
                        datePeriodEdit1.Properties.OptionsSelection.ShowWeekLevel = false;
                        datePeriodEdit1.Properties.OptionsSelection.LowLevel = ViewLevel.Days;
                        datePeriodEdit1.Properties.OptionsSelection.HightLevel = ViewLevel.Years;
                        datePeriodEdit1.Properties.ShowWeekNumbers = false;
                    }
                break;
                case 2:
                {
                    datePeriodEdit1.Properties.OptionsSelection.MultiselectBehaviour = MultiselectBehaviour.Intersection;
                    datePeriodEdit1.Properties.OptionsSelection.ShowWeekLevel = false;
                    datePeriodEdit1.Properties.OptionsSelection.LowLevel = ViewLevel.Days;
                    datePeriodEdit1.Properties.OptionsSelection.HightLevel = ViewLevel.Years;
                    datePeriodEdit1.Properties.ShowWeekNumbers = false;
                    break;
                }

            }
    
        }

        private void SimpleButton2Click(object sender, EventArgs e)
        {
            Close();
        }


        private void SimpleButton3Click(object sender, EventArgs e)
        {
            SetPrintingMargins();
            if (PparPage == 0)
            {
                var dataSource2 = new BindingSource {DataSource = _lanalizotch};
                var xrp = new XtraReportVUJVRIF(dataSource2, datePeriodEdit1.Text) {RequestParameters = false};
                xrp.ShowPreview();
            }
            else if (PparPage == 1)
            {
                var dataSource2 = new BindingSource {DataSource = _lanalizotch};
                var xrp = new XtraReportVUJVMAZKIFLORA(dataSource2, datePeriodEdit1.Text)
                              {RequestParameters = false};
                xrp.ShowPreview();
            }
            else if (PparPage == 2)
            {
                var dataSource2 = new BindingSource {DataSource = _lanalizotch};
                var xrp = new XtraReportVUJVOC(dataSource2, datePeriodEdit1.Text) {RequestParameters = false};
                xrp.ShowPreview();
            }
            else if (PparPage == 3)
            {
                var dataSource2 = new BindingSource { DataSource = _lanalizotch };
                var xrp = new XtraReportVUJVCHESOTKA(dataSource2, datePeriodEdit1.Text) { RequestParameters = false };
                xrp.ShowPreview();
            }
            else if (PparPage == 4)
            {
                var dataSource2 = new BindingSource { DataSource = _lanalizotch };
                var xrp = new XtraReportVUJVJECGLISTU(dataSource2, datePeriodEdit1.Text) { RequestParameters = false };
                xrp.ShowPreview();
            }
            else if (PparPage == 5)
            {
                var dataSource2 = new BindingSource { DataSource = _lanalizotch };
                var xrp = new XtraReportVUJVPCR(dataSource2, datePeriodEdit1.Text) { RequestParameters = false };
                xrp.ShowPreview();
            }
        }



    }
}