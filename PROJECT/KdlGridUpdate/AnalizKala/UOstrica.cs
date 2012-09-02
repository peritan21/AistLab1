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
    public partial class UOstrica : UserControl
    {
        private KALOSTRICPERIANAL _kl;
        private DataClassesLabDataContext _db;
        private readonly List<AccessorLab.Antitela> _lantitela = new List<AccessorLab.Antitela>();

        public UOstrica()
        {
            InitializeComponent();
            _lantitela.Add(new AccessorLab.Antitela(0, "нет значения"));
            _lantitela.Add(new AccessorLab.Antitela(1, "необнаружно"));
            _lantitela.Add(new AccessorLab.Antitela(2, "обнаружно"));
           
            //   
            //lantitela.Add(new AccessorLab.Antitela(1, "0.05 - 0.15"));
            //lantitela.Add(new AccessorLab.Antitela(2, "0.2   - 0.4"));
            //lantitela.Add(new AccessorLab.Antitela(3, "0.5  -  0.75"));
            //lantitela.Add(new AccessorLab.Antitela(4, "1     -  1.65"));
            //lantitela.Add(new AccessorLab.Antitela(5, "2   и выше"));
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

        public BindingNavigator BnKALOSTRICPERIANAL { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.KALOSTRICPERIANALs where c.pacient_id == PpacientID && c.otd == Potd select c);
            kALOSTRICPERIANALBindingSource.DataSource = res;
            kRSAHARGridControl.DataSource = kALOSTRICPERIANALBindingSource;
            repositoryItemLookUpEdit1.DataSource=Llaboranth;
        }
 
        private void KAlostricperianalBindingNavigatorSaveItemClick(object sender, EventArgs e)
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
            _kl = (KALOSTRICPERIANAL)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            _kl.eostric = 1;
           // db.KALOSTRICPERIANALs.InsertOnSubmit(kl);
            var frm = new FrmKalOstric(kALOSTRICPERIANALBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);
        }
        public void InsertOrder(KALOSTRICPERIANAL o)
        {
            _db = new DataClassesLabDataContext();
            _db.KALOSTRICPERIANALs.InsertOnSubmit(o);
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
            _kl = (KALOSTRICPERIANAL)kALOSTRICPERIANALBindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmKalOstric(kALOSTRICPERIANALBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else kALOSTRICPERIANALBindingSource.CancelEdit();
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
