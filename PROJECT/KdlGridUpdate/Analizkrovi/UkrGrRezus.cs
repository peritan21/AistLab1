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
    public partial class UkrGrRezus : UserControl
    {
        private KRGRUPREZ _kl;
        private DataClassesLabDataContext _db;
        private readonly List<AccessorLab.Gruppakrovi> _grupkrovm = new List<AccessorLab.Gruppakrovi>();
        private readonly List<AccessorLab.Rezusfaktor> _lrezus = new List<AccessorLab.Rezusfaktor>();
        private readonly List<AccessorLab.Antitela> _lantitela = new List<AccessorLab.Antitela>();
        private readonly List<AccessorLab.Antitela> _lkumbsa = new List<AccessorLab.Antitela>();

        public UkrGrRezus()
        {
            InitializeComponent();
          //  InitSQLData();
        }
        public int PpacientId
       { get; set; }
        public int PlaborantId
        { get; set; }
        public int Potd
        { get; set; }
        public string PFIO { get; set; }
        public string PZAGOLOVOK { get; set; }
        public List<LABORANT> Llaboranth
        { get; set; }

        public BindingNavigator BnKrgruprez { get; set; }

        public void InitSqlData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.KRGRUPREZs where c.pacient_id == PpacientId && c.otd == Potd select c);
            kRGRUPREZBindingSource.DataSource = res;
            if (kRGRUPREZGridControl != null) kRGRUPREZGridControl.DataSource = kRGRUPREZBindingSource;
            repositoryItemLookUpEdit4.DataSource = Llaboranth;
        }
        private void KRgruprezBindingNavigatorSaveItemClick(object sender, EventArgs e)
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
            int sel = gridView1.FocusedRowHandle;
            _kl = (KRGRUPREZ)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientId;
            _kl.laborant_id = PlaborantId;
            _kl.otd = Potd;
            using (var frm = new FrmRekvLaborant(kRGRUPREZBindingSource))
            {
                frm.Llabanaliz = Llaboranth;
                frm.Text += "  " + PFIO;
                frm.InitLookup();
                if (DialogResult.OK == frm.ShowDialog())
                {
                    InsertOrder(_kl);
                }
                else if (sel > 0) gridView1.DeleteRow(sel);
            }
        }
        public void InsertOrder(KRGRUPREZ o)
        {
            _db = new DataClassesLabDataContext();
            _db.KRGRUPREZs.InsertOnSubmit(o);
            try
            {
                _db.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException)
            {
            }
        } 

        private void UkrGrRezusLoad(object sender, EventArgs e)
        {
            _grupkrovm.Add(new AccessorLab.Gruppakrovi(0, "нет значения"));
            _grupkrovm.Add(new AccessorLab.Gruppakrovi(1, "Первая О(I)"));
            _grupkrovm.Add(new AccessorLab.Gruppakrovi(2, "Вторая А(II)"));
            _grupkrovm.Add(new AccessorLab.Gruppakrovi(3, "Третья В(III)"));
            _grupkrovm.Add(new AccessorLab.Gruppakrovi(4, "Четвертая АВ(IV)"));
            _grupkrovm.Add(new AccessorLab.Gruppakrovi(5, "Вторая А2(II)"));
            _grupkrovm.Add(new AccessorLab.Gruppakrovi(6, "Четвертая А2В(IV)"));
            _lrezus.Add(new AccessorLab.Rezusfaktor(0, "нет значения"));
            _lrezus.Add(new AccessorLab.Rezusfaktor(1, "Rh(положительный)"));
            _lrezus.Add(new AccessorLab.Rezusfaktor(2, "Rh(отрицательный)"));
            _lrezus.Add(new AccessorLab.Rezusfaktor(3, "Слабо положительный Du "));
            _lantitela.Add(new AccessorLab.Antitela(0, "нет значения"));
            _lantitela.Add(new AccessorLab.Antitela(1, "Отрицательные"));
            _lantitela.Add(new AccessorLab.Antitela(2, "Положительные"));
            _lkumbsa.Add(new AccessorLab.Antitela(0, "нет значения"));
            _lkumbsa.Add(new AccessorLab.Antitela(1, "Отрицательная"));
            _lkumbsa.Add(new AccessorLab.Antitela(2, "Положительная"));
            repositoryItemLookUpEdit1.DataSource = _grupkrovm;
            repositoryItemLookUpEdit2.DataSource = _lrezus;
            repositoryItemLookUpEdit3.DataSource = _lantitela;
            repositoryItemLookUpEdit5.DataSource = _lkumbsa;
        }

        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            UpdateAnaliz();
        }

        public void UpdateAnaliz()
        {
            if (kRGRUPREZBindingSource != null)
            {
                _kl = (KRGRUPREZ)kRGRUPREZBindingSource.Current;
                if (_kl == null) return;
                using (var frm = new FrmRekvLaborant(kRGRUPREZBindingSource))
                {
                    frm.Llabanaliz = Llaboranth;
                    frm.Text += "  " + PFIO;
                    frm.PZAGOLOVOK0 = PZAGOLOVOK;
                    frm.InitLookup();
                    if (DialogResult.OK == frm.ShowDialog())
                    {
                        //this.kRGRUPREZBindingSource.EndEdit();
                        TablFormUpdate();
                    }
                    else kRGRUPREZBindingSource.CancelEdit();
                }
            }
        }

    
    }
}
