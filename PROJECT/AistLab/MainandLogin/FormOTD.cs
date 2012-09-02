using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using CustomControlLib;
using System.Data.Linq;

namespace AistLab.MainandLogin
{
    public partial class FormOTD : DevExpress.XtraEditors.XtraForm
    {
        private OTD _kl;
        private DataClassesLabDataContext _db;
        private readonly List<AccessorLab.ProfilOTD> _lprofotd = new List<AccessorLab.ProfilOTD>();
        private readonly List<AccessorLab.ProfilOTD> _lxozraschet = new List<AccessorLab.ProfilOTD>();
        public FormOTD()
        {
            InitializeComponent();
        }

        private void OTdBindingNavigatorSaveItemClick(object sender, EventArgs e)
        {
            TablFormUpdate();
        }
        private void TablFormUpdate()
        {
            //Validate();
            //_db.SubmitChanges();
            Validate();
            try
            {
                _db.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException)
            {
            }
        }
        public void InsertOrder(OTD o)
        {
            _db = new DataClassesLabDataContext();
            _db.OTDs.InsertOnSubmit(o);
            try
            {
                _db.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException)
            {
            }
        }
        private void FormOTDLoad(object sender, EventArgs e)
        {
  
            _lprofotd.Add(new AccessorLab.ProfilOTD(0, "Амбулаторное"));
            _lprofotd.Add(new AccessorLab.ProfilOTD(1, "Стационарное"));
            _lxozraschet.Add(new AccessorLab.ProfilOTD(0, "ОМС"));
            _lxozraschet.Add(new AccessorLab.ProfilOTD(1, "ДМС"));
            _lxozraschet.Add(new AccessorLab.ProfilOTD(2, "Хозрасчетное"));
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.OTDs  select c);
            oTDBindingSource.DataSource = res;
            gridControl1.DataSource = oTDBindingSource;
            repositoryItemLookUpEdit1.DataSource = _lprofotd;
            repositoryItemLookUpEdit2.DataSource = _lxozraschet;
        }

 
        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ToolStripButton2Click(object sender, EventArgs e)
        {
            // Редактирование
            int sel = gridView1.FocusedRowHandle;
            _kl = (OTD)oTDBindingSource[sel];
            if (_kl == null) return;
     
            var frm = new FormOTDNAME(oTDBindingSource);
            // frm.Parent = this;
            if (DialogResult.OK == frm.ShowDialog())
            {
                oTDBindingSource.EndEdit();
                TablFormUpdate();
            }
            else oTDBindingSource.CancelEdit();
        }

        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            // Добавление
            int sel = gridView1.FocusedRowHandle;
            _kl = (OTD)gridView1.GetRow(sel);
            _kl.kod_otd = "";
            _kl.name_otdsokr = "";
            _kl.name_otd = "";
           // kl.kod_otdel = "";
            _kl.tip_otd = "";
            _kl.kol_koek = 0;
            _kl.kod_prof = "";
            _kl.etap = 0;
            _kl.plan_kg = 0;
            _kl.srdl = 0;
            _kl.priznakstac = 0;
            var frm = new FormOTDNAME(oTDBindingSource);
            // frm.Parent = this;
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else gridView1.DeleteRow(sel);
        }

     

        private void ToolStripButton3Click(object sender, EventArgs e)
        {
            //  Удаление отделения
            int sel = gridView1.FocusedRowHandle;
            _kl = (OTD)gridView1.GetRow(sel);
            var ressum = from c in _db.PACIENTPPCs where c.otd_id == _kl.otd_id select c;
            int lccountanaliz = ressum.Count();
            if (lccountanaliz > 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Удалять запись нельзя. Необходимо удалить записи  пациентов по этому отделению !!! ");
                return;
            }
            if (_kl == null) return;
            _db.OTDDel(_kl.otd_id);
            var res = (from c in _db.OTDs select c);
            oTDBindingSource.DataSource = null;
            oTDBindingSource.DataSource = res;
            //koldetei = resdeti.Count();
            gridControl1.DataSource = null;
            gridControl1.DataSource = oTDBindingSource;
        }

    }
}