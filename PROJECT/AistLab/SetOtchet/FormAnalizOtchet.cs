using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AistLabData;

namespace AistLab.SetOtchet
{
    public partial class FormAnalizOtchet : DevExpress.XtraEditors.XtraForm
    {
        private ANALIZOTCHET _kl; 
        private  DataClassesLabDataContext _dt ;
        private readonly List<ANALIZMENU> _analizList = new List<ANALIZMENU>();
        private int _lcTreeID;

        public FormAnalizOtchet()
        {
            InitializeComponent();
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
        }
        #endregion


        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            // Добавление строк для отчета
            int sel = gridView1.FocusedRowHandle;
            _kl = (ANALIZOTCHET)gridView1.GetRow(sel);
            _kl.Analiz_ID = _lcTreeID;
            var frm = new FormEditParOtchet(aNALIZOTCHETBindingSource);
            // frm.Parent = this;
            if (DialogResult.OK == frm.ShowDialog())
            {
                aNALIZOTCHETBindingSource.EndEdit();
                TablFormUpdate();
            }
            else gridView1.DeleteRow(sel);
        }

        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            // Редактирование
            int sel = gridView1.FocusedRowHandle;
            _kl = (ANALIZOTCHET)aNALIZOTCHETBindingSource[sel];
            if (_kl == null) return;
            var frm = new FormEditParOtchet(aNALIZOTCHETBindingSource);
             if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else aNALIZOTCHETBindingSource.CancelEdit();
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
               int.TryParse(e.Node.GetDisplayText(treeListColumn2),out _lcTreeID);
              // if (!bollc) return;
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
            var res = (from c in _dt.ANALIZOTCHETs where c.Analiz_ID ==  _lcTreeID select c);
            aNALIZOTCHETBindingSource.DataSource = res;
            kRSAHARGridControl.DataSource = aNALIZOTCHETBindingSource;
        }
        /*
        #region Рекурсивная процедура
        private void RecurTree(System.Windows.Forms.TreeView TreeView, TreeNodePlusKol parentNode, int TopNode, List<ANALIZMENU> HierarchyCollecton)
        {

            int lcNodeId = 0;
            int lcPRIZNAK = 0;
            int lcTabindex = 0;
            string lcNameN = "";
             for (int intTemp = 0; intTemp <= HierarchyCollecton.Count - 1; intTemp++)
            {
                if (HierarchyCollecton[intTemp].Parent_ID == TopNode)
                {
                    lcNodeId = HierarchyCollecton[intTemp].Analiz_ID;
                    lcNameN = HierarchyCollecton[intTemp].NAME;
                    lcTabindex = (int)HierarchyCollecton[intTemp].TABINDEX;
                  TreeNodePlusKol tmpNode = new TreeNodePlusKol();
                    tmpNode.NodeId = lcNodeId;
                    if (flag_TextNode)
                    {
                        tmpNode.Text = ": " + lcNodeId.ToString() + "  : " + lcNameN;
                    }
                    else
                    {
                        tmpNode.Text = lcNameN;
                    }
                    tmpNode.NodeName = lcNameN;
                    tmpNode.NodePRIZNAK = lcPRIZNAK;
                    tmpNode.NodeRTabIndex = lcTabindex;
                   //  tmpNode.ImageIndex = SelectImageN;
                    RecurTree(TreeView, tmpNode, HierarchyCollecton[intTemp].Analiz_ID, HierarchyCollecton);
                    if (parentNode == null)
                    {
                        TreeView.Nodes.Add(tmpNode);
                    }
                    else
                    {
                        parentNode.Nodes.Add(tmpNode);
                    }
                }
            }
        }
        #endregion
        private void FormTreeMenu()
        {
    
                var resroot = (from c in dt.ANALIZMENUs where c.Analiz_Level == 0  select c);
                this.treeViewDoc.Nodes.Clear();
                 foreach (var i in resroot)
                {
                    TreeNodePlusKol tv = new TreeNodePlusKol();
                    tv.Text = i.NAME;
                    tv.NodeName = i.NAME;  
                    tv.NodeId = i.Analiz_ID;
                    this.treeViewDoc.Nodes.Add(tv);
                    var TreeDoc = dt.ANALIZMENU_GET(i.Analiz_ID, 8);
                    VChargeList.Clear();
                    foreach (var t in TreeDoc)
                    {
                        ANALIZMENU vc = new ANALIZMENU();
                        vc.Analiz_ID = (int)t.Analiz_ID;
                        vc.Analiz_Level = t.Analiz_Level;
                        vc.NAME = t.NAME;
                        vc.Parent_ID = (int)t.Parent_ID;
                        vc.TABINDEX = (int)t.TABINDEX;

                        VChargeList.Add(vc);
                    }

                    RecurTree(this.treeViewDoc, tv, i.Analiz_ID, VChargeList);
                }
         
           
   
        }
        */
 


    }
}