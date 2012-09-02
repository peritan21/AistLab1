using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using CustomControlLib;
using KdlForm.Analizkrovi;

namespace KdlGridUpdate.Analizkrovi
{
    public partial class UkrGemoliz : UserControl
    {
        private KRGEMOLIZ _kl;
        private DataClassesLabDataContext _db;
        private readonly List<AccessorLab.Gemoliz> _lgemoliz= new List<AccessorLab.Gemoliz>();
 
        public UkrGemoliz()
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

        public BindingNavigator BnKRGEMOLIZ { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.KRGEMOLIZs where c.pacient_id == PpacientID && c.otd == Potd select c);
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
            _lgemoliz.Add(new AccessorLab.Gemoliz(0, "не определяется"));
            _lgemoliz.Add(new AccessorLab.Gemoliz(1, "слабо выраженный"));
            _lgemoliz.Add(new AccessorLab.Gemoliz(2, "умеренно выраженный"));
            _lgemoliz.Add(new AccessorLab.Gemoliz(3, "резко выраженный"));
            repositoryItemLookUpEdit2.DataSource = _lgemoliz;
  
        }private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            int sel = gridView1.FocusedRowHandle;
            _kl = (KRGEMOLIZ)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            _kl.gemoliz = 0;
            var frm = new FrmKrGemoliz(kRGEMOLIZBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);
        }
        public void InsertOrder(KRGEMOLIZ o)
        {
            _db = new DataClassesLabDataContext();
            _db.KRGEMOLIZs.InsertOnSubmit(o);
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
            if (kRGEMOLIZBindingSource.Count == 0) return;
            _kl = (KRGEMOLIZ)kRGEMOLIZBindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmKrGemoliz(kRGEMOLIZBindingSource) {Llabanaliz = Llaboranth};
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
