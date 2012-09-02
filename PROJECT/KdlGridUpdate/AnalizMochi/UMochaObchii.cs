using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using KdlForm.AnalizMochi;

namespace KdlGridUpdate.AnalizMochi
{
    public partial class UMochaObchii : UserControl
    {
        private MOCHAOBCH _kl;
        private DataClassesLabDataContext _db;
        public UMochaObchii()
        {
            InitializeComponent();
        }
        public int PpacientId
        { get; set; }
        public int PlaborantId
        { get; set; }
        public int Potd
        { get; set; }
        public string PFIO { get; set; }
        public string PZAGOLOVOK { get; set; }
        public List<LABORANT> Llaboranth
        { get; set; }

        public BindingNavigator BnMochaobch { get; set; }

        public void InitSqlData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.MOCHAOBCHes where c.pacient_id == PpacientId && c.otd == Potd select c);
            mOCHAOBCHBindingSource.DataSource = res;
            mOCHAOBCHGridControl.DataSource = mOCHAOBCHBindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;
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

 
        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            if (gridView1 != null)
            {
                int sel = gridView1.FocusedRowHandle;
                _kl = (MOCHAOBCH)gridView1.GetRow(sel);
                _kl.data = DateTime.Now;
                _kl.datatek = DateTime.Now;
                _kl.pacient_id = PpacientId;
                _kl.laborant_id = PlaborantId;
                _kl.otd = Potd;
                _kl.sahar = 1;
                _kl.belokyes = 1;
                using (var frm = new FrmMochaObchii(mOCHAOBCHBindingSource))
                {
                    frm.Llabanaliz = Llaboranth;
                    frm.Text += "  " + PFIO;
                    frm.InitLookup();
                    if (DialogResult.OK == frm.ShowDialog())
                    {
                        if (mOCHAOBCHBindingSource != null)
                        {
                            mOCHAOBCHBindingSource.EndEdit();
                            TablFormUpdate();
                        }
                    }
                    else if (sel > 0) gridView1.DeleteRow(sel);
                }
            }
        }
        public void InsertOrder(MOCHAOBCH o)
        {
            _db = new DataClassesLabDataContext();
            _db.MOCHAOBCHes.InsertOnSubmit(o);
            try
            {
                _db.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException)
            {
            }
        }

        public void UpdateAnaliz()
        {
            _kl = (MOCHAOBCH)mOCHAOBCHBindingSource.Current;
            if (_kl == null) return;
            if (mOCHAOBCHBindingSource != null)
                using (var frm = new FrmMochaObchii(mOCHAOBCHBindingSource))
                {
                    frm.Llabanaliz = Llaboranth;
                    frm.Text += "  " + PFIO;
                    frm.PZAGOLOVOK0 = PZAGOLOVOK;
                    frm.InitLookup();
                    if (DialogResult.OK == frm.ShowDialog())
                    {
                        TablFormUpdate();
                    }
                    else mOCHAOBCHBindingSource.CancelEdit();
                }
        }

        private void MOchaobchBindingNavigatorSaveItemClick(object sender, EventArgs e)
        {
            TablFormUpdate();

        }

    }
}
