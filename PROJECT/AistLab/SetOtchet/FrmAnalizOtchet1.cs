using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using DevExpress.XtraTreeList.Data;
using AistLabData;
using CustomControlLib;

namespace AistLab.SetOtchet
{
    public partial class FrmAnalizOtchet1 : DevExpress.XtraEditors.XtraForm
    {private ANLOTCHET_TREE _kle;
        private DataClassesLabDataContext  _dt = new DataClassesLabDataContext();
        private AccessorLab.AnalizOtchetUsl _klusl;
        private readonly List<ANALIZMENU> _analizList = new List<ANALIZMENU>();
        private readonly List<AccessorLab.AnalizOtchetUsl> _lusl = new List<AccessorLab.AnalizOtchetUsl>();
        private TreeListNode _trr;
        private int _lcTreeID;
        private int _lcstrokaID;
        private  int _lcTreeIDvurez;

        public FrmAnalizOtchet1()
        {
           
            InitializeComponent();
          InitSQLDataOtchet();
          FormMenuAnaliz();
            PorAnd = false;
        }
        public bool PorAnd
        {
            set { radioGroup1.EditValue = value; }
            get { return bool.Parse(radioGroup1.EditValue.ToString()); }

        }
        #region РАБОТА С ТАБЛИЦЕЙ ЗАПИСЕЙ ОТЧЕТА
        public void InitSQLDataOtchet()
        {
             //this.aNLOTCHETTREEBindingSource.DataSource = null;
            //ANALIZListTree.Clear();
            _dt = new DataClassesLabDataContext();
             var res = (from c in _dt.ANLOTCHET_TREEs orderby c.NpunktOtchet  select c);
             //ANALIZListTree = res.ToList<ANLOTCHET_TREE>();
             aNLOTCHETTREEBindingSource.DataSource = res;
             //this.treeList2.DataSource = null;
            treeList2.DataSource = aNLOTCHETTREEBindingSource;
            treeList2.ExpandAll();
       }
  
