using System;
using System.Collections.Generic;
using AistLabData;

namespace AistLab.MainandLogin
{
    public partial class FormAnalizMenu : DevExpress.XtraEditors.XtraForm
    {
        readonly DataClassesLabDataContext _dt = new DataClassesLabDataContext();
        private readonly List<ANALIZMENU> _analizList = new List<ANALIZMENU>();

        public FormAnalizMenu()
        {
            InitializeComponent();
            FormMenuAnaliz();
        }
        #region «¿œŒÀÕ≈Õ»≈ œ–Œ¬ŒƒÕ» ¿ ¿Õ¿À»«Œ¬
        private void FormMenuAnaliz()
        {
            _analizList.Clear();
            // (Pfullmenuanaliz)
            var res = _dt.ANALIZMENU_GET2(3, 3);
            foreach (var t in res)
            {
                ANALIZMENU an = new ANALIZMENU();
                an.Analiz_ID = (int)t.Analiz_ID;
                an.Analiz_Level = t.Analiz_Level;
                an.NAME = t.NAME;
                an.Parent_ID = t.Parent_ID;
                an.TABINDEX = t.TABINDEX;
                an.VIBMENU = t.VIBMENU;
                _analizList.Add(an);
            }
            this.treeList1.RootValue = 3;
            this.treeList1.DataSource = _analizList;
            this.treeList1.ExpandAll();
        }
        #endregion

        private void SimpleButton1Click(object sender, EventArgs e)
        {
            foreach (var t in _analizList)
            {
                _dt.VVIB_ANALIZ(t.Analiz_ID, t.VIBMENU);
                _dt.VUPDATE_ANALIZ();
            }
        }
        /*
        #region –ÂÍÛÒË‚Ì‡ˇ ÔÓˆÂ‰Û‡
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