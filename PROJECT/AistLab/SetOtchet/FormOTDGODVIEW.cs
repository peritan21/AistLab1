using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using CustomControlLib;

namespace AistLab.SetOtchet
{
    public partial class FormOtdGODVIEW : DevExpress.XtraEditors.XtraForm
    {
        private OTD _kl;
        private DataClassesLabDataContext _db;
        private readonly List<AccessorLab.OtchetUslkol> _lotchuslkol = new List<AccessorLab.OtchetUslkol>();
        private readonly List<AccessorLab.AnalizOtchet> _lanalizotch2 = new List<AccessorLab.AnalizOtchet>();
        //private List<LABORANT> _labanaliz = new List<LABORANT>();
        private AccessorLab.OtchetUslkol _uslkol;
        private BindingSource _dataSource1;
        private AccessorLab.AnalizOtchet _otch;
        private int _tablid1;
        public FormOtdGODVIEW()
        {
            InitializeComponent();
            gridControl2.UseEmbeddedNavigator = true;
        }

        public AccessorLab.OTCHETPERIODR_ROTD _klevib { get; set; }
        public int _otdvib { get; set; }
        public string _periodvib { get; set; }
        public List<LABORANT> _labanalizt { get; set; }

        public void InitLookup()
        {
           
           
        }

        private void FormOtdGODVIEW_Load(object sender, EventArgs e){
            using(_db=new DataClassesLabDataContext())
            {
                _lotchuslkol.Clear();
                var resgrid = (from c in _db.ANALOTCHET_USLs
                               join u in _db.ANALIZMENUs
                                   on c.Analiz_ID equals u.Analiz_ID
                              where c.analizotch_id == _klevib.analizotch_id
                              select new { c.analotchetusl_id, u.NAME, u.TABLNAME,u.TABL_ID });
                foreach (var t in resgrid)
                {
                    _lotchuslkol.Add(new AccessorLab.OtchetUslkol(t.analotchetusl_id, t.NAME, t.TABLNAME, t.TABL_ID, 0, 0));
                }
                gridControl6.DataSource = null;
                gridControl6.DataSource = _lotchuslkol;
            }
         //   _labanaliz = _db.GetTable<LABORANT>().ToList<LABORANT>();
        }

        private void gridControl6_Click(object sender, EventArgs e)
        {
            int sel = gridView6.FocusedRowHandle;
            _uslkol = (AccessorLab.OtchetUslkol) gridView6.GetRow(sel);
            VivodGRIDOV(_uslkol.analotchetusl_id);

        }
        private void VivodGRIDOV(int klID)
        {
            //if (kle.TABLNAME.Trim().Length > 0)
            //{
               using(_db=new DataClassesLabDataContext())
               {
                   _lanalizotch2.Clear();
                   gridControl2.DataSource = null;
                   var resotch2 = _db.ANALIZ_OTCHETSKIPGOD(klID, _periodvib, _otdvib.ToString());
                   foreach (var t in resotch2)
                   {
                       if (t.noomer != null)
                       {
                           if (t.data != null)
                           {
                               if (t.tab_id != null)
                               {
                                   var p = new AccessorLab.AnalizOtchet((int) t.noomer, t.fio, (int) t.noomer,
                                                                        t.name_otd, (DateTime) t.data, 0, (int) t.tab_id);
                                   _lanalizotch2.Add(p);
                               }
                           }
                       }
                   }
                   gridControl2.DataSource = _lanalizotch2;
               }

            //return klID;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _dataSource1 = new BindingSource();
            _otch = (AccessorLab.AnalizOtchet)gridView2.GetRow(gridView2.FocusedRowHandle);
            if (_otch != null) _tablid1 = _otch.tab_id;
            else _tablid1 = 0;
            var clshowanaliz = new ClassShowAnalizForm { Labanalizc = _labanalizt };
            clshowanaliz.ShowCaseInFormAnaliz(_dataSource1, _tablid1, null, null, null, _uslkol);
        }

    }
}