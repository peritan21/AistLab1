using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraPrinting;
using AistLabData;
using CustomControlLib;

namespace AistLab.SetOtchet
{
    public partial class FrmAnalizOtchetSITOG : DevExpress.XtraEditors.XtraForm
    {
        private AccessorLab.OTCHETPERIODR_RI _kle;
        private readonly DataClassesLabDataContext  _dt = new DataClassesLabDataContext();
        private readonly List<AccessorLab.OTCHETPERIODR_RI> _lanalizr = new List<AccessorLab.OTCHETPERIODR_RI>();
        private readonly List<AccessorLab.AnalizOtchet> _lanalizotch1 = new List<AccessorLab.AnalizOtchet>();
        private readonly List<AccessorLab.AnalizOtchet> _lanalizotch2 = new List<AccessorLab.AnalizOtchet>();
        private readonly List<AccessorLab.AnalizOtchet> _lanalizotch3 = new List<AccessorLab.AnalizOtchet>();
        private readonly List<AccessorLab.OtchetUslkol> _lotchuslkol = new List<AccessorLab.OtchetUslkol>();
        private List<LABORANT> _labanaliz = new List<LABORANT>();
        private AccessorLab.AnalizOtchet _otch;
        private AccessorLab.OtchetUslkol _uslkol;
        private BindingSource _dataSource1;
        private int _tablid1;
        private const char SeparatorChar = ',';
        private const int Parselperiod = 0;
        private StatusProgresbar _statb;
        private readonly PrintableComponentLink _link;

        //protected AverageInfo defaultProvider;
        public FrmAnalizOtchetSITOG()
        {
            InitializeComponent();
          InitSQLDataOtchet();
          //this.gridControl1.EmbeddedNavigator.Show();
          //gridControl1.UseEmbeddedNavigator = true;
          gridControl2.UseEmbeddedNavigator = true;
          gridControl3.UseEmbeddedNavigator = true;
      
            datePeriodEdit1.Properties.SeparatorChar = SeparatorChar;
            datePeriodEdit1.Properties.OptionsSelection.MultiselectBehaviour =MultiselectBehaviour.Disabled;
            datePeriodEdit1.Properties.OptionsSelection.ShowWeekLevel =false;
            datePeriodEdit1.Properties.OptionsSelection.LowLevel = ViewLevel.Months;
            datePeriodEdit1.Properties.OptionsSelection.HightLevel =ViewLevel.Years;
            datePeriodEdit1.Properties.ShowWeekNumbers = false;
            imageComboBoxEdit1.SelectedIndex = Parselperiod;
            //PselFiltr = true;
            PselPromItog = true;
            // Create a PrintingSystem component.
            var ps = new PrintingSystem();
            // Create a link that will print a control.
            _link = new PrintableComponentLink(ps)
                        {Component = treeList2, PaperKind = System.Drawing.Printing.PaperKind.A4};
            // Specify the control to be printed.
            // Set the paper format.
            // Subscribe to the CreateReportHeaderArea event used to generate the report header.
            _link.CreateReportHeaderArea += PrintableComponentLink1CreateReportHeaderArea;
        }
    

        public static Period Parse1(String str)
        {
            str = str.Trim();
            if (str.Contains(" - "))
            {
                bool success = true;
                var periodSeparators = new string[1];
                periodSeparators[0] = " - ";
                string[] sides = string.Format("{0}", str).Split(periodSeparators, StringSplitOptions.RemoveEmptyEntries);
                var dates = new DateTime[2];
                int i = 0;
                foreach (string dateStr in sides)
                {
                    if (i > 1) continue;
                    string stringDate = dateStr.Trim();
                    success = success && DateTime.TryParse(stringDate,out dates[i]);
                    i++;
                }
                if (success)
                    if (dates[0] <= dates[1])
                        return new Period(dates[0], dates[1]);
            }
            else
            {
                DateTime dt;
                if (DateTime.TryParse(str, out dt))
                    return new Period(dt);
            }
            return null;
        }
        private void PrintableComponentLink1CreateReportHeaderArea(object sender,CreateAreaEventArgs e)
        {
          string strob = datePeriodEdit1.Text;
           string reportHeader = "Выполняемый в КДЛ БУ «ЦГБ» МЗ СР ЧР перечень лабораторных исследований за период:" + strob;
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
            e.Graph.Font = new Font("Tahoma", 10, FontStyle.Bold);
            var rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
            e.Graph.DrawString(reportHeader, Color.Black, rec, BorderSide.None);
        }


