using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using KdlForm.Analizkrovi;

namespace KdlGridUpdate.Analizkrovi
{
    public partial class UkrObchi : UserControl
    {
        private KROBANALIZ _kl;
        private DataClassesLabDataContext _db;
 
        public UkrObchi()
        {
            InitializeComponent();
        }
        public string PFIO { get; set; }
        public string PZAGOLOVOK { get; set; }
        public string POTDSOKR { get; set; }
        public int PpacientID
        { get; set; }
        public int PlaborantID
        { get; set; }
        public int Potd
        { get; set; }
        public List<LABORANT> Llaboranth
        { get; set; }

        public BindingNavigator BnKROBANALIZ { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.KROBANALIZs where c.pacient_id == PpacientID && c.otd == Potd select c);
            kROBANALIZBindingSource.DataSource = res;
            kROBANALIZGridControl.DataSource = kROBANALIZBindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;

        }
        private void KRobanalizBindingNavigatorSaveItemClick(object sender, EventArgs e)
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
            _kl = (KROBANALIZ)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;

            var frm = new FrmKrOb(kROBANALIZBindingSource) {Llabanaliz = Llaboranth};
          
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else  if (sel > 0) gridView1.DeleteRow(sel);
        }
        public void InsertOrder(KROBANALIZ o)
        {
            _db = new DataClassesLabDataContext();
            _db.KROBANALIZs.InsertOnSubmit(o);
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
            _kl = (KROBANALIZ)kROBANALIZBindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmKrOb(kROBANALIZBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else kROBANALIZBindingSource.CancelEdit();
        }

     
     
    }
}
