using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AistLab.ReportDDL;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraPrinting;
using AistLabData;
using System.Collections;
using CustomControlLib;

namespace AistLab.SetOtchet
{
    public partial class FrmAnalizOtchetMS : DevExpress.XtraEditors.XtraForm
    {
        private ANALIZMENU _kle;
        private readonly DataClassesLabDataContext  _dt = new DataClassesLabDataContext();
        private readonly List<ANALIZMENU> _analizList = new List<ANALIZMENU>();
        private readonly List<AccessorLab.AnalizOtchet> _lanalizotch1= new List<AccessorLab.AnalizOtchet>();
        private readonly List<AccessorLab.AnalizOtchet> _lanalizotch2= new List<AccessorLab.AnalizOtchet>();
        private readonly List<AccessorLab.AnalizOtchet> _lanalizotch3= new List<AccessorLab.AnalizOtchet>();
        private List<LABORANT> _labanaliz = new List<LABORANT>();
        private AccessorLab.AnalizOtchet _otch;
        private BindingSource _dataSource1;
        private int _tablid1;
        private const char SeparatorChar = ',';
        private const int Parselperiod = 0;
        private StatusProgresbar _statb;
        private PrintableComponentLink _link;
        private IEnumerator _en;

        //protected AverageInfo defaultProvider;
        public FrmAnalizOtchetMS()
        {
            InitializeComponent();
          InitSQLDataOtchet();
          //this.gridControl1.EmbeddedNavigator.Show();
          //gridControl1.UseEmbeddedNavigator = true;
          gridControl2.UseEmbeddedNavigator = true;
          gridControl3.UseEmbeddedNavigator = true;
      
            datePeriodEdit3.Properties.SeparatorChar = SeparatorChar;
            datePeriodEdit3.Properties.OptionsSelection.MultiselectBehaviour =MultiselectBehaviour.Disabled;
            datePeriodEdit3.Properties.OptionsSelection.ShowWeekLevel =false;
            datePeriodEdit3.Properties.OptionsSelection.LowLevel = ViewLevel.Months;
            datePeriodEdit3.Properties.OptionsSelection.HightLevel =ViewLevel.Years;
            datePeriodEdit3.Properties.ShowWeekNumbers = false;
            imageComboBoxEdit1.SelectedIndex = Parselperiod;
            //PselFiltr = true;
            PselPromItog = true;
            // Create a PrintingSystem component.
            //PrintingSystem ps = new PrintingSystem();
            //// Create a link that will print a control.
            //link = new PrintableComponentLink(ps);
            //// Specify the control to be printed.
            //link.Component = this.treeList2;
            //// Set the paper format.
            //link.PaperKind = System.Drawing.Printing.PaperKind.A4;
            //// Subscribe to the CreateReportHeaderArea event used to generate the report header.
            //link.CreateReportHeaderArea +=
            //  new CreateAreaEventHandler(printableComponentLink1_CreateReportHeaderArea);
            //link.CreateDetailArea+=new CreateAreaEventHandler(link_CreateDetailArea);

        }
        //private void link_CreateDetailArea(object sender, CreateAreaEventArgs e)
        //{
        //    //e.Graph.PrintingSystem.
        //   //e.Graph.DrawLine(
        //}

