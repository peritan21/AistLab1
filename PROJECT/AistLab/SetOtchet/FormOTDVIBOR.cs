using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using CustomControlLib;

namespace AistLab.SetOtchet
{
    public partial class FormOtdvibor : DevExpress.XtraEditors.XtraForm
    {
        //private OTD _kl;
        private DataClassesLabDataContext _db;
        
        public FormOtdvibor()
        {
            InitializeComponent();
        }
        public  List<AccessorLab.Viborotd> Lotd { get; set; }
        public List<AccessorLab.Viborotd> LotdVib { get; set; }
        public void InitLookup()
        {
            oTDBindingSource.DataSource = Lotd;
            gridControl1.DataSource = oTDBindingSource;
        }

        private void SimpleButton1Click(object sender, EventArgs e)
        {
            var list = Lotd.Where(c => c.Vib).ToList();
            LotdVib = list;
        }
   


    }
}