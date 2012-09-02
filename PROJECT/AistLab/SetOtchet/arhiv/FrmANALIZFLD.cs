using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AistLabData;

namespace AistLab
{
    public partial class FrmANALIZFLD : DevExpress.XtraEditors.XtraForm
    {
  
        private DataClassesLabDataContext db;
        private List<ANALIZOTCHETFLD> lfld = new List<ANALIZOTCHETFLD>();
        private ANLOTCHET_TREE kle1;
        private BindingSource dataSource1;
        private int selnode1;
        public FrmANALIZFLD(BindingSource dataSource,int selnode)
        {
            InitializeComponent();
            dataSource1=dataSource;
            selnode1 = selnode;
        }
        public int PAnaliz_ID
        { set; get; }
        public int Pstroka_ID
        { set; get; }
        public void INITSQL()
        {
  
            db = new DataClassesLabDataContext();
            var res = (from c in db.ANALIZOTCHETFLDs where c.Analiz_ID == PAnaliz_ID select c);
            lfld = res.ToList<ANALIZOTCHETFLD>();
            this.gridControl1.DataSource = lfld;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           FormListFld();
        }

        public void FormListFld()
        {     
            db = new DataClassesLabDataContext();
            string strstrokaotch = "";
            string strstrokaanaliz = "";
            var resstr = (from c in db.ANALIZOTCHETs where c.analizotch_id == Pstroka_ID select c);
            foreach (var t in resstr) strstrokaotch = t.NameStr;
            var resstr1 = (from c in db.ANALIZMENUs where c.Analiz_ID == PAnaliz_ID select c);
            foreach (var t in resstr1) strstrokaanaliz = t.NAME;
            //if ((DevExpress.XtraEditors.XtraMessageBox.Show("Вы хотите сформировать для строки отчета : " + strstrokaotch + " по анализу : " + strstrokaanaliz, "Сообщения по редактированию  ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) == DialogResult.Yes)
            //{
                bool bol1 = true;
                var res = (from c in lfld where (bool)c.vib.Equals(bol1) select c);
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
                    strusl = strusl + " AND " + strus2;
                    var res1 = db.ANALIZOTCHLISTFLD_ADD(Pstroka_ID, PAnaliz_ID, t.analizrekv_id);
                //}
                    kle1 = (ANLOTCHET_TREE)dataSource1[selnode1];
                    kle1.Analiz_ID = PAnaliz_ID;
                    kle1.Uslivie = strusl;
                var res2 = db.ANALIZOTCHET_UpdUsl(Pstroka_ID,PAnaliz_ID, strusl);
            }
        }

 
    }
}