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
    public partial class UAnalKalUglev : UserControl
    {
        //DataRow dr;
        //DataView dv;
        private KALANALIZUGLEV _kl;
        private DataClassesLabDataContext _db;
        private readonly List<AccessorLab.Antitela> _lantitela = new List<AccessorLab.Antitela>();
        
        public UAnalKalUglev()
        {
            InitializeComponent();
            _lantitela.Add(new AccessorLab.Antitela(0, "нет значения"));
            _lantitela.Add(new AccessorLab.Antitela(1, "Отрицательно"));
            _lantitela.Add(new AccessorLab.Antitela(2, "0.05 - 0.15"));
            _lantitela.Add(new AccessorLab.Antitela(3, "0.2   - 0.4"));
            _lantitela.Add(new AccessorLab.Antitela(4, "0.5  -  0.75"));
            _lantitela.Add(new AccessorLab.Antitela(5, "1   -  1.65"));
            _lantitela.Add(new AccessorLab.Antitela(6, "2   и выше")); 
            repositoryItemLookUpEdit3.DataSource = _lantitela;

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

        public BindingNavigator BnKALANALIZUGLEV { get; set; }

        public void InitSQLData()
        {
           _db = new DataClassesLabDataContext();
            var res = (from c in _db.KALANALIZUGLEVs where c.pacient_id == PpacientID  &&  c.otd == Potd select c);
            kALANALIZUGLEVBindingSource.DataSource = res;
            mAZKINAFLORUGridControl.DataSource = kALANALIZUGLEVBindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;
        }
        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            int sel = gridView1.FocusedRowHandle;
            _kl = (KALANALIZUGLEV)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            //_kl.labanaliz = PlaborantID;
            _kl.otd = Potd;
            var frm = new FrmAnalKalUgl(kALANALIZUGLEVBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);
        }

        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            //if (this.kALANALIZUGLEVBindingSource.Count == 0) return;
            UpdateAnaliz();
        }

        public void UpdateAnaliz()
        {
            _kl = (KALANALIZUGLEV)kALANALIZUGLEVBindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmAnalKalUgl(kALANALIZUGLEVBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                kALANALIZUGLEVBindingSource.EndEdit();
                TablFormUpdate();


            }
            else kALANALIZUGLEVBindingSource.CancelEdit();
        }
        public void InsertOrder(KALANALIZUGLEV o)
        {
            var db = new DataClassesLabDataContext();
            db.KALANALIZUGLEVs.InsertOnSubmit(o);
            // Exception handling not shown.
            db.SubmitChanges();
        }

     
       private void KAlanalizuglevBindingNavigatorSaveItemClick(object sender, EventArgs e)
        {
            TablFormUpdate();
        }
        protected void TablFormUpdate()
        {
            //db = new DataClassesLabDataContext();
            Validate();
            try
            {
                // ConflictMode is an optional parameter.
                _db.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException)
            {
                // Get conflict information, and take actions
                // that are appropriate for your application.
                // See MSDN Article How to: Manage Change Conflicts (LINQ to SQL).
            }
        }
 
    }
}
