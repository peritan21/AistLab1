using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using AistLabData;
using CustomControlLib;

namespace AistLab.SetOtchet
{
    public partial class FrmAnalizOtchetFld : DevExpress.XtraEditors.XtraForm
    {
        private ANALIZMENU _am;
        private ANALIZOTCHETFLD _kl; 
        private  DataClassesLabDataContext _dt ;
        private readonly List<ANALIZMENU> _analizList = new List<ANALIZMENU>();
        private readonly List<AccessorLab.Gemoliz> _lgemoliz = new List<AccessorLab.Gemoliz>();
        private int _lcTreeID;
        private readonly int _klsetnode;
        public FrmAnalizOtchetFld(int klfokusnode)
        {
            _lgemoliz.Add(new AccessorLab.Gemoliz(0, "> 0"));
            _lgemoliz.Add(new AccessorLab.Gemoliz(1, "Не пусто"));
            _lgemoliz.Add(new AccessorLab.Gemoliz(2, "Длина строки >0"));
            InitializeComponent();
            _klsetnode = klfokusnode;
            FormMenuAnaliz();
   
        }
        #region ЗАПОЛНЕНИЕ ПРОВОДНИКА АНАЛИЗОВ
        private void FormMenuAnaliz()
        {
            _analizList.Clear();
            _dt = new DataClassesLabDataContext();
            var res = _dt.ANALIZMENU_GET2(3, 3);
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
            treeList1.RootValue = 3;
            treeList1.DataSource = _analizList;
            treeList1.ExpandAll();
            treeList1.FocusedNode = treeList1.FindNodeByKeyID(_klsetnode );
           // this.treeList1.FocusedNode = this.treeList1.FindNodeByKeyID(Convert.ToInt32(klsetnode.ToString()));
          //this.treeList1.NodesIterator.DoOperation(new CollapseExceptSpecifiedOperation(treeList1.FocusedNode));
        }
        #endregion
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

        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            // Добавление строк для отчета
            int sel = gridView1.FocusedRowHandle;
            _kl = (ANALIZOTCHETFLD)gridView1.GetRow(sel);
            _kl.Analiz_ID = _lcTreeID;
            _kl.namefield = "";
            _kl.namefldru = "";
            _kl.znachpusto = 0;
    
        }

     
        private void KRgemolizBindingNavigatorSaveItemClick(object sender, EventArgs e)
        {
            // Сохранение данных
            TablFormUpdate();
        }

        private void TablFormUpdate()
        {
            Validate();
            _dt.SubmitChanges();
        }

        private void TreeList1FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            _lcTreeID = 0;
          
            if (e.Node != null)
            {
                _am = _analizList[treeList1.FocusedNode.Id];
                _lcTreeID = _am.Analiz_ID;
               //bool bollc =int.TryParse(e.Node.GetDisplayText(treeListColumn2),out lcTree_ID) ;
               InitSQLData();
            }
        }

        private void TreeList1Click(object sender, EventArgs e)
        {
            if (_lcTreeID == 0) return;
            InitSQLData();

        }
        public void InitSQLData()
        {
            _dt = new DataClassesLabDataContext();
            var res = (from c in _dt.ANALIZOTCHETFLDs where c.Analiz_ID ==  _lcTreeID select c);
            aNALIZOTCHETFLDBindingSource.DataSource = res;
            kRSAHARGridControl.DataSource = aNALIZOTCHETFLDBindingSource;
            repositoryItemLookUpEdit2.DataSource = _lgemoliz;
        }
 
 


    }
}