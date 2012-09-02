using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using CustomControlLib;
using KdlForm.New2202;

namespace KdlGridUpdate.New2202
{
    public partial class UDiagSifilis : UserControl
    {
        private DIAGSIFILISA _kl;
        private DataClassesLabDataContext _db;
        private readonly List<AccessorLab.Rpr> _lrpr = new List<AccessorLab.Rpr>();

        public UDiagSifilis()
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

        public BindingNavigator BnDIAGSIFILISA { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.DIAGSIFILISAs where c.pacient_id == PpacientID && c.otd == Potd select c);
            dIAGSIFILISABindingSource.DataSource = res;
            iMUNTESTGridControl.DataSource = dIAGSIFILISABindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;
            _lrpr.Add(new AccessorLab.Rpr(0, "нет значения"));
            _lrpr.Add(new AccessorLab.Rpr(1, "слабо положительно"));
            _lrpr.Add(new AccessorLab.Rpr(2, "положительно"));
            _lrpr.Add(new AccessorLab.Rpr(3, "отрицательно"));
            repositoryItemLookUpEdit4.DataSource = _lrpr;
            repositoryItemLookUpEdit5.DataSource = _lrpr;
        }
  
 

        private void DIagsifilisaBindingNavigatorSaveItemClick(object sender, EventArgs e)
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
            // Добавление
            int sel = gridView1.FocusedRowHandle;
            _kl = (DIAGSIFILISA)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            _kl.rpr = 0;
            //kl.rpga = 0;
            var frm = new FrmDiagSifilisa(dIAGSIFILISABindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);
        }
        private void InsertOrder(DIAGSIFILISA o)
        {
            _db = new DataClassesLabDataContext();
            _db.DIAGSIFILISAs.InsertOnSubmit(o);
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
            // Редактирование
            if (dIAGSIFILISABindingSource.Count == 0) return;
            _kl = (DIAGSIFILISA)dIAGSIFILISABindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmDiagSifilisa(dIAGSIFILISABindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else dIAGSIFILISABindingSource.CancelEdit();
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
