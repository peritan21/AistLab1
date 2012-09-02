using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using DevExpress.XtraTreeList.Data;
using AistLabData;


namespace AistLab
{
    public partial class FrmAnalizOtchet1 : DevExpress.XtraEditors.XtraForm
    {
        
        private SqlConnection dpStr = new SqlConnection(AistLabData.Resource1.StringLab);
         DataView dv;
        private ANALIZOTCHET klo;
        private ANLOTCHET_TREE kle;
        private ANALIZMENU am;
        private ANALIZOTCHETFLD kl;
        private ANALIZOTCHLISTFLD klf;
        private DataClassesLabDataContext  dt = new DataClassesLabDataContext();
        private List<ANALIZMENU> ANALIZList = new List<ANALIZMENU>();
        private List<ANLOTCHET_TREE> ANALIZListTree = new List<ANLOTCHET_TREE>();
        private List<AccessorLab.Gemoliz> lgemoliz = new List<AccessorLab.Gemoliz>();
       private TreeListNode trr;
        private int lcTree_ID = 0;
        private int lcstroka_ID = 0;
        private bool flag_TextNode = false;   // выводить Charge_ID
        public FrmAnalizOtchet1()
        {
            InitializeComponent();
          InitSQLDataOtchet();
            FormMenuAnaliz();
        }
        #region РАБОТА С ТАБЛИЦЕЙ ЗАПИСЕЙ ОТЧЕТА
        public void InitSQLDataOtchet()
        {

             var res = (from c in dt.ANLOTCHET_TREEs select c);
            this.aNLOTCHETTREEBindingSource.DataSource = res;
            this.treeList2.DataSource = null;
            this.treeList2.DataSource = this.aNLOTCHETTREEBindingSource;
            this.treeList2.ExpandAll();
       }
  
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Добавление корня
            FormEditParOtchet fg = new FormEditParOtchet(this.aNLOTCHETTREEBindingSource);
            fg.PNameStr = "";
            fg.PNpunktOtchet = 0;
            fg.Pkolamb=0;
            fg.Pkolstac = 0;
            if (DialogResult.OK == fg.ShowDialog())
            {
                var result = dt.ANOTCHETTREE_AddNewR(fg.PNameStr, 0, 0, fg.PNpunktOtchet, fg.Pkolamb, fg.Pkolstac);
                foreach (var t in result)
                {
                    TreeListNode parentForRootNodes =null;
                    TreeListNode rootNode = this.treeList2.AppendNode(
                    new object[] { t.analizotch_id, t.Analiz_Level, t.Parent_ID, t.TABINDEX, t.Analiz_ID, t.NameStr,
                        t.NpunktOtchet,t.Uslivie,t.kolamb,t.kolstac}, parentForRootNodes);

                }
            }
        }
        private void treeList2_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
               trr = e.Node;
               FindNode1();
               InitSQLData(textEdit1.Text, textEdit4.Text);
         
            }
        }
        public class TreeListOperationFindNodeByProductAndCountryValues1 : TreeListOperation
        {
           //public const string ProductIDColumnName = "ID";
            public const string ProductIDColumnName = "Analiz_ID";
            private TreeListNode nodeCore;
            private object productIDCore;
            //private object countryIDCore;
            private bool isNullCore;
            public TreeListOperationFindNodeByProductAndCountryValues1(object productID)
            {
                this.productIDCore = productID;
                this.nodeCore = null;
                this.isNullCore = TreeListData.IsNull(productIDCore);
            }
            public override void Execute(TreeListNode node)
            {
                if (IsLookedFor(node.GetValue(ProductIDColumnName)))
                    this.nodeCore = node;
            }
            bool IsLookedFor(object productID)
            {
                if (IsNull) return (productIDCore == productID);
                return productIDCore.Equals(productID);
            }
            protected bool IsNull { get { return isNullCore; } }
            public override bool CanContinueIteration(TreeListNode node) { return Node == null; }
            public TreeListNode Node { get { return nodeCore; } }
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
            TreeListNode visibleNode;
            public CollapseExceptSpecifiedOperation(TreeListNode visibleNode)
                : base()
            {
                this.visibleNode = visibleNode;
            }
            public override void Execute(TreeListNode node)
            {
                if (!visibleNode.HasAsParent(node))
                    node.Expanded = false;
            }
            public override bool NeedsFullIteration
            { get { return false; } }
        }
        #endregion
        #region   Подсчет количества узлов на определенном уровне
        class CustomNodeOperation : TreeListOperation
        {
            int level;
            int nodeCount;
            public CustomNodeOperation(int level)
                : base()
            {
                this.level = level;
                this.nodeCount = 0;
            }
            public override void Execute(TreeListNode node)
            {
                if (node.Level == level)
                    nodeCount++;
            }
            public int NodeCount
            {
                get { return nodeCount; }
            }
        }
        #endregion

        private void FindNode1()
        {
            kle = (ANLOTCHET_TREE)this.aNLOTCHETTREEBindingSource[treeList2.FocusedNode.Id];
            if (kle != null)
            {
                if (kle.Analiz_ID != null)
                {
                    treeList1.FocusedNode = treeList1.FindNodeByKeyID(Convert.ToInt32(kle.Analiz_ID));
                 }
            }
    
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Добавление подраздела
            if (trr != null)
            {
                lcTree_ID = int.Parse(textEdit1.Text);
                FormEditParOtchet fg = new FormEditParOtchet(this.aNLOTCHETTREEBindingSource);
                fg.PNameStr = "";
                fg.PNpunktOtchet = 0;
                fg.Pkolamb = 0;
                fg.Pkolstac = 0;
                fg.Text = "Добавление раздела для:  " + trr.GetDisplayText(treeListColumn2);
                if (DialogResult.OK == fg.ShowDialog())
                {
                    var result = dt.ANOTCHETTREE_AddNewR(fg.PNameStr, lcTree_ID, 0, fg.PNpunktOtchet, fg.Pkolamb, fg.Pkolstac);
                   //this.treeList2.BeginUnboundLoad();
                    foreach (var t in result)
                    {
                        if (treeList2.FocusedNode != null)
                        {
                            this.treeList2.AppendNode(new object[] { t.analizotch_id, t.Analiz_Level, t.Parent_ID, 
                       t.TABINDEX, t.Analiz_ID, t.NameStr,
                        t.NpunktOtchet,t.Uslivie,t.kolamb,t.kolstac}, treeList2.FocusedNode);   //treeList2.FocusedNode
                            this.treeList2.MoveLast();
                        }
                    }
                    //this.treeList2.EndUnboundLoad();
                   this.treeList2.Refresh();
                }
            }
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // Редактирование выбранного Node
            if (trr != null)
            {
                lcTree_ID = int.Parse(textEdit1.Text);
                FormEditParOtchet fg = new FormEditParOtchet(this.aNLOTCHETTREEBindingSource);
                kle = (ANLOTCHET_TREE)this.aNLOTCHETTREEBindingSource[treeList2.FocusedNode.Id];
                fg.PNameStr= kle.NameStr ;
                fg.Pkolamb= (int)kle.kolamb;
                fg.Pkolstac=(int)kle.kolstac;
                 fg.PNpunktOtchet=(int)kle.NpunktOtchet; 
                fg.Text = "Редактирование:  " + trr.GetDisplayText(treeListColumn2);
                if (DialogResult.OK == fg.ShowDialog())
                {
                    var result = dt.ANLOTCHETTREE_UpdateR(lcTree_ID,fg.PNameStr, 0, fg.PNpunktOtchet, fg.Pkolamb, fg.Pkolstac);
                    kle.NameStr = fg.PNameStr;
                    kle.kolamb = fg.Pkolamb;
                    kle.kolstac = fg.Pkolstac;
                    kle.NpunktOtchet = fg.PNpunktOtchet;
                }
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            // Удаление выбранного Node
            if (trr != null)
            {
                if (MessageBox.Show("Вы хотите удалить раздел :  ( " + trr.GetDisplayText(treeListColumn2) + "  )",
                "Сообщение", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    //Если была нажата  кнопка Yes, вызываем процедуру удаления пользователя
                    lcTree_ID = int.Parse(textEdit1.Text);
                    if (lcTree_ID > 0)
                    {
                        try
                        {
                            int lcret = dt.ANLOTCHETTREE_Delete(lcTree_ID);
                            if (lcret == 0)
                            {
                                  if (treeList2.FocusedNode != null)  this.treeList2.DeleteNode(this.treeList2.FocusedNode);
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
            ANALIZList.Clear();
            DataClassesLabDataContext dk = new DataClassesLabDataContext();
            var res = dk.ANALIZMENU_GET2(3, 3);
            foreach (var t in res)
            {
                ANALIZMENU an = new ANALIZMENU();
                an.Analiz_ID = (int)t.Analiz_ID;
                an.Analiz_Level = t.Analiz_Level;
                an.NAME = t.NAME;
                an.Parent_ID = t.Parent_ID;
                an.TABINDEX = t.TABINDEX;
                an.VIBMENU = t.VIBMENU;
                ANALIZList.Add(an);
            }
            this.treeList1.RootValue = 3;
            this.aNALIZMENUBindingSource.DataSource = ANALIZList;
            this.treeList1.DataSource = this.aNALIZMENUBindingSource;
            //this.treeList1.ExpandAll();
        }
        #endregion
        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            lcTree_ID = 0;

            if (e.Node != null)
            {
                //bool bollc = int.TryParse(e.Node.GetDisplayText(AnalizIDcolumn), out lcTree_ID);
                //bool bollc = int.TryParse(e.Node.GetValue(AnalizIDcolumn), out lcTree_ID);
                InitSQLData(textEdit1.Text,this.textEdit4.Text);
            }
        }

        private void treeList1_Click(object sender, EventArgs e)
        {
           // if (lcTree_ID == 0) return;
            InitSQLData(textEdit1.Text, this.textEdit4.Text);

        }
        public void InitSQLData(string strstroka_ID, string strlcTree_ID)
        {
             DataClassesLabDataContext db = new DataClassesLabDataContext();
             bool  bollcstroka_ID = int.TryParse(strstroka_ID, out   lcstroka_ID);
             bool  bollcTree_ID = int.TryParse(strlcTree_ID, out lcTree_ID);
            var res = dt.ANALIZOTCHLISTFLD_GET(lcstroka_ID, lcTree_ID);
            this.aNALIZOTCHLISTFLDBindingSource.DataSource = res;
            this.gridControl1.DataSource = this.aNALIZOTCHLISTFLDBindingSource;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // Добавление выбора 
            AddListFLD();
        }

        private void AddListFLD()
        {
            int lcsel = treeList2.FocusedNode.Id;
            TreeListNode node1 = treeList2.FocusedNode;
            FrmANALIZFLD fa = new FrmANALIZFLD(this.aNLOTCHETTREEBindingSource, lcsel);
            // fa.PAnaliz_ID = lcTree_ID;
            //fa.Pstroka_ID = lcstroka_ID;
            fa.PAnaliz_ID = int.Parse(textEdit4.Text);
            fa.Pstroka_ID = int.Parse(textEdit1.Text);
            fa.INITSQL();
            if (DialogResult.OK == fa.ShowDialog())
            {
                InitSQLData(textEdit1.Text, textEdit4.Text);
                //InitSQLDataOtchet();
                //treeList2.NodesIterator.DoOperation(new CollapseExceptSpecifiedOperation(node1));
            }
        }

        private void kRSAHARGridControl_Click(object sender, EventArgs e)
        {
            SelStrOtchet();
        }

        private void SelStrOtchet()
        {
           // int sel = gridView1.FocusedRowHandle;
            int sel = 0;
          //  klo = (ANALIZOTCHET)this.aNALIZOTCHETBindingSource[sel];
            if (klo == null) return;
            lcstroka_ID = klo.analizotch_id;
            InitSQLData(textEdit1.Text, textEdit4.Text);
        }

        private void FrmAnalizOtchet0_Load(object sender, EventArgs e)
        {

        }

        private void kRSAHARGridControl_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            SelStrOtchet();
       }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DeleteListFLD();
        }

        private void DeleteListFLD()
        {
            // Удаление реквизита из определения строки для отчета
            int sel = gridView3.FocusedRowHandle;
            int lckl = 0;
            bool bollckl = int.TryParse(this.textEdit5.Text, out lckl);
            if ((DevExpress.XtraEditors.XtraMessageBox.Show("Вы хотите удалить запись по : " + gridView3.GetRowCellDisplayText(sel, gridColumn3), "Сообщения по редактированию  ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) == DialogResult.Yes)
            {
                if (lckl > 0)
                {
                    DataClassesLabDataContext db = new DataClassesLabDataContext();
                    var res = db.ANALIZOTCHLISTFLD_DEL(lckl);
                    gridView3.DeleteRow(sel);
                }
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            // Сохранить все изменения
            DataClassesLabDataContext db = new DataClassesLabDataContext();
            var res = db.CORR_ANALIZOTCHET();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            //DataClassesLabDataContext dt = new DataClassesLabDataContext();
            //var res = (from c in dt.ANALIZOTCHETs select c);
            //this.aNALIZOTCHETBindingSource.DataSource = res;
            //this.kRSAHARGridControl.DataSource = null;
            //this.kRSAHARGridControl.DataSource = this.aNALIZOTCHETBindingSource;
        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
           // am = (ANALIZMENU)this.aNALIZMENUBindingSource[treeList1.FocusedNode.Id];
            int lckle11 = int.Parse(textEdit4.Text);
            FrmAnalizOtchetFld faofld = new FrmAnalizOtchetFld(lckle11);
            faofld.Show();
        }

        private void свернутьВсеУзлыКромеВыбранногоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeList2.NodesIterator.DoOperation(new CollapseExceptSpecifiedOperation(treeList2.FocusedNode));
        }

     

     
    }
}