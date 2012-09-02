using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using KdlForm.Analizkrovi;

namespace KdlGridUpdate.Analizkrovi
{
    public partial class UkrEli24 : UserControl
    {
        private ELI24 _kl;
        private DataClassesLabDataContext _db;
        public UkrEli24()
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
        //public BindingNavigator eLI12BindingNavigator
        //{
        //    set { this.eLI12BindingNavigator = value; }
        //    get { return this.eLI12BindingNavigator; }
        //}
        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.ELI24s where c.pacient_id == PpacientID && c.otd == Potd select c);
            eLI12BindingSource.DataSource = res;
            kRBIOHIMIIGridControl.DataSource = eLI12BindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;
        }
        private void KRbiohimiiBindingNavigatorSaveItemClick(object sender, EventArgs e)
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
            _kl = (ELI24)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;

            var frm = new FrmKrELI24(eLI12BindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
               InsertOrder(_kl);
            }
            else if (sel>0)   gridView1.DeleteRow(sel);
        }
        public void InsertOrder(ELI24 o)
        {
            _db = new DataClassesLabDataContext();
            _db.ELI24s.InsertOnSubmit(o);
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
            _kl = (ELI24)eLI12BindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmKrELI24(eLI12BindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else eLI12BindingSource.CancelEdit();
        }
    }
}