        //public bool PselFiltr
        //{
        //    set 
        //    {
        //        this.checkBox1.Checked = value;
        //        //if (value) this.treeList2.OptionsBehavior.EnableFiltering = true;
        //        //else this.treeList2.OptionsBehavior.EnableFiltering = false;
        //    }
        //    get { return this.checkBox1.Checked; }
        //}
        public bool PselPromItog
        {
            set
            {
                checkBox2.Checked = value;

            }
            get { return checkBox2.Checked; }
        }
        //public void InitFiltering()
        //{
        //    treeList2.FilterConditions.Add(new FilterCondition(FilterConditionEnum.NotBetween, treeList1.Columns["Budget"], 40000, 1200000, true));
        //    treeList2.FilterConditions.Add(new FilterCondition(FilterConditionEnum.NotEquals, treeList1.Columns["Location"], "Monterey", null, true));
        //    treeList3.FilterConditions.Add(new FilterCondition(FilterConditionEnum.Greater, treeList1.Columns["LastOrder"], new DateTime(2004, 11, 30), null, true));
        //}

        #region РАБОТА С ТАБЛИЦЕЙ ЗАПИСЕЙ ОТЧЕТА
        public void InitSQLDataOtchet()
        {

            // var res = (from c in dt.ANLOTCHET_TREEs select c);
            //this.aNLOTCHETTREEBindingSource.DataSource = res;
            //this.treeList2.DataSource = null;
            //this.treeList2.DataSource = this.aNLOTCHETTREEBindingSource;
            //this.treeList2.ExpandAll();
        
            //FilterCondition fc = new FilterCondition(FilterConditionEnum.Equals, treeListColumn3, "0");
            //FilterCondition fc1 = new FilterCondition(FilterConditionEnum.Equals, treeListColumn1, "0");
            //treeList2.FilterConditions.Add(fc);
            //treeList2.FilterConditions.Add(fc1);
            _labanaliz = _dt.GetTable<LABORANT>().ToList<LABORANT>();

       }
        public string Pdatevibstr
        {
            set { datePeriodEdit1.EditValue= value; }
            get { return datePeriodEdit1.EditValue.ToString(); }
        }
    
