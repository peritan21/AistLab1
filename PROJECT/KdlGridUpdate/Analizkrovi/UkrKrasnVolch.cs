using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using KdlForm.Analizkrovi;

namespace KdlGridUpdate.Analizkrovi
{
    public partial class UkrKrasnVolch : UserControl
    {
        private KRKRASNVOLCH _kl;
        private DataClassesLabDataContext _db;
        public UkrKrasnVolch()
        {
            InitializeComponent();
        }
        public int PpacientID
        { get; set; }
        public int PlaborantID
        { get; set; }
        public int Potd
        { get; set; }
        public string PFIO { get; set; }
        public string PZAGOLOVOK { get; set; }
        public List<LABORANT>  Llaboranth
        { get; set; }

        public BindingNavigator BnKRKRASNVOLCH { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.KRKRASNVOLCHes where c.pacient_id == PpacientID && c.otd == Potd select c);
            kRKRASNVOLCHBindingSource.DataSource = res;
            kRSAHARGridControl.DataSource = kRKRASNVOLCHBindingSource;
            repositoryItemLookUpEdit1.DataSource=Llaboranth;
        }
   
   
        private void KRkrasnvolchBindingNavigatorSaveItemClick(object sender, EventArgs e)
        {
            TablFormUpdate();
        }
        public void InsertOrder(KRKRASNVOLCH o)
        {
            _db = new DataClassesLabDataContext();
            _db.KRKRASNVOLCHes.InsertOnSubmit(o);
            try
            {
                _db.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException)
            {
            }
        } 
        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            int sel = gridView1.FocusedRowHandle;
            _kl = (KRKRASNVOLCH)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            _kl.volchanka = false;
            _kl.pol = 0;
            var frm = new FrmKrasnVolch(kRKRASNVOLCHBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                if (_kl.volchanka == false) _kl.pol = 0;
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);
        }
        private void TablFormUpdate()
        {
            Validate();
            try
            {
                _db.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException)
            {
            }
        }
        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            // Редактирование
            _kl = (KRKRASNVOLCH)kRKRASNVOLCHBindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmKrasnVolch(kRKRASNVOLCHBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                if (_kl.volchanka == false) _kl.pol = 0;
                TablFormUpdate();
            }
            else kRKRASNVOLCHBindingSource.CancelEdit();
        }

    }
}
