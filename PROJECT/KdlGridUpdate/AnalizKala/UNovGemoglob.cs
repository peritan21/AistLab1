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
    public partial class UNovGemoglob : UserControl
    {
        //DataRow dr;
        //DataView dv;
        private KALNOVGEMOGLOBIN _kl;
        private DataClassesLabDataContext _db;
        private readonly List<AccessorLab.Antitela> _lantitela = new List<AccessorLab.Antitela>();
        public UNovGemoglob()
        {
            InitializeComponent();
            _lantitela.Add(new AccessorLab.Antitela(0, "нет значения"));
            _lantitela.Add(new AccessorLab.Antitela(1, "HbA"));
            _lantitela.Add(new AccessorLab.Antitela(2, "HbF"));
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
        public List<LABORANT>  Llaboranth
        { get; set; }

        public BindingNavigator BnKALNOVGEMOGLOBIN { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.KALNOVGEMOGLOBINs where c.pacient_id == PpacientID && c.otd == Potd select c);
            kALNOVGEMOGLOBINBindingSource.DataSource = res;
            kRSAHARGridControl.DataSource = kALNOVGEMOGLOBINBindingSource;
            repositoryItemLookUpEdit1.DataSource=Llaboranth;
        }
   
   

        private void KAlnovgemoglobinBindingNavigatorSaveItemClick(object sender, EventArgs e)
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
            _kl = (KALNOVGEMOGLOBIN)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            _kl.rezultat = 0;
           // db.KALNOVGEMOGLOBINs.InsertOnSubmit(kl);
            var frm = new FrmNovGemoglob(kALNOVGEMOGLOBINBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);
        }
        public void InsertOrder(KALNOVGEMOGLOBIN o)
        {
            _db = new DataClassesLabDataContext();
            _db.KALNOVGEMOGLOBINs.InsertOnSubmit(o);
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
            _kl = (KALNOVGEMOGLOBIN)kALNOVGEMOGLOBINBindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmNovGemoglob(kALNOVGEMOGLOBINBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else kALNOVGEMOGLOBINBindingSource.CancelEdit();
        }

     
    }
}
