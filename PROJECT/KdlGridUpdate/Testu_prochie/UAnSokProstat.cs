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
    public partial class UAnSokProstat : UserControl
    {
        private SOKPROSTAT _kl;
        private DataClassesLabDataContext _db;
        private readonly List<AccessorLab.Antitela> _lantitela = new List<AccessorLab.Antitela>();
        private readonly List<AccessorLab.Antitela> _lantitelas = new List<AccessorLab.Antitela>();
        private readonly List<AccessorLab.Antitela> _lantitelat = new List<AccessorLab.Antitela>();


        public UAnSokProstat()
        {
            InitializeComponent();
            _lantitela.Add(new AccessorLab.Antitela(0, "Нет значения"));
            _lantitela.Add(new AccessorLab.Antitela(1, "Небольшом"));
            _lantitela.Add(new AccessorLab.Antitela(2, "Умеренном"));
            _lantitela.Add(new AccessorLab.Antitela(3, "Большом"));
            _lantitelas.Add(new AccessorLab.Antitela(0, "Нет значения"));
            _lantitelas.Add(new AccessorLab.Antitela(1, "Единичные"));
            _lantitelas.Add(new AccessorLab.Antitela(2, "Небольшом"));
            _lantitelas.Add(new AccessorLab.Antitela(3, "Большом"));
            _lantitelat.Add(new AccessorLab.Antitela(0, "Нет значения"));
            _lantitelat.Add(new AccessorLab.Antitela(1, "Необнаружены"));
            _lantitelat.Add(new AccessorLab.Antitela(2, "Обнаружены"));

            repositoryItemLookUpEdit2.DataSource = _lantitela;
            repositoryItemLookUpEdit3.DataSource = _lantitelas;
            repositoryItemLookUpEdit4.DataSource = _lantitelat;

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

        public BindingNavigator BnSOKPROSTAT { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.SOKPROSTATs where c.pacient_id == PpacientID && c.otd == Potd select c);
            sOKPROSTATBindingSource.DataSource = res;
            mAZKINAFLORUGridControl.DataSource = sOKPROSTATBindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;
        }
 
        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            // Добавление
            int sel = gridView1.FocusedRowHandle;
            _kl = (SOKPROSTAT)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            var frm = new FrmAnSokProstat(sOKPROSTATBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);
        }
        public void InsertOrder(SOKPROSTAT o)
        {
            _db = new DataClassesLabDataContext();
            _db.SOKPROSTATs.InsertOnSubmit(o);
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
            _kl = (SOKPROSTAT)sOKPROSTATBindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmAnSokProstat(sOKPROSTATBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else sOKPROSTATBindingSource.CancelEdit();
        }

        private void SOkprostatBindingNavigatorSaveItemClick(object sender, EventArgs e)
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
 
    }
}
