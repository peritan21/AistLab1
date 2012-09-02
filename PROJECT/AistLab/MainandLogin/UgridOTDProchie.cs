using System;
using System.Collections.Generic;
using System.Data;
using AistLabData;

namespace AistLab.MainandLogin
{
    public partial class UgridOTDProchie : DevExpress.XtraEditors.XtraUserControl
    {
        DataRow _dr;
        DataView _dv;
        public UgridOTDProchie()
        {
            InitializeComponent();
        }
        public int PpacientID
        { get; set; }
        public int PotdID
        { get; set; }
        public int PlaborantID
        { get; set; }
        public List<LABORANT> Llaboranth
        { get; set; }
        public List<OTD> Lotdh
        { get; set; }
        public void InitSQLData()
        {
            pACIENTPPCTableAdapter.Fill(dataSetLab.PACIENTPPC, PpacientID);
            var dvManager = new DataViewManager(dataSetLab);
            _dv = dvManager.CreateDataView(dataSetLab.PACIENTPPC);
            pACIENTPPCBindingSource.DataSource = _dv;
            pACIENTPPCGridControl.DataSource = pACIENTPPCBindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;
            repositoryItemLookUpEdit2.DataSource = Lotdh;
        }
        private void PAcientppcBindingNavigatorSaveItemClick(object sender, EventArgs e)
        {
            TablFormUpdate();
        }

        private void TablFormUpdate()
        {
            Validate();
            pACIENTPPCBindingSource.EndEdit();
            tableAdapterManager.UpdateAll(dataSetLab);
        }
        
        private void GridView1InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            _dr = gridView1.GetDataRow(e.RowHandle);
            _dr["laborant_id"] = PlaborantID;
            _dr["data"] = DateTime.Now;
            _dr["noomer"] = 0;
            _dr["fio1"] = "";
            _dr["fio2"] = "";
            _dr["fio3"] = "";
            _dr["otd_id"] = PotdID;
      
        }
    }
}
