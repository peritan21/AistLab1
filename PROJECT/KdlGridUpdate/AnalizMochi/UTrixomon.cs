using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using KdlForm.AnalizMochi;

namespace KdlGridUpdate.AnalizMochi
{
    public partial class UTrixomon : UserControl
    {
        private MOCHATRIHOMON _kl;
        private DataClassesLabDataContext _db;
        public UTrixomon()
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

        public BindingNavigator BnMOCHATRIHOMON { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.MOCHATRIHOMONs where c.pacient_id == PpacientID && c.otd == Potd select c);
            mOCHATRIHOMONBindingSource.DataSource = res;
            mOCHATRIHOMONGridControl.DataSource = mOCHATRIHOMONBindingSource;
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
        private void MOchatrihomonBindingNavigatorSaveItemClick(object sender, EventArgs e)
        {
            TablFormUpdate();
    
        }

        private void BindingNavigatorAddNewItemClick1(object sender, EventArgs e)
        {
            int sel =bandedGridView1.FocusedRowHandle;
            _kl = (MOCHATRIHOMON)bandedGridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            var frm = new FrmTrixomonad(mOCHATRIHOMONBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel>0) bandedGridView1.DeleteRow(sel);
        }
        public void InsertOrder(MOCHATRIHOMON o)
        {
            _db = new DataClassesLabDataContext();
            _db.MOCHATRIHOMONs.InsertOnSubmit(o);
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
            _kl = (MOCHATRIHOMON)mOCHATRIHOMONBindingSource.Current;
            //kl = (MOCHATRIHOMON)this.mOCHATRIHOMONBindingSource[sel];
            if (_kl == null) return;
            var frm = new FrmTrixomonad(mOCHATRIHOMONBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else mOCHATRIHOMONBindingSource.CancelEdit();
        }
    }
}
