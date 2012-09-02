using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using KdlForm.Testu_prochie;

namespace KdlGridUpdate.Testu_prochie
{
    public partial class UAMGFvSperm : UserControl
    {
        private SPERMAMGF _kl;
        private DataClassesLabDataContext _db;
        public UAMGFvSperm()
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

        public BindingNavigator BnSPERMAMGF { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.SPERMAMGFs where c.pacient_id == PpacientID && c.otd == Potd select c);
            sPERMAMGFBindingSource.DataSource = res;
            kRSAHARGridControl.DataSource = sPERMAMGFBindingSource;
            repositoryItemLookUpEdit1.DataSource=Llaboranth;
        }
   
   
        private void SPermamgfBindingNavigatorSaveItemClick(object sender, EventArgs e)
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

        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            // Добавление
            int sel = gridView1.FocusedRowHandle;
            _kl = (SPERMAMGF)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            _kl.amgf = 0;
            var frm = new FrmSpermAMGF(sPERMAMGFBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);
        }
        private void InsertOrder(SPERMAMGF o)
        {
            _db = new DataClassesLabDataContext();
            _db.SPERMAMGFs.InsertOnSubmit(o);
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
            _kl = (SPERMAMGF)sPERMAMGFBindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmSpermAMGF(sPERMAMGFBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else sPERMAMGFBindingSource.CancelEdit();
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
    }
}