        public static Period Parse1(String str)
        {
            str = str.Trim();
            if (str.Contains(" - "))
            {
                bool success = true;
                string[] periodSeparators = new string[1];
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
          string strob = datePeriodEdit3.Text;
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
        //        if (value) this.treeList2.OptionsBehavior.EnableFiltering = true;
        //        else this.treeList2.OptionsBehavior.EnableFiltering = false;
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
            set { datePeriodEdit3.EditValue= value; }
            get { return datePeriodEdit3.EditValue.ToString(); }
        }
    
        private void TreeList2FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                _kle = (ANALIZMENU)aNALIZMENUBindingSource[treeList2.FocusedNode.Id];
                if (_kle != null)
                {
                    if (_kle.TABLNAME != null)
                    {
                        if (_kle.TABLNAME.Trim().Length > 0)
                        {
                            //DataClassesLabDataContext dk = new DataClassesLabDataContext();
                            //lcmc = (byte)Pdatevib.Month;
                            //lcgod = Pdatevib.Year;
                            //selectperiod 
                            //string strvib11 = Pdatevibstr;
                            int klID = Convert.ToInt32(_kle.Analiz_ID);
                            _lanalizotch1.Clear();
                            //gridControl1.DataSource = null;
                            //_dt.ANALIZ_OTCHETSKIPRODM(klID, Pdatevibstr);
                            //var resotch1 = _dt.ANALIZ_OTCHETSKIPRODM(klID, Pdatevibstr);
                            //foreach (var t in resotch1)
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
                            //gridControl1.DataSource = _lanalizotch1;   
                            _lanalizotch2.Clear();
                            gridControl2.DataSource = null;
                            var resotch2 = _dt.ANALIZ_OTCHETSKIPSTACM(klID, Pdatevibstr);
                            foreach (var t in resotch2)
                            {
                                if (t.noomer != null)
                                {
                                    if (t.data != null)
                                    {
                                        if (t.tab_id != null)
                                        {
                                            var p = new AccessorLab.AnalizOtchet((int)t.noomer, t.fio, 0,t.name_otd, (DateTime)t.data, 0, (int)t.tab_id);
                                            _lanalizotch2.Add(p);
                                        }
                                    }
                                }
                            }
                            gridControl2.DataSource = _lanalizotch2;
                            _lanalizotch3.Clear();
                            gridControl3.DataSource = null;
                            var resotch3 =   _dt.ANALIZ_OTCHETSKIPAMBM(klID, Pdatevibstr);
                            foreach (var t in resotch3)
                            {
                                if (t.noomer != null)
                                {
                                    if (t.data != null)
                                    {
                                        if (t.tab_id != null)
                                        {
                                            var p = new AccessorLab.AnalizOtchet((int)t.noomer, t.fio,0, t.name_otd, (DateTime)t.data, 0, (int)t.tab_id);
                                            _lanalizotch3.Add(p);
                                        }
                                    }
                                }
                            }
                            gridControl3.DataSource = _lanalizotch3;
                        }
                    }
                    // this.gridControl1.DataSource = res0;
                }
               //FindNode1();
               //InitSQLData(textEdit1.Text, textEdit4.Text);
         
            }
        }
 
        #endregion
   
        private void LoadZapros()
        {
            if (Pdatevibstr.Length == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Вы не выбрали период для формирования отчета ??? ");
                return;
            }

            //Pdatevibstr = " 01/01/2010 00:00:00 - 05/30/2010 23:59:59";
            int? kol=0;
            var res11 = _dt.OTCHETPERIODM0(Pdatevibstr,ref kol );
            _analizList.Clear();
            _statb = new StatusProgresbar(Bounds) {Text = @"Загрузка данных с сервера"};
            treeList2.Nodes.Clear();
            if (kol != null) _statb.maxbar = (int)kol;
            _statb.stepbar = 1;
  
            foreach (var t in res11)
            {
                _statb.StartPosition = FormStartPosition.CenterScreen;
                _statb.Show();
                var am = new ANALIZMENU {Analiz_ID = (int) t.Analiz_ID, Analiz_Level = t.Analiz_Level};
                if (t.Parent_ID != null) am.Parent_ID = t.Parent_ID;
                else am.Parent_ID = 0;
                if (t.NAME != null) am.NAME = t.NAME;
                else am.NAME = "";
                if (t.TABINDEX != null) am.TABINDEX = t.TABINDEX;
                else am.TABINDEX = 0;
                if (t.TABLNAME != null) am.TABLNAME = t.TABLNAME;
                else am.TABLNAME = "";
                if (t.VIB != null) am.VIB = t.VIB;
                else am.VIB = false;
                if (t.colamb != null) am.colamb = t.colamb;
                else am.colamb = 0;
                if (t.colstac != null) am.colstac = t.colstac;
                else am.colstac = 0;
                _analizList.Add(am);
                _statb.ProgresBar.PerformStep();
                _statb.ProgresBar.Update();
            }
            _statb.maxbar = 0;
            _statb.Close();
            aNALIZMENUBindingSource.DataSource = _analizList;
            treeList2.DataSource = aNALIZMENUBindingSource;
            treeList2.ExpandAll();
        }

