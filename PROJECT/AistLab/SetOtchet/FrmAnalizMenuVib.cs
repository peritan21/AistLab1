using System;
using System.Collections.Generic;
using System.Linq;
using AistLabData;

namespace AistLab.SetOtchet
{
    public partial class FrmAnalizMenuVib : DevExpress.XtraEditors.XtraForm
    {
        public FrmAnalizMenuVib()
        {
            InitializeComponent();
        }
        public List<ANALIZMENU> ANALIZListh { get; set; }
        public List<ANALIZMENU> ANALIZListvib { get; set; }
        public void InitAnalizMenu()
        {
            var res = from c in ANALIZListh where c.VIB == true select c;
            foreach (var t in res)
            {
                t.VIB = false;
            }
            aNALIZMENUBindingSource.DataSource = ANALIZListh;
            treeList1.DataSource = aNALIZMENUBindingSource;
            treeList1.ExpandAll();
        }

        private void SimpleButton1Click(object sender, EventArgs e)
        {
            ANALIZListvib = (from c in ANALIZListh where c.VIB == true select c).ToList<ANALIZMENU>();
        }
    }
}