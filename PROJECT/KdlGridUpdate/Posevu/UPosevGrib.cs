using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using CustomControlLib;
using KdlForm.Posevu;

namespace KdlGridUpdate.Posevu
{
    public partial class UPosevGrib : UserControl
    {
        private POSEVGRIB _kl;
        private DataClassesLabDataContext _db;
        private readonly List<AccessorLab.Antitela> _lantitela = new List<AccessorLab.Antitela>();

        public UPosevGrib()
        {
            InitializeComponent();
            _lantitela.Add(new AccessorLab.Antitela(0, "нет значения"));
            _lantitela.Add(new AccessorLab.Antitela(1, "необнаружено"));
            _lantitela.Add(new AccessorLab.Antitela(2, "обнаружено"));
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

        public BindingNavigator BnPOSEVGRIB { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.POSEVGRIBs where c.pacient_id == PpacientID  &&  c.otd == Potd select c);
            pOSEVGRIBBindingSource.DataSource = res;
            kRSAHARGridControl.DataSource = pOSEVGRIBBindingSource;
            repositoryItemLookUpEdit1.DataSource=Llaboranth;
            repositoryItemLookUpEdit2.DataSource = _lantitela;
        }
   
   
        private void POsevgribBindingNavigatorSaveItemClick(object sender, EventArgs e)
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
            _kl = (POSEVGRIB)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            var frm = new FrmPosevGrib(pOSEVGRIBBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);
        }
        public void InsertOrder(POSEVGRIB o)
        {
            _db = new DataClassesLabDataContext();
            _db.POSEVGRIBs.InsertOnSubmit(o);
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
            _kl = (POSEVGRIB)pOSEVGRIBBindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmPosevGrib(pOSEVGRIBBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else pOSEVGRIBBindingSource.CancelEdit();
        }

    
    }
}
