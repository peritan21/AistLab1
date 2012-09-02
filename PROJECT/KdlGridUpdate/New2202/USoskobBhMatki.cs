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
    public partial class USoskobBhmatki : UserControl
    {
        private SOSKOBHEIMATKI _kl;
        private DataClassesLabDataContext _db;
        private readonly List<AccessorLab.Antitela> _lantitela = new List<AccessorLab.Antitela>();

        public USoskobBhmatki()
        {
            InitializeComponent();
            _lantitela.Add(new AccessorLab.Antitela(0, "нет значения"));
            _lantitela.Add(new AccessorLab.Antitela(1, "без особенностей"));
            _lantitela.Add(new AccessorLab.Antitela(2, "атрофический тип мазка"));
            _lantitela.Add(new AccessorLab.Antitela(3, "эстрогенный тип м."));
            _lantitela.Add(new AccessorLab.Antitela(4, "пролифирации жел.эпит."));
            _lantitela.Add(new AccessorLab.Antitela(5, "гиперкератозу плоск.эпит."));
            _lantitela.Add(new AccessorLab.Antitela(6, "воспалит.процес.лейкоц."));
            _lantitela.Add(new AccessorLab.Antitela(7, "бактериальному вагинозу"));
            _lantitela.Add(new AccessorLab.Antitela(8, "атрофическому кольпиту"));
            _lantitela.Add(new AccessorLab.Antitela(9, "легкой дисплазии"));
            _lantitela.Add(new AccessorLab.Antitela(10, "измен.хар.для папилломавирусной инф."));
            _lantitela.Add(new AccessorLab.Antitela(11, "умеренной дисплазии"));
            _lantitela.Add(new AccessorLab.Antitela(12, "тяжолой дисплазии"));
            _lantitela.Add(new AccessorLab.Antitela(13, "раку"));
            _lantitela.Add(new AccessorLab.Antitela(14, "клеточ.состав не обнаружен"));
            _lantitela.Add(new AccessorLab.Antitela(15, "материал взят плохо"));
            _lantitela.Add(new AccessorLab.Antitela(16, "кокобацилярная флора"));
            repositoryItemLookUpEdit4.DataSource = _lantitela;
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

        public BindingNavigator BnSOSKOBHEIMATKI { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.SOSKOBHEIMATKIs where c.pacient_id == PpacientID && c.otd == Potd select c);
            sOSKOBHEIMATKIBindingSource.DataSource = res;
            iMUNTESTGridControl.DataSource = sOSKOBHEIMATKIBindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;

        }
  

         private void SOskobheimatkiBindingNavigatorSaveItemClick(object sender, EventArgs e)
        {
            TablFormUpdate();
        }
        private void TablFormUpdate()
        {
            Validate();
            _db.SubmitChanges();
        }

        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            UpdateAnaliz();
        }

        public void UpdateAnaliz()
        {
            // Редактирование
            _kl = (SOSKOBHEIMATKI)sOSKOBHEIMATKIBindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmSoskobHMatki(sOSKOBHEIMATKIBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else sOSKOBHEIMATKIBindingSource.CancelEdit();
        }
        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            // Добавление
            int sel = gridView1.FocusedRowHandle;
            _kl = (SOSKOBHEIMATKI)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            var frm = new FrmSoskobHMatki(sOSKOBHEIMATKIBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);
        }
        public void InsertOrder(SOSKOBHEIMATKI o)
        {
            _db = new DataClassesLabDataContext();
            _db.SOSKOBHEIMATKIs.InsertOnSubmit(o);
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
