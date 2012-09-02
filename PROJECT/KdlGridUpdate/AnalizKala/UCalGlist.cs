using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AistLab
{
    public partial class UCalGlist : UserControl
    {
        DataRow dr;
        DataView dv;
        private List<AccessorLab.Antitela> lantitela = new List<AccessorLab.Antitela>();

        public UCalGlist()
        {
            InitializeComponent();
            lantitela.Add(new AccessorLab.Antitela(0, "необнаружено"));
            lantitela.Add(new AccessorLab.Antitela(1, "обнаружено"));
            this.repositoryItemLookUpEdit3.DataSource = lantitela;

        }
        public int Ppacient_id
        { get; set; }
        public int Plaborant_id
        { get; set; }
        public List<LABORANT> llaboranth
        { get; set; }   
        public void InitSQLData()
        {
            this.kALGLISTTableAdapter.Fill(this.dataSetLab.KALGLIST, Ppacient_id);
            DataViewManager dvManager = new DataViewManager(this.dataSetLab);
            dv = dvManager.CreateDataView(this.dataSetLab.KALGLIST);
            this.kALGLISTBindingSource.DataSource = dv;
            this.mAZKINAFLORUGridControl.DataSource = this.kALGLISTBindingSource;
            this.repositoryItemLookUpEdit1.DataSource = llaboranth;
        }
 

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            // добавление  записи
            dr = this.gridView1.GetDataRow(e.RowHandle);
            dr["data"] = DateTime.Now;
            dr["pacient_id"] = Ppacient_id;
            dr["laborant_id"] = Plaborant_id;
            dr[4] = 0;
            dr[5] = 0;
            dr[6] = 0;
            dr[7] = 0;
     
 
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            int sel = gridView1.FocusedRowHandle;
            DataRow row = gridView1.GetDataRow(sel);
            if (row == null) return;
            FrmCalglist frm = new FrmCalglist(this.kALGLISTBindingSource);
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else gridView1.DeleteRow(sel);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int sel = gridView1.FocusedRowHandle;
            DataRow row = gridView1.GetDataRow(sel);
            if (row == null) return;
            FrmCalglist frm = new FrmCalglist(this.kALGLISTBindingSource);
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else this.kALGLISTBindingSource.CancelEdit();
        }


        private void kALGLISTBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            TablFormUpdate();
        }

        private void TablFormUpdate()
        {
            this.Validate();
            this.kALGLISTBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSetLab);
        }
 
    }
}
