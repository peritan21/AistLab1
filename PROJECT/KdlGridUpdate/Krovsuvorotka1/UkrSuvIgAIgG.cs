﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using KdlForm.Krsuvorotka1;

namespace KdlGridUpdate.Krovsuvorotka1
{
    public partial class UkrSuvIgMigG : UserControl
    {
        private KRSIMMUNIgAIgMIgGIgE _kl;
        private DataClassesLabDataContext _db;
  
        public UkrSuvIgMigG()
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

        public BindingNavigator BnKrsimmunigAigMigGigE { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.KRSIMMUNIgAIgMIgGIgEs where c.pacient_id == PpacientID && c.otd == Potd select c);
            kRSIMMUNIgAIgMIgGIgEBindingSource.DataSource = res;
            kRSAHARGridControl.DataSource = kRSIMMUNIgAIgMIgGIgEBindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;
          }
      
  

        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            UpdateAnaliz();
        }

        public void UpdateAnaliz()
        {
            // Редактирование
            _kl = (KRSIMMUNIgAIgMIgGIgE)kRSIMMUNIgAIgMIgGIgEBindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmKrSImmunIgAigMigGigE(kRSIMMUNIgAIgMIgGIgEBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                //this.kRBIOHIMIIBindingSource.EndEdit();
                TablFormUpdate();
            }
            else kRSIMMUNIgAIgMIgGIgEBindingSource.CancelEdit();
        }

        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            // Добавление
            int sel = gridView1.FocusedRowHandle;
            _kl = (KRSIMMUNIgAIgMIgGIgE)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            var frm = new FrmKrSImmunIgAigMigGigE(kRSIMMUNIgAIgMIgGIgEBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);
        }
        public void InsertOrder(KRSIMMUNIgAIgMIgGIgE o)
        {
            _db = new DataClassesLabDataContext();
            _db.KRSIMMUNIgAIgMIgGIgEs.InsertOnSubmit(o);
            try
            {
                _db.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException)
            {
            }
        }
        private void KRsimmunigAigMigGigEBindingNavigatorSaveItemClick(object sender, EventArgs e)
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
