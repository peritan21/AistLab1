using System;
using System.Collections.Generic;
using System.Linq;using AistLabData;

namespace AistLab.SetOtchet
{
    public partial class FrmANALIZFLD : DevExpress.XtraEditors.XtraForm
    {
        private DataClassesLabDataContext _db;
        private List<ANALIZOTCHETFLD> _lfld = new List<ANALIZOTCHETFLD>();

        public FrmANALIZFLD()
        {
            InitializeComponent();
        }

        public bool PorAndh { get; set; }

        public int PanalizotchID { set; get; }
        public int PAnalizID  { set; get; }
        public int PstrokaID  { set; get; }
        public void INITSQL()
        {
  
            _db = new DataClassesLabDataContext();
            var res = (from c in _db.ANALIZOTCHETFLDs where c.Analiz_ID == PAnalizID select c);
            _lfld = res.ToList();
            gridControl1.DataSource = _lfld;
        }

        private void SimpleButton1Click(object sender, EventArgs e)
        {
           FormListFld();
        }

        public void FormListFld()
        {     
            _db = new DataClassesLabDataContext();
            string strorand = " AND ";
            if (!PorAndh) strorand =  " OR ";
            const bool bol1 = true;
                var res = (from c in _lfld where c.vib.Equals(bol1) select c);
                string strusl = "";
                string strus2 = "";
                foreach (var t in res)
                {
                    switch (t.znachpusto)
                    {
                        case 0:
                            strus2 = " m." + t.namefield + " >0 ";
                            break;
                        case 1:
                            strus2 = " m." + t.namefield + " IS NOT NULL ";
                            break;
                        case 2:
                            strus2 = " LEN(" + "m." + t.namefield + ")>0 ";
                            break;
                    }
                    strusl = strusl + strorand + strus2;
                    _db.ANALIZOTCHLISTFLDUSL_ADD(PstrokaID,PanalizotchID, PAnalizID, t.analizrekv_id);
    
                }
                //kle1 = (ANLOTCHET_TREE)dataSource1[selnode1];
                //kle1.Analiz_ID = PAnaliz_ID;
                //kle1.Uslivie = strusl;
                if (!PorAndh) strusl = "  AND ( " + strusl.Substring(5) + " )";
                _db.ANALIZOTCHETUSL_UpdUsl(PstrokaID, PAnalizID, strusl);
    
        }

 
    }
}