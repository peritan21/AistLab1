using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AistLabData;
using CustomControlLib;
using KdlForm.AnalizKala;
using KdlForm.AnalizMochi;
using KdlForm.Analizkrovi;
using KdlForm.Krsuvorotka1;
using KdlForm.Maski;
using KdlForm.Mielogramma;
using KdlForm.New2202;
using KdlForm.Posevu;
using KdlForm.Testu_prochie;


namespace AistLab
{
    class ClassShowAnalizForm
    {
        //private AccessorLab.OTCHETPERIODR_R kle;
        //private AccessorLab.AnalizOtchet otch;
        //private int tablid1 = 0;
        private readonly DataClassesLabDataContext _dt = new DataClassesLabDataContext();
        public List<LABORANT> Labanalizc      { get; set; }
        public void ShowCaseInFormAnaliz(BindingSource dataSource1, int tablid1, AccessorLab.OTCHETPERIODR_R kle, ANALIZMENU kle1,AccessorLab.FullOtchet kle2,AccessorLab.OtchetUslkol kle3) 
        {
            string strtablname = "";
            if (kle != null) strtablname = kle.TABLNAME;
            else if (kle1!=null) strtablname = kle1.TABLNAME;
            else if (kle2 != null) strtablname = kle2.nametable;
            else if (kle3 != null) strtablname = kle3.TABLNAME;
            switch (strtablname)
            {
                case "MOCHAOBCH":

                    dataSource1.DataSource = from c in _dt.MOCHAOBCHes where c.mochaobch_id == tablid1 select c;
                    var fmo1 = new FrmMochaObchii(dataSource1) {Llabanaliz = Labanalizc};
                    fmo1.InitLookup();
                    if (DialogResult.OK == fmo1.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "MOCHATRIHOMON":

                    dataSource1.DataSource = from c in _dt.MOCHATRIHOMONs where c.mochatrihomon_id == tablid1 select c;
                    var fmo2 = new FrmTrixomonad(dataSource1) {Llabanaliz = Labanalizc};
                    fmo2.InitLookup();
                    if (DialogResult.OK == fmo2.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "MOHASAHARBELOK":

                    dataSource1.DataSource = from c in _dt.MOHASAHARBELOKs where c.sutmohasahbelok_id == tablid1 select c;
                    var fmo3 = new FrmMohasaharbelok(dataSource1) {Llabanaliz = Labanalizc};
                    fmo3.InitLookup();
                    if (DialogResult.OK == fmo3.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "MOHAZEMNICKOGO":

                    dataSource1.DataSource = from c in _dt.MOHAZEMNICKOGOs where c.mohazemnickii_id == tablid1 select c;
                    var fmo4 = new FrmZimnickgo(dataSource1) {Llabanaliz = Labanalizc};
                    fmo4.InitLookup();
                    if (DialogResult.OK == fmo4.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "MOCHANEHIPOR":

                    dataSource1.DataSource = from c in _dt.MOCHANEHIPORs where c.nechip_id == tablid1 select c;
                    var fmo5 = new FrmNechipor(dataSource1) {Llabanaliz = Labanalizc};
                    fmo5.InitLookup();
                    if (DialogResult.OK == fmo5.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KRGRUPREZ":

                    dataSource1.DataSource = from c in _dt.KRGRUPREZs where c.skrgruprezus_id == tablid1 select c;
                    var fmo6 = new FrmRekvLaborant(dataSource1) {Llabanaliz = Labanalizc};
                    fmo6.InitLookup();
                    if (DialogResult.OK == fmo6.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KRGEMOLIZ":

                    dataSource1.DataSource = from c in _dt.KRGEMOLIZs where c.krgemoliz_id == tablid1 select c;
                    var fmo7 = new FrmKrGemoliz(dataSource1) {Llabanaliz = Labanalizc};
                    fmo7.InitLookup();
                    if (DialogResult.OK == fmo7.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KRVICH":

                    dataSource1.DataSource = from c in _dt.KRVICHes where c.vich_id == tablid1 select c;
                    var fmo8 = new FrmKrVich(dataSource1) {Llabanaliz = Labanalizc};
                    fmo8.InitLookup();
                    if (DialogResult.OK == fmo8.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KROBANALIZ":

                    dataSource1.DataSource = from c in _dt.KROBANALIZs where c.krobch_id == tablid1 select c;
                    var fmo9 = new FrmKrOb(dataSource1) {Llabanaliz = Labanalizc};
                    fmo9.InitLookup();
                    if (DialogResult.OK == fmo9.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KRBIOHIMII":

                    dataSource1.DataSource = from c in _dt.KRBIOHIMIIs where c.krbiohim_id == tablid1 select c;
                    var fmo10 = new FrmKrBioxim(dataSource1) {Llabanaliz = Labanalizc};
                    fmo10.InitLookup();
                    if (DialogResult.OK == fmo10.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KRSAHAR":

                    dataSource1.DataSource = from c in _dt.KRSAHARs where c.analsahar_id == tablid1 select c;
                    var fmo11 = new FrmKrSaxar(dataSource1) {Llabanaliz = Labanalizc};
                    fmo11.InitLookup();
                    if (DialogResult.OK == fmo11.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "MAZKINAFLORU":

                    dataSource1.DataSource = from c in _dt.MAZKINAFLORUs where c.mazkibafloru_id == tablid1 select c;
                    var fmo12 = new FrmMazkinaFloru(dataSource1) {Llabanaliz = Labanalizc};
                    fmo12.InitLookup();
                    if (DialogResult.OK == fmo12.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "RIFMAZKA":

                    dataSource1.DataSource = from c in _dt.RIFMAZKAs where c.rifmazka_id == tablid1 select c;
                    var fmo13 = new FrmRIFmazka(dataSource1) {Llabanaliz = Labanalizc};
                    fmo13.InitLookup();
                    if (DialogResult.OK == fmo13.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "CITOGRAMMA":

                    dataSource1.DataSource = from c in _dt.CITOGRAMMAs where c.citologij_id == tablid1 select c;
                    var fmo14 = new FrmCitogram(dataSource1) {Llabanaliz = Labanalizc};
                    fmo14.InitLookup();
                    if (DialogResult.OK == fmo14.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "POSEVGRIB":

                    dataSource1.DataSource = from c in _dt.POSEVGRIBs where c.posevgrib_id == tablid1 select c;
                    var fmo15 = new FrmPosevGrib(dataSource1) {Llabanaliz = Labanalizc};
                    fmo15.InitLookup();
                    if (DialogResult.OK == fmo15.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "TESTBEREM":

                    dataSource1.DataSource = from c in _dt.TESTBEREMs where c.testberem_id == tablid1 select c;
                    var fmo16 = new FrmTestBerem(dataSource1) {Llabanaliz = Labanalizc};
                    fmo16.InitLookup();
                    if (DialogResult.OK == fmo16.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "EKUSUDTRANSUD":

                    dataSource1.DataSource = from c in _dt.EKUSUDTRANSUDs where c.eksudat_id == tablid1 select c;
                    var fmo17 = new FormEksTrans(dataSource1) {Llabanaliz = Labanalizc};
                    fmo17.InitLookup();
                    if (DialogResult.OK == fmo17.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KRSUVGORMIFA":

                    dataSource1.DataSource = from c in _dt.KRSUVGORMIFAs where c.krissuvgormifa_id == tablid1 select c;
                    var fmo18 = new FrmKrSuvGormIFA(dataSource1) {Llabanaliz = Labanalizc};
                    fmo18.InitLookup();
                    if (DialogResult.OK == fmo18.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KRSIMMUNIgAIgMIgGIgE":

                    dataSource1.DataSource = from c in _dt.KRSIMMUNIgAIgMIgGIgEs where c.krsopimmungl_id == tablid1 select c;
                    var fmo19 = new FrmKrSImmunIgAigMigGigE(dataSource1) {Llabanaliz = Labanalizc};
                    fmo19.InitLookup();
                    if (DialogResult.OK == fmo19.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KRSISSNARFERMIFA":

                    dataSource1.DataSource = from c in _dt.KRSISSNARFERMIFAs where c.krsissbarfertifa_id == tablid1 select c;
                    var fmo20 = new FrmKrSIssNarFerIFA(dataSource1) {Llabanaliz = Labanalizc};
                    fmo20.InitLookup();
                    if (DialogResult.OK == fmo20.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KRSUVIFAXGCH":

                    dataSource1.DataSource = from c in _dt.KRSUVIFAXGCHes where c.antixgh_id == tablid1 select c;
                    var fmo21 = new FrmKrSuvIfaXgch(dataSource1) {Llabanaliz = Labanalizc};
                    fmo21.InitLookup();
                    if (DialogResult.OK == fmo21.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KROPBFSMUEFASTRA":

                    dataSource1.DataSource = from c in _dt.KROPBFSMUEFASTRAs where c.opbelfrsuvkruef_id == tablid1 select c;
                    var fmo22 = new FrmKRopSMetelektUEFAstra(dataSource1) {Llabanaliz = Labanalizc};
                    fmo22.InitLookup();
                    if (DialogResult.OK == fmo22.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KRGLIKEMPR":

                    dataSource1.DataSource = from c in _dt.KRGLIKEMPRs where c.ankrglikemprof_id == tablid1 select c;
                    var fmo23 = new FrmAnalKrGlikemihPr(dataSource1) {Llabanaliz = Labanalizc};
                    fmo23.InitLookup();
                    if (DialogResult.OK == fmo23.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KRKOAGOLOGRAMMA":

                    dataSource1.DataSource = from c in _dt.KRKOAGOLOGRAMMAs where c.koakulogramma_id == tablid1 select c;
                    var fmo24 = new FrmKoagylogramma(dataSource1) {Llabanaliz = Labanalizc};
                    fmo24.InitLookup();
                    if (DialogResult.OK == fmo24.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "MOHABIOHIM":

                    dataSource1.DataSource = from c in _dt.MOHABIOHIMs where c.biohimmoha_id == tablid1 select c;
                    var fmo25 = new FrmMohaBiohim(dataSource1) {Llabanaliz = Labanalizc};
                    fmo25.InitLookup();
                    if (DialogResult.OK == fmo25.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KRKRASNVOLCH":

                    dataSource1.DataSource = from c in _dt.KRKRASNVOLCHes where c.krkracnvolch_id == tablid1 select c;
                    var fmo26 = new FrmKrasnVolch(dataSource1) {Llabanaliz = Labanalizc};
                    fmo26.InitLookup();
                    if (DialogResult.OK == fmo26.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "MIELOGRAMMA":

                    dataSource1.DataSource = from c in _dt.MIELOGRAMMAs where c.mielogramma_id == tablid1 select c;
                    var fmo27 = new FrmMielogramma(dataSource1) {Llabanaliz = Labanalizc};
                    fmo27.InitLookup();
                    if (DialogResult.OK == fmo27.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "BAKTERIOSBIOMAT":

                    dataSource1.DataSource = from c in _dt.BAKTERIOSBIOMATs where c.bakterioskopbiom_id == tablid1 select c;
                    var fmo28 = new FrmBakteriosBiomat1(dataSource1) {Llabanaliz = Labanalizc};
                    fmo28.InitLookup();
                    if (DialogResult.OK == fmo28.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "IMUNTEST":

                    dataSource1.DataSource = from c in _dt.IMUNTESTs where c.immuntest_id == tablid1 select c;
                    var fmo29 = new FrmImunTest(dataSource1) {Llabanaliz = Labanalizc};
                    fmo29.InitLookup();
                    if (DialogResult.OK == fmo29.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "OPAGRTRBIOLELA230_2":

                    dataSource1.DataSource = from c in _dt.OPAGRTRBIOLELA230_2s where c.opagrtromstimind_id == tablid1 select c;
                    var fmo30 = new FrmOpAgrTrBioleLa(dataSource1) {Llabanaliz = Labanalizc};
                    fmo30.InitLookup();
                    if (DialogResult.OK == fmo30.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "CITOKIN":
                    dataSource1.DataSource = from c in _dt.CITOKINs where c.citokin_id == tablid1 select c;
                    var fmo31 = new FrmCitokin(dataSource1) {Llabanaliz = Labanalizc};
                    fmo31.InitLookup();
                    if (DialogResult.OK == fmo31.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "DIAGSIFILISA":
                    dataSource1.DataSource = from c in _dt.DIAGSIFILISAs where c.diagsifilisa_id == tablid1 select c;
                    var fmo32 = new FrmDiagSifilisa(dataSource1) {Llabanaliz = Labanalizc};
                    fmo32.InitLookup();
                    if (DialogResult.OK == fmo32.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KALANALIZUGLEV":
                    dataSource1.DataSource = from c in _dt.KALANALIZUGLEVs where c.kaluglev_id == tablid1 select c;
                    var fmo33 = new FrmAnalKalUgl(dataSource1) {Llabanaliz = Labanalizc};
                    fmo33.InitLookup();
                    if (DialogResult.OK == fmo33.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KALISSLEDOV":
                    dataSource1.DataSource = from c in _dt.KALISSLEDOVs where c.kalaissledov_id == tablid1 select c;
                    var fmo34 = new FrmIssledKala(dataSource1) {Llabanaliz = Labanalizc};
                    fmo34.InitLookup();
                    if (DialogResult.OK == fmo34.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KALGLIST":
                    dataSource1.DataSource = from c in _dt.KALGLISTs where c.kalglist_id == tablid1 select c;
                    var fmo35 = new FrmCalglistLINQ(dataSource1) {Llabanaliz = Labanalizc};
                    fmo35.InitLookup();
                    if (DialogResult.OK == fmo35.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KALOSTRICPERIANAL":
                    dataSource1.DataSource = from c in _dt.KALOSTRICPERIANALs where c.kalostricperianal_id == tablid1 select c;
                    var fmo36 = new FrmKalOstric(dataSource1) {Llabanaliz = Labanalizc};
                    fmo36.InitLookup();
                    if (DialogResult.OK == fmo36.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "EAKULJT":
                    dataSource1.DataSource = from c in _dt.EAKULJTs where c.aneakulijt_id == tablid1 select c;
                    var fmo37 = new FrmSpermObchii(dataSource1) {Llabanaliz = Labanalizc};
                    fmo37.InitLookup();
                    if (DialogResult.OK == fmo37.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "SPERMAMGF":
                    dataSource1.DataSource = from c in _dt.SPERMAMGFs where c.spermamgf_id == tablid1 select c;
                    var fmo38 = new FrmSpermAMGF(dataSource1) {Llabanaliz = Labanalizc};
                    fmo38.InitLookup();
                    if (DialogResult.OK == fmo38.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KALNOVGEMOGLOBIN":
                    dataSource1.DataSource = from c in _dt.KALNOVGEMOGLOBINs where c.oprkalnovgemogl_id == tablid1 select c;
                    var fmo39 = new FrmNovGemoglob(dataSource1) {Llabanaliz = Labanalizc};
                    fmo39.InitLookup();
                    if (DialogResult.OK == fmo39.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "LIKVORAISSLED":
                    dataSource1.DataSource = from c in _dt.LIKVORAISSLEDs where c.issledlikvora_id == tablid1 select c;
                    var fmo40 = new FrmLikvoraIssled(dataSource1) {Llabanaliz = Labanalizc};
                    fmo40.InitLookup();
                    if (DialogResult.OK == fmo40.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KRIFA":
                    dataSource1.DataSource = from c in _dt.KRIFAs where c.ifa_id == tablid1 select c;
                    var fmo41 = new FrmIsSKrmetIFA(dataSource1) {Llabanaliz = Labanalizc};
                    fmo41.InitLookup();
                    if (DialogResult.OK == fmo41.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "SOKPROSTAT":
                    dataSource1.DataSource = from c in _dt.SOKPROSTATs where c.ansokaprostat_id == tablid1 select c;
                    var fmo42 = new FrmAnSokProstat(dataSource1) {Llabanaliz = Labanalizc};
                    fmo42.InitLookup();
                    if (DialogResult.OK == fmo42.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KRTESTTOLERGL":
                    dataSource1.DataSource = from c in _dt.KRTESTTOLERGLs where c.testtolerg_id == tablid1 select c;
                    var fmo43 = new FrmTestTolerantGlycoze(dataSource1) {Llabanaliz = Labanalizc};
                    fmo43.InitLookup();
                    if (DialogResult.OK == fmo43.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KRGOMOCISTEIN":
                    dataSource1.DataSource = from c in _dt.KRGOMOCISTEINs where c.gomocisteinr_id == tablid1 select c;
                    var fmo44 = new FrmKrGomocistein(dataSource1) {Llabanaliz = Labanalizc};
                    fmo44.InitLookup();
                    if (DialogResult.OK == fmo44.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KRTROMBOEKSTOGRAMM":
                    dataSource1.DataSource = from c in _dt.KRTROMBOEKSTOGRAMMs where c.krtromboeks_id == tablid1 select c;
                    var fmo45 = new FrmKrTromboex(dataSource1) {Llabanaliz = Labanalizc};
                    fmo45.InitLookup();
                    if (DialogResult.OK == fmo45.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "ELI12":
                    dataSource1.DataSource = from c in _dt.ELI12s where c.elip12_id == tablid1 select c;
                    var fmo46 = new FrmKrELI12(dataSource1) {Llabanaliz = Labanalizc};
                    fmo46.InitLookup();
                    if (DialogResult.OK == fmo46.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "ELI24":
                    dataSource1.DataSource = from c in _dt.ELI24s where c.elip24_id == tablid1 select c;
                    var fmo47 = new FrmKrELI24(dataSource1) {Llabanaliz = Labanalizc};
                    fmo47.InitLookup();
                    if (DialogResult.OK == fmo47.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KRCA125":
                    dataSource1.DataSource = from c in _dt.KRCA125s where c.ca125_id == tablid1 select c;
                    var fmo48 = new FrmKrCA125(dataSource1) {Llabanaliz = Labanalizc};
                    fmo48.InitLookup();
                    if (DialogResult.OK == fmo48.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "MOCHASULKOVICH":
                    dataSource1.DataSource = from c in _dt.MOCHASULKOVICHes where c.mochasulkov_id == tablid1 select c;
                    var fmo49 = new FrmMohaSulkovich(dataSource1) {Llabanaliz = Labanalizc};
                    fmo49.InitLookup();
                    if (DialogResult.OK == fmo49.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "MOCHASUTPBELGLUK":
                    dataSource1.DataSource = from c in _dt.MOCHASUTPBELGLUKs where c.mochasutbg_id == tablid1 select c;
                    var fmo50 = new FrmMohaSutpbg(dataSource1) {Llabanaliz = Labanalizc};
                    fmo50.InitLookup();
                    if (DialogResult.OK == fmo50.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KRGEMOSTAZIO":
                    dataSource1.DataSource = from c in _dt.KRGEMOSTAZIOs where c.gemostazio_id == tablid1 select c;
                    var fmo51 = new FrmGemostazio(dataSource1) {Llabanaliz = Labanalizc};
                    fmo51.InitLookup();
                    if (DialogResult.OK == fmo51.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KROSMOTREZERITR":
                    dataSource1.DataSource = from c in _dt.KROSMOTREZERITRs where c.osmotrezeritr_id == tablid1 select c;
                    var fmo52 = new FrmKrOsmotRezEritr(dataSource1) {Llabanaliz = Labanalizc};
                    fmo52.InitLookup();
                    if (DialogResult.OK == fmo52.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "PUNKTATONKOCIT":
                    dataSource1.DataSource = from c in _dt.PUNKTATONKOCITs where c.punktatonko_id == tablid1 select c;
                    var fmo53 = new FrmPunktOnkolog(dataSource1) {Llabanaliz = Labanalizc};
                    fmo53.InitLookup();
                    if (DialogResult.OK == fmo53.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "ASPIRATONKOCIT":
                    dataSource1.DataSource = from c in _dt.ASPIRATONKOCITs where c.aspiratonko_id == tablid1 select c;
                    var fmo54 = new FrmAspiratOnkolog(dataSource1) {Llabanaliz = Labanalizc};
                    fmo54.InitLookup();
                    if (DialogResult.OK == fmo54.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "REBERGA":
                    dataSource1.DataSource = from c in _dt.REBERGAs where c.reberga_id == tablid1 select c;
                    var fmo55 = new FrmReberga(dataSource1) {Llabanaliz = Labanalizc};
                    fmo55.InitLookup();
                    if (DialogResult.OK == fmo55.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "PCRISSLEDOV":
                    dataSource1.DataSource = from c in _dt.PCRISSLEDOVs where c.pcrisledov_id == tablid1 select c;
                    var fmo56 = new FrmPCRisledov(dataSource1) { Llabanaliz = Labanalizc };
                    fmo56.InitLookup();
                    if (DialogResult.OK == fmo56.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KRANTIGOMINIZ":
                    dataSource1.DataSource = from c in _dt.KRANTIGOMINIZs where c.krantigominiz_id == tablid1 select c;
                    var fmo57 = new FrmKrantihominiz(dataSource1) { Llabanaliz = Labanalizc };
                    fmo57.InitLookup();
                    if (DialogResult.OK == fmo57.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;
                case "KRANTITELA":
                    dataSource1.DataSource = from c in _dt.KRANTITELAs where c.krantitela_id == tablid1 select c;
                    var fmo58 = new FrmKrantitelaigmigg(dataSource1) { Llabanaliz = Labanalizc };
                    fmo58.InitLookup();
                    if (DialogResult.OK == fmo58.ShowDialog())
                    {
                        _dt.SubmitChanges();
                    }
                    break;                    
            }
        }
    }
}
