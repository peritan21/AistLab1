using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using KdlForm.New2202;

namespace KdlGridUpdate.New2202
{
    public partial class UBacterioBiomat : UserControl
    {
        private BAKTERIOSBIOMAT _kl;
        private DataClassesLabDataContext _db;
      // private List<AccessorLab.Tkscs> ltkscs = new List<AccessorLab.Tkscs>();

        public UBacterioBiomat()
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

        public BindingNavigator BnBAKTERIOSBIOMAT { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.BAKTERIOSBIOMATs where c.pacient_id == PpacientID && c.otd == Potd select c);
            bAKTERIOSBIOMATBindingSource.DataSource = res;
            iMUNTESTGridControl.DataSource = bAKTERIOSBIOMATBindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;
        }

   
        private void BAkteriosbiomatBindingNavigatorSaveItemClick(object sender, EventArgs e)
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

        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            UpdateAnaliz();
        }

        public void UpdateAnaliz()
        {
            // Редактирование
            _kl = (BAKTERIOSBIOMAT)bAKTERIOSBIOMATBindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmBakteriosBiomat1(bAKTERIOSBIOMATBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            // frm.Parent = this;
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else bAKTERIOSBIOMATBindingSource.CancelEdit();
        }

        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            // Добавление
            int sel = gridView1.FocusedRowHandle;
            _kl = (BAKTERIOSBIOMAT)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            _kl.florayes = false;
            _kl.drojgribyes = false;
            var frm = new FrmBakteriosBiomat1(bAKTERIOSBIOMATBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            // frm.Parent = this;
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);

        }
        public void InsertOrder(BAKTERIOSBIOMAT o)
        {
            _db = new DataClassesLabDataContext();
            _db.BAKTERIOSBIOMATs.InsertOnSubmit(o);
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
