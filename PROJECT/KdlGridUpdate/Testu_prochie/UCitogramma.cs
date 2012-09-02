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
    public partial class UCitogramma : UserControl
    {
        private CITOGRAMMA _kl;
        private DataClassesLabDataContext _db;
        private readonly List<AccessorLab.Antitela> _lantitela = new List<AccessorLab.Antitela>();
        private readonly List<AccessorLab.Antitela> _lantitelas = new List<AccessorLab.Antitela>();
        private readonly List<AccessorLab.Antitela> _lantiteladrugie = new List<AccessorLab.Antitela>();
  

        public UCitogramma()
        {
            InitializeComponent();
            _lantitela.Add(new AccessorLab.Antitela(0, "нет значения"));
            _lantitela.Add(new AccessorLab.Antitela(1, "адекватный"));
            _lantitela.Add(new AccessorLab.Antitela(2, "недостаточно адекватный"));
            _lantitela.Add(new AccessorLab.Antitela(3, "неадекватный"));
            _lantitelas.Add(new AccessorLab.Antitela(0, "нет значения"));
            _lantitelas.Add(new AccessorLab.Antitela(1, "без особенностей"));
            _lantitelas.Add(new AccessorLab.Antitela(2, "атрофический тип мазка"));
            _lantitelas.Add(new AccessorLab.Antitela(3, "эстрогенный тип мазка"));
            _lantitelas.Add(new AccessorLab.Antitela(4, "пролиферанции (гиперилазии) железистого эпителия"));
            _lantitelas.Add(new AccessorLab.Antitela(5, "гиперкератозу плоского эпителия"));
            _lantitelas.Add(new AccessorLab.Antitela(6, "воспалительному процессу слизистой оболочки"));
            _lantitelas.Add(new AccessorLab.Antitela(7, "бактериальному вагинозу"));
            _lantitelas.Add(new AccessorLab.Antitela(8, "атрофическому кольпиту"));
            _lantitelas.Add(new AccessorLab.Antitela(9, "легкой дисплазии"));
            _lantitelas.Add(new AccessorLab.Antitela(10, "умеренной дисплазии"));
            _lantitelas.Add(new AccessorLab.Antitela(11, "тяжелой дисплазии"));
            _lantitelas.Add(new AccessorLab.Antitela(12, "раку"));
            _lantitelas.Add(new AccessorLab.Antitela(13, "изменениям характерным для папилломавирусной инфекции"));
            _lantitelas.Add(new AccessorLab.Antitela(14, "коккобацилярная флора"));
            _lantitelas.Add(new AccessorLab.Antitela(15, "вирус Herpes Simpl -обнаружен"));
            //====
            _lantiteladrugie.Add(new AccessorLab.Antitela(0, "нет значения"));
            _lantiteladrugie.Add(new AccessorLab.Antitela(1, "атрофический тип мазка"));
            _lantiteladrugie.Add(new AccessorLab.Antitela(2, "эстрогенный тип мазка"));
            _lantiteladrugie.Add(new AccessorLab.Antitela(3, "пролиферанции (гиперилазии) железистого эпителия"));
            _lantiteladrugie.Add(new AccessorLab.Antitela(4, "гиперкератозу плоского эпителия"));
            _lantiteladrugie.Add(new AccessorLab.Antitela(5, "воспалительному процессу слизистой оболочки"));
            _lantiteladrugie.Add(new AccessorLab.Antitela(6, "бактериальному вагинозу"));
            _lantiteladrugie.Add(new AccessorLab.Antitela(7, "атрофическому кольпиту"));
            _lantiteladrugie.Add(new AccessorLab.Antitela(8, "легкой дисплазии"));
            _lantiteladrugie.Add(new AccessorLab.Antitela(9, "умеренной дисплазии"));
            _lantiteladrugie.Add(new AccessorLab.Antitela(10, "тяжелой дисплазии"));
            _lantiteladrugie.Add(new AccessorLab.Antitela(11, "раку"));
            _lantiteladrugie.Add(new AccessorLab.Antitela(12, "изменениям характерным для папилломавирусной инфекции"));
            _lantiteladrugie.Add(new AccessorLab.Antitela(13, "коккобацилярная флора"));
            _lantiteladrugie.Add(new AccessorLab.Antitela(14, "вирус Herpes Simpl -обнаружен"));
            //=====
            repositoryItemLookUpEdit2.DataSource = _lantitela;
            repositoryItemLookUpEdit3.DataSource = _lantitelas;
            repositoryItemLookUpEdit4.DataSource = _lantiteladrugie;

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

        public BindingNavigator BnCITOGRAMMA { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.CITOGRAMMAs where c.pacient_id == PpacientID && c.otd == Potd select c);
            cITOGRAMMABindingSource.DataSource = res;
            mAZKINAFLORUGridControl.DataSource = cITOGRAMMABindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;
        }
 
        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            // Добавление
            int sel = gridView1.FocusedRowHandle;
            _kl = (CITOGRAMMA)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            var frm = new FrmCitogram(cITOGRAMMABindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);
        }
        public void InsertOrder(CITOGRAMMA o)
        {
            _db = new DataClassesLabDataContext();
            _db.CITOGRAMMAs.InsertOnSubmit(o);
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
            _kl = (CITOGRAMMA)cITOGRAMMABindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmCitogram(cITOGRAMMABindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else cITOGRAMMABindingSource.CancelEdit();
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
