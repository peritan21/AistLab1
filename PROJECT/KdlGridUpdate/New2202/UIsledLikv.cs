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
    public partial class UIsledLikv : UserControl
    {
        private LIKVORAISSLED _kl;
        private DataClassesLabDataContext _db;
        private readonly List<AccessorLab.Prozrahnost> _lrozrahnost = new List<AccessorLab.Prozrahnost>();
        private readonly List<AccessorLab.Cvet> _lcvet = new List<AccessorLab.Cvet>();
        private readonly List<AccessorLab.Pandi> _lpandi = new List<AccessorLab.Pandi>();
        private readonly List<AccessorLab.Likvorogramma> _llikvor = new List<AccessorLab.Likvorogramma>();

        public UIsledLikv()
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

        public BindingNavigator BnLIKVORAISSLED { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.LIKVORAISSLEDs where c.pacient_id == PpacientID && c.otd == Potd select c);
            lIKVORAISSLEDBindingSource.DataSource = res;
            iMUNTESTGridControl.DataSource = lIKVORAISSLEDBindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;
            _lrozrahnost.Add(new AccessorLab.Prozrahnost(0, "нет значения"));
            _lrozrahnost.Add(new AccessorLab.Prozrahnost(1, "прозрачная"));
            _lrozrahnost.Add(new AccessorLab.Prozrahnost(2, "мутноватая"));
            _lrozrahnost.Add(new AccessorLab.Prozrahnost(3, "мутная"));
            _lrozrahnost.Add(new AccessorLab.Prozrahnost(4, "бесцветная"));
            _lcvet.Add(new AccessorLab.Cvet(0, "нет значения"));
            _lcvet.Add(new AccessorLab.Cvet(1, "светло-желтый"));
            _lcvet.Add(new AccessorLab.Cvet(2, "бесцветный"));
            _lcvet.Add(new AccessorLab.Cvet(3, "желтый"));
            _lcvet.Add(new AccessorLab.Cvet(4, "бурый"));
            _lpandi.Add(new AccessorLab.Pandi(0, "нет значения"));
            _lpandi.Add(new AccessorLab.Pandi(1, "отрицательная"));
            _lpandi.Add(new AccessorLab.Pandi(2, "+"));
            _lpandi.Add(new AccessorLab.Pandi(3, "++"));
            _lpandi.Add(new AccessorLab.Pandi(4, "+++"));
            _lpandi.Add(new AccessorLab.Pandi(5, "++++"));
            _llikvor.Add(new AccessorLab.Likvorogramma(0, "нет значения"));
            _llikvor.Add(new AccessorLab.Likvorogramma(1, "нейтрофилы"));
            _llikvor.Add(new AccessorLab.Likvorogramma(2, "лимфоциты"));
            _llikvor.Add(new AccessorLab.Likvorogramma(3, "эозинофилы"));
            _llikvor.Add(new AccessorLab.Likvorogramma(4, "эритроциты"));

            repositoryItemLookUpEdit2.DataSource = _lrozrahnost;
            repositoryItemLookUpEdit3.DataSource = _lcvet;
            repositoryItemLookUpEdit4.DataSource = _lpandi;
            repositoryItemLookUpEdit5.DataSource = _llikvor;
        }
     
 

        private void LIkvoraissledBindingNavigatorSaveItemClick(object sender, EventArgs e)
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
            _kl = (LIKVORAISSLED)lIKVORAISSLEDBindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmLikvoraIssled(lIKVORAISSLEDBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else lIKVORAISSLEDBindingSource.CancelEdit();
        }

        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            // Добaвление
            int sel = gridView1.FocusedRowHandle;
            _kl = (LIKVORAISSLED)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            var frm = new FrmLikvoraIssled(lIKVORAISSLEDBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);

        }
        public void InsertOrder(LIKVORAISSLED o)
        {
            _db = new DataClassesLabDataContext();
            _db.LIKVORAISSLEDs.InsertOnSubmit(o);
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