        private void SimpleButton1Click(object sender, EventArgs e)
        {
            LoadZapros();
            ClearFirstColamb();
            if (PselPromItog) ClearColambStac();

        }

        private void ClearFirstColamb()
        {
             _en = treeList2.Nodes.GetEnumerator();
            TreeListColumn colcolamb = treeList2.Columns["colamb"];
            TreeListColumn colcolstac = treeList2.Columns["colstac"];
            bool moveNext = _en.MoveNext();
            TreeListNode node1 = null;
            switch (moveNext)
            {
                case true:
                    if (_en.Current != null)   node1 = (TreeListNode)_en.Current;
                    break;
            }
            if (node1 != null)
            {
                node1.SetValue(colcolamb, "");
                node1.SetValue(colcolstac, "");
            }
        }

        private void ClearColambStac()
        {
            treeList2.Nodes.GetEnumerator();
            TreeListColumn colcolamb = treeList2.Columns["colamb"];
            TreeListColumn colcolstac = treeList2.Columns["colstac"];
            var operation = new TreeListExceedLimitOperation(colcolamb, colcolstac);
            treeList2.NodesIterator.DoOperation(operation);
        }

        public class TreeListExceedLimitOperation : TreeListOperation
        {
            private readonly TreeListColumn _colcolamb0;
            private readonly TreeListColumn _colcolstac0;
            public TreeListExceedLimitOperation(TreeListColumn colcolamb0, TreeListColumn colcolstac0)
            {
    
                _colcolamb0 = colcolamb0;
                _colcolstac0 = colcolstac0;
            }
            public override void Execute(TreeListNode node)
            {
                if (node.HasChildren)
                {
                    node.SetValue(_colcolamb0, "");
                    node.SetValue(_colcolstac0, "");
                }
            }
        }


//
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
                        datePeriodEdit3.Properties.OptionsSelection.MultiselectBehaviour = MultiselectBehaviour.Disabled;
                        datePeriodEdit3.Properties.OptionsSelection.ShowWeekLevel = false;
                        datePeriodEdit3.Properties.OptionsSelection.LowLevel = ViewLevel.Months;
                        datePeriodEdit3.Properties.OptionsSelection.HightLevel = ViewLevel.Years;
                        datePeriodEdit3.Properties.ShowWeekNumbers = false;
                    }
                    break;
                case 1:
                    {
                        datePeriodEdit3.Properties.OptionsSelection.MultiselectBehaviour = MultiselectBehaviour.Disabled;
                        datePeriodEdit3.Properties.OptionsSelection.ShowWeekLevel = false;
                        datePeriodEdit3.Properties.OptionsSelection.LowLevel = ViewLevel.Days;
                        datePeriodEdit3.Properties.OptionsSelection.HightLevel = ViewLevel.Years;
                        datePeriodEdit3.Properties.ShowWeekNumbers = false;
                    }
                    break;
                case 2:
                    {
                        datePeriodEdit3.Properties.OptionsSelection.MultiselectBehaviour = MultiselectBehaviour.Intersection;
                        datePeriodEdit3.Properties.OptionsSelection.ShowWeekLevel = false;
                        datePeriodEdit3.Properties.OptionsSelection.LowLevel = ViewLevel.Days;
                        datePeriodEdit3.Properties.OptionsSelection.HightLevel = ViewLevel.Years;
                        datePeriodEdit3.Properties.ShowWeekNumbers = false;
                        break;
                    }
            }
            //if (imageComboBoxEdit1.SelectedIndex == 0)
            //{
            //    datePeriodEdit2.Properties.OptionsSelection.MultiselectBehaviour = MultiselectBehaviour.Disabled;
            //    datePeriodEdit2.Properties.OptionsSelection.ShowWeekLevel = false;
            //    datePeriodEdit2.Properties.OptionsSelection.LowLevel = ViewLevel.Months;
            //    datePeriodEdit2.Properties.OptionsSelection.HightLevel = ViewLevel.Years;
            //    datePeriodEdit2.Properties.ShowWeekNumbers = false;
            //}
            //else
            //{
            //    datePeriodEdit2.Properties.OptionsSelection.MultiselectBehaviour = MultiselectBehaviour.Disabled;
            //    datePeriodEdit2.Properties.OptionsSelection.ShowWeekLevel = false;
            //    datePeriodEdit2.Properties.OptionsSelection.LowLevel = ViewLevel.Days;
            //    datePeriodEdit2.Properties.OptionsSelection.HightLevel = ViewLevel.Years;
            //    datePeriodEdit2.Properties.ShowWeekNumbers = false;
            //}

        }

      

        //private void treeList2_FilterNode(object sender, FilterNodeEventArgs e)
        //{
        //    if (PselFiltr)
        //    {
        //        if (Convert.ToInt32(e.Node[treeListColumn3]) == 0 && Convert.ToInt32(e.Node[treeListColumn1]) == 0)
        //        {
        //            e.Node.Visible = true;  // false;
        //            e.Handled = true;
        //        }
        //    }

        //}

        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox1.Checked) this.treeList2.OptionsBehavior.EnableFiltering = true;
        //    else  this.treeList2.OptionsBehavior.EnableFiltering = false;
        //    //treeList2.FilterConditions[0].Visible = !checkBox1.Checked;
        //    //treeList2.FilterConditions[1].Visible = !checkBox1.Checked;

        //}
        private void SetPrintingMargins()
        {
            var ps = new PrintingSystem();
            // Create a link that will print a control.
            _link = new PrintableComponentLink(ps) {Component = treeList2};
            // Specify the control to be printed.
            // Set the paper format.
            _link.CreateReportHeaderArea += PrintableComponentLink1CreateReportHeaderArea;
            _link.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            _link.Landscape = true;
            //link.Margins.Left = 15;
            //link.Margins.Right = 6;
            //link.Margins.Top = 10;
            //link.Margins.Bottom = 10;
        }
        private void SimpleButton3Click(object sender, EventArgs e)
        {
            // Generate the report.
            SetPrintingMargins();
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
            System.Diagnostics.Process.Start(strfile);
        }

        private void ToolStripMenuItem1Click(object sender, EventArgs e)
        {
            // Вывод на печать
          PeriodsSet res1=  PeriodsSet.Parse(Pdatevibstr);
          string str11 = res1.Periods[0].ToString();
       
             
            if (_kle != null)
            {
                if (_kle.NAME != null)
                {
                    //var frs1 = new FormRSView(str11, _kle.NAME);
                    //frs1.Show();
                    //Pdatevibstr
                }
            }
        }

        private void ToolStripMenuItem2Click(object sender, EventArgs e)
        {
            // Просмотр анализа
          //_dataSource1 = new BindingSource();
          //  _otch = (AccessorLab.AnalizOtchet)gridView1.GetRow(gridView1.FocusedRowHandle);
          //    if (_otch != null) _tablid1 = _otch.tab_id;
          //  else _tablid1 = 0;
          //  var clshowanaliz = new ClassShowAnalizForm {Labanalizc = _labanaliz};
          //  clshowanaliz.ShowCaseInFormAnaliz(_dataSource1, _tablid1, null, _kle, null, null);
        }

        private void ContextMenuStrip3Opening(object sender, CancelEventArgs e)
        {
            _dataSource1 = new BindingSource();
            _otch = (AccessorLab.AnalizOtchet)gridView2.GetRow(gridView2.FocusedRowHandle);
            _tablid1 = _otch != null ? _otch.tab_id : 0;
            var clshowanaliz = new ClassShowAnalizForm {Labanalizc = _labanaliz};
            clshowanaliz.ShowCaseInFormAnaliz(_dataSource1, _tablid1, null, _kle, null,null);
        }

        private void ToolStripMenuItem4Click(object sender, EventArgs e)
        {
            _dataSource1 = new BindingSource();
            _otch = (AccessorLab.AnalizOtchet)gridView3.GetRow(gridView3.FocusedRowHandle);
            _tablid1 = _otch != null ? _otch.tab_id : 0;
            var clshowanaliz = new ClassShowAnalizForm {Labanalizc = _labanaliz};
            clshowanaliz.ShowCaseInFormAnaliz(_dataSource1, _tablid1, null, _kle, null, null);
        }

      }
}