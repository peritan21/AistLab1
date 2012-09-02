using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using KdlForm.Krsuvorotka1;

namespace KdlGridUpdate.Krovsuvorotka1
{
    public partial class UkrSuv01Astra : UserControl
    {
        private KROPBFSMUEFASTRA _kl;
        private DataClassesLabDataContext _db;
        public UkrSuv01Astra()
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

        public BindingNavigator BnKROPBFSMUEFASTRA { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.KROPBFSMUEFASTRAs where c.pacient_id == PpacientID && c.otd == Potd select c);
            kROPBFSMUEFASTRABindingSource.DataSource = res;
            kRSAHARGridControl.DataSource = kROPBFSMUEFASTRABindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;
          }
      
   

        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            UpdateAnaliz();
        }

        public void UpdateAnaliz()
        {
            // Редактирование
            _kl = (KROPBFSMUEFASTRA)kROPBFSMUEFASTRABindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmKRopSMetelektUEFAstra(kROPBFSMUEFASTRABindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                //this.kRBIOHIMIIBindingSource.EndEdit();
                TablFormUpdate();
            }
            else kROPBFSMUEFASTRABindingSource.CancelEdit();
        }

        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            // Добавление
            int sel = gridView1.FocusedRowHandle;
            _kl = (KROPBFSMUEFASTRA)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            var frm = new FrmKRopSMetelektUEFAstra(kROPBFSMUEFASTRABindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);
        }
        public void InsertOrder(KROPBFSMUEFASTRA o)
        {
            _db = new DataClassesLabDataContext();
            _db.KROPBFSMUEFASTRAs.InsertOnSubmit(o);
            try
            {
                _db.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException)
            {
            }
        }
        private void KRopbfsmuefastraBindingNavigatorSaveItemClick(object sender, EventArgs e)
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
