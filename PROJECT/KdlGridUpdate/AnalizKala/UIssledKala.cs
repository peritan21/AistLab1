using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using CustomControlLib;
using KdlForm.AnalizKala;

namespace KdlGridUpdate.AnalizKala
{
    public partial class UIssledKala : UserControl
    {
         private KALISSLEDOV _kl;
        private DataClassesLabDataContext _db;
        private readonly List<AccessorLab.Antitela> _lantitela = new List<AccessorLab.Antitela>();

        public UIssledKala()
        {
            InitializeComponent();
            _lantitela.Add(new AccessorLab.Antitela(0, "нет значения"));
            _lantitela.Add(new AccessorLab.Antitela(1, "Единичная"));
            _lantitela.Add(new AccessorLab.Antitela(2, "Небольшом"));
            _lantitela.Add(new AccessorLab.Antitela(3, "Большом"));
            repositoryItemLookUpEdit2.DataSource = _lantitela;
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

        public BindingNavigator BnKALISSLEDOV { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.KALISSLEDOVs where c.pacient_id == PpacientID  && c.otd==Potd select c);
            kALISSLEDOVBindingSource.DataSource = res;
            mAZKINAFLORUGridControl.DataSource = kALISSLEDOVBindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;
        }
 

 
        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            int sel = gridView1.FocusedRowHandle;
            _kl = (KALISSLEDOV)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            _kl.iodofilflora = 5;
            _kl.krahmal = 5;
            var frm = new FrmIssledKala(kALISSLEDOVBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);
        }
        public void InsertOrder(KALISSLEDOV o)
        {
            _db = new DataClassesLabDataContext();
            _db.KALISSLEDOVs.InsertOnSubmit(o);
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
            _kl = (KALISSLEDOV)kALISSLEDOVBindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmIssledKala(kALISSLEDOVBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else kALISSLEDOVBindingSource.CancelEdit();
        }
        private void KAlissledovBindingNavigatorSaveItemClick(object sender, EventArgs e)
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

   
 
    }
}
