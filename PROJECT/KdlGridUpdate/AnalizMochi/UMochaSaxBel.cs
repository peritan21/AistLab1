using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using KdlForm.AnalizMochi;

namespace KdlGridUpdate.AnalizMochi
{
    public partial class UMochaSaxBel : UserControl
    {
        private MOHASAHARBELOK _kl;
        private DataClassesLabDataContext _db;
        public UMochaSaxBel()
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

        public BindingNavigator BnMOHASAHARBELOK { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.MOHASAHARBELOKs where c.pacient_id == PpacientID && c.otd == Potd select c);
            mOHASAHARBELOKBindingSource.DataSource = res;
            mOHASAHARBELOKGridControl.DataSource = mOHASAHARBELOKBindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;
        }
        private void MOhasaharbelokBindingNavigatorSaveItemClick(object sender, EventArgs e)
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
            // Добавление записи
            int sel = gridView1.FocusedRowHandle;
            _kl = (MOHASAHARBELOK)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            var frm = new FrmMohasaharbelok(mOHASAHARBELOKBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);

        }
        public void InsertOrder(MOHASAHARBELOK o)
        {
            _db = new DataClassesLabDataContext();
            _db.MOHASAHARBELOKs.InsertOnSubmit(o);
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
            _kl = (MOHASAHARBELOK)mOHASAHARBELOKBindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmMohasaharbelok(mOHASAHARBELOKBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else mOHASAHARBELOKBindingSource.CancelEdit();
        }
    }
}
