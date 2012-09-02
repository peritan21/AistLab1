using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AistLab
{
    public partial class FrmAnalizOtchet0 : DevExpress.XtraEditors.XtraForm
    {
        private ANALIZOTCHET klo;
        private ANALIZMENU am;
        private ANALIZOTCHETFLD kl;
        private ANALIZOTCHLISTFLD klf;
        private DataClassesLabDataContext  dt = new DataClassesLabDataContext();
        private List<ANALIZMENU> ANALIZList = new List<ANALIZMENU>();
        private List<AccessorLab.Gemoliz> lgemoliz = new List<AccessorLab.Gemoliz>();
        private int lcTree_ID = 0;
        private int lcstroka_ID = 0;
        private bool flag_TextNode = false;   // выводить Charge_ID
        public FrmAnalizOtchet0()
        {
            InitializeComponent();
           InitSQLDataOtchet();
            FormMenuAnaliz();
        }
        #region РАБОТА С ТАБЛИЦЕЙ ЗАПИСЕЙ ОТЧЕТА
        public void InitSQLDataOtchet()
        {
            var res = (from c in dt.ANALIZOTCHETs select c);
            this.aNALIZOTCHETBindingSource.DataSource = res;
            this.kRSAHARGridControl.DataSource = this.aNALIZOTCHETBindingSource;
        }
        private void kRGEMOLIZBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            // Сохранение данных
            TablFormUpdate();
        }
        private void TablFormUpdate()
        {
            //dt = new DataClassesLabDataContext();
            this.Validate();
            dt.SubmitChanges();
        }
        private void bindingNavigatorAddNewItem_Click_1(object sender, EventArgs e)
        {
            // Добавление в таблицу записей отчета
            int sel = gridView1.FocusedRowHandle;
            klo = (ANALIZOTCHET)gridView1.GetRow(sel);
            klo.Analiz_ID = lcTree_ID;
            FormEditParOtchet frm = new FormEditParOtchet(this.aNALIZOTCHETBindingSource);
            // frm.Parent = this;
            if (DialogResult.OK == frm.ShowDialog())
            {
                this.aNALIZOTCHETBindingSource.EndEdit();
                TablFormUpdate();
                InitSQLData(textEdit1.Text, textEdit4.Text);
            }
            else gridView1.DeleteRow(sel);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Редактирование строки записи отчета
            int sel = gridView1.FocusedRowHandle;
            klo = (ANALIZOTCHET)this.aNALIZOTCHETBindingSource[sel];
            if (klo == null) return;
            FormEditParOtchet frm = new FormEditParOtchet(this.aNALIZOTCHETBindingSource);
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else this.aNALIZOTCHETBindingSource.CancelEdit();
        }

        //private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        //{
        //    // Удаление записи из записей отчета
        //    int sel = gridView1.FocusedRowHandle;
        //    klo = (ANALIZOTCHET)this.aNALIZOTCHETBindingSource[sel];
        //    if (klo == null) return;
        //    if (klo.analizotch_id > 0)
        //    {
        //        if ((DevExpress.XtraEditors.XtraMessageBox.Show("Вы хотите удалить запись по : " + klo.NameStr, "Сообщения по редактированию  ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) == DialogResult.Yes)
        //        {

        //        }
        //    }
        //}
        #endregion

        #region ЗАПОЛНЕНИЕ ПРОВОДНИКА АНАЛИЗОВ
        private void FormMenuAnaliz()
        {
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
            this.treeList1.ExpandAll();
        }
        #endregion

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            // Добавление строк для списка реквизитов анализа
            int sel = gridView1.FocusedRowHandle;
            kl = (ANALIZOTCHETFLD)gridView1.GetRow(sel);
            kl.Analiz_ID = lcTree_ID;
            kl.namefield = "";
            kl.namefldru = "";
            kl.znachpusto = 0;

        }



        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            lcTree_ID = 0;

            if (e.Node != null)
            {
              //  bool bollc = int.TryParse(e.Node.GetDisplayText(treeListColumn2), out lcTree_ID);
                InitSQLData(textEdit1.Text, textEdit4.Text);
            }
        }

        private void treeList1_Click(object sender, EventArgs e)
        {
           // if (lcTree_ID == 0) return;
            InitSQLData(textEdit1.Text, textEdit4.Text);

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
            FrmANALIZFLD fa = new FrmANALIZFLD();
            // fa.PAnaliz_ID = lcTree_ID;
            //fa.Pstroka_ID = lcstroka_ID;
            fa.PAnaliz_ID = int.Parse(textEdit4.Text);
            fa.Pstroka_ID = int.Parse(textEdit1.Text);
            fa.INITSQL();
            if (DialogResult.OK == fa.ShowDialog())
            {
                InitSQLData(textEdit1.Text, textEdit4.Text);
                InitSQLDataOtchet();
            }
        }

        private void kRSAHARGridControl_Click(object sender, EventArgs e)
        {
            SelStrOtchet();
        }

        private void SelStrOtchet()
        {
            int sel = gridView1.FocusedRowHandle;
            klo = (ANALIZOTCHET)this.aNALIZOTCHETBindingSource[sel];
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
            DataClassesLabDataContext dt = new DataClassesLabDataContext();
            var res = (from c in dt.ANALIZOTCHETs select c);
            this.aNALIZOTCHETBindingSource.DataSource = res;
            this.kRSAHARGridControl.DataSource = null;
            this.kRSAHARGridControl.DataSource = this.aNALIZOTCHETBindingSource;
        }

    }
}