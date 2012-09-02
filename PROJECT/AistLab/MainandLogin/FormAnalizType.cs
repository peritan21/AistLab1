using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using AistLabData;

namespace AistLab.MainandLogin
{
    public partial class FormAnalizType : Form
    {
        readonly DataClassesLabDataContext _dt = new DataClassesLabDataContext();
        private readonly List<ANALIZMENU> _analizList = new List<ANALIZMENU>();
        private ANALIZMENU _kle;
        private int _lcTreeID;
        private int _lcTreeIDvurez;
        private TreeListNode  _trr;
        public FormAnalizType()
        {
            InitializeComponent();
            FormMenuAnaliz();
            lookUpEdit2.Properties.DataSource = _dt.GETMENUSOKR();
    
            //InitData();
        }
        #region ЗАПОЛНЕНИЕ ПРОВОДНИКА АНАЛИЗОВ
        private void FormMenuAnaliz()
        {
            _analizList.Clear();
            // (Pfullmenuanaliz)
            var res = _dt.ANALIZMENU_GET2(3, 3);
            //ANALIZList = res.ToList<ANALIZMENU>();
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
                                     VIBMENU = t.VIBMENU,
                                     TABLNAME = t.TABLNAME,
                                     TABL_ID = t.TABL_ID,
                                     analiz_sokr = t.analiz_sokr
                                 };
                    _analizList.Add(an);
                }
            }
            treeList1.RootValue = 3;
            aNALIZMENUBindingSource.DataSource = _analizList;
            treeList1.DataSource = aNALIZMENUBindingSource;
            //datasource0 = new BindingSource();
            //datasource0.DataSource = ANALIZList;
           
            //textEdit1.DataBindings.Add(new Binding("Text", datasource0, "analiz_sokr", true));
            treeList1.ExpandAll();

        }
        #endregion
  

        private void ToolStripMenuItem1Click(object sender, EventArgs e)
        {
            // Добавление корня
            var fg = new FormEditGroup1 {NameGroup = "", Text = @"Добавление заголовка меню", RTabIndex = "0"};
            if (DialogResult.OK == fg.ShowDialog())
            {
                var result = _dt.ANALIZMENU_AddNewR(fg.NameGroup, 0, int.Parse(fg.RTabIndex));
                foreach (var t in result)
                {
                    treeList1.AppendNode(
                        new object[] { t.Analiz_ID, t.Analiz_Level, t.Parent_ID, t.TABINDEX,  t.NAME }, null);
                    treeList1.FocusedNode["NAME"] = t.NAME;
                    treeList1.FocusedNode["TABINDEX"] = t.TABINDEX;
                    treeList1.Refresh();
                }
            }
        }

        private void ToolStripMenuItem2Click(object sender, EventArgs e)
        {
            // Добавление подраздела
               _trr = treeList1.FocusedNode;
            if (_trr != null)
            {
                _kle = (ANALIZMENU) aNALIZMENUBindingSource[treeList1.FocusedNode.Id];
                _lcTreeID = _kle.Analiz_ID;
                var fg = new FormEditGroup1 {Text = @"Добавление раздела для:  " + _kle.NAME};
                //fg.NameGroup = "";
                int fnodecount = _trr.Nodes.Count;
                fg.RTabIndex = fnodecount.ToString();
                if (DialogResult.OK == fg.ShowDialog())
                {
                    try
                    {
                        var result = _dt.ANALIZMENU_AddNewR(fg.NameGroup, _lcTreeID, int.Parse(fg.RTabIndex));

                        foreach (var t in result)
                        {
                            treeList1.AppendNode(new object[] {  t.Analiz_ID, t.Analiz_Level, t.Parent_ID, t.TABINDEX,  t.NAME}, 
                                treeList1.FocusedNode);   
                            //this.treeList1.MoveLast();
                            treeList1.FocusedNode["NAME"] = t.NAME;
                            treeList1.FocusedNode["TABINDEX"] = t.TABINDEX;
                            treeList1.Refresh();

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.Source);
                    }
                }
            }
  
        }

        private void ToolStripMenuItem3Click(object sender, EventArgs e)
        {
     
            // Редактирование выбранного пункта
            //TreeNodePlusKol tr = new TreeNodePlusKol();
            int ret;
            _trr= treeList1.FocusedNode;
            if (_trr != null)
            {
               _kle = (ANALIZMENU) aNALIZMENUBindingSource[treeList1.FocusedNode.Id];
                //kle = (ANALIZMENU)this.aNALIZMENUBindingSource.Current;
                _lcTreeID = _kle.Analiz_ID;
                var fg = new FormEditGroup1();
                fg.NameGroup = _kle.NAME;
                fg.RTabIndex = _kle.TABINDEX.ToString();
                fg.NameTable = _kle.TABLNAME;
                fg.NameKey = _kle.TABL_ID;

                fg.Text = @"Редактирование выделенной строки меню";
                if (DialogResult.OK == fg.ShowDialog())
                {
                    ret = _dt.ANALIZMENU_UpdateR(_lcTreeID, fg.NameGroup, 0, int.Parse(fg.RTabIndex), fg.NameTable,fg.NameKey);
                    if (ret == 0)
                    {
                        _kle.NAME = fg.NameGroup;
                        _kle.TABINDEX = int.Parse(fg.RTabIndex);
                        _kle.TABLNAME = fg.NameTable;
                        _kle.TABL_ID = fg.NameKey;
                        _trr["NAME"] = fg.NameGroup;
                    }
                }
            }
 

        }

        private void ToolStripMenuItem4Click(object sender, EventArgs e)
        {
            // Удаление
             _trr = treeList1.FocusedNode;
              if (_trr != null)
            {
                _kle = (ANALIZMENU) aNALIZMENUBindingSource[treeList1.FocusedNode.Id];
                _lcTreeID = _kle.Analiz_ID;
     
                if (MessageBox.Show(@"Вы хотите удалить раздел меню "+_kle.NAME+ @"  )",
                @"Сообщение", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    //Если была нажата  кнопка Yes, вызываем процедуру удаления пользователя
                    if (_lcTreeID > 0)
                    {
                        try
                        {
                            int lcret = _dt.ANALIZMENU_Delete(_lcTreeID);
                            if (lcret == 0)
                            {
                                treeList1.DeleteNode(_trr);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, ex.Source);
                        }
                    }
            }

        }
    
        private void TreeList1FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                _trr = e.Node;
                _kle = (ANALIZMENU) aNALIZMENUBindingSource[treeList1.FocusedNode.Id];
             //   kle = (ANALIZMENU)this.aNALIZMENUBindingSource[treeList1.FocusedNode.Id];
                _lcTreeID = _kle.Analiz_ID;
            }
        }

        private void ВырезатьToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Вырезать
            _lcTreeIDvurez = _kle.Analiz_ID;
            contextMenuStrip1.Items[4].Enabled = false;
            contextMenuStrip1.Items[5].Enabled = true;
        }

        private void ВставитьToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Вставить
            _lcTreeID = _kle.Analiz_ID;
            if (_lcTreeIDvurez > 0 && _lcTreeID>0)
            {
                _dt.ANALIZMENU_VUREZ(_lcTreeIDvurez, _lcTreeID);
                _lcTreeIDvurez = 0;
                _lcTreeID = 0;
                contextMenuStrip1.Items[5].Enabled = false;
                //datasource0.DataSource =null;
                treeList1.DataSource = null;
                FormMenuAnaliz();
                contextMenuStrip1.Items[4].Enabled = true;
            }
        }

        private void SimpleButton2Click(object sender, EventArgs e)
        {
            Close();
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
        public string Ploopfind
        {
            set { lookUpEdit2.EditValue = value; }
            get { return lookUpEdit2.EditValue.ToString(); }
        }
        public void FindNodeTreeForID(object lckey)
        {
            treeList1.BeginUpdate();
            try
            {
                treeList1.FocusedNode = treeList1.FindNodeByKeyID(lckey);
                treeList1.FocusedNode.Checked = true;
                treeList1.NodesIterator.DoOperation(new CollapseExceptSpecifiedOperation(treeList1.FocusedNode));
            }
            finally
            {
                treeList1.EndUpdate();
            }
        }
        #endregion

        private void LookUpEdit2EditValueChanged(object sender, EventArgs e)
        {
            FindNodeTreeForID(lookUpEdit2.EditValue);
        }

        private void SimpleButton1Click(object sender, EventArgs e)
        {
            //  Сохранить данные нстройки
            TreeListNode node = treeList1.FocusedNode;
            if (node.HasChildren)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Вы должны выбрать конкретный анализ, а не группу анализов ");
                return;
            }
            if (_kle != null)
            {
                int lcres = _dt.ANALIZSOKR_UPDATE(_kle.Analiz_ID, textEdit1.Text);
                if (lcres == 0)
                {
                    lookUpEdit2.Properties.DataSource = _dt.GETMENUSOKR();
                }
            }
        }

    }
}