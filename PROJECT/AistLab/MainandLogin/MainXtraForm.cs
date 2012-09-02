using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using AistLab.SetOtchet;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using AistLabData;
using KdlForm.AnalizKala;
using KdlGridUpdate.AnalizKala;
using KdlGridUpdate.Analizkrovi;
using KdlGridUpdate.AnalizMochi;
using KdlGridUpdate.Krovsuvorotka1;
using KdlGridUpdate.Maski;
using KdlGridUpdate.Mielogramma;
using KdlGridUpdate.New2202;
using KdlGridUpdate.Posevu;
using KdlGridUpdate.Testu_prochie;
using System.Configuration;
using CustomControlLib;
using System.Diagnostics;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Security.Principal;
using System.ComponentModel;



namespace AistLab.MainandLogin
{
    public partial class MainXtraForm : DevExpress.XtraEditors.XtraForm
    {
        readonly DataClassesLabDataContext _dt = new DataClassesLabDataContext();
        DataClassesLabDataContext _db;
        private DETILAB _detikl;
        //====================
        private ANALIZMENU _vklanalizmenu;
        private DETILAB _vkldeti;
        private DataRow _rowpac,_rowpacppc;
        //=========================
        private int _koldetei;
        private bool _setprosmotrall;
        private readonly SqlConnection _dpStr = new SqlConnection(AccessorLab.ClassDecrypt.Decrypt(ConfigurationManager.ConnectionStrings["KDL"].ConnectionString, Resource1.StringLab));
        private readonly List<ANALIZMENU> _analizList = new List<ANALIZMENU>();
        private readonly List<LABORANT> _llaborant = new List<LABORANT>();
        private readonly List<OTD> _lotd = new List<OTD>();
        private readonly List<DETILAB> _ldeti = new List<DETILAB>();
        private readonly List<TablSkin> _lskin = new List<TablSkin>();
        private UAnalKalUglev _uankalugl;
        private UCalGlistLINQ _ucalgl;
        private UAnSokProstat _usokpr;
        private UMielogramma _umie;
        private UEksTrans _uekstrans;
        private UBacterioBiomat _ubiomat;
        private UkrSuvNarFerIFA _narfer;
        private UkrSuv01Astra _as01;
        private UkrSuvIgMigG _igmigg;
        private UkrSuvIFAAxgc _ifaaxgc;
        private UkrSuvGormIFA _sgifa;
        private UAgregacTromb _atb;
        private UTestberem _tbm;
        private UPosevGrib _pgr;
        private UOstrica _uostric;
        private UNovGemoglob _unovgem;
        private UMazkinaFloru _mfl;
        private UAMGFvSperm _uamgf;
        private USpermObchi _usperm;
        private UIsledLikv _isl;
        private UCitocinu _uct;
        private UDiagSifilis _dsf;
        private UImmunTest _umt;
        private UkrKrasnVolch _fukv;
        private UIssledKala _uisledkal;
        private UkrGrRezus _fugrrez;
        private UkrGemoliz _ugem;
        private UkrgLukpROF _ugkrof;
        private UkrVich _uvich;
        private UkrSaxar _krsax;
        private UkrIFA _ufkrifa;
        private UkrKougul _ukkoa;
        private UkrBioxim _ubkrbio;
        private UkrObchi _uokrobch;
        private UZemnickogo _uzemnic;
        private UNechipor _unechip;
        private UMochaSaxBel _msaxbel;
        private UMochaObchii _mochobch;
        private UMochaBoixim _mochbioxim;
        private UTrixomon _trixom;
        private UCitogramma _ucitogram;
        private UkrTestTolerant _uttoler;
        private URIFmazka _urifmazka;
        private UkrGomocistein _ugomocis;
        private UkrTromboeks _ukrtromboeks;
        private UkrTromboelast _ukrtromboelast;
        private UkrEli12 _ukkreli12;
        private UkrEli24 _ukkreli24;
        private UkrCA125 _ukrca125;
        private UMochaSulkovich _umochasulkovich;
        private Ukrgazelektro _ukrgazelektro;
        private UkrGemostazio _ukrgemostazio;
        private UkrOsmotRezEritr _ukrosmotrezeritr;
        private UPunktatOnkocit _upunktatonkocit;
        private UAspiratOnkocit _uaspiratonkocit;
        private UkrGomNizkogoUr _ukrgomnizkogour;
        private UReberga _ureberga;
        private UkrPCRMutacii _upcrmutacii;
        private UkrPCRisledov _upcrisledov;
        private UChesotka _uchesototka;
        private Ukrantitela _ukrantitela;
        private Ukrantigominiz _ukrantigominiz;
        private PACIENTPPC _klppc;
        private BindingList<PACIENTPPC> lpacientppc = new BindingList<PACIENTPPC>();
        bool _lcbolchek1 = true;
        string _strParent="";
        bool setprogram = false;

        string _strdetinomer = "";
       private string _strNHistory= "";
       private string _strNFIO = "";
       private string _strNOTDSOKR = "";
        int _lckeyId;
        int _lcpacientId;
        int _lcdetiId;
        int _lcOtd;
        private DataViewManager _dvManager,_dpManager;
        private DataView _dv,_dp;
        private static SqlDataAdapter _pacientadapter;
        private string _vdopsql = "LEN(vippacdata)>4 ";
        DataRow _dpr;

        private string _lcUserLogin = "";
        //private bool SelectVvod = true;
        public MainXtraForm()
        {
            setprogram = kldsimple01(); 
            //_usoskm = usoskm;
            InitializeComponent();
            label4.Text = DateTime.Now.ToShortDateString();
           _llaborant = _dt.GetTable<LABORANT>().ToList<LABORANT>();
           _lotd = _dt.GetTable<OTD>().ToList<OTD>();
           _lskin = _dt.GetTable<TablSkin>().ToList<TablSkin>();
          //  _lotd = new List<OTD>(_lotd.Where(c => c.otd_id == 46 || c.otd_id == 47));
           lookUpEdit1.Properties.DataSource = _lotd;
           lookUpEdit2.Properties.DataSource = _dt.GETMENUSOKR();
           Ptekgod = DateTime.Now.Year.ToString();
           PotdId = "0";
           Pselvvod = true;
            //==
           //lcbolchek1 = Pselvvod; // checkEdit1.Checked;
           //gridControl1.Visible = lcbolchek1;
           //if (lcbolchek1 == false)
           //{
           //    Pselvvoddeti = false;
           //    this.panelControl5.Visible = lcbolchek1;
           //    gridControl2.Visible = lcbolchek1;
           //    checkEdit4.Visible = lcbolchek1;
           //    this.gridControl1.DataSource = null;
           //    this.textEdit6.Text = "";
           //    this.textEdit7.Text = "";
           //    Potd_id = "9";
           //    // this.pPacientRodBindingSource.DataSource = null;
           //}
           //else checkEdit4.Visible = lcbolchek1;
           //lookUpEdit1.Enabled = !lcbolchek1;
           //this.pACIENTPPCGridControl.Visible = !lcbolchek1;
           //this.pACIENTPPCBindingNavigator.Visible = !lcbolchek1;
           //this.splitContainerControl3.Panel2.Controls.Clear();
           //this.tabTextBox1.Text = "";
            //==
           PSelectVvod =false;
           Pselvvoddeti = false;
          SetLookupSkin();
          Pfullmenuanaliz = false;  // true;
            FormMenuAnaliz();
            _lcbolchek1 = false;   // checkEdit1.Checked;
            //gridControl1.Visible = _lcbolchek1;
            //if (_lcbolchek1 == false)
            //{
            //    Pselvvoddeti = false;
            //    panelControl5.Visible = _lcbolchek1;
            //    gridControl2.Visible = _lcbolchek1;
            //    checkEdit4.Visible = _lcbolchek1;
            //    gridControl1.DataSource = null;
            //    textEdit6.Text = "";
            //    textEdit7.Text = "";
            //    // this.pPacientRodBindingSource.DataSource = null;
            //}
            //else
            checkEdit4.Visible = _lcbolchek1;
            lookUpEdit1.Enabled = !_lcbolchek1;
            pACIENTPPCGridControl.Visible = !_lcbolchek1;
            pACIENTPPCBindingNavigator.Visible = !_lcbolchek1;
            splitContainerControl3.Panel2.Controls.Clear();
            tabTextBox1.Text = "";
          //  checkEdit1.Checked = true;
            Pselvvod = false;
            checkEdit1.Visible = false;
            dateEdit4.DateTime = DateTime.Now;
         //  lookUpEdit1.EditValue=1;
        //   simpleButton25.PerformClick();
        }

     

        #region НАЧАЛЬНАЯ ИНИЦИАЛИЗАЦИЯ ФОНА ФОРМ
        private void SetLookupSkin()
        {
             lookUpEditSkinName.Properties.DataSource = _lskin;
           PskinId = "2";
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Money Twins");
        }
    
        public string PskinId
        {
            set { lookUpEditSkinName.EditValue = value; }
            get { return lookUpEditSkinName.EditValue.ToString(); }
        }
        #endregion

        #region ЗАПОЛНЕНИЕ ПРОВОДНИКА АНАЛИЗОВ
        private void FormMenuAnaliz()
        {
            if (!setprogram) return;
            _analizList.Clear();
            treeList1.Nodes.Clear();
            var res = _dt.ANALIZMENU_GET0(3, 3, Pfullmenuanaliz);
            foreach (var t in res)
            {
                if (t.Analiz_ID != null)
                {
                    var an = new ANALIZMENU
                                 {
                                     Analiz_ID = (int) t.Analiz_ID,
                                     Analiz_Level = t.Analiz_Level,
                                     NAME = t.NAME,
                                     Parent_ID = t.Parent_ID,
                                     TABINDEX = t.TABINDEX
                                 };
                    _analizList.Add(an);
                }
            }
            treeList1.RootValue = 3;
            aNALIZMENUBindingSource.DataSource = _analizList;
            treeList1.DataSource = aNALIZMENUBindingSource;   // ANALIZList;
            treeList1.ExpandAll();
        }
        private void FormMenuAnaliz1(string strpacId,string strotd)
        {
            _analizList.Clear();
            treeList1.Nodes.Clear();
            var res = _dt.VGET_ANALIZ0(strpacId, strotd,3, 3);
            //var res = dt.ANALIZMENU_GET0(3, 3, Pfullmenuanaliz);
            foreach (var t in res)
            {
                if (t.Analiz_ID != null)
                {
                    var an = new ANALIZMENU
                                 {
                                     Analiz_ID = (int) t.Analiz_ID,
                                     Analiz_Level = t.Analiz_Level,
                                     NAME = t.NAME,
                                     Parent_ID = t.Parent_ID,
                                     TABINDEX = t.TABINDEX
                                 };
                    _analizList.Add(an);
                }
            }
            treeList1.RootValue = 3;
            //this.treeList1.DataSource = ANALIZList;
            aNALIZMENUBindingSource.DataSource = _analizList;
            treeList1.DataSource = aNALIZMENUBindingSource;   // ANALIZList;
            treeList1.ExpandAll();
        }
        #endregion
    
