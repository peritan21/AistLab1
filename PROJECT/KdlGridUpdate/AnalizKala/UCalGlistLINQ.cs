using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Windows.Forms;
using AistLabData;
using CustomControlLib;
using KdlForm.AnalizKala;

namespace KdlGridUpdate.AnalizKala
{
    public partial class UCalGlistLINQ : UserControl
    {
        private DataClassesLabDataContext _db;
        private KALGLIST _kl;
        private readonly List<AccessorLab.Antitela> _lantitela = new List<AccessorLab.Antitela>();
        public UCalGlistLINQ()
        {
            InitializeComponent();
            _lantitela.Add(new AccessorLab.Antitela(0, "нет значения"));
            _lantitela.Add(new AccessorLab.Antitela(1, "необнаружено"));
            _lantitela.Add(new AccessorLab.Antitela(2, "обнаружено"));
            repositoryItemLookUpEdit3.DataSource = _lantitela;
         }
        public int PpacientID
        { set; get; }
        public int PlaborantID
        { get; set; }
        public int Potd
        { get; set; }
        public string PFIO { get; set; }
        public string PZAGOLOVOK { get; set; }
        public List<LABORANT> Llaboranth
        { get; set; }

        public BindingNavigator BnKALGLIST { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
           var res =(from c in _db.KALGLISTs where c.pacient_id== PpacientID  && c.otd==Potd select c);
           kALGLISTBindingSource.DataSource =res;
           mAZKINAFLORUGridControl.DataSource = kALGLISTBindingSource;
           repositoryItemLookUpEdit1.DataSource = Llaboranth;
        }
        private void SubmitChangesClick(object sender, EventArgs e)
        {
            //Causes the control container to validate and end editing.
            TablFormUpdate();
        }

        private void TablFormUpdate()
        {
            Validate();
            try
            {
                // ConflictMode is an optional parameter.
                _db.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException)
            {
                // Get conflict information, and take actions
                // that are appropriate for your application.
                // See MSDN Article How to: Manage Change Conflicts (LINQ to SQL).
            }

            //db.SubmitChanges();
        }

  

        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            UpdateAnaliz();
        }

        public void UpdateAnaliz()
        {
            // Редактирование
            _kl = (KALGLIST)kALGLISTBindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmCalglistLINQ(kALGLISTBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else kALGLISTBindingSource.CancelEdit();
        }

        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            int sel = gridView1.FocusedRowHandle;
             _kl = (KALGLIST)gridView1.GetRow(sel);
             _kl.data = DateTime.Now;
             _kl.datatek = DateTime.Now;
             _kl.pacient_id = PpacientID;
             _kl.laborant_id = PlaborantID;
             _kl.otd = Potd;
             _kl.prosteihie = 1;
             _kl.prosteihiekol = 0;
             _kl.eglist = 1;
             _kl.eglistkol = 0;
            var frm = new FrmCalglistLINQ(kALGLISTBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);
        }
        public void InsertOrder(KALGLIST o)
        {
            _db = new DataClassesLabDataContext();
            //db.KALGLISTs.Attach(o, false);
            _db.KALGLISTs.InsertOnSubmit(o);
            // Exception handling not shown.
            try
            {
                // ConflictMode is an optional parameter.
                _db.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException)
            {
                // Get conflict information, and take actions
                // that are appropriate for your application.
                // See MSDN Article How to: Manage Change Conflicts (LINQ to SQL).
            }

        }
     

    }
}
