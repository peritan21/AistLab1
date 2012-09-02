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
    public partial class UkrPCRMutacii : UserControl
    {
        private KRPCRMUTACII _kl;
        private DataClassesLabDataContext _db;
        private readonly List<AccessorLab.Gemoliz> _lgemoliz= new List<AccessorLab.Gemoliz>();

        public UkrPCRMutacii()
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

        public BindingNavigator BnPCRMutacii { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.KRPCRMUTACIIs where c.pacient_id == PpacientID && c.otd == Potd select c);
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
            _lgemoliz.Add(new AccessorLab.Gemoliz(1, "Нормальная гомозигота"));
            _lgemoliz.Add(new AccessorLab.Gemoliz(2, "Гетерозигота"));
            _lgemoliz.Add(new AccessorLab.Gemoliz(3, "Мутантная гомозигота"));
            repositoryItemLookUpEdit2.DataSource = _lgemoliz;
  
        }

        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            int sel = gridView1.FocusedRowHandle;
            _kl = (KRPCRMUTACII)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            //kl.gemoliz = 0;
            var frm = new FrmKrPCRMutacii(kRGEMOLIZBindingSource) {Llabanaliz = Llaboranth};
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);
        }
        public void InsertOrder(KRPCRMUTACII o)
        {
            _db = new DataClassesLabDataContext();
            _db.KRPCRMUTACIIs.InsertOnSubmit(o);
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
            _kl = (KRPCRMUTACII)kRGEMOLIZBindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmKrPCRMutacii(kRGEMOLIZBindingSource) {Llabanaliz = Llaboranth};
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