        private void ToolStripMenuItem1Click(object sender, EventArgs e)
        {
            // Добавление корня
            var fg = new FormEditParOtchet(aNLOTCHETTREEBindingSource)
                         {PNameStr = "", PNpunktOtchet = 0, Pkolamb = 0, Pkolstac = 0};
            if (DialogResult.OK == fg.ShowDialog())
            {
                var result = _dt.ANOTCHETTREE_AddNewR(fg.PNameStr, 0, 0, fg.PNpunktOtchet, fg.Pkolamb, fg.Pkolstac);
                foreach (var t in result)
                {
                    treeList2.AppendNode(
                        new object[] { t.analizotch_id, t.Analiz_Level, t.Parent_ID, t.TABINDEX, t.Analiz_ID, t.NameStr,
                                       t.NpunktOtchet,t.Uslivie,t.kolamb,t.kolstac}, null);
                }
                InitSQLDataOtchet();
            }
        }
        private void TreeList2FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
               _trr = e.Node;
               FindNode1();
               //InitSQLData(textEdit1.Text, textEdit4.Text);
              // InitSQLData(kle.analizotch_id.ToString(), textEdit4.Text);
         
            }
        }
        public class TreeListOperationFindNodeByProductAndCountryValues1 : TreeListOperation
        {
           //public const string ProductIDColumnName = "ID";
            public const string ProductIDColumnName = "Analiz_ID";
            private TreeListNode _nodeCore;
            private readonly object _productIDCore;
            //private object countryIDCore;
            private readonly bool _isNullCore;
            public TreeListOperationFindNodeByProductAndCountryValues1(object productID)
            {
                _productIDCore = productID;
                _nodeCore = null;
                _isNullCore = TreeListData.IsNull(_productIDCore);
            }
            public override void Execute(TreeListNode node)
            {
                if (IsLookedFor(node.GetValue(ProductIDColumnName)))
                    _nodeCore = node;
            }
            bool IsLookedFor(object productID)
            {
                if (IsNull) return (_productIDCore == productID);
                return _productIDCore.Equals(productID);
            }
            protected bool IsNull { get { return _isNullCore; } }
            public override bool CanContinueIteration(TreeListNode node) { return Node == null; }
            public TreeListNode Node { get { return _nodeCore; } }
        }
        #region   Сворачивание не родительских узлов
        ///*  treeList1.NodesIterator.DoOperation(new CollapseExceptSpecifiedOperation(treeList1.FocusedNode));
        // В следующем примере показано, как создать операции класса, 
        //  который будет сворачивать все узлы, 
        //  которые не содержат указанный узел, как своего потомка.
        //  Только родители узла будут раскрыты в результате.
        // */
        public class CollapseExceptSpecifiedOperation : TreeListOperation
        {
            readonly TreeListNode _visibleNode;
            public CollapseExceptSpecifiedOperation(TreeListNode visibleNode)
            {
                _visibleNode = visibleNode;
            }
            public override void Execute(TreeListNode node)
            {
                if (!_visibleNode.HasAsParent(node))
                    node.Expanded = false;
            }
            public override bool NeedsFullIteration
            { get { return false; } }
        }
        #endregion
        #region   Подсчет количества узлов на определенном уровне

        #endregion

        private void FindNode1()
        {
            _kle = (ANLOTCHET_TREE)aNLOTCHETTREEBindingSource[treeList2.FocusedNode.Id];
            if (_kle != null)
            {
                if (_kle.Analiz_ID != null)
                {
                    TreeListNode node1 = treeList2.FocusedNode;
                    //treeList1.FocusedNode = treeList1.FindNodeByKeyID(Convert.ToInt32(kle.Analiz_ID));
                    if (!node1.HasChildren)   LoadAnalizOtchetUsl();
                 
                    //VivodRekvizitov();
                 }
            }
    
        }

        private void LoadAnalizOtchetUsl()
        {
            int lcusl = 0;
            int i = 0;
                _lusl.Clear();
                var resusl = from c in _dt.ANALOTCHET_USLs
                             join p in _dt.ANALIZMENUs on c.Analiz_ID equals p.Analiz_ID
                             where c.analizotch_id == _kle.analizotch_id
                             select new { c.analotchetusl_id, c.analizotch_id, p.Analiz_ID, p.NAME, c.Uslivie };
                foreach (var t in resusl)
                {
                    if (i == 0) lcusl = t.analotchetusl_id;
                    _lusl.Add(new AccessorLab.AnalizOtchetUsl(t.analotchetusl_id, (int)t.analizotch_id, t.Analiz_ID, t.NAME, t.Uslivie));
                    i++;
                }
                AnalizUslbindingSource.DataSource = _lusl;
                gridControl2.DataSource = null;
                gridControl2.DataSource = AnalizUslbindingSource;
                //int sel = gridView1.FocusedRowHandle;
                //klusl = (AccessorLab.AnalizOtchetUsl)gridView1.GetRow(sel);
                InitSQLData(lcusl.ToString(), textEdit4.Text);
           
        }
        private void ToolStripMenuItem2Click(object sender, EventArgs e)
        {
            // Добавление подраздела
            if (_trr != null)
            {
                _lcTreeID = _kle.analizotch_id;   // int.Parse(textEdit1.Text);
                var fg = new FormEditParOtchet(aNLOTCHETTREEBindingSource)
                             {
                                 PNameStr = "",
                                 PNpunktOtchet = 0,
                                 Pkolamb = 0,
                                 Pkolstac = 0,
                                 Text = @"Добавление раздела для:  " + _trr.GetDisplayText(treeListColumn2)
                             };
                if (DialogResult.OK == fg.ShowDialog())
                {
                    var result = _dt.ANOTCHETTREE_AddNewR(fg.PNameStr, _lcTreeID, 0, fg.PNpunktOtchet, fg.Pkolamb, fg.Pkolstac);
                   //this.treeList2.BeginUnboundLoad();
                    foreach (var t in result)
                    {
                        int lcTreeIDnew = t.analizotch_id;
                        if (treeList2.FocusedNode != null)
                        {
                            treeList2.AppendNode(new object[] { t.analizotch_id, t.Analiz_Level, t.Parent_ID, 
                       t.TABINDEX, t.Analiz_ID, t.NameStr,
                        t.NpunktOtchet,t.Uslivie,t.kolamb,t.kolstac}, treeList2.FocusedNode);   //treeList2.FocusedNode
                           // this.treeList2.MoveLast();
                            InitSQLDataOtchet();
                            treeList2.FocusedNode = treeList2.FindNodeByKeyID(lcTreeIDnew);
                            treeList2.NodesIterator.DoOperation(new CollapseExceptSpecifiedOperation(treeList2.FocusedNode));
                        }
                    }
                    //this.treeList2.EndUnboundLoad();
                 //  this.treeList2.Refresh();
                   // InitSQLDataOtchet();
                    //treeList2.FocusedNode = treeList2.FindNodeByKeyID(lcTreeIDnew);
                    //treeList2.NodesIterator.DoOperation(new CollapseExceptSpecifiedOperation(treeList2.FocusedNode));
                }
            }
        }
        private void ToolStripMenuItem3Click(object sender, EventArgs e)
        {
            // Редактирование выбранного Node
            if (_trr != null)
            {
                _lcTreeID = _kle.analizotch_id;   // int.Parse(textEdit1.Text);
                var fg = new FormEditParOtchet(aNLOTCHETTREEBindingSource);
                _kle = (ANLOTCHET_TREE)aNLOTCHETTREEBindingSource[treeList2.FocusedNode.Id];
                fg.PNameStr= _kle.NameStr ;
                if (_kle.kolamb != null) fg.Pkolamb= (int)_kle.kolamb;
                if (_kle.kolstac != null) fg.Pkolstac=(int)_kle.kolstac;
                if (_kle.NpunktOtchet != null) fg.PNpunktOtchet=(int)_kle.NpunktOtchet;
                //fg.PNameID = kle.TABL_ID;
                fg.Text = @"Редактирование:  " + _trr.GetDisplayText(treeListColumn2);
                if (DialogResult.OK == fg.ShowDialog())
                {
                    _dt.ANLOTCHETTREE_UpdateR(_lcTreeID, fg.PNameStr, 0, fg.PNpunktOtchet, fg.Pkolamb, fg.Pkolstac, "");
                    _kle.NameStr = fg.PNameStr;
                    _kle.kolamb = fg.Pkolamb;
                    _kle.kolstac = fg.Pkolstac;
                    _kle.NpunktOtchet = fg.PNpunktOtchet;
                    InitSQLDataOtchet();
                }
            }
        }

        private void ToolStripMenuItem4Click(object sender, EventArgs e)
        {
            // Удаление выбранного Node
            if (_trr != null)
            {
                if (MessageBox.Show(@"Вы хотите удалить раздел :  ( " + _trr.GetDisplayText(treeListColumn2) + @"  )",
                @"Сообщение", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    //Если была нажата  кнопка Yes, вызываем процедуру удаления пользователя
                    _lcTreeID = _kle.analizotch_id;    // int.Parse(textEdit1.Text);
                    if (_lcTreeID > 0)
                    {
                        try
                        {
                            int lcret = _dt.ANLOTCHETTREE_Delete(_lcTreeID);
                            if (lcret == 0)
                            {
                                  if (treeList2.FocusedNode != null)  treeList2.DeleteNode(treeList2.FocusedNode);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, ex.Source);
                        }
                    }
            }
        }

        #endregion
     
  
        #region ЗАПОЛНЕНИЕ ПРОВОДНИКА АНАЛИЗОВ

        private void FormMenuAnaliz()
        {
            //InitSQLData1("[ANALIZMENU]");
            _analizList.Clear();
            var dk = new DataClassesLabDataContext();
            var res = dk.ANALIZMENU_GET2(3, 3);
            foreach (var t in res)
            {
                if (t.Analiz_ID != null)
                {
                    var an = new ANALIZMENU
                                 {
                                     Analiz_ID = (int) t.Analiz_ID,
                                     Analiz_Level = t.Analiz_Level,
                                     NAME = t.NAME,
                                     Parent_ID = t.Parent_ID,
                                     TABINDEX = t.TABINDEX,
                                     VIBMENU = t.VIBMENU
                                 };
                    _analizList.Add(an);
                }
            }
            //this.treeList1.RootValue = 3;
            //this.aNALIZMENUBindingSource.DataSource = ANALIZList;
            //this.treeList1.DataSource = this.aNALIZMENUBindingSource;
            //this.treeList1.ExpandAll();
        }
        #endregion
        //private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        //{
        //    lcTree_ID = 0;

        //    if (e.Node != null)
        //    {
        //        //bool bollc = int.TryParse(e.Node.GetDisplayText(AnalizIDcolumn), out lcTree_ID);
        //        //bool bollc = int.TryParse(e.Node.GetValue(AnalizIDcolumn), out lcTree_ID);
        //        kle = (ANLOTCHET_TREE)this.aNLOTCHETTREEBindingSource[treeList2.FocusedNode.Id];
        //        InitSQLData(kle.analizotch_id.ToString(),this.textEdit4.Text);
        //    }
        //}

        //private void treeList1_Click(object sender, EventArgs e)
        //{
        //   // if (lcTree_ID == 0) return;
        //    InitSQLData(kle.analizotch_id.ToString(), this.textEdit4.Text);

        //}
        public void InitSQLData(string strstrokaID, string strlcTreeID)
        {
             //DataClassesLabDataContext db = new DataClassesLabDataContext();
             int.TryParse(strstrokaID, out   _lcstrokaID);
             int.TryParse(strlcTreeID, out _lcTreeID);
           // var res = dt.ANALIZOTCHLISTFLD_GET(lcstroka_ID, lcTree_ID);
             var res = _dt.ANALIZOTCHLISTFLDUSL_GET(_lcstrokaID, _lcTreeID);
             aNALIZOTCHLISTFLDBindingSource.DataSource = res;
             gridControl1.DataSource = aNALIZOTCHLISTFLDBindingSource;
        }

        private void ToolStripButton2Click(object sender, EventArgs e)
        {
            // Добавление выбора 
            AddListFLD();
        }

        private void AddListFLD()
        {
            int sel = gridView1.FocusedRowHandle;
            _klusl = (AccessorLab.AnalizOtchetUsl)gridView1.GetRow(sel);
            var fa = new FrmANALIZFLD
                         {
                             PstrokaID = _klusl.analotchetusl_id,
                             PanalizotchID = _klusl.analizotch_id,
                             PAnalizID = _klusl.Analiz_ID,
                             PorAndh = PorAnd
                         };

            // fa.PAnaliz_ID = lcTree_ID;
            // lcstroka_ID;
            // int.Parse(textEdit4.Text);
            //fa.Pstroka_ID = klusl.analizotch_id;   // int.Parse(textEdit1.Text);
            fa.INITSQL();
            if (DialogResult.OK == fa.ShowDialog())
            {
                InitSQLData(_klusl.analotchetusl_id.ToString(), textEdit4.Text);
                LoadAnalizOtchetUsl();
                //treeList2.NodesIterator.DoOperation(new CollapseExceptSpecifiedOperation(node1));
            }
        }


        private void SimpleButton2Click(object sender, EventArgs e)
        {
            DeleteListFLD();
        }

        private void DeleteListFLD()
        {
            // Удаление реквизита из определения строки для отчета
            int sel = gridView3.FocusedRowHandle;
            //klfusl = (ANALIZOTCHLISTFLDUSL)gridView3.GetRow(sel);
            int lckl;
            int.TryParse(textEdit5.Text, out lckl);
            if ((DevExpress.XtraEditors.XtraMessageBox.Show("Вы хотите удалить запись по : " + gridView3.GetRowCellDisplayText(sel, gridColumn3), "Сообщения по редактированию  ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) == DialogResult.Yes)
            {
                if (lckl > 0)
                {
                    var db = new DataClassesLabDataContext();
                    db.ANALIZOTCHLISTFLDUSL_DEL(lckl);
                    gridView3.DeleteRow(sel);
                    //LoadAnalizOtchetUsl();
                    //UPDATEUSLOVIE();
                }
            }
        }


        private void SimpleButton3Click1(object sender, EventArgs e)
        {
            Close();
        }

        private void SimpleButton4Click(object sender, EventArgs e)
        {
           // am = (ANALIZMENU)this.aNALIZMENUBindingSource[treeList1.FocusedNode.Id];
            int lckle11 = _klusl.Analiz_ID;   // int.Parse(textEdit4.Text);
            var faofld = new FrmAnalizOtchetFld(lckle11);
            faofld.Show();
        }

        private void СвернутьВсеУзлыКромеВыбранногоToolStripMenuItemClick(object sender, EventArgs e)
        {
            treeList2.NodesIterator.DoOperation(new CollapseExceptSpecifiedOperation(treeList2.FocusedNode));
        }

        private void СохранитьИзмененияToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Сохранить изменения
            Validate();
            try
            {
                _dt.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException)
            {
            }
        }

        private void ВырезатьToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Вырезать
            _lcTreeIDvurez = _kle.analizotch_id; // int.Parse(textEdit1.Text);
            _lcTreeID = _kle.analizotch_id;
            contextMenuStrip1.Items[6].Enabled = false;
            contextMenuStrip1.Items[7].Enabled = true;
        }

        private void ВставитьToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Вставить
            //TreeListNode node11 = treeList2.FocusedNode;
            _lcTreeID = _kle.analizotch_id;  // int.Parse(textEdit1.Text);  
            if (_lcTreeIDvurez > 0 && _lcTreeID > 0)
            {
                _dt.ANLOTCHET_TREE_VUREZ(_lcTreeIDvurez, _lcTreeID);
                _lcTreeIDvurez = 0;
                _lcTreeID = 0;
                contextMenuStrip1.Items[7].Enabled = false;
                //aNLOTCHETTREEBindingSource.DataSource = null;
                treeList2.DataSource = null;
                InitSQLDataOtchet();
                contextMenuStrip1.Items[6].Enabled = true;
                treeList2.FocusedNode = treeList2.FindNodeByKeyID(Convert.ToInt32(_lcTreeIDvurez));
                treeList2.NodesIterator.DoOperation(new CollapseExceptSpecifiedOperation(treeList2.FocusedNode));
            }
        }

        private void SimpleButton5Click(object sender, EventArgs e)
        {
            // Обновить условие
            UPDATEUSLOVIE();
        }

        private void UPDATEUSLOVIE()
        {
            string strusl = "";
            string strus2 = "";
            string strorand = " AND ";
            if (PorAnd == false) strorand = " OR ";
            else strorand = " AND ";
            var res = from c in _dt.ANALIZOTCHLISTFLDUSLs
                      join p in _dt.ANALIZOTCHETFLDs on c.analizrekv_id equals p.analizrekv_id
                      where c.analotchetusl_id == _klusl.analotchetusl_id
                      select new { p.znachpusto, p.namefield };
            foreach (var t in res)
            {
                switch (t.znachpusto)
                {
                    case 0:
                        strus2 = " m." + t.namefield + " >0 ";
                        break;
                    case 1:
                        strus2 = " m." + t.namefield + " IS NOT NULL ";
                        break;
                    case 2:
                        strus2 = " LEN(" + "m." + t.namefield + ")>0 ";
                        break;
                }
                strusl = strusl + strorand + strus2;
            }
            //if (PorAnd == false) strusl = "  AND ( " + strusl + " )";
            if (!PorAnd) strusl = "  AND ( " + strusl.Substring(5) + " )";
            int intres2 = _dt.ANALIZOTCHETUSL_UpdUsl(_klusl.analotchetusl_id, _klusl.Analiz_ID, strusl);
            if (intres2 == 0) DevExpress.XtraEditors.XtraMessageBox.Show("Условие успешно обновлено");
            treeList2.DataSource = null;
            InitSQLDataOtchet();
        }

        private void ToolStripMenuItem5Click(object sender, EventArgs e)
        {
            // Добавление анализа для строки отчета
            var fmavib = new FrmAnalizMenuVib {ANALIZListh = _analizList};
            fmavib.InitAnalizMenu();
            if (DialogResult.OK == fmavib.ShowDialog())
            {
                foreach (var t in  fmavib.ANALIZListvib)
                {
                    _dt.ANALOTCHET_USL_Updadd(null, _kle.analizotch_id, t.Analiz_ID, "");
                }
                LoadAnalizOtchetUsl();
            }
        }

        private void GridControl2Click(object sender, EventArgs e)
        {
            VivodRekvizitov();
        }

        private void VivodRekvizitov()
        {
            int sel = gridView1.FocusedRowHandle;
            _klusl = (AccessorLab.AnalizOtchetUsl)gridView1.GetRow(sel);
            if (_klusl != null)
            {
                var res = _dt.ANALIZOTCHLISTFLDUSL_GET(_klusl.analotchetusl_id, _klusl.Analiz_ID);
                aNALIZOTCHLISTFLDBindingSource.DataSource = res;
                gridControl1.DataSource = aNALIZOTCHLISTFLDBindingSource;
            }
        }

        private void ПросмотрУсловияToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Просмотр условия
            int sel = gridView1.FocusedRowHandle;
            _klusl = (AccessorLab.AnalizOtchetUsl)gridView1.GetRow(sel);
            var f1 = new FrmViewUsl {PNameStr = _klusl.NAME, PNameStrUsl = _klusl.Uslivie};
            if (DialogResult.OK == f1.ShowDialog())
            {
            }
        }

        private void УдалениеToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Удаление строки условия
            int rescount;
            int sel = gridView1.FocusedRowHandle;
            _klusl = (AccessorLab.AnalizOtchetUsl)gridView1.GetRow(sel);
            var res1 = (from c in _dt.ANALIZOTCHLISTFLDUSLs where c.analotchetusl_id == _klusl.analotchetusl_id select c);
            rescount = res1.Count();
             if (rescount > 0)
             {
                 DevExpress.XtraEditors.XtraMessageBox.Show("Удаление невозможно есть список реквизитов");
                 return;
             }
            _dt.ANALOTCHET_USLDel(_klusl.analotchetusl_id);
            LoadAnalizOtchetUsl();

        }

     
    }
}