using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using KdlForm.AnalizMochi;

namespace KdlGridUpdate.AnalizMochi
{
    public partial class UZemnickogo : UserControl
    {
        private MOHAZEMNICKOGO _kl;
        private DataClassesLabDataContext _db;
        public UZemnickogo()
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

        public BindingNavigator BnMohazemnickogo { get; set; }

        public void InitSqlData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.MOHAZEMNICKOGOs where c.pacient_id == PpacientId && c.otd == Potd select c);
            mOHAZEMNICKOGOBindingSource.DataSource = res;
            mOHAZEMNICKOGOGridControl.DataSource = mOHAZEMNICKOGOBindingSource;
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
 
        private void MOhazemnickogoBindingNavigatorSaveItemClick4(object sender, EventArgs e)
        {
            TablFormUpdate();
        }

        private void BindingNavigatorAddNewItemClick1(object sender, EventArgs e)
        {
            int sel = gridView1.FocusedRowHandle;
            _kl = (MOHAZEMNICKOGO)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientId;
            _kl.laborant_id = PlaborantId;
            _kl.otd = Potd;
            using (var frm = new FrmZimnickgo(mOHAZEMNICKOGOBindingSource) {Llabanaliz = Llaboranth})
            {
                frm.Text += "  " + PFIO;
                frm.InitLookup();
                if (DialogResult.OK == frm.ShowDialog())
                {
                    InsertOrder(_kl);
                }
                else if (sel > 0) gridView1.DeleteRow(sel);
            }
        }
        public void InsertOrder(MOHAZEMNICKOGO o)
        {
            _db = new DataClassesLabDataContext();
            o.dnevnoidiurezkol = o.inter6_9kol + o.inter9_12kol + o.inter12_15kol + o.inter15_18kol;
            o.nohnoidiurkol = o.ibter18_21kol + o.inter21_24kol + o.inter0_3kol + o.inter3_6kol;
            o.obdiurezkol = o.dnevnoidiurezkol + o.nohnoidiurkol;
            _db.MOHAZEMNICKOGOs.InsertOnSubmit(o);
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
            _kl = (MOHAZEMNICKOGO) mOHAZEMNICKOGOBindingSource.Current;
            if (_kl == null) return;
            using (var frm = new FrmZimnickgo(mOHAZEMNICKOGOBindingSource))
            {
                frm.Llabanaliz = Llaboranth;
                frm.Text += "  " + PFIO;
                frm.PZAGOLOVOK0 = PZAGOLOVOK;
                frm.InitLookup();
                if (DialogResult.OK == frm.ShowDialog())
                {
                    _kl.dnevnoidiurezkol = _kl.inter6_9kol + _kl.inter9_12kol + _kl.inter12_15kol + _kl.inter15_18kol;
                    _kl.nohnoidiurkol = _kl.ibter18_21kol + _kl.inter21_24kol + _kl.inter0_3kol + _kl.inter3_6kol;
                    _kl.obdiurezkol = _kl.dnevnoidiurezkol + _kl.nohnoidiurkol;
                    TablFormUpdate();
                }
                else mOHAZEMNICKOGOBindingSource.CancelEdit();
            }
        }

    }
}
