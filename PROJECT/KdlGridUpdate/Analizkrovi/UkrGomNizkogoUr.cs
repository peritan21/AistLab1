using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using KdlForm.Analizkrovi;

namespace KdlGridUpdate.Analizkrovi
{
    public partial class UkrGomNizkogoUr : UserControl
    {
        private KRGOMONIZKOGOUR _kl;
        private DataClassesLabDataContext _db;
        public UkrGomNizkogoUr()
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

        public BindingNavigator BnKRGOMOCISTEIN { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.KRGOMONIZKOGOURs where c.pacient_id == PpacientID && c.otd == Potd select c);
            kRGOMOCISTEINBindingSource.DataSource = res;
            kRSAHARGridControl.DataSource = kRGOMOCISTEINBindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;
        }
        private void KRsaharBindingNavigatorSaveItemClick(object sender, EventArgs e)
        {
            TablFormUpdate();

        }
        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            // Добавление
            int sel = gridView1.FocusedRowHandle;
            _kl = (KRGOMONIZKOGOUR)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            //_kl.hb = 0;
            //_kl.gemoliz = 0;
            var frm = new FrmKrGemNizkogoUr(kRGOMOCISTEINBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
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
        public void InsertOrder(KRGOMONIZKOGOUR o)
        {
            _db = new DataClassesLabDataContext();
            _db.KRGOMONIZKOGOURs.InsertOnSubmit(o);
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
            _kl = (KRGOMONIZKOGOUR)kRGOMOCISTEINBindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmKrGemNizkogoUr(kRGOMOCISTEINBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else kRGOMOCISTEINBindingSource.CancelEdit();
        }
    }
}
