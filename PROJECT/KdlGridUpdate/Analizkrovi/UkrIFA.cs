using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using KdlForm.Analizkrovi;

namespace KdlGridUpdate.Analizkrovi
{
    public partial class UkrIFA : UserControl
    {
        private KRIFA _kl;
        private DataClassesLabDataContext _db;
        public UkrIFA()
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
        public string POTDSOKR { get; set; }
        public string PZAGOLOVOK { get; set; }
        public List<LABORANT> Llaboranth
        { get; set; }

        public BindingNavigator BnKRIFA { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.KRIFAs where c.pacient_id == PpacientID && c.otd == Potd select c);
            kRIFABindingSource.DataSource = res;
            kRIFAGridControl.DataSource = kRIFABindingSource;
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
            int sel = gridView1.FocusedRowHandle;
            _kl = (KRIFA)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            var frm = new FrmIsSKrmetIFA(kRIFABindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);
        }
        public void InsertOrder(KRIFA o)
        {
            _db = new DataClassesLabDataContext();
            _db.KRIFAs.InsertOnSubmit(o);
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
          
            _kl = (KRIFA)kRIFABindingSource.Current;
            if (_kl == null) return;

            var frm = new FrmIsSKrmetIFA(kRIFABindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else kRIFABindingSource.CancelEdit();
        }

        private void KRifaBindingNavigatorSaveItemClick(object sender, EventArgs e)
        {
            TablFormUpdate();

        }

    

    }
}
