using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using CustomControlLib;
using KdlForm.Testu_prochie;

namespace KdlGridUpdate.Testu_prochie
{
    public partial class UkrPCRisledov : UserControl
    {
        private PCRISSLEDOV _kl;
        private DataClassesLabDataContext _db;
        private readonly List<AccessorLab.Gemoliz> _lgemoliz= new List<AccessorLab.Gemoliz>();
        private readonly List<AccessorLab.Gemoliz> _lmaterial = new List<AccessorLab.Gemoliz>();
        public UkrPCRisledov()
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
        public List<LABORANT>  Llaboranth
        { get; set; }

        public BindingNavigator BnPCRISSLEDOV { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.PCRISSLEDOVs where c.pacient_id == PpacientID && c.otd == Potd select c);
            kRGEMOLIZBindingSource.DataSource = res;
            kRSAHARGridControl.DataSource = kRGEMOLIZBindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;
         }
        private void KRgemolizBindingNavigatorSaveItemClick(object sender, EventArgs e)
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

        private void UkrGemolizLoad(object sender, EventArgs e)
        {
            _lgemoliz.Add(new AccessorLab.Gemoliz(0, "нет значения"));
            _lgemoliz.Add(new AccessorLab.Gemoliz(1, "отриц."));
            _lgemoliz.Add(new AccessorLab.Gemoliz(2, "положит."));

            _lmaterial.Add(new AccessorLab.Gemoliz(0, "урогенитальный соскоб"));
            _lmaterial.Add(new AccessorLab.Gemoliz(1, "моча"));
            _lmaterial.Add(new AccessorLab.Gemoliz(2, "кровь"));

            repositoryItemLookUpEdit1.DataSource = _lmaterial;            
            repositoryItemLookUpEdit2.DataSource = _lgemoliz;

        }

        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            int sel = gridView1.FocusedRowHandle;
            _kl = (PCRISSLEDOV)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            _kl.material = 0;
            //kl.gemoliz = 0;
            var frm = new FrmPCRisledov(kRGEMOLIZBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);
        }
        public void InsertOrder(PCRISSLEDOV o)
        {
            _db = new DataClassesLabDataContext();
            _db.PCRISSLEDOVs.InsertOnSubmit(o);
            try
            {
                _db.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException)
            {
            }
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
        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            // Редактирование
            _kl = (PCRISSLEDOV)kRGEMOLIZBindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmPCRisledov(kRGEMOLIZBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else kRGEMOLIZBindingSource.CancelEdit();
        }

    
    }
}
