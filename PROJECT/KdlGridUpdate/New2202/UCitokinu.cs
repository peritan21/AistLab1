using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using KdlForm.New2202;

namespace KdlGridUpdate.New2202
{
    public partial class UCitocinu : UserControl
    {
        private CITOKIN _kl;
        private DataClassesLabDataContext _db;

        public UCitocinu()
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
        public List<LABORANT> Llaboranth
        { get; set; }

        public BindingNavigator BnCITOKIN { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.CITOKINs where c.pacient_id == PpacientID && c.otd == Potd select c);
            cITOKINBindingSource.DataSource = res;
            iMUNTESTGridControl.DataSource = cITOKINBindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;

        }
  
        private void CItokinBindingNavigatorSaveItemClick(object sender, EventArgs e)
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
        public void InsertOrder(CITOKIN o)
        {
            _db = new DataClassesLabDataContext();
            _db.CITOKINs.InsertOnSubmit(o);
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
            _kl = (CITOKIN)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            _kl.il1v = 0;
            _kl.il6 = 0;
            _kl.yinf = 0;
            _kl.afno = 0;
            var frm = new FrmCitokin(cITOKINBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);
        }

        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            UpdateAnaliz();
        }
        public void UpdateAnaliz()
        {
            _kl = (CITOKIN)cITOKINBindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmCitokin(cITOKINBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else cITOKINBindingSource.CancelEdit();
        }
    }
}
