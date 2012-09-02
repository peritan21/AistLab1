using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using CustomControlLib;

namespace AistLab
{
    public partial class FormLABORANTvibor : DevExpress.XtraEditors.XtraForm
    {
        //private OTD _kl;
        private DataClassesLabDataContext _db;

        public FormLABORANTvibor()
        {
            InitializeComponent();
        }
        public List<AccessorLab.Viborlaborant> Llaborant { get; set; }
        public List<AccessorLab.Viborlaborant> LlaborantVib { get; set; }
        public void InitLookup()
        {
            oTDBindingSource.DataSource = Llaborant;
            gridControl1.DataSource = oTDBindingSource;
        }

        private void SimpleButton1Click(object sender, EventArgs e)
        {
            var list = Llaborant.Where(c => c.Vib).ToList();
            LlaborantVib = list;
        }
   


    }
}