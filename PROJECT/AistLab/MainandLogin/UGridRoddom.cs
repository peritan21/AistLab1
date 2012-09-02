using System.Data;

namespace AistLab.MainandLogin
{
    public partial class UGridRoddom : DevExpress.XtraEditors.XtraUserControl
    {
        private  int _lcpacientID;
        public UGridRoddom()
        {
            InitializeComponent();
        }
        public DevExpress.XtraGrid.GridControl Pgrid
        { set; get; }
        public DevExpress.XtraGrid.Views.Grid.GridView Pview
        { set; get; }
   
        public int RetpacientID()
        {
            // определение ид пациента
            _lcpacientID = 0;
            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (row == null) return _lcpacientID;
            int.TryParse(row["pacient_id"].ToString(), out _lcpacientID);
            return _lcpacientID;
        }
    }
}
