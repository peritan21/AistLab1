﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using KdlForm.Testu_prochie;

namespace KdlGridUpdate.Testu_prochie
{
    public partial class UAspiratOnkocit : UserControl
    {
        private ASPIRATONKOCIT _kl;
        private DataClassesLabDataContext _db;


        public UAspiratOnkocit()
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

        public BindingNavigator BnASPIRATONKOCIT { get; set; }

        public void InitSQLData()
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.ASPIRATONKOCITs where c.pacient_id == PpacientID && c.otd == Potd select c);
            cITOGRAMMABindingSource.DataSource = res;
            mAZKINAFLORUGridControl.DataSource = cITOGRAMMABindingSource;
            repositoryItemLookUpEdit1.DataSource = Llaboranth;
        }
 
        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            // Добавление
            int sel = gridView1.FocusedRowHandle;
            _kl = (ASPIRATONKOCIT)gridView1.GetRow(sel);
            _kl.data = DateTime.Now;
            _kl.datatek = DateTime.Now;
            _kl.pacient_id = PpacientID;
            _kl.laborant_id = PlaborantID;
            _kl.otd = Potd;
            var frm = new FrmAspiratOnkolog(cITOGRAMMABindingSource) {Llabanaliz = Llaboranth};
            frm.Text += "  " + PFIO;
            frm.PZAGOLOVOK0 = PZAGOLOVOK;
            frm.InitLookup();
            if (DialogResult.OK == frm.ShowDialog())
            {
                InsertOrder(_kl);
            }
            else if (sel > 0) gridView1.DeleteRow(sel);
        }
        public void InsertOrder(ASPIRATONKOCIT o)
        {
            _db = new DataClassesLabDataContext();
            _db.ASPIRATONKOCITs.InsertOnSubmit(o);
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
            _kl = (ASPIRATONKOCIT)cITOGRAMMABindingSource.Current;
            if (_kl == null) return;
            var frm = new FrmAspiratOnkolog(cITOGRAMMABindingSource) {Llabanaliz = Llaboranth};
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
