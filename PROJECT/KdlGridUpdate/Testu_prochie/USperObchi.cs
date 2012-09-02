using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using KdlForm.Testu_prochie;

namespace KdlGridUpdate.Testu_prochie
{
    public partial class USpermObchi : UserControl
    {
        private EAKULJT _kl;
        private DataClassesLabDataContext _db;
        public USpermObchi()
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

        public BindingNavigator BnEAKULJT { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.EAKULJTs where c.pacient_id == PpacientID && c.otd == Potd select c);
            eAKULJTBindingSource.DataSource = res;
            mAZKINAFLORUGridControl.DataSource = eAKULJTBindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;
        }
 
        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            // Добавление
            int sel = gridView1.FocusedRowHandle;
            _kl = (EAKULJT)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            var frm = new FrmSpermObchii(eAKULJTBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel>0) gridView1.DeleteRow(sel);
        }
        public void InsertOrder(EAKULJT o)
        {
            _db = new DataClassesLabDataContext();
            _db.EAKULJTs.InsertOnSubmit(o);
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
            _kl = (EAKULJT)eAKULJTBindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmSpermObchii(eAKULJTBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else eAKULJTBindingSource.CancelEdit();
        }

        private void EAkuljtBindingNavigatorSaveItemClick(object sender, EventArgs e)
        {
            TablFormUpdate();
        }

        private void TablFormUpdate()
        {
            Validate();
            _db.SubmitChanges();
        }

    }
}