        #region ГЛОБАЛЬНЫЕ ПЕРЕМЕННЫЕ ДЛЯ ВСЕХ ФУНКЦИЙ
        public string Ptekgod
        {
            set { tabSpinEdit2.Text = value; }
            get { return tabSpinEdit2.Text; }
        }
        public int LcUserId
        { get; set; }
        public string LcUserName
       { get; set; }
        public string LcUserDoljn
        { get; set; }
        public bool Pselvvod
        {
            set { checkEdit1.Checked = value; }
            get { return checkEdit1.Checked; }
        }
        public bool Pselvvoddeti
        {
            set 
            { 
                checkEdit4.Checked = value;
                //gridControl2.Visible = value;
                //panelControl5.Visible = value;
                //this.DetiBindingNavigator.Visible = value;
            }
            get { return checkEdit4.Checked; }
        }
        public bool PSelectVvod
        {
            set { checkEdit3.Checked = value; }
            get { return checkEdit3.Checked; }
        }
        //checkEdit3
        public bool Pfullmenuanaliz
        {
            set { checkEdit2.Checked = value; }
            get { return checkEdit2.Checked; }
        }
        public string PotdId
        {
            set 
            {
                lookUpEdit1.EditValue = value;
           }
            get { return lookUpEdit1.EditValue.ToString(); }
        }
        public string Pnomer
        {
            set { tabTextBox1.Text = value; }
            get { return tabTextBox1.Text; }
        }

        #endregion

        #region РЕГИСТРАЦИЯ USERа
        public bool Registracij(int lcUser, string lcPsw)
        {
            //  VolumeInfo vg = new VolumeInfo();
            //  string strHardID = vg.GetVolumeSerial('c');
            //  HardDiskInfo hdd = AtapiDevice.GetHddInfo(0);
            //  strHardID = hdd.SerialNumber;
            if (BuildForm1(lcUser, lcPsw))
            {
               // FormListSprav();
              //  nastItembar(lcUser_ID, lcUser_NOTE);
            }
            else
            {
                // this.Disposed+=new EventHandler(frmMain_Disposed);
                return false;
                // this.Close();
            }
            return true;
        }
          [DebuggerNonUserCodeAttribute]
        private bool BuildForm1(int lstrLoginUser, string lstrLoginPass)
        {
            bool lcexit;
            using (var con = new SqlConnection(AccessorLab.ClassDecrypt.Decrypt(ConfigurationManager.ConnectionStrings["KDL"].ConnectionString, Resource1.StringLab)))
            {
                var acommand = new SqlCommand("TestPassword", con) {CommandType = CommandType.StoredProcedure};
                acommand.Parameters.Add(new SqlParameter("id", lstrLoginUser));
                acommand.Parameters.Add(new SqlParameter("PASSWORD", lstrLoginPass));
                con.Open();
                try
                {
                    SqlDataReader dsr = acommand.ExecuteReader();
                    while (dsr.Read())
                    {
                        LcUserId = int.Parse(dsr["laborant_id"].ToString());
                        LcUserName = dsr["fio1"] + " " + dsr["fio2"] +" "+ dsr["fio3"];
                        LcUserDoljn = dsr["dlg"].ToString();
                        _lcUserLogin = dsr["Login"].ToString();
                    }

                    if (LcUserId == 0)
                    {
                        MessageBox.Show(@"Не найден пользователь или неверно указан пароль! ");
                        lcexit = true;
                    }
                    else
                    {
                        lcexit = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source);
                    return false;
                }
                con.Close();
            }
            bool lcboolret = !lcexit;
            if (_lcUserLogin.Trim().Substring(0,5) == "Admin")
            {
                navBarItem1.Visible = true;
                navBarItem2.Visible = true;
                navBarItem3.Visible = true;
                navBarItem4.Visible = true;
                navBarItem5.Visible = true;
                navBarItem6.Visible = true;
                navBarItem7.Visible = true;
                navBarItem8.Visible = true;
                navBarItem9.Visible = true;
             }
            else
            {
                navBarItem1.Visible = false;
                navBarItem2.Visible = false;
                navBarItem3.Visible = false;
                navBarItem4.Visible = true;
                navBarItem5.Visible = true;
                navBarItem6.Visible = false;
                navBarItem7.Visible = false;
                navBarItem8.Visible = false;
                navBarItem9.Visible = false;
            }
            return lcboolret;
        }
        #endregion


        private int SetOTD()
        {
            _lcOtd = 0;

            if (Pselvvod)
            {
                _lcOtd = Pselvvoddeti ? 2 : 0;
            }
            else _lcOtd = 1;
            return _lcOtd;
        }
        #region ОПРЕДЕЛЕНИЕ ID ПАЦИЕНТА ИЗ ТАБЛИЦЫ
        private int SetpacientId()
        {

           // определение ид пациента
             _lcpacientId = 0;
                  if (Pselvvod)
                {
                }
                else
                {
                 _klppc= (PACIENTPPC)gridView5.GetRow(gridView5.FocusedRowHandle);
                 if (_klppc == null)   return _lcpacientId = 0;
                    _strNHistory =  _klppc.noomer.ToString();
                    _strNFIO = String.Format("{0} {1} {2}", _klppc.fio1, _klppc.fio2, _klppc.fio3);
                    _lcpacientId = _klppc.pacient_id;
                }
             return _lcpacientId;
        }
        private void SetDetiId()
        {
            _lcdetiId = 0;
            //int sel = gridView7.FocusedRowHandle;
            //_detikl = (DETILAB)gridView7.GetRow(sel);
            //if (_detikl != null)
            //{
            //    _lcdetiId = _detikl.deti_id;
            //    _strdetinomer = _detikl.nomer.ToString();
            //}
            return;
        }
        #endregion

        #region ЗАПОЛНЕНИЕ ТАБЛИЦЫ ПАЦИЕНТОВ ПО ПОИСКУ ИЗ РОДДОМА ИЛИ ДРУГИХ ОТДЕЛЕНИЙ
        private void InitSQLData(SqlConnection connectionString, string zapros)
        {

            //dataSetAist.PACIENT.Clear();
            //_pacientadapter = new SqlDataAdapter(zapros, connectionString);
            //_pacientadapter.Fill(dataSetAist.PACIENT);
            //_dvManager = new DataViewManager(dataSetAist);
            //_dv = _dvManager.CreateDataView(dataSetAist.PACIENT);
            //pPacientRodBindingSource.DataSource = _dv;
            //gridControl1.DataSource = pPacientRodBindingSource;   // dv;

        }

        public void Pvdopsql()
        {
            // if (Ppriznvuvoda) vdopsql = " LEN(vippacdata)>4 ";
            //  else vdopsql = "  LEN(vippacdata)<=4  ";
            _vdopsql = " ";
        }
        private void Button1Click(object sender, EventArgs e)
        {
            //if (!provlic()) return;
            string lcFIO = textEdit1.Text;
            //lcSer = this.textBox4.Text;
            //lcNom = this.textBox3.Text;
            string lcNhistory = tabTextBox1.Text;
            int lcNhistoryint;
            int lcOTDID;
            int.TryParse(lcNhistory, out lcNhistoryint);
            int.TryParse(PotdId, out lcOTDID);
            DateTime lcDatapriema;
  
            DateTime.TryParse(dateEdit4.Text, out lcDatapriema);
            Pvdopsql();
            DateTime lcDatapriema1 = lcDatapriema.AddDays(1);
            string strDatapriema = lcDatapriema.Year.ToString() + "/" + lcDatapriema.Month.ToString() + "/" + lcDatapriema.Day.ToString();
            string strDatapriema1 = lcDatapriema1.Year.ToString() + "/" + lcDatapriema1.Month.ToString() + "/" + lcDatapriema1.Day.ToString();
            bool boldatpacppc = false;
            bool boldatpacrod = false;
                  if (lcFIO.Length > 0)    // Поиск по инициалам
                {
                    //InitSQLDataPPC(dpStr, "SELECT pacient_id,laborant_id,data,noomer,fio1,fio2,fio3,inicial,otd_id   FROM PACIENTPPC  where inicial  like " + "'" + lcFIO + "%" + "  and otd_id=" + "'" + Potd_id + "'");
                    InitSQLDataPPC(0, lcOTDID, lcFIO, "", "", 1);
                    boldatpacppc = true;
                }

                else if (lcNhistory.Length > 0)     // Поиск по №
                {
                   // InitSQLDataPPC(dpStr, "SELECT pacient_id,laborant_id,data,noomer,fio1,fio2,fio3,inicial,otd_id   FROM PACIENTPPC  where noomer= " + "'" + lcNhistory + "  and otd_id=" + "'" + Potd_id + "'");
                    InitSQLDataPPC(lcNhistoryint, lcOTDID, "", "", "", 0);
                    boldatpacppc = true;
                  }
                else if ((lcDatapriema.Date.Year > 1900) && (lcNhistory.Length == 0))     //  Поиск за дату 
                {
                    //InitSQLDataPPC(dpStr, "SELECT pacient_id,laborant_id,data,noomer,fio1,fio2,fio3,inicial,otd_id   FROM PACIENTPPC  where  " + " data >= CONVERT(DATETIME," + "'" + strDatapriema + "'" + ",101)" + " and data <= CONVERT(DATETIME," + "'" + strDatapriema1 + "'" + ",101)");
                    InitSQLDataPPC(0, lcOTDID, "", strDatapriema, strDatapriema1, 2);
                    boldatpacppc = true;
                }
           
            if (Pselvvod && !boldatpacrod) InitSQLData(_dpStr, "SELECT p.fiopluswork,p.diagnozpost,p.pacient_id, p.datpriemtime, p.vozrast, p.lpunaprav, p.adres, p.namestrax,  p.n_history, p.data_priem, v.kuda, p.nacij FROM Pacient p  LEFT OUTER JOIN   dbo.PAC_PRIEMVRACH v    ON p.pacient_id=v.pacient_id where " + _vdopsql + " n_history  = " + "'" + "" + "'");
            if (!Pselvvod && !boldatpacppc) InitSQLDataPPC(0, lcOTDID, "", "", "", 0);
            VivodAnaliz(0);
        }
        #endregion
        #region Определение строки из проводника меню
        private void TreeList1FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                _strchk = e.Node.GetDisplayText(treeListColumn1);
                _vklanalizmenu=  (ANALIZMENU)aNALIZMENUBindingSource.Current;  // ivan
                _lckeyId = _vklanalizmenu.Analiz_ID;
               //string lckeyId = treeList1.KeyFieldName;
                _strParent = e.Node.ParentNode != null ? e.Node.ParentNode.GetDisplayText(treeListColumn1) : "";
                if (_strParent == "Анализ") _strParent = "";
                splitContainerControl3.Panel2.Controls.Clear();
            }
        }
        #endregion
        #region ВЫХОД ИЗ ПРОГРАММЫ
        private void SimpleButton2Click(object sender, EventArgs e)
        {
            //string currentDirName = System.IO.Directory.GetCurrentDirectory();
            //string[] files = System.IO.Directory.GetFiles(currentDirName, "*.rdlc*");
            //foreach (string s in files)
            //{
            //    // Create the FileInfo object only when needed to ensure
            //    // the information is as current as possible.
            //    System.IO.FileInfo fi = null;
            //    try
            //    {
            //        fi = new System.IO.FileInfo(s);
            //        fi.Delete();
            //    }
            //    catch (System.IO.FileNotFoundException ex)
            //    {
            //        continue;
            //    }
            //}
            Close();
        }
        #endregion

        #region      ОСНОВНОЙ ЦИКЛ ВВОДА АНАЛИЗОВ
        private void VivodAnaliz(int selidPac)
        {
            switch (selidPac)
            {
                case 0:
                    SetpacientId();
                    break;
                case 1:
                    SetpacientId();
                    break;
                case 2:
                    SetDetiId();
                    break;

            }
            _strNOTDSOKR = Pselvvod ? "Роддом" : lookUpEdit1.Text;
            if (Pselvvoddeti && _lcdetiId > 0)
            {
                _lcpacientId = _lcdetiId;
  
                label2.Text = string.Format("N : {0}/{1} {2} {3}           {4}: {5}", _strNHistory.TrimEnd(), _strdetinomer, _strParent, _strchk, LcUserDoljn, LcUserName);
                _strNFIO = string.Format("N : {0}/{1} {2}  отд: {3}", _strNHistory.TrimEnd(), _strdetinomer, _strNFIO, _strNOTDSOKR);
            }
            else
            {
                label2.Text = string.Format("N : {0} {1} {2}           {3}: {4}", _strNHistory, _strParent, _strchk, LcUserDoljn, LcUserName);
                _strNFIO = string.Format("N : {0} {1} отд: {2}", _strNHistory.TrimEnd(), _strNFIO, _strNOTDSOKR);
                _lcdetiId = 0;
            }
           // this.label2.Text = "N : " + strN_history + " " + strParent + " " + strchk + "           " + lcUserDoljn + ": " + lcUser_Name;
            splitContainerControl3.Panel2.Controls.Clear();
    
            _lcpacientId = 0;
            _klppc = (PACIENTPPC)gridView5.GetRow(gridView5.FocusedRowHandle);
            if (!Pselvvod && _klppc == null) return;
            _lcpacientId = _klppc.pacient_id;
            if (_lcpacientId==0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Вы не выбрали пациента для формирования анализа !!! ");
                return;
            }
            if (_setprosmotrall) FormMenuAnaliz1(_lcpacientId.ToString(), SetOTD().ToString());  //ivan
            #region вывод форм анализа
            switch (_lckeyId)   // (strchk)
            {
                case 5:   //"на трихомонады":
                    FormUTrixomon();
                    break;
                case 84:   // "биохимия мочи":
                    FrmMochaBioxim();
                    break;
                case 7:  // "общий":
                    FrmMochaObchi();
                    break;
                case 6:  //"суточная моча на сахар и белок":
                    FrmMochaSaxBel();
                    break;
                case 9:   // "по Нечипоренко":
                    FrmNechipor();
                    break;
                case 8:  //"по Зимницкому":
                    FrmZemnickogo();
                    break;
                case 26:  //"анализ крови общий":
                    FrmKrObchi();
                    break;
                case 27:  //"биохимический анализ крови":
                    FrmKrBioxim();
                    break;
                case 82:  //"коагулограмма":
                    FrmKoagulogram();
                    break;
                case 103:  //"определение антител":
                    FrmKrIFA();
                    break;
                //исследование сыворотки определение антител
                case 28:  //"кровь на сахар":
                    FrmKrSaxar();
                    break;
                case 25: //"выявление антител к ВИЧ 1 и 2 типов (ИФА)":
                    FrmKrVich();
                    break;
                case 24:  //"на гемолиз":
                    FormUAnaliz();
                    break;
                //на гемолиз
                case 81:  //"на гликемический профиль натощак":
                    FrmKrGlukProf();
                    break;
                //case "на тест толерантности к глюкозе":
                //    // FormZemnickogo();
                //    break;
                case 22: //"на группу и резус фактор":
                    FrmKrGroupRezus();
                    break;
                case 95:  //"исследование кала":
                    IssledovKala();
                    break;
                //UIssledKala
                case 85:  //"Обнаружение клеток красной волчанки(LE-клеток)":
                    KrasnVolachanki();
                    break;
                case 89:   //"Иммунологический тест":
                    ImmunTest();
                    break;
                case 93:  //"Диагностика сифилиса (RPR,РПГА)":
                    DiagRPRRPGA();
                    break;
                case 92: //"ЦИТОКИНЫ":
                    Citocinu();
                    break;
                case 101: //"Исследование ликвора":
                    IssledLikvora();
                    break;
                case 98:  //"Анализ эякулята":
                    AnalizEjkulata();
                    break;
                case 99: //"определение АМГФ в сперме":
                    AMGFvSperme();
                    break;
                // UAMGFvSperm
                case 39:  //"Мазки на флору":
                    MazoknaFloru();
                    break;
                case 100: //"определение в кале новорожденного гемоглобина (проба АПТА)":
                    OprvKaleNovGemogl();
                    break;
                case 96:   //"кал на я/г и простейшие":
                    KalJicaGlistu();
                    // UCalGlist
                    break;
                case 94: //"на углеводы":
                    KalnaUglevodu();
                    break;
                // UAnalKalUglev
                case 97:   //"обнаружение яиц острицы на перианальных складках":
                    KalnaOstricu();
                    break;
                // UOstrica
                case 43:  //"Посевы и грибы":
                    PoseviGribu();
                    break;
                case 44:   //"Тесты на беременность":
                    TestnaBeremen();
                    break;
                case 91:  //"Определение агрегации тромбоцидов, стимулированной индуктором ":
                    AgregacTrombocid();
                    break;
                case 46:  //"на гормоны методом ИФА":
                    GormonmetIFA();
                    break;
                case 49: //"методом ИФА на антитела к ХГЧ и суммарные тела к кардиолипину":
                    MetIfakXGCh();
                    break;
                case 47:  //"определение иммуноглобулинов":
                    ImmunoIgaIGm();
                    break;
                case 50:  //"белковых фракций методом электрофореза на УЭФ":
                    BelkFraknaUEF();
                    break;
                case 48:  //"при нарушении фертильности методом ИФА":
                    FertmetIFA();
                    break;
                case 88:  //"Бактериоскопия биоматериала":
                    BakterBioMaterial();
                    break;
                //case "Исследование соскобов с шейки матки и цервикального канала":
                //    IssledSoskobMatki();
                //    break;
                case 45:  //"Экссудаты и транссудаты":
                    EksudatTransudat();
                    break;
                case 86:  //"Миелограмма":
                    Mielogramma();
                    break;
                case 104:  //"Анализ сока простаты":
                    SokProstatu();
                    break;
                case 41:  //"Мазок на онкоцитологию":
                    _ucitogram = new UCitogramma
                    {
                        Dock = DockStyle.Fill,
                        PpacientID = _lcpacientId,
                        PlaborantID = LcUserId,
                        PFIO = _strNFIO,
                        PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                        Potd = SetOTD(),
                        Llaboranth = _llaborant
                    };
                    _ucitogram.InitSQLData();
                    splitContainerControl3.Panel2.Controls.Add(_ucitogram);
                    break;
                case 105:  //"на тест толерантности к глюкозе":
                    _uttoler = new UkrTestTolerant
                    {
                        Dock = DockStyle.Fill,
                        PpacientID = _lcpacientId,
                        PlaborantID = LcUserId,
                        PFIO = _strNFIO,
                        PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                        Potd = SetOTD(),
                        Llaboranth = _llaborant
                    };
                    _uttoler.InitSQLData();
                    splitContainerControl3.Panel2.Controls.Add(_uttoler);
                    break;
                case 40:  //"РИФ мазка":
                    _urifmazka = new URIFmazka
                    {
                        Dock = DockStyle.Fill,
                        PpacientID = _lcpacientId,
                        PlaborantID = LcUserId,
                        PFIO = _strNFIO,
                        PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                        Potd = SetOTD(),
                        Llaboranth = _llaborant
                    };
                    _urifmazka.InitSQLData();
                    splitContainerControl3.Panel2.Controls.Add(_urifmazka);
                    break;
                case 106:  //"на гомоцистеин":
                    _ugomocis = new UkrGomocistein
                    {
                        Dock = DockStyle.Fill,
                        PpacientID = _lcpacientId,
                        PlaborantID = LcUserId,
                        PFIO = _strNFIO,
                        PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                        Potd = SetOTD(),
                        Llaboranth = _llaborant
                    };
                    _ugomocis.InitSQLData();
                    splitContainerControl3.Panel2.Controls.Add(_ugomocis);
                    break;
                case 113:  //"Тромбоэластограмма":
                    _ukrtromboelast = new UkrTromboelast
                    {
                        Dock = DockStyle.Fill,
                        PpacientID = _lcpacientId,
                        PlaborantID = LcUserId,
                        PFIO = _strNFIO,
                        PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                        Potd = SetOTD(),
                        Llaboranth = _llaborant
                    };
                    _ukrtromboelast.InitSQLData();
                    splitContainerControl3.Panel2.Controls.Add(_ukrtromboelast);
                    break;
                case 114:  //"Эли-П-Комплекс- 12":
                    _ukkreli12 = new UkrEli12
                    {
                        Dock = DockStyle.Fill,
                        PpacientID = _lcpacientId,
                        PlaborantID = LcUserId,
                        PFIO = _strNFIO,
                        PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                        Potd = SetOTD(),
                        Llaboranth = _llaborant
                    };
                    _ukkreli12.InitSQLData();
                    splitContainerControl3.Panel2.Controls.Add(_ukkreli12);
                    break;
                case 115:  //"Эли-Висцеро-тест-24":
                    _ukkreli24 = new UkrEli24
                    {
                        Dock = DockStyle.Fill,
                        PpacientID = _lcpacientId,
                        PlaborantID = LcUserId,
                        PFIO = _strNFIO,
                        PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                        Potd = SetOTD(),
                        Llaboranth = _llaborant
                    };
                    _ukkreli24.InitSQLData();
                    splitContainerControl3.Panel2.Controls.Add(_ukkreli24);
                    break;
                case 116:  //"на CA-125 (ИФА)":
                    _ukrca125 = new UkrCA125
                    {
                        Dock = DockStyle.Fill,
                        PpacientID = _lcpacientId,
                        PlaborantID = LcUserId,
                        PFIO = _strNFIO,
                        PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                        Potd = SetOTD(),
                        Llaboranth = _llaborant
                    };
                    _ukrca125.InitSQLData();
                    splitContainerControl3.Panel2.Controls.Add(_ukrca125);
                    break;
                case 117: //"Проба Сулковича":
                    _umochasulkovich = new UMochaSulkovich
                    {
                        Dock = DockStyle.Fill,
                        PpacientID = _lcpacientId,
                        PlaborantID = LcUserId,
                        PFIO = _strNFIO,
                        PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                        Potd = SetOTD(),
                        Llaboranth = _llaborant
                    };
                    _umochasulkovich.InitSQLData();
                    splitContainerControl3.Panel2.Controls.Add(_umochasulkovich);
                    break;
                //case "Суточная потеря белка и глюкозы в моче":
                //    umochastpbg = new UMochaSutpbg();
                //    umochastpbg.Dock = System.Windows.Forms.DockStyle.Fill;
                //    umochastpbg.Ppacient_id = lcpacient_id;
                //    umochastpbg.Plaborant_id = lcUser_ID;
                //    umochastpbg.Potd = SetOTD();
                //    umochastpbg.llaboranth = llaborant;
                //    umochastpbg.InitSQLData();
                //    this.splitContainerControl3.Panel2.Controls.Add(umochastpbg);
                //    break;
                case 119:  //"Газы и электролиты":
                    _ukrgazelektro = new Ukrgazelektro
                    {
                        Dock = DockStyle.Fill,
                        PpacientID = _lcpacientId,
                        PlaborantID = LcUserId,
                        PFIO = _strNFIO,
                        PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                        Potd = SetOTD(),
                        Llaboranth = _llaborant
                    };
                    _ukrgazelektro.InitSQLData();
                    splitContainerControl3.Panel2.Controls.Add(_ukrgazelektro);
                    break;
                case 120:  //"Гемостазиограмма":
                    _ukrgemostazio = new UkrGemostazio
                    {
                        Dock = DockStyle.Fill,
                        PpacientID = _lcpacientId,
                        PlaborantID = LcUserId,
                        PFIO = _strNFIO,
                        PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                        Potd = SetOTD(),
                        Llaboranth = _llaborant
                    };
                    _ukrgemostazio.InitSQLData();
                    splitContainerControl3.Panel2.Controls.Add(_ukrgemostazio);
                    break;
                case 121:  //"Осмотическая резистентность эритроцитов":
                    _ukrosmotrezeritr = new UkrOsmotRezEritr
                    {
                        Dock = DockStyle.Fill,
                        PpacientID = _lcpacientId,
                        PlaborantID = LcUserId,
                        PFIO = _strNFIO,
                        PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                        Potd = SetOTD(),
                        Llaboranth = _llaborant
                    };
                    _ukrosmotrezeritr.InitSQLData();
                    splitContainerControl3.Panel2.Controls.Add(_ukrosmotrezeritr);
                    break;
                case 122:  //"Исследование пунктата на онкоцитологию":
                    _upunktatonkocit = new UPunktatOnkocit
                    {
                        Dock = DockStyle.Fill,
                        PpacientID = _lcpacientId,
                        PlaborantID = LcUserId,
                        PFIO = _strNFIO,
                        PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                        Potd = SetOTD(),
                        Llaboranth = _llaborant
                    };
                    _upunktatonkocit.InitSQLData();
                    splitContainerControl3.Panel2.Controls.Add(_upunktatonkocit);
                    break;
                //Исследование пунктата на онкоцитологию
                case 123:  //"Исследование аспирата из полости матки на онкоцитологию":
                    _uaspiratonkocit = new UAspiratOnkocit
                    {
                        Dock = DockStyle.Fill,
                        PpacientID = _lcpacientId,
                        PlaborantID = LcUserId,
                        PFIO = _strNFIO,
                        PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                        Potd = SetOTD(),
                        Llaboranth = _llaborant
                    };
                    _uaspiratonkocit.InitSQLData();
                    splitContainerControl3.Panel2.Controls.Add(_uaspiratonkocit);
                    break;
                case 124:  //"Определение гемолиза в крови и низкого уровня Hb":
                    _ukrgomnizkogour = new UkrGomNizkogoUr
                    {
                        Dock = DockStyle.Fill,
                        PpacientID = _lcpacientId,
                        PlaborantID = LcUserId,
                        PFIO = _strNFIO,
                        PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                        Potd = SetOTD(),
                        Llaboranth = _llaborant
                    };
                    _ukrgomnizkogour.InitSQLData();
                    splitContainerControl3.Panel2.Controls.Add(_ukrgomnizkogour);
                    break;
                case 125:  //"Проба Реберга -Тореева":
                    _ureberga = new UReberga
                    {
                        Dock = DockStyle.Fill,
                        PpacientID = _lcpacientId,
                        PlaborantID = LcUserId,
                        PFIO = _strNFIO,
                        PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                        Potd = SetOTD(),
                        Llaboranth = _llaborant
                    };
                    _ureberga.InitSQLData();
                    splitContainerControl3.Panel2.Controls.Add(_ureberga);
                    break;
                case 126:  //"Выявление мутаций (полиморфизмов) в геноме методом ПЦР":
                    _upcrmutacii = new UkrPCRMutacii
                    {
                        Dock = DockStyle.Fill,
                        PpacientID = _lcpacientId,
                        PlaborantID = LcUserId,
                        PFIO = _strNFIO,
                        PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                        Potd = SetOTD(),
                        Llaboranth = _llaborant
                    };
                    _upcrmutacii.InitSQLData();
                    splitContainerControl3.Panel2.Controls.Add(_upcrmutacii);
                    break;
                case 127:  //"Исследование методом ПЦР:
                    _upcrisledov = new UkrPCRisledov
                    {
                        Dock = DockStyle.Fill,
                        PpacientID = _lcpacientId,
                        PlaborantID = LcUserId,
                        PFIO = _strNFIO,
                        PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                        Potd = SetOTD(),
                        Llaboranth = _llaborant
                    };
                    _upcrisledov.InitSQLData();
                    splitContainerControl3.Panel2.Controls.Add(_upcrisledov);
                    break;
                case 128:  //"Чесотка:
                    _uchesototka = new UChesotka 
                    {
                        Dock = DockStyle.Fill,
                        PpacientID = _lcpacientId,
                        PlaborantID = LcUserId,
                        PFIO = _strNFIO,
                        PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                        Potd = SetOTD(),
                        Llaboranth = _llaborant
                    };
                    _uchesototka.InitSQLData();
                    splitContainerControl3.Panel2.Controls.Add(_uchesototka);
                    break;
                case 129:  //"на антетала(гельминты, лямблии):
                    
                    _ukrantitela = new Ukrantitela
                    {
                        Dock = DockStyle.Fill,
                        PpacientID = _lcpacientId,
                        PlaborantID = LcUserId,
                        PFIO = _strNFIO,
                        PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                        Potd = SetOTD(),
                        Llaboranth = _llaborant
                    };
                    _ukrantitela.InitSQLData();
                    splitContainerControl3.Panel2.Controls.Add(_ukrantitela);
                    break;
                case 130:  //"на антетала(гельминты, лямблии):

                    _ukrantigominiz = new Ukrantigominiz
                    {
                        Dock = DockStyle.Fill,
                        PpacientID = _lcpacientId,
                        PlaborantID = LcUserId,
                        PFIO = _strNFIO,
                        PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                        Potd = SetOTD(),
                        Llaboranth = _llaborant
                    };
                    _ukrantigominiz.InitSQLData();
                    splitContainerControl3.Panel2.Controls.Add(_ukrantigominiz);
                    break;
            }
            #endregion

            // gridControl1.DataSource = null;
           // textBox2.Text = "";
        }
# endregion
        #region ПОДПРОГРАММЫ ВЫЗОВА ФОРМ В PANEL2
        private void SokProstatu()
        {
            _usokpr = new UAnSokProstat
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _usokpr.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_usokpr);
        }

        private void Mielogramma()
        {
            _umie = new UMielogramma
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _umie.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_umie);
        }

        private void EksudatTransudat()
        {
            _uekstrans = new UEksTrans
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _uekstrans.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_uekstrans);
        }

        private void BakterBioMaterial()
        {
            _ubiomat = new UBacterioBiomat
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _ubiomat.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_ubiomat);
        }

        private void FertmetIFA()
        {
            _narfer = new UkrSuvNarFerIFA
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _narfer.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_narfer);
        }

        private void BelkFraknaUEF()
        {
            _as01 = new UkrSuv01Astra
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _as01.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_as01);
        }

        private void ImmunoIgaIGm()
        {
            _igmigg = new UkrSuvIgMigG
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _igmigg.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_igmigg);
        }

        private void MetIfakXGCh()
        {
            _ifaaxgc = new UkrSuvIFAAxgc
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _ifaaxgc.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_ifaaxgc);
        }

        private void GormonmetIFA()
        {
            _sgifa = new UkrSuvGormIFA
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _sgifa.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_sgifa);
        }

        private void AgregacTrombocid()
        {
            _atb = new UAgregacTromb
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _atb.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_atb);
        }

        private void TestnaBeremen()
        {
            _tbm = new UTestberem
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _tbm.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_tbm);
        }

        private void PoseviGribu()
        {
            _pgr = new UPosevGrib
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _pgr.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_pgr);
        }

        private void KalnaOstricu()
        {
            _uostric = new UOstrica
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _uostric.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_uostric);
        }

        private void KalnaUglevodu()
        {
            if (!PSelectVvod)
            {
                _uankalugl = new UAnalKalUglev
                {
                    Dock = DockStyle.Fill,
                    PpacientID = _lcpacientId,
                    PlaborantID = LcUserId,
                    PFIO = _strNFIO,
                    PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                    Potd = SetOTD()
                };
                _uankalugl.Potd = SetOTD();
                _uankalugl.Llaboranth = _llaborant;
                _uankalugl.InitSQLData();
                splitContainerControl3.Panel2.Controls.Add(_uankalugl);
            }
            else
            {
                var fuakuggr = new FrmAnalKalUgkGrid { PpacientID = _lcpacientId, PlaborantID = LcUserId, Potd = SetOTD() };
                fuakuggr.Potd = SetOTD();
                fuakuggr.Show();
            }
        }

        private void KalJicaGlistu()
        {
            //UCalGlist ucalgl = new UCalGlist();
            _ucalgl = new UCalGlistLINQ
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                Potd = SetOTD(),
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Llaboranth = _llaborant
            };
            _ucalgl.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_ucalgl);
        }

        private void OprvKaleNovGemogl()
        {
            _unovgem = new UNovGemoglob
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                Llaboranth = _llaborant,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD()
            };
            _unovgem.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_unovgem);
            // UNovGemoglob
        }

        private void MazoknaFloru()
        {
            _mfl = new UMazkinaFloru
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _mfl.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_mfl);
        }

        private void AMGFvSperme()
        {
            _uamgf = new UAMGFvSperm
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _uamgf.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_uamgf);
        }

        private void AnalizEjkulata()
        {
            _usperm = new USpermObchi
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _usperm.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_usperm);
        }

        private void IssledLikvora()
        {
            _isl = new UIsledLikv
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _isl.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_isl);
            //UTestberemv  Иммунологический тест
        }

        private void Citocinu()
        {
            _uct = new UCitocinu
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _uct.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_uct);
            //UIsledLikv  Иммунологический тест
        }

        private void DiagRPRRPGA()
        {
            _dsf = new UDiagSifilis
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _dsf.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_dsf);
            //UCitocinu  Иммунологический тест
        }

        private void ImmunTest()
        {
            _umt = new UImmunTest
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _umt.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_umt);
            //UDiagSifilis  Диагностика сифилиса (RPR,РПГА)
        }

        private void KrasnVolachanki()
        {
            _fukv = new UkrKrasnVolch
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _fukv.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_fukv);
        }

        private void IssledovKala()
        {
            _uisledkal = new UIssledKala
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _uisledkal.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_uisledkal);
        }

        private void FrmKrGroupRezus()
        {
            _fugrrez = new UkrGrRezus
            {
                Dock = DockStyle.Fill,
                PpacientId = _lcpacientId,
                PlaborantId = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _fugrrez.InitSqlData();
            splitContainerControl3.Panel2.Controls.Add(_fugrrez);
        }

        private void FrmKrGlukProf()
        {
            _ugkrof = new UkrgLukpROF
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _ugkrof.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_ugkrof);
        }

        private void FrmKrVich()
        {
            _uvich = new UkrVich
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _uvich.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_uvich);
        }

        private void FrmKrSaxar()
        {
            _krsax = new UkrSaxar
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _krsax.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_krsax);
        }

        private void FrmKrIFA()
        {
            _ufkrifa = new UkrIFA
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _ufkrifa.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_ufkrifa);
        }

        private void FrmKoagulogram()
        {
            _ukkoa = new UkrKougul
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _ukkoa.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_ukkoa);
        }

        private void FrmKrBioxim()
        {
            _ubkrbio = new UkrBioxim
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _ubkrbio.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_ubkrbio);
        }
        private void FrmKrObchi()
        {
            _uokrobch = new UkrObchi
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _uokrobch.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_uokrobch);
        }

        private void FrmZemnickogo()
        {
            _uzemnic = new UZemnickogo
            {
                Dock = DockStyle.Fill,
                PpacientId = _lcpacientId,
                PlaborantId = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _uzemnic.InitSqlData();
            splitContainerControl3.Panel2.Controls.Add(_uzemnic);
        }

        private void FrmNechipor()
        {
            _unechip = new UNechipor
            {
                Dock = DockStyle.Fill,
                PpacientId = _lcpacientId,
                PlaborantId = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _unechip.InitSqlData();
            splitContainerControl3.Panel2.Controls.Add(_unechip);
        }

        private void FrmMochaSaxBel()
        {
            _msaxbel = new UMochaSaxBel
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _msaxbel.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_msaxbel);
        }

        private void FrmMochaObchi()
        {
            _mochobch = new UMochaObchii
            {
                Dock = DockStyle.Fill,
                PpacientId = _lcpacientId,
                PlaborantId = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _mochobch.InitSqlData();
            splitContainerControl3.Panel2.Controls.Add(_mochobch);
        }

        private void FrmMochaBioxim()
        {
            _mochbioxim = new UMochaBoixim
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _mochbioxim.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_mochbioxim);
        }

        private void FormUTrixomon()
        {
            _trixom = new UTrixomon
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _trixom.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_trixom);
        }

        private void FormUAnaliz()
        {
            _ugem = new UkrGemoliz
            {
                Dock = DockStyle.Fill,
                PpacientID = _lcpacientId,
                PlaborantID = LcUserId,
                PFIO = _strNFIO,
                PZAGOLOVOK = _strParent + " " + _strchk + " " + _strNFIO,
                Potd = SetOTD(),
                Llaboranth = _llaborant
            };
            _ugem.InitSQLData();
            splitContainerControl3.Panel2.Controls.Add(_ugem);
        }
        #endregion

        #region  ВЫЗОВ ПРОГРАММЫ ВВОДА АНАЛИЗА ПО ЩЕЛЧКУ КОНТРОЛОВ
        private void TreeList1Click(object sender, EventArgs e)
        {
            VivodAnaliz(0);
        }
        private void GridControl1Click(object sender, EventArgs e)
        {
            VivodAnaliz(1);
        }
        private void PAcientppcGridControlClick(object sender, EventArgs e)
        {
            VivodAnaliz(1);
        }
        private void GridControl2Click(object sender, EventArgs e)
        {
            // Вызов программы (ввода (просмотра анализов по ребёнку)
            VivodAnaliz(2);
        }
        #endregion

        #region ВЫЗОВ ДРУГИХ ФОРМ ИЗ NavBar
        private void NavBarItem4LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Смена пароля
            ChangePassword();
        }
        private void ChangePassword()
        {
            // Смена пароля
            var fpw = new FrmEditPasword();
            if (DialogResult.OK == fpw.ShowDialog())
            {
                int lcres = _dt.ChangePassword(_lcUserLogin, fpw.PNEWPASS, fpw.POLDPASS);
                if (lcres == 0) DevExpress.XtraEditors.XtraMessageBox.Show("Пароль успешно заменён ! ");
            }
        }
        private void NavBarItem3LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var fat = new FormLaborant();
            fat.Show();
        }

        private void NavBarItem6LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Ввод данных по отделению
           var fotd = new FormOTD();
           fotd.Show();

        }

        private void LookUpEdit2EditValueChanged(object sender, EventArgs e)
        {
            int lcskinId;
            int.TryParse(lookUpEditSkinName.EditValue.ToString(), out lcskinId);
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_lskin[lcskinId - 1].skinname);

        }

        private void NavBarItem2LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Редактирование меню анализов
            var fantyp = new FormAnalizType();
            fantyp.Show();
        }
        #endregion
        #region ПЕРЕКЛЮЧЕНИЯ РЕЖИМА ВВОДА С РОДДОМА НА ДРУГИЕ ОТДЕЛЕНИЯ
        private void CheckEdit1CheckedChanged(object sender, EventArgs e)
        {
            _lcbolchek1 = checkEdit1.Checked;
            //gridControl1.Visible=_lcbolchek1;
            //if (_lcbolchek1 == false)
            //{
            //    Pselvvoddeti = false;
            //    panelControl5.Visible = _lcbolchek1;
            //    gridControl2.Visible = _lcbolchek1;
            //    checkEdit4.Visible = _lcbolchek1;
            //    gridControl1.DataSource = null;
            //    textEdit6.Text = "";
            //    textEdit7.Text = "";
            //   // this.pPacientRodBindingSource.DataSource = null;
            //}
            //else 
            checkEdit4.Visible = _lcbolchek1;
            lookUpEdit1.Enabled = !_lcbolchek1;
            pACIENTPPCGridControl.Visible = !_lcbolchek1;
            pACIENTPPCBindingNavigator.Visible = !_lcbolchek1;
            splitContainerControl3.Panel2.Controls.Clear();
            tabTextBox1.Text = "";
            //this.simpleButton25.PerformClick();
            //this.pACIENTPPCGridControl.DataSource = null;
     
        }
        public  void PVvodOut()
        {
            //textBox2.Text ="";
           //gridControl1.DataSource = null;
           pACIENTPPCGridControl.DataSource = null;
          //  simpleButton25
        }
        #endregion

        #region ВВОД ПАЦИЕНТОВ С ДРУГИХ ОТДЕЛЕНИЙ
        private void InitSQLDataPPC(int lcnomer, int lcotd, string lcinicial, string lcdata1, string lcdata2, int lcsel)
        {
            DateTime lcDatapriema = dateEdit4.DateTime;
            //DateTime.TryParse(dateEdit4.Text, out lcDatapriema);
            DateTime lcDatapriema1 = lcDatapriema.AddDays(1);
            if (!setprogram) return;
            //dataSetLab1.PACIENTPPC.Clear();
            switch (lcsel)
            {
                case 0:
                  //  pACIENTPPCTableAdapter.FillByNomer(dataSetLab1.PACIENTPPC, lcnomer, lcotd, (int)tabSpinEdit2.Value);
                    lpacientppc.Clear();
                    using (DataClassesLabDataContext db = new DataClassesLabDataContext())
                    {
                        var resppc3 = db.PPCpacientSelectNomer(lcnomer, lcotd, (int)tabSpinEdit2.Value);
                        foreach (var t in resppc3)
                        {
                            PACIENTPPC p = new PACIENTPPC();
                            p.pacient_id = t.pacient_id;
                            p.laborant_id = t.laborant_id;
                            p.data = t.data;
                            p.noomer = t.noomer;
                            p.fio1 = t.fio1;
                            p.fio2 = t.fio2;
                            p.fio3 = t.fio3;
                            p.otd_id = t.otd_id;
                            lpacientppc.Add(p);
                        }
                        pACIENTPPCBindingSource.DataSource = lpacientppc;
                    }
                    break;
                case 1:
                   // pACIENTPPCTableAdapter.FillByInicial(dataSetLab1.PACIENTPPC, lcinicial, lcotd);
                    lpacientppc.Clear();
                    using (DataClassesLabDataContext db = new DataClassesLabDataContext())
                    {
                        var resppc1 = db.PPCpacientSelectInicial(lcinicial, lcotd);
                        foreach (var t in resppc1)
                        {
                            PACIENTPPC p = new PACIENTPPC();
                            p.pacient_id = t.pacient_id;
                            p.laborant_id = t.laborant_id;
                            p.data = t.data;
                            p.noomer = t.noomer;
                            p.fio1 = t.fio1;
                            p.fio2 = t.fio2;
                            p.fio3 = t.fio3;
                            p.otd_id = t.otd_id;
                            lpacientppc.Add(p);
                        }
                        pACIENTPPCBindingSource.DataSource = lpacientppc;
                    }
                    break;
                case 2:
                 //   pACIENTPPCTableAdapter.FillByData(dataSetLab1.PACIENTPPC, lcdata1, lcdata2, lcotd);
                    using (DataClassesLabDataContext db = new DataClassesLabDataContext())
                    {
                        lpacientppc.Clear();
                      var resppc = db.PPCpacientSelectData(lcdata1, lcdata2, lcotd);
                      foreach (var t in resppc)
                      {
                          PACIENTPPC p = new PACIENTPPC();
                          p.pacient_id = t.pacient_id;
                          p.laborant_id = t.laborant_id;
                          p.data = t.data;
                          p.noomer = t.noomer;
                          p.fio1 = t.fio1;
                          p.fio2 = t.fio2;
                          p.fio3 = t.fio3;
                          p.otd_id = t.otd_id;
                          lpacientppc.Add(p);
                      }
                      //lpacientppc = new BindingList<PACIENTPPC>(resppc.ToList<PACIENTPPC>());
                      pACIENTPPCBindingSource.DataSource = lpacientppc;
                    }
                    break;
            }
            //_dpManager = new DataViewManager(dataSetLab1);
            //_dp = _dpManager.CreateDataView(dataSetLab1.PACIENTPPC);
            //pACIENTPPCBindingSource.DataSource = _dp;
             pACIENTPPCGridControl.DataSource = pACIENTPPCBindingSource;
            repositoryItemLookUpEdit244.DataSource = _llaborant;
            repositoryItemLookUpEdit255.DataSource = _lotd;
        }

        //GridView1InitNewRow
        public void InsertOrder(PACIENTPPC o)
        {
            using (DataClassesLabDataContext _db = new DataClassesLabDataContext())
            {
                _db.PACIENTPPCs.InsertOnSubmit(o);
                try
                {
                    _db.SubmitChanges(ConflictMode.ContinueOnConflict);
                }
                catch (ChangeConflictException)
                {
                }
            }
        } 
        private void GridView1InitNewRow(object sender, InitNewRowEventArgs e)
        {
            int sel = gridView5.FocusedRowHandle;
            _klppc = (PACIENTPPC)gridView5.GetRow(sel);
            _klppc.laborant_id = LcUserId;
            _klppc.data = DateTime.Now;
             _klppc.noomer = 0;
            _klppc.fio1 = "";
            _klppc.fio2 = "";
            _klppc.fio3 = "";
            int.TryParse(PotdId, out _lcOtd);
            _klppc.otd_id = _lcOtd;
            if (_lcOtd == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Вы не выбрали отделение ! ");
                gridView5.DeleteRow(sel);
                return;
            }
            var frm = new FormFIOPPP(pACIENTPPCBindingSource);
            if (DialogResult.OK == frm.ShowDialog())
            {
                //using (DataClassesLabDataContext db = new DataClassesLabDataContext())
                //{
                //    db.PPCpacientInsert(_klppc.laborant_id, _klppc.data, _klppc.noomer, _klppc.fio1, _klppc.fio2, _klppc.fio3,_klppc.otd_id);
                //}
                InsertOrder(_klppc);
            }
          else gridView5.DeleteRow(sel);
            //int lcOTDID;
            //int.TryParse(PotdId, out lcOTDID);
            //DateTime lcDatapriema;
            //DateTime.TryParse(dateEdit4.Text, out lcDatapriema);
            //Pvdopsql();
            //DateTime lcDatapriema1 = lcDatapriema.AddDays(1);
            //string strDatapriema = lcDatapriema.Year.ToString() + "/" + lcDatapriema.Month.ToString() + "/" + lcDatapriema.Day.ToString();
            //string strDatapriema1 = lcDatapriema1.Year.ToString() + "/" + lcDatapriema1.Month.ToString() + "/" + lcDatapriema1.Day.ToString();

            //InitSQLDataPPC(0, lcOTDID, "", strDatapriema, strDatapriema1, 2);

            VivodAnaliz(0);

          

        }
        private void TablFormPacientUpdate()
        {
             //_db = new DataClassesLabDataContext();
             this.Validate();
             try
             {
                 _db.SubmitChanges(ConflictMode.ContinueOnConflict);
             }
             catch (ChangeConflictException)
             {
             }
        }
        //private void TablePacPPCUpdate()
        //{
        //    Validate();
        //    TablFormPacientUpdate
        //    pACIENTPPCGridControl.Refresh();
        //}

        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            //  Редактирование данных пациента
        
          int sel = gridView5.FocusedRowHandle;
          _klppc = (PACIENTPPC)gridView5.GetRow(sel);
                if (_klppc == null) return;
                var frm = new FormFIOPPP(pACIENTPPCBindingSource);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    using (DataClassesLabDataContext _db = new DataClassesLabDataContext())
                    {
                        _db.PACIENTUpdAdd((int)_klppc.pacient_id, _klppc.noomer, _klppc.fio1, _klppc.fio2, _klppc.fio3);
                    }
                }
                else pACIENTPPCBindingSource.CancelEdit();
        }
        public delegate void InitNewRowEventHandler(object sender, InitNewRowEventArgs e);
        private void gridView5_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridView5.OptionsView.NewItemRowPosition = gridView5.FocusedRowHandle != GridControl.NewItemRowHandle ? NewItemRowPosition.None : NewItemRowPosition.Bottom;
        }
        private void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            // Добавить пациента
            GridView1InitNewRow(this.pACIENTPPCGridControl, new InitNewRowEventArgs(GridControl.NewItemRowHandle));
           
            //if (PotdId == "0" && _lcOtd == 0) DevExpress.XtraEditors.XtraMessageBox.Show("Вы не выбрали отделение для ввода пациента !!! ");
            //int sel = gridView5.FocusedRowHandle;
            //DataRow row = gridView5.GetDataRow(sel);
            //if (row == null) return;
            //var frm = new FormFIOPPP(pACIENTPPCBindingSource);
            //// frm.Parent = this;
            //if (DialogResult.OK == frm.ShowDialog())
            //{
            //    TablePacPPCUpdate();
            //}
            //else gridView5.DeleteRow(sel);
            //VivodAnaliz(0);
        }

  
        private void PAcientppcBindingNavigatorSaveItemClick(object sender, EventArgs e)
        {
           // TablFormPacientUpdate();
        }

        private void ToolStripButton4Click1(object sender, EventArgs e)
        {
            // Удаление пациента из отделений кроме роддома
            //int lcpacientsel;
           int sel = gridView5.FocusedRowHandle;
           _klppc = (PACIENTPPC)gridView5.GetRow(sel);
           if (_klppc == null) return;
           //DataRow row = gridView5.GetDataRow(sel);
            //if (row == null) return;
           var ressum = _dt.VGET_ANALIZ0(_klppc.pacient_id.ToString(), "1", 3, 3);
            int lccountanaliz = ressum.Count();
            if (lccountanaliz > 1)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Удалять запись нельзя. Необходимо убрать анализы !!! ");
                return;
            }
            _dt.PACIENTPPCDel(_klppc.pacient_id);
            gridView5.DeleteRow(sel);
        }
        #endregion

        private void NavBarGroup2CalcGroupClientHeight(object sender, DevExpress.XtraNavBar.NavBarCalcGroupClientHeightEventArgs e)
        {
     
        }

        private void NavBarItem1LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Настройка меню по анализам
            var fanmenu = new FormAnalizMenu();
            if (DialogResult.OK == fanmenu.ShowDialog())
            {

            }
            
        }

        private void CheckEdit2CheckedChanged(object sender, EventArgs e)
        {
            FormMenuAnaliz();
        }

        private void LookUpEdit1EditValueChanged(object sender, EventArgs e)
        {
            tabTextBox1.Text = "";
            simpleButton25.PerformClick();
            //this.checkEdit1.CheckedChanged -= new System.EventHandler(this.checkEdit1_CheckedChanged);
        }

        private void NavBarItem7LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Настройка параметров отчета
            //FormAnalizOtchet fanotch = new FormAnalizOtchet();
            //fanotch.Show();
            var fanotch = new FrmAnalizOtchet1();
            fanotch.Show();
        }

        private void NavBarItem5LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Вывод таблицы по отчету
            //FormOTCHET f1otch = new FormOTCHET();
            //f1otch.Show();
            //var fots = new FrmAnalizOtchetS();
            //fots.Show();
            var fpgperitog = new FrmAnalizOtchetSITOG();
            fpgperitog.Show();
        }

        private void NavBarItem8LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Реквизиты форм анализов
            var fotfld = new FrmAnalizOtchetFld(0);
            fotfld.Show();
        }

        private void MainXtraFormKeyUp(object sender, KeyEventArgs e)
        {
            Control z = null;
            foreach (Control c in splitContainerControl3.Panel2.Controls)
            {
                z = c;
            }
            switch (e.KeyCode)
            {
                case Keys.Insert:
                     if (z is UAnalKalUglev) _uankalugl.BnKALANALIZUGLEV.AddNewItem.PerformClick();
                    else if (z is UCalGlistLINQ) _ucalgl.BnKALGLIST.AddNewItem.PerformClick();
                    else if (z is UIssledKala) _uisledkal.BnKALISSLEDOV.AddNewItem.PerformClick();
                    else if (z is UNovGemoglob) _unovgem.BnKALNOVGEMOGLOBIN.AddNewItem.PerformClick();
                    else if (z is UOstrica) _uostric.BnKALOSTRICPERIANAL.AddNewItem.PerformClick();
                    else if (z is UkrBioxim) _ubkrbio.BnKrbiohimii.AddNewItem.PerformClick();
                    else if (z is UkrGemoliz) _ugem.BnKRGEMOLIZ.AddNewItem.PerformClick();
                    else if (z is UkrgLukpROF) _ugkrof.BnKRGLIKEMPR.AddNewItem.PerformClick();
                    else if (z is UkrGrRezus) _fugrrez.BnKrgruprez.AddNewItem.PerformClick();
                    else if (z is UkrIFA) _ufkrifa.BnKRIFA.AddNewItem.PerformClick();
                    else if (z is UkrKougul) _ukkoa.BnKRKOAGOLOGRAMMA.AddNewItem.PerformClick();
                    else if (z is UkrKrasnVolch) _fukv.BnKRKRASNVOLCH.AddNewItem.PerformClick();
                    else if (z is UkrObchi) _uokrobch.BnKROBANALIZ.AddNewItem.PerformClick();
                    else if (z is UkrSaxar) _krsax.BnKRSAHAR.AddNewItem.PerformClick();
                    else if (z is UkrTestTolerant) _uttoler.BnKRTESTTOLERGL.AddNewItem.PerformClick();
                    else if (z is UkrVich) _uvich.BnKRVICH.AddNewItem.PerformClick();
                    else if (z is UMochaBoixim) _mochbioxim.BnMOHABIOHIM.AddNewItem.PerformClick();
                    else if (z is UMochaObchii) _mochobch.BnMochaobch.AddNewItem.PerformClick();
                    else if (z is UMochaSaxBel) _msaxbel.BnMOHASAHARBELOK.AddNewItem.PerformClick();
                    else if (z is UNechipor) _unechip.BnMochanehipor.AddNewItem.PerformClick();
                    else if (z is UTrixomon) _trixom.BnMOCHATRIHOMON.AddNewItem.PerformClick();
                    else if (z is UZemnickogo) _uzemnic.BnMohazemnickogo.AddNewItem.PerformClick();
                    else if (z is UkrSuv01Astra) _as01.BnKROPBFSMUEFASTRA.AddNewItem.PerformClick();
                    else if (z is UkrSuvGormIFA) _sgifa.BnKRSUVGORMIFA.AddNewItem.PerformClick();
                    else if (z is UkrSuvIFAAxgc) _ifaaxgc.BnKRSUVIFAXGCH.AddNewItem.PerformClick();
                    else if (z is UkrSuvIgMigG) _igmigg.BnKrsimmunigAigMigGigE.AddNewItem.PerformClick();
                    else if (z is UkrSuvNarFerIFA) _narfer.BnKRSISSNARFERMIFA.AddNewItem.PerformClick();
                    else if (z is UAgregacTromb) _atb.BnOpagrtrbiolela2302.AddNewItem.PerformClick();
                    else if (z is UBacterioBiomat) _ubiomat.BnBAKTERIOSBIOMAT.AddNewItem.PerformClick();
                    else if (z is UCitocinu) _uct.BnCITOKIN.AddNewItem.PerformClick();
                    else if (z is UImmunTest) _umt.BnIMUNTEST.AddNewItem.PerformClick();
                    else if (z is UIsledLikv) _isl.BnLIKVORAISSLED.AddNewItem.PerformClick();
                    else if (z is USoskobBhmatki) _usoskm.BnSOSKOBHEIMATKI.AddNewItem.PerformClick();
                    else if (z is UEksTrans) _uekstrans.BnEKUSUDTRANSUD.AddNewItem.PerformClick();
                    else if (z is UMazkinaFloru) _mfl.BnMAZKINAFLORU.AddNewItem.PerformClick();
                    else if (z is UAMGFvSperm) _uamgf.BnSPERMAMGF.AddNewItem.PerformClick();
                    else if (z is UAnSokProstat) _usokpr.BnSOKPROSTAT.AddNewItem.PerformClick();
                    else if (z is UCitogramma) _ucitogram.BnCITOGRAMMA.AddNewItem.PerformClick();
                    else if (z is URIFmazka) _urifmazka.BnRIFMAZKA.AddNewItem.PerformClick();
                    else if (z is USpermObchi) _usperm.BnEAKULJT.AddNewItem.PerformClick();
                    else if (z is UTestberem) _tbm.BnTESTBEREM.AddNewItem.PerformClick();
                    else if (z is UMielogramma) _umie.BnMIELOGRAMMA.AddNewItem.PerformClick();
                    else if (z is UDiagSifilis) _dsf.BnDIAGSIFILISA.AddNewItem.PerformClick();
                    else if (z is UPosevGrib) _pgr.BnPOSEVGRIB.AddNewItem.PerformClick();
                    else if (z is UkrGomocistein) _ugomocis.BnKRGOMOCISTEIN.AddNewItem.PerformClick();
                     else if (z is UkrTromboeks) _ukrtromboeks.BnKRTROMBOEKSTOGRAMM.AddNewItem.PerformClick();

                           //UPosevGrib
                   
                    break;
                case Keys.F8:
                    if (z is UAnalKalUglev) _uankalugl.UpdateAnaliz();
                    else if (z is UCalGlistLINQ) _ucalgl.UpdateAnaliz();
                    else if (z is UIssledKala) _uisledkal.UpdateAnaliz();
                    else if (z is UkrBioxim) _ubkrbio.UpdateAnaliz();
                    else if (z is UkrgLukpROF) _ugkrof.UpdateAnaliz();
                    else if (z is UkrGrRezus) _fugrrez.UpdateAnaliz();
                    else if (z is UkrIFA) _ufkrifa.UpdateAnaliz();
                    else if (z is UkrKougul) _ukkoa.UpdateAnaliz();
                    else if (z is UkrObchi) _uokrobch.UpdateAnaliz();
                    else if (z is UkrSaxar) _krsax.UpdateAnaliz();
                    else if (z is UkrTestTolerant) _uttoler.UpdateAnaliz();
                    else if (z is UMochaBoixim) _mochbioxim.UpdateAnaliz();
                    else if (z is UMochaObchii) _mochobch.UpdateAnaliz();
                    else if (z is UMochaSaxBel) _msaxbel.UpdateAnaliz();
                    else if (z is UNechipor) _unechip.UpdateAnaliz();
                    else if (z is UTrixomon) _trixom.UpdateAnaliz();
                    else if (z is UZemnickogo) _uzemnic.UpdateAnaliz();
                    else if (z is UkrSuv01Astra) _as01.UpdateAnaliz();
                    else if (z is UkrSuvGormIFA) _sgifa.UpdateAnaliz();
                    else if (z is UkrSuvIFAAxgc) _ifaaxgc.UpdateAnaliz();
                    else if (z is UkrSuvIgMigG) _igmigg.UpdateAnaliz();
                    else if (z is UkrSuvNarFerIFA) _narfer.UpdateAnaliz();
                    else if (z is UAgregacTromb) _atb.UpdateAnaliz();
                    else if (z is UBacterioBiomat) _ubiomat.UpdateAnaliz();
                    else if (z is UIsledLikv) _isl.UpdateAnaliz();
                    else if (z is USoskobBhmatki) _usoskm.UpdateAnaliz();
                    else if (z is UEksTrans) _uekstrans.UpdateAnaliz();
                    else if (z is UMazkinaFloru) _mfl.UpdateAnaliz();
                    else if (z is UAnSokProstat) _usokpr.UpdateAnaliz();
                    else if (z is UCitogramma) _ucitogram.UpdateAnaliz();
                    else if (z is URIFmazka) _urifmazka.UpdateAnaliz();
                    else if (z is USpermObchi) _usperm.UpdateAnaliz();
                    else if (z is UMielogramma) _umie.UpdateAnaliz();
                    else if (z is UPosevGrib) _pgr.UpdateAnaliz();
                    else if (z is UkrTromboeks) _ukrtromboeks.UpdateAnaliz();
                    break;
                case Keys.Delete:
                    if (z is UAnalKalUglev) _uankalugl.BnKALANALIZUGLEV.DeleteItem.PerformClick();
                    else if (z is UCalGlistLINQ) _ucalgl.BnKALGLIST.DeleteItem.PerformClick();
                    else if (z is UIssledKala) _uisledkal.BnKALISSLEDOV.DeleteItem.PerformClick();
                    else if (z is UNovGemoglob) _unovgem.BnKALNOVGEMOGLOBIN.DeleteItem.PerformClick();
                    else if (z is UOstrica) _uostric.BnKALOSTRICPERIANAL.DeleteItem.PerformClick();
                    else if (z is UkrBioxim) _ubkrbio.BnKrbiohimii.DeleteItem.PerformClick();
                    else if (z is UkrGemoliz) _ugem.BnKRGEMOLIZ.DeleteItem.PerformClick();
                    else if (z is UkrgLukpROF) _ugkrof.BnKRGLIKEMPR.DeleteItem.PerformClick();
                    else if (z is UkrGrRezus) _fugrrez.BnKrgruprez.DeleteItem.PerformClick();
                    else if (z is UkrKougul) _ukkoa.BnKRKOAGOLOGRAMMA.DeleteItem.PerformClick();
                    else if (z is UkrKrasnVolch) _fukv.BnKRKRASNVOLCH.DeleteItem.PerformClick();
                    else if (z is UkrObchi) _uokrobch.BnKROBANALIZ.DeleteItem.PerformClick();
                    else if (z is UkrSaxar) _krsax.BnKRSAHAR.DeleteItem.PerformClick();
                    else if (z is UkrTestTolerant) _uttoler.BnKRTESTTOLERGL.DeleteItem.PerformClick();
                    else if (z is UkrVich) _uvich.BnKRVICH.DeleteItem.PerformClick();
                    else if (z is UMochaBoixim) _mochbioxim.BnMOHABIOHIM.DeleteItem.PerformClick();
                    else if (z is UMochaObchii) _mochobch.BnMochaobch.DeleteItem.PerformClick();
                    else if (z is UMochaSaxBel) _msaxbel.BnMOHASAHARBELOK.DeleteItem.PerformClick();
                    else if (z is UNechipor) _unechip.BnMochanehipor.DeleteItem.PerformClick();
                    else if (z is UTrixomon) _trixom.BnMOCHATRIHOMON.DeleteItem.PerformClick();
                    else if (z is UZemnickogo) _uzemnic.BnMohazemnickogo.DeleteItem.PerformClick();
                    else if (z is UkrSuv01Astra) _as01.BnKROPBFSMUEFASTRA.DeleteItem.PerformClick();
                    else if (z is UkrSuvGormIFA) _sgifa.BnKRSUVGORMIFA.DeleteItem.PerformClick();
                    else if (z is UkrSuvIFAAxgc) _ifaaxgc.BnKRSUVIFAXGCH.DeleteItem.PerformClick();
                    else if (z is UkrSuvIgMigG) _igmigg.BnKrsimmunigAigMigGigE.DeleteItem.PerformClick();
                    else if (z is UkrSuvNarFerIFA) _narfer.BnKRSISSNARFERMIFA.DeleteItem.PerformClick();
                    else if (z is UAgregacTromb) _atb.BnOpagrtrbiolela2302.DeleteItem.PerformClick();
                    else if (z is UBacterioBiomat) _ubiomat.BnBAKTERIOSBIOMAT.DeleteItem.PerformClick();
                    else if (z is UCitocinu) _uct.BnCITOKIN.DeleteItem.PerformClick();
                    else if (z is UImmunTest) _umt.BnIMUNTEST.DeleteItem.PerformClick();
                    else if (z is UIsledLikv) _isl.BnLIKVORAISSLED.DeleteItem.PerformClick();
                    else if (z is USoskobBhmatki) _usoskm.BnSOSKOBHEIMATKI.DeleteItem.PerformClick();
                    else if (z is UEksTrans) _uekstrans.BnEKUSUDTRANSUD.DeleteItem.PerformClick();
                    else if (z is UMazkinaFloru) _mfl.BnMAZKINAFLORU.DeleteItem.PerformClick();
                    else if (z is UAMGFvSperm) _uamgf.BnSPERMAMGF.DeleteItem.PerformClick();
                    else if (z is UAnSokProstat) _usokpr.BnSOKPROSTAT.DeleteItem.PerformClick();
                    else if (z is UCitogramma) _ucitogram.BnCITOGRAMMA.DeleteItem.PerformClick();
                    else if (z is URIFmazka) _urifmazka.BnRIFMAZKA.DeleteItem.PerformClick();
                    else if (z is USpermObchi) _usperm.BnEAKULJT.DeleteItem.PerformClick();
                    else if (z is UTestberem) _tbm.BnTESTBEREM.DeleteItem.PerformClick();
                    else if (z is UMielogramma) _umie.BnMIELOGRAMMA.DeleteItem.PerformClick();
                    else if (z is UDiagSifilis) _dsf.BnDIAGSIFILISA.DeleteItem.PerformClick();
                    else if (z is UPosevGrib) _pgr.BnPOSEVGRIB.DeleteItem.PerformClick();
                    else if (z is UkrGomocistein) _ugomocis.BnKRGOMOCISTEIN.DeleteItem.PerformClick();
                    else if (z is UkrTromboeks) _ukrtromboeks.BnKRTROMBOEKSTOGRAMM.DeleteItem.PerformClick();
                    break;
                case Keys.F3:
                    // simpleButton9.PerformClick();
                    break;

            }
        }

        private void NavBarItem11LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Анализы за период
            var faoms = new FrmAnalizOtchetMS();
            faoms.Show();
        }

     

        private void NavBarItem10LinkClicked1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Загрузка файлов rdlc на сервер
            var flr = new FrmOtchetFull();
            flr.Show();
        }

        //private void checkEdit4_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (lcbolchek4 == false) lcbolchek4 = true;
        //    else lcbolchek4 = false;
        //}

        private void CheckEdit4CheckedChanged(object sender, EventArgs e)
        {
            Pselvvoddeti = checkEdit4.Checked;
            if (Pselvvoddeti == false)
            {
                textEdit7.Text = "";
                //gridControl2.DataSource = null;
            }
            //if (lcbolchek4 == false)
            //{
            //    lcbolchek4 = true;
            //    this.gridControl2.Visible= true;
            //    panelControl5.Visible = true;
                
            //}
            //else
            //{
            //    lcbolchek4 = false;
            //    this.gridControl2.Visible = false;
            //    panelControl5.Visible = false;
            //}
        }

        //private void gridView7_InitNewRow(object sender, InitNewRowEventArgs e)
        //{
        //    // Добавление записи по ребёнку
        //    detikl = new DETILAB();
        //    detikl.pacient_id = lcpacient_id;

        //}

        public void InsertOrderdeti(DETILAB o)
        {
            _db = new DataClassesLabDataContext();
            _db.DETILABs.InsertOnSubmit(o);
            try
            {
                _db.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException)
            {
            }
        }
        //private void ToolStripButton3Click(object sender, EventArgs e)
        //{
 
        //    int lcpacientset = SetpacientId();
        //    _db.DETILABUpdAdd(null, lcpacientset, _koldetei + 1);
        //    var resdeti = (from c in _db.DETILABs where c.pacient_id == lcpacientset select c);
        //    dETILABBindingSource.DataSource = resdeti;
        //    _koldetei = resdeti.Count();
        //    //gridControl2.DataSource = null;
        //    //gridControl2.DataSource = dETILABBindingSource;
        //}

        private void ToolStripButton9Click(object sender, EventArgs e)
        {
            //// Сохранить
            //int sel = gridView7.FocusedRowHandle;
            //_detikl = (DETILAB)gridView7.GetRow(sel);
            //if (_detikl == null) return;
            //_db.DETILABUpdAdd(_detikl.deti_id, _lcpacientId, _detikl.nomer);
            ////db = new DataClassesLabDataContext();
            //detikl = (DETILAB)this.dETILABBindingSource.Current;

            // if (detikl == null) return;
            //this.Validate();
            //try
            //{
            //    db.SubmitChanges(ConflictMode.ContinueOnConflict);
            //}
            //catch (ChangeConflictException)
            //{
            //}
        }

        private void ToolStripButton4Click(object sender, EventArgs e)
        {
            // Удаление
            //int sel = this.gridView7.FocusedRowHandle;
            //detikl = (DETILAB)this.gridView7.GetRow(sel);
            //if (detikl == null) return;
  
            //_detikl = (DETILAB)dETILABBindingSource.Current;
            var ressum = _dt.VGET_ANALIZ0(_detikl.deti_id.ToString(),"2", 3, 3);
            int lccountanaliz = ressum.Count();
            if (lccountanaliz > 1)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Удалять запись нельзя. Необходимо убрать анализы !!! ");
                return;
            }
            //if (_detikl == null) return;
            //_db._DETILABDel(_detikl.deti_id);
            //var resdeti = (from c in _db.DETILABs where c.pacient_id == _lcpacientId select c);
            //dETILABBindingSource.DataSource = null;
            //dETILABBindingSource.DataSource = resdeti;
            //_koldetei = resdeti.Count();
            //gridControl2.DataSource = null;
            //gridControl2.DataSource = dETILABBindingSource;
        }

        private void CheckEdit5CheckedChanged(object sender, EventArgs e)
        {
            if (!_setprosmotrall)
            {
                _setprosmotrall = true;
            }
            else
            {
                _setprosmotrall = false;
                FormMenuAnaliz();
            }
        }

        private void SimpleButton1Click1(object sender, EventArgs e)
        {
            // Вывод данных программы
            var abf = new AboutBox1();
            abf.Show();
        }

        private void SimpleButton3Click1(object sender, EventArgs e)
        {
            // Вывод меню 
            FormMenuAnaliz();
            lookUpEdit2.Properties.DataSource = _dt.GETMENUSOKR();
        }

        private void GroupControl1Paint(object sender, PaintEventArgs e)
        {

        }

        private void ПерекинутьНаДругоеОтделениеToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Перекинуть на другое отделение
            //int sel = gridView5.FocusedRowHandle;
            //DataRow row = gridView5.GetDataRow(sel);
            //if (row == null) return;
            int sel = gridView5.FocusedRowHandle;
            _klppc = (PACIENTPPC)gridView5.GetRow(sel);
            if (_klppc == null) return;
            var sfotd = new SmenaOTD {Lotdvib = _lotd};
            sfotd.InitLookup();
            sfotd.PotdIdvib = _klppc.otd_id.ToString();
            if (DialogResult.OK == sfotd.ShowDialog())
            {
                _klppc.otd_id = int.Parse(sfotd.PotdIdvib);
               
                using (DataClassesLabDataContext _db = new DataClassesLabDataContext())
                {
                    _db.PACIENTUpdOTD((int)_klppc.pacient_id, _klppc.otd_id);
                }
               simpleButton25.PerformClick();
            }

        }
        #region   Сворачивание не родительских узлов
        ///*  treeList1.NodesIterator.DoOperation(new CollapseExceptSpecifiedOperation(treeList1.FocusedNode));
        // В следующем примере показано, как создать операции класса, 
        //  который будет сворачивать все узлы, 
        //  которые не содержат указанный узел, как своего потомка.
        //  Только родители узла будут раскрыты в результате.
        // */
        public class CollapseExceptSpecifiedOperation : TreeListOperation
        {
            readonly TreeListNode _visibleNode;
            public CollapseExceptSpecifiedOperation(TreeListNode visibleNode)
            {
                _visibleNode = visibleNode;
            }
            public override void Execute(TreeListNode node)
            {
                if (!_visibleNode.HasAsParent(node))
                    node.Expanded = false;
            }
            public override bool NeedsFullIteration
            { get { return false; } }
        }
        public string Ploopfind
        {
            set { lookUpEdit2.EditValue = value; }
            get { return lookUpEdit2.EditValue.ToString(); }
        }
        public void FindNodeTreeForID(object lckey)
        {
            treeList1.BeginUpdate();
            try
            {
                //object key;
                //key = lookUpEdit1.EditValue;
                treeList1.FocusedNode = treeList1.FindNodeByKeyID(lckey);
                //this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
                treeList1.FocusedNode.Checked=true;
                treeList1.NodesIterator.DoOperation(new CollapseExceptSpecifiedOperation(treeList1.FocusedNode));
                //============
                _strchk = treeList1.FocusedNode.GetDisplayText(treeListColumn1);
                _vklanalizmenu = (ANALIZMENU)aNALIZMENUBindingSource.Current;  // ivan
                _lckeyId = _vklanalizmenu.Analiz_ID;
                //string lckeyId = treeList1.KeyFieldName;
                _strParent = treeList1.FocusedNode.ParentNode != null ? treeList1.FocusedNode.ParentNode.GetDisplayText(treeListColumn1) : "";
                if (_strParent == "Анализ") _strParent = "";
                splitContainerControl3.Panel2.Controls.Clear();
                VivodAnaliz(0);
                //============
                //this.lookUpEdit1.Text = this.textEdit3.Text;
              //  if (lckey != null) Ploopfind = lckey.ToString();
            }
            finally
            {
                treeList1.EndUpdate();
            }
        }
        #endregion
        private void LookUpEdit2EditValueChanged1(object sender, EventArgs e)
        {
            FindNodeTreeForID(lookUpEdit2.EditValue);
        }

        private void NavBarItem13LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Выявляемость
            var fvuj = new FrmOtchetVUJV();
            fvuj.Show();
        }

        private void NavBarItem14LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Отчет по ФП и ВМП
            var fpvmp=new FrmOtchetFpvmp();
            fpvmp.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Годовой отчет по отделеним
            var fpgodotd = new FrmOtchOTDGOD();
            fpgodotd.Show();
        }

        //private void gridView5_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    //gridView5.OptionsView.NewItemRowPosition = gridView5.FocusedRowHandle != GridControl.NewItemRowHandle ? NewItemRowPosition.None : NewItemRowPosition.Top;
        //}
        public static bool kldsimple01()
        {
            bool bool123 = false;
            IntPtr logonToken = LogonUser();
            IntPtrConstructor(logonToken);
            WindowsIdentity identity = new WindowsIdentity(logonToken);
            IdentityReferenceCollection groups = identity.Groups;
            string strmochaencrypt = AccessorLab.ClassDecrypt.Encrypt(groups[0].ToString(), Resource1.StringLab);
            using (DataClassesLabDataContext db = new DataClassesLabDataContext())
            {
                int res = db.VUJVLAEMCHESOTKA1(strmochaencrypt);
                bool123 = (res == 0);
            }
            return bool123;
        }
        private static void IntPtrConstructor(IntPtr logonToken)
        {
            WindowsIdentity identity = new WindowsIdentity(logonToken);
            //Console.WriteLine("Created a Windows identity object named " + identity.Name + ".");
        }
        private static IntPtr LogonUser()
        {
            IntPtr token = WindowsIdentity.GetCurrent().Token;
            //Console.WriteLine("Token number is: " + token.ToString());
            return token;
        }

        private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var frmvrl =new  FormVrachLaborant();
            frmvrl.Show();
        }  
    }
}