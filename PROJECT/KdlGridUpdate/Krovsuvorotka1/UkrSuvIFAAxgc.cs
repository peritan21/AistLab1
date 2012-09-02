using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using CustomControlLib;
using KdlForm.Krsuvorotka1;

namespace KdlGridUpdate.Krovsuvorotka1
{
    public partial class UkrSuvIFAAxgc : UserControl
    {
        private KRSUVIFAXGCH _kl;
        private DataClassesLabDataContext _db;
        private readonly List<AccessorLab.Antitela> _lantitela = new List<AccessorLab.Antitela>();

        public UkrSuvIFAAxgc()
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

        public BindingNavigator BnKRSUVIFAXGCH { get; set; }

        public void InitSQLData()
        {
            _lantitela.Add(new AccessorLab.Antitela(0, "нет значения"));
            _lantitela.Add(new AccessorLab.Antitela(1, "Отрицательно"));
            _lantitela.Add(new AccessorLab.Antitela(2, "Положительно"));
            _lantitela.Add(new AccessorLab.Antitela(3, "Слабо положит."));
            _lantitela.Add(new AccessorLab.Antitela(4, "Резко положит."));
            
            //Слабо положит.

            _db = new DataClassesLabDataContext();
            var res = (from c in _db.KRSUVIFAXGCHes where c.pacient_id == PpacientID && c.otd == Potd select c);
            kRSUVIFAXGCHBindingSource.DataSource = res;
            kRSAHARGridControl.DataSource = kRSUVIFAXGCHBindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;
            repositoryItemLookUpEdit3.DataSource = _lantitela;
         }
      
            private void KRsuvifaxgchBindingNavigatorSaveItemClick(object sender, EventArgs e)
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

        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            UpdateAnaliz();
        }

        public void UpdateAnaliz()
        {
            // Редактирование
            _kl = (KRSUVIFAXGCH)kRSUVIFAXGCHBindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmKrSuvIfaXgch(kRSUVIFAXGCHBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                //this.kRBIOHIMIIBindingSource.EndEdit();
                TablFormUpdate();
            }
            else kRSUVIFAXGCHBindingSource.CancelEdit();
        }

        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            // Добавление
            int sel = gridView1.FocusedRowHandle;
            _kl = (KRSUVIFAXGCH)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            var frm = new FrmKrSuvIfaXgch(kRSUVIFAXGCHBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);
        }
        public void InsertOrder(KRSUVIFAXGCH o)
        {
            _db = new DataClassesLabDataContext();
            _db.KRSUVIFAXGCHes.InsertOnSubmit(o);
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
