using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using KdlForm.Krsuvorotka1;

namespace KdlGridUpdate.Krovsuvorotka1
{
    public partial class UkrSuvGormIFA : UserControl
    {
        private KRSUVGORMIFA _kl;
        private DataClassesLabDataContext _db;
        public UkrSuvGormIFA()
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

        public BindingNavigator BnKRSUVGORMIFA { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.KRSUVGORMIFAs where c.pacient_id == PpacientID && c.otd == Potd select c);
            kRSUVGORMIFABindingSource.DataSource = res;
            kRSAHARGridControl.DataSource = kRSUVGORMIFABindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;
        }
     

   
        private void KRsuvgormifaBindingNavigatorSaveItemClick(object sender, EventArgs e)
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

  

        private void BindingNavigatorAddNewItemClick1(object sender, EventArgs e)
        {
            // Добавление
            int sel = gridView1.FocusedRowHandle;
            _kl = (KRSUVGORMIFA)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            var frm = new FrmKrSuvGormIFA(kRSUVGORMIFABindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.InitLookup();
             if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
             else if (sel > 0) gridView1.DeleteRow(sel);
        }
        public void InsertOrder(KRSUVGORMIFA o)
        {
            _db = new DataClassesLabDataContext();
            _db.KRSUVGORMIFAs.InsertOnSubmit(o);
            try
            {
                _db.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException)
            {
            }
        }
        private void ToolStripButton1Click1(object sender, EventArgs e)
        {
            UpdateAnaliz();
        }

        public void UpdateAnaliz()
        {
            // Редактирование
            _kl = (KRSUVGORMIFA)kRSUVGORMIFABindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmKrSuvGormIFA(kRSUVGORMIFABindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else kRSUVGORMIFABindingSource.CancelEdit();
        }
    }
}
