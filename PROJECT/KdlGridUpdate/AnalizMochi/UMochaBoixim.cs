﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using KdlForm.AnalizMochi;

namespace KdlGridUpdate.AnalizMochi
{
    public partial class UMochaBoixim : UserControl
    {
        private MOHABIOHIM _kl;
        private DataClassesLabDataContext _db;
        public UMochaBoixim()
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

        public BindingNavigator BnMOHABIOHIM { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.MOHABIOHIMs where c.pacient_id == PpacientID && c.otd == Potd select c);
            mOHABIOHIMBindingSource.DataSource = res;
            mOHABIOHIMGridControl.DataSource = mOHABIOHIMBindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;
        }
  
        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            // Добавление 
            int sel = gridView1.FocusedRowHandle;
            _kl = (MOHABIOHIM)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            var frm = new FrmMohaBiohim(mOHABIOHIMBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                mOHABIOHIMBindingSource.EndEdit();
                TablFormUpdate();
            }
            else if (sel > 0) gridView1.DeleteRow(sel);
        }
        public void InsertOrder(MOHABIOHIM o)
        {
            _db = new DataClassesLabDataContext();
            _db.MOHABIOHIMs.InsertOnSubmit(o);
            try
            {
                _db.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException)
            {
            }
        }
        private void MOhabiohimBindingNavigatorSaveItemClick(object sender, EventArgs e)
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
        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            UpdateAnaliz();
        }

        public void UpdateAnaliz()
        {
            // Редактирование, просмотр 
            _kl = (MOHABIOHIM)mOHABIOHIMBindingSource.Current; 
            if (_kl == null) return;
            var frm = new FrmMohaBiohim(mOHABIOHIMBindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                TablFormUpdate();
            }
            else mOHABIOHIMBindingSource.CancelEdit();
        }

    }
}