        private void TreeList2FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                _kle = (AccessorLab.OTCHETPERIODR_RI)aNLOTCHETTREEBindingSource[treeList2.FocusedNode.Id];
                if (_kle != null)
                {
                    int klID=Convert.ToInt32(_kle.analizotch_id);
                    if (!e.Node.HasChildren)
                    {
                        _lotchuslkol.Clear();
                        var resgrid = _dt.ANALOTCHET_USLCOUNT(klID, Pdatevibstr);
                        foreach (var t in resgrid)
                        {
                            if (t.analotchetusl_id != null)
                                if (t.kolstac != null)
                                    if (t.kolamb != null)
                                        _lotchuslkol.Add(new AccessorLab.OtchetUslkol((int)t.analotchetusl_id,t.NAME,t.TABLNAME,t.TABL_ID,(int)t.kolstac,(int)t.kolamb));
                        }
                        gridControl6.DataSource = null;
                        gridControl6.DataSource = _lotchuslkol;
                    }
                    // VivodGRIDOV(klID);
                }
            }
        }

        private void VivodGRIDOV(int klID)
        {
            //if (kle.TABLNAME.Trim().Length > 0)
            //{
                new DataClassesLabDataContext();
                //lcmc = (byte)Pdatevib.Month;
                //lcgod = Pdatevib.Year;
                //selectperiod
                //klID = Convert.ToInt32(kle.analizotch_id);
                _lanalizotch1.Clear();
                //gridControl1.DataSource = null;
                //var resotch = _dt.ANALIZ_OTCHETSKIPROD(klID, Pdatevibstr);
                //foreach (var t in resotch)
                //{
                //    if (t.nomer != null)
                //    {
                //        if (t.data != null)
                //        {
                //            if (t.tab_id != null)
                //            {
                //                var p = new AccessorLab.AnalizOtchet(int.Parse(t.n_history), t.fio, (int)t.nomer, "", (DateTime)t.data, 0, (int)t.tab_id);
                //                _lanalizotch1.Add(p);
                //            }
                //        }
                //    }
                //}
                //gridControl1.DataSource = _lanalizotch1; // dt.ANALIZ_OTCHETSKIPROD(klID, Pdatevibstr);
                _lanalizotch2.Clear();
                gridControl2.DataSource = null;
                var resotch2 = _dt.ANALIZ_OTCHETSKIPSTAC(klID, Pdatevibstr);
                foreach (var t in resotch2)
                {
                    if (t.noomer != null)
                    {
                        if (t.data != null)
                        {
                            if (t.tab_id != null)
                            {
                                var p = new AccessorLab.AnalizOtchet((int)t.noomer, t.fio, (int)t.noomer, t.name_otd, (DateTime)t.data, 0, (int)t.tab_id);
                                _lanalizotch2.Add(p);
                            }
                        }
                    }
                }
                gridControl2.DataSource = _lanalizotch2;
                _lanalizotch3.Clear();
                gridControl3.DataSource = null;
                var resotch3 = _dt.ANALIZ_OTCHETSKIPAMB(klID, Pdatevibstr);
                foreach (var t in resotch3)
                {
                    if (t.noomer != null)
                    {
                        if (t.data != null)
                        {
                            if (t.tab_id != null)
                            {
                                var p = new AccessorLab.AnalizOtchet((int)t.noomer, t.fio, (int)t.noomer, t.name_otd, (DateTime)t.data, 0, (int)t.tab_id);
                                _lanalizotch3.Add(p);
                            }
                        }
                    }
                }
                gridControl3.DataSource = _lanalizotch3;
            //}

            //return klID;
        }
 
        #endregion

        //private void toolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    // Выбор переиода
        //    FormParamPeriod fper = new FormParamPeriod();
        //    if (DialogResult.OK == fper.ShowDialog())
        //    {
        //        selmc = fper.Pmc;
        //        selday = fper.Pday;
        //        seldata = fper.Pdate;

        //    }
        //}

        //private void toolStripMenuItem2_Click(object sender, EventArgs e)
        //{
        //    LoadZapros();
        //}

        private void LoadZapros()
        {
            if (Pdatevibstr.Length == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Вы не выбрали период для формирования отчета ??? ");
                return;
            }
            int kolamb;
            string TABLNAME_;
           string colamb_;
            string colstac,colitog;
            int? kol=0;
            var res11 = _dt.OTCHETPERIOD0NEWI(Pdatevibstr,ref kol );
            _lanalizr.Clear();
            _statb = new StatusProgresbar(Bounds) 
            {Text = @"Загрузка данных с сервера"};
            treeList2.Nodes.Clear();
            if (kol != null) _statb.maxbar = (int)kol;
            _statb.stepbar = 1;
            _statb.StartPosition = FormStartPosition.CenterScreen;
            _statb.Show();
            foreach (var t in res11)
            {
                var analizotchID = (int)t.analizotch_id;
                var analizLevel = (byte)t.Analiz_Level;
                int parentID;
                if (t.Parent_ID != null) parentID = (int)t.Parent_ID;
                else parentID = 0;
                int tabindex;
                if (t.TABINDEX != null) tabindex = (int)t.TABINDEX;
                else tabindex = 0;
                int analizID;
                if (t.Analiz_ID != null) analizID = (int)t.Analiz_ID;
                else analizID = 0;
                string nameStr = t.NameStr ?? "";
                int npunktOtchet;
                if (t.NpunktOtchet != null) npunktOtchet = (int)t.NpunktOtchet;
                else npunktOtchet = 0;
                string uslivie;
                if (t.Uslivie != null) uslivie = t.Uslivie;
                else uslivie = "";
                if (t.kolamb != null) kolamb = (int)t.kolamb;
                else kolamb = 0;
                int kolstac;
                if (t.kolstac != null) kolstac = (int)t.kolstac;
                else kolstac = 0;
                if (t.TABLNAME != null) TABLNAME_ = t.TABLNAME;
                else TABLNAME_ = "";
                if (t.colamb != null) colamb_ = t.colamb.ToString();
                else colamb_ = "";
                if (t.colstac != null) colstac = t.colstac.ToString();
                else colstac = "";
                if (t.colitog != null) colitog = t.colitog.ToString();
                else colitog = "";
                _lanalizr.Add(new AccessorLab.OTCHETPERIODR_RI(analizotchID, analizLevel
              , parentID
              , tabindex
             , analizID
            , nameStr
             , npunktOtchet
             , uslivie
             , kolamb
             , kolstac
            , TABLNAME_
             , colamb_
             , colstac
             ,colitog));
                _statb.ProgresBar.PerformStep();
                _statb.ProgresBar.Update();
            }
            _statb.maxbar = 0;
            _statb.Close();
            TreeListColumn column;
            column = treeList2.Columns.Add();
            column.FieldName = "colstac";
            column.Caption = "Стац.";
            column.VisibleIndex = treeList2.Columns.Count + 1;
            
            column = treeList2.Columns.Add();
            column.FieldName = "colamb";
            column.Caption = "Амб.";
            column.VisibleIndex = treeList2.Columns.Count + 1;
         
            column = treeList2.Columns.Add();
            column.FieldName = "colitog";
            column.Caption = "Итого";
            column.VisibleIndex = treeList2.Columns.Count + 1;
            aNLOTCHETTREEBindingSource.DataSource = _lanalizr;
            treeList2.DataSource = aNLOTCHETTREEBindingSource;
            treeList2.ExpandAll();
        }

        private void SimpleButton1Click(object sender, EventArgs e)
        {
            LoadZapros();
         // ClearFirstColamb();
        if (PselPromItog) ClearColambStac();
        }

        private void ClearColambStac()
        {
            treeList2.Nodes.GetEnumerator();TreeListColumn colcolamb = treeList2.Columns["colamb"];
            TreeListColumn colcolstac = treeList2.Columns["colstac"];
            TreeListColumn colcoitog= treeList2.Columns["colitog"];
            var operation = new TreeListExceedLimitOperation(colcolamb, colcolstac,colcoitog);
            treeList2.NodesIterator.DoOperation(operation);
        }

        public class TreeListExceedLimitOperation : TreeListOperation
        {
            private readonly TreeListColumn _colcolamb0;
            private readonly TreeListColumn _colcolstac0;
            private readonly TreeListColumn _colcolitog0;
            public TreeListExceedLimitOperation(TreeListColumn colcolamb0, TreeListColumn colcolstac0, TreeListColumn colcolitog0)
            {

                _colcolamb0 = colcolamb0;
                _colcolstac0 = colcolstac0;
                _colcolitog0 = colcolitog0;
            }
            public override void Execute(TreeListNode node)
            {
                if (node.HasChildren)
                {
                    node.SetValue(_colcolamb0, "");
                    node.SetValue(_colcolstac0, "");
                    node.SetValue(_colcolitog0, "");
                }
            }
        }

        private void SimpleButton2Click(object sender, EventArgs e)
        {
            Close();
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
            //if (imageComboBoxEdit1.SelectedIndex == 0)
            //{
            //    datePeriodEdit1.Properties.OptionsSelection.MultiselectBehaviour = MultiselectBehaviour.Disabled;
            //    datePeriodEdit1.Properties.OptionsSelection.ShowWeekLevel = false;
            //    datePeriodEdit1.Properties.OptionsSelection.LowLevel = ViewLevel.Months;
            //    datePeriodEdit1.Properties.OptionsSelection.HightLevel = ViewLevel.Years;
            //    datePeriodEdit1.Properties.ShowWeekNumbers = false;
            //}
            //else
            //{
            //    datePeriodEdit1.Properties.OptionsSelection.MultiselectBehaviour = MultiselectBehaviour.Disabled;
            //    datePeriodEdit1.Properties.OptionsSelection.ShowWeekLevel = false;
            //    datePeriodEdit1.Properties.OptionsSelection.LowLevel = ViewLevel.Days;
            //    datePeriodEdit1.Properties.OptionsSelection.HightLevel = ViewLevel.Years;
            //    datePeriodEdit1.Properties.ShowWeekNumbers = false;
            //}

        }

        private void DatePeriodEdit1EditValueChanged(object sender, EventArgs e)
        {
            //  this.Text = datePeriodEdit1.EditValue.GetType().ToString() + ": " + datePeriodEdit1.EditValue.ToString();
        }

        //private void treeList2_FilterNode(object sender, FilterNodeEventArgs e)
        //{
        //    if (PselFiltr)
        //    {
        //        //if (Convert.ToInt32(e.Node[treeListColumn3]) == 0 && Convert.ToInt32(e.Node[treeListColumn1]) == 0)
        //        //{
        //        //    e.Node.Visible = true;  // false;
        //        //    e.Handled = true;
        //        //}
        //    }

        //}

        private void SimpleButton3Click(object sender, EventArgs e)
        {
            // Generate the report.
            _link.CreateDocument();
            //link.PrintingSystem.ExportToRtf(@"c:\PPC-KDL\kdl.rtf"); 
            // Show the report.
            _link.ShowPreview();
        }

        private void SimpleButton4Click(object sender, EventArgs e)
        {
            _link.CreateDocument();
            const string strfile = "kdl.rtf";
            _link.PrintingSystem.ExportToRtf(strfile);
            //const string strfile = "kdl.xlsx";
            //_link.PrintingSystem.ExportToXlsx(strfile);

            System.Diagnostics.Process.Start(strfile);
        }

        private void ToolStripMenuItem2Click(object sender, EventArgs e)
        {
            // Просмотр анализа с 1 го грида
            //_dataSource1 = new BindingSource();
            //_otch = (AccessorLab.AnalizOtchet)gridView1.GetRow(gridView1.FocusedRowHandle);
            //if (_otch != null) _tablid1 = _otch.tab_id;
            //else _tablid1 = 0;
            //var clshowanaliz = new ClassShowAnalizForm {Labanalizc = _labanaliz};
            //clshowanaliz.ShowCaseInFormAnaliz(_dataSource1, _tablid1, null, null, null, _uslkol);
        }

        private void ToolStripMenuItem3Click(object sender, EventArgs e)
        {
            // Просмотр анализа с 2 го грида
            _dataSource1 = new BindingSource();
            _otch = (AccessorLab.AnalizOtchet)gridView2.GetRow(gridView2.FocusedRowHandle);
            if (_otch != null) _tablid1 = _otch.tab_id;
            else _tablid1 = 0;
            var clshowanaliz = new ClassShowAnalizForm {Labanalizc = _labanaliz};
            clshowanaliz.ShowCaseInFormAnaliz(_dataSource1, _tablid1, null, null, null, _uslkol);
        }

        private void ToolStripMenuItem4Click(object sender, EventArgs e)
        {
            // Просмотр анализа с 3 го грида
            _dataSource1 = new BindingSource();
            _otch = (AccessorLab.AnalizOtchet)gridView3.GetRow(gridView3.FocusedRowHandle);
            if (_otch != null) _tablid1 = _otch.tab_id;
            else _tablid1 = 0;
            var clshowanaliz = new ClassShowAnalizForm {Labanalizc = _labanaliz};
            clshowanaliz.ShowCaseInFormAnaliz(_dataSource1, _tablid1, null, null, null, _uslkol);
        }

        private void GridControl6Click(object sender, EventArgs e)
        {
            // Выбор из списка файлов с условиями
            int sel = gridView6.FocusedRowHandle;
            _uslkol = (AccessorLab.OtchetUslkol)gridView6.GetRow(sel);
            VivodGRIDOV(_uslkol.analotchetusl_id);
        }
     

     
    }
}