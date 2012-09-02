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
    public partial class UImmunTest : UserControl
    {
        private IMUNTEST _kl;
        private DataClassesLabDataContext _db;
        private readonly List<AccessorLab.Tkscs> _ltkscs = new List<AccessorLab.Tkscs>();

        public UImmunTest()
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

        public BindingNavigator BnIMUNTEST { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.IMUNTESTs where c.pacient_id == PpacientID && c.otd == Potd select c);
            iMUNTESTBindingSource.DataSource = res;
            iMUNTESTGridControl.DataSource = iMUNTESTBindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;
            _ltkscs.Add(new AccessorLab.Tkscs(0, "нет значения"));
            _ltkscs.Add(new AccessorLab.Tkscs(1, "отличный"));
            _ltkscs.Add(new AccessorLab.Tkscs(2, "удовлетворительный"));
            _ltkscs.Add(new AccessorLab.Tkscs(3, "плохой"));
            _ltkscs.Add(new AccessorLab.Tkscs(4, "сомнительный"));
            _ltkscs.Add(new AccessorLab.Tkscs(5, "отрицательный"));
            repositoryItemLookUpEdit2.DataSource = _ltkscs;
            repositoryItemLookUpEdit3.DataSource = _ltkscs;
        }
        private void MuntestBindingNavigatorSaveItemClick(object sender, EventArgs e)
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
            // Добавление
            int sel = gridView1.FocusedRowHandle;
            _kl = (IMUNTEST)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            _kl.tkczc = 0;
            _kl.pkt = 0;
            var frm = new FrmImunTest(iMUNTESTBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);
        }
        public void InsertOrder(IMUNTEST o)
        {
            _db = new DataClassesLabDataContext();
            _db.IMUNTESTs.InsertOnSubmit(o);
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
            //if (iMUNTESTBindingSource.Count == 0) return;
            _kl = (IMUNTEST)iMUNTESTBindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmImunTest(iMUNTESTBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else iMUNTESTBindingSource.CancelEdit();
        }
 
    
    }
}
