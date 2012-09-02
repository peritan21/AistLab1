using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using KdlForm.AnalizMochi;

namespace KdlGridUpdate.AnalizMochi
{
    public partial class UNechipor : UserControl
    {
        private MOCHANEHIPOR _kl;
        private DataClassesLabDataContext _db;

        public UNechipor()
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

        public BindingNavigator BnMochanehipor { get; set; }

        public void InitSqlData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.MOCHANEHIPORs where c.pacient_id == PpacientId && c.otd == Potd select c);
            mOCHANEHIPORBindingSource.DataSource = res;
            mOCHANEHIPORGridControl.DataSource = mOCHANEHIPORBindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;
        }
        private void MOchanehiporBindingNavigatorSaveItemClick(object sender, EventArgs e)
        {
            TablFormUpdate();
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
            int sel = gridView1.FocusedRowHandle;
            _kl = (MOCHANEHIPOR)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientId;
            _kl.laborant_id = PlaborantId;
            _kl.otd = Potd;
            using (var frm = new FrmNechipor(mOCHANEHIPORBindingSource))
            {
                frm.Llabanaliz = Llaboranth;
                frm.Text += "  " + PFIO;
                frm.InitLookup();
                if (DialogResult.OK == frm.ShowDialog())
                {
                    InsertOrder(_kl);
                }
                else if (sel > 0) gridView1.DeleteRow(sel);
            }
        }
        public void InsertOrder(MOCHANEHIPOR o)
        {
            _db = new DataClassesLabDataContext();
            _db.MOCHANEHIPORs.InsertOnSubmit(o);
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
            UpdateAnaliz();
        }

        public void UpdateAnaliz()
        {
      
            _kl = (MOCHANEHIPOR)mOCHANEHIPORBindingSource.Current;
            if (_kl == null) return;
            using (var frm = new FrmNechipor(mOCHANEHIPORBindingSource))
            {
                frm.Llabanaliz = Llaboranth;
                frm.Text += "  " + PFIO;
                frm.PZAGOLOVOK0 = PZAGOLOVOK;
                frm.InitLookup();
                if (DialogResult.OK == frm.ShowDialog())
                {
                    TablFormUpdate();
                }
                else mOCHANEHIPORBindingSource.CancelEdit();
            }
        }
    }
}
