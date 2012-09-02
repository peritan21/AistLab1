using System;
using System.Linq;
using System.Windows.Forms;
using AistLabData;

namespace AistLab
{
    public partial class FormLaborant : DevExpress.XtraEditors.XtraForm
    {
        private LABORANT _kl;
        private DataClassesLabDataContext _db;
        //System.Data.Linq.Binary lcpwd;
        public FormLaborant()
        {
            InitializeComponent();
        }

        private void LAborantBindingNavigatorSaveItemClick(object sender, EventArgs e)
        {
            TablFormUpdate();

        }

        private void TablFormUpdate()
        {
            Validate();
            _db.SubmitChanges();
        }

        private void FormLaborantLoad(object sender, EventArgs e)
        {
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.LABORANTs  select c);
            lABORANTBindingSource.DataSource = res;
            lABORANTGridControl.DataSource = lABORANTBindingSource;
          //  this.lABORANTTableAdapter.Fill(this.dataSetLab.LABORANT);
        }

  
        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            int sel = gridView1.FocusedRowHandle;
            _kl = (LABORANT)gridView1.GetRow(sel);
            _kl.fio1 = "";
            _kl.fio2 = "";
            _kl.fio3 = "";
            _kl.dlg = "";
            var frm = new FormLabFIO(lABORANTBindingSource);
            // frm.Parent = this;
            if (DialogResult.OK == frm.ShowDialog())
            {
                lABORANTBindingSource.EndEdit();
                TablFormUpdate();
            }
            else gridView1.DeleteRow(sel);
        }
        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            int sel = gridView1.FocusedRowHandle;
            _kl = (LABORANT)lABORANTBindingSource[sel];
            if (_kl == null) return;
            var frm = new FormLabFIO(lABORANTBindingSource);
            // frm.Parent = this;
            if (DialogResult.OK == frm.ShowDialog())
            {
                //this.kRGRUPREZBindingSource.EndEdit();
                TablFormUpdate();
            }
            else lABORANTBindingSource.CancelEdit();
        }

        private void ToolStripButton2Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}