using System;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using CustomControlLib;
using System.Collections.Generic;
using System.Data.Linq;
using System.ComponentModel;

namespace AistLab
{
    public partial class FormVrachLaborant : DevExpress.XtraEditors.XtraForm
    {
        private VRACHLABORANT _kl;
        private List<AccessorLab.Viborlaborant> laborantvib = new List<AccessorLab.Viborlaborant>();
        //private BindingList<AccessorLab.Vrachlaborant> ldnevnik = new BindingList<AccessorLab.Vrachlaborant>();
        private DataClassesLabDataContext _db;
        private readonly List<AccessorLab.Antitela> _lantitela = new List<AccessorLab.Antitela>();
        //System.Data.Linq.Binary lcpwd;
        public FormVrachLaborant()
        {
            InitializeComponent();
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.LABORANTs select c);
            foreach (var t in res)
            {
                laborantvib.Add(new AccessorLab.Viborlaborant(t.laborant_id,t.fio,t.dlg,false));
            }
             _lantitela.Add(new AccessorLab.Antitela(0, "Лаборант"));
            _lantitela.Add(new AccessorLab.Antitela(1, "Врач"));
        }

        private void LAborantBindingNavigatorSaveItemClick(object sender, EventArgs e)
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

        private void FormLaborantLoad(object sender, EventArgs e)
        {

            InitSQLTable();
          //  this.lABORANTTableAdapter.Fill(this.dataSetLab.LABORANT);
        }

        private void InitSQLTable()
        {
            _db = new DataClassesLabDataContext();
            var resvrachlab = (from c in _db.VRACHLABORANTs join l in _db.LABORANTs on c.laborant_id equals l.laborant_id select c);
            lABORANTBindingSource.DataSource = resvrachlab;
            lABORANTGridControl.DataSource = lABORANTBindingSource;
            repositoryItemLookUpEdit1.DataSource = _lantitela;
            repositoryItemLookUpEdit2.DataSource = laborantvib;
        }

  
        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
                    var frm1 = new FormLABORANTvibor();
          //  frm1.Parent = this;
            frm1.Llaborant = laborantvib;
            frm1.InitLookup();
            if (DialogResult.OK == frm1.ShowDialog())
            {
                foreach (var t in frm1.LlaborantVib)
                {
                    VRACHLABORANT p=new VRACHLABORANT();
                    p.laborant_id = t.Laborantid;
                    p.priznak = 0;
                    InsertOrder(p);
                }
            }
          InitSQLTable();
        }
        public void InsertOrder(VRACHLABORANT o)
        {
            _db = new DataClassesLabDataContext();
            _db.VRACHLABORANTs.InsertOnSubmit(o);
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
            //int sel = gridView1.FocusedRowHandle;
            //_kl = (LABORANT)lABORANTBindingSource[sel];
            //if (_kl == null) return;
            //var frm = new FormLabFIO(lABORANTBindingSource);
            //// frm.Parent = this;
            //if (DialogResult.OK == frm.ShowDialog())
            //{
            //    //this.kRGRUPREZBindingSource.EndEdit();
            //    TablFormUpdate();
            //}
            //else lABORANTBindingSource.CancelEdit();
        }

        private void ToolStripButton2Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}