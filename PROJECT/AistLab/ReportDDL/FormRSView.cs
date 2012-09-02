using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using AistLabData;

namespace AistLab.ReportDDL
{
    public partial class FormRSView : Form
    {
        #region ПРИВАТНЫЕ ПЕРЕМЕННЫЕ И LIST
        private DateTime _data1=DateTime.Parse("01.05.2010");
        private DateTime _data2=DateTime.Parse("31.05.2010");
        private DateTime _data3 = DateTime.Parse("31.05.2010");
        private DataClassesLabReportDataContext _db;
        private List<VBAKTERIOSBIOMAT_RU>  _lVbakteriosbiomatRu = new List<VBAKTERIOSBIOMAT_RU>();
        private List<VCITOGRAMMA_RU>  _lVcitogrammaRu = new List<VCITOGRAMMA_RU>();
        private List<VCITOKIN_RU>  _lVcitokinRu = new List<VCITOKIN_RU>();
        private List<VDIAGSIFILISA_RU>  _lVdiagsifilisaRu = new List<VDIAGSIFILISA_RU>();
        private List<VEAKULJT_RU>  _lVeakuljtRu = new List<VEAKULJT_RU>();
        private List<VEKUSUDTRANSUD_RU>  _lVekusudtransudRu = new List<VEKUSUDTRANSUD_RU>();
        private List<VIMUNTEST_RU>  _lVimuntestRu = new List<VIMUNTEST_RU>();
        private List<VKALGLIST_RU>  _lVkalglistRu = new List<VKALGLIST_RU>();
        private List<VKALISSLEDOV_RU>  _lVkalissledovRu = new List<VKALISSLEDOV_RU>();
        private List<VKALNOVGEMOGLOBIN_RU>  _lVkalnovgemoglobinRu = new List<VKALNOVGEMOGLOBIN_RU>();
        private List<VKALOSTRICPERIANAL_RU>  _lVkalostricperianalRu = new List<VKALOSTRICPERIANAL_RU>();
        private List<VKALANALIZUGLEV_RU> _lVkalanalizuglevRu = new List<VKALANALIZUGLEV_RU>();
        private List<VKRBIOHIMII_RU>  _lVkrbiohimiiRu = new List<VKRBIOHIMII_RU>();
        private List<VKRGEMOLIZ_RU>  _lVkrgemolizRu = new List<VKRGEMOLIZ_RU>();
        private List<VKRGLIKEMPR>  _lVkrglikemprRu = new List<VKRGLIKEMPR>();
        private List<VKRGOMOCISTEIN_RU>  _lVkrgomocisteinRu = new List<VKRGOMOCISTEIN_RU>();
        private List<VKRGRUPREZ_RU>  _lVkrgruprezRu = new List<VKRGRUPREZ_RU>();
        private List<VKRIFA_RU>  _lVkrifaRu = new List<VKRIFA_RU>();
        private List<VKRKOAGOLOGRAMMA_RU>  _lVkrkoagologrammaRu = new List<VKRKOAGOLOGRAMMA_RU>();
        private List<VKRKRASNVOLCH_RU>  _lVkrkrasnvolchRu = new List<VKRKRASNVOLCH_RU>();
        private List<VKROBANALIZ_RU>  _lVkrobanalizRu = new List<VKROBANALIZ_RU>();
        private List<VKROPBFSMUEFASTRA_RU>  _lVkropbfsmuefastraRu = new List<VKROPBFSMUEFASTRA_RU>();
        private List<VKRSAHAR_RU>  _lVkrsaharRu = new List<VKRSAHAR_RU>();
        private List<VKRSIMMUNIgAIgMIgGIgE_RU>   _lVkrsimmunigAigMigGigERu = new List<VKRSIMMUNIgAIgMIgGIgE_RU>();
        private List<VKRSISSNARFERMIFA_RU>  _lVkrsissnarfermifaRu = new List<VKRSISSNARFERMIFA_RU>();
        private List<VKRSUVGORMIFA_RU>  _lVkrsuvgormifaRu = new List<VKRSUVGORMIFA_RU>();
        private List<VKRSUVIFAXGCH_RU>  _lVkrsuvifaxgchRu = new List<VKRSUVIFAXGCH_RU>();
        private List<VKRVICH_RU>  _lVkrvichRu = new List<VKRVICH_RU>();
        private List<VLIKVORAISSLED_RU>   _lVlikvoraissledRu = new List<VLIKVORAISSLED_RU>();
        private List<VMAZKINAFLORU_RU>  _lVmazkinafloruRu = new List<VMAZKINAFLORU_RU>();
        private List<VMIELOGRAMMA_RU>  _lVmielogrammaRu = new List<VMIELOGRAMMA_RU>();
        private List<VMOCHANEHIPOR_RU>  _lVmochanehiporRu = new List<VMOCHANEHIPOR_RU>();
        private List<VMOCHAOBCH_RU>   _lVmochaobchRu = new List<VMOCHAOBCH_RU>();
        private List<VMOCHATRIHOMON_RU> _lVmochatrihomonRu = new List<VMOCHATRIHOMON_RU>();
        private List<VMOHABIOHIM_RU>  _lVmohabiohimRu = new List<VMOHABIOHIM_RU>();
        private List<VMOHASAHARBELOK_RU> _lVmohasaharbelokRu = new List<VMOHASAHARBELOK_RU>();
        private List<VMOHAZEMNICKOGO_RU>   _lVmohazemnickogoRu = new List<VMOHAZEMNICKOGO_RU>();
        private List<VOPAGRTRBIOLELA230_2_RU>  _lVopagrtrbiolela2302Ru = new List<VOPAGRTRBIOLELA230_2_RU>();
        private List<VPOSEVGRIB_RU>  _lVposevgribRu = new List<VPOSEVGRIB_RU>();
        private List<VRIFMAZKA_RU>   _lVrifmazkaRu = new List<VRIFMAZKA_RU>();
        private List<VSOKPROSTAT_RU>  _lVsokprostatRu = new List<VSOKPROSTAT_RU>();
        private List<VSPERMAMGF_RU>   _lVspermamgfRu = new List<VSPERMAMGF_RU>();
        private List<VTESTBEREM_RU>  _lVtestberemRu = new List<VTESTBEREM_RU>();
        private List<VKRTESTTOLERGL_RU> _lVkrtesttolerglRu = new List<VKRTESTTOLERGL_RU>();
        private List<VKRTROMBOEKSTOGRAMM> _lVkrtromboekstogramm = new List<VKRTROMBOEKSTOGRAMM>();
        private List<VELI12> _lVeli12 = new List<VELI12>();
        private List<VELI24> _lVeli24 = new List<VELI24>();
        private readonly string _strperod;
        private string _strpath;

        #endregion

         public FormRSView(string strperod,string stranaliz)
        {
             if (strperod == null) throw new ArgumentNullException("strperod");
             _strperod=strperod;
             InitializeComponent();
            FormRS(stranaliz);
            WindowState = FormWindowState.Maximized;
        }
 
        private void FormRS(string stranaliz)
        {
            //SetParameter(String.Format(" c: {0} по: {1}", data1.ToString("dd.MM.yyyy"), data2.ToString("dd.MM.yyyy")));
            //string strpath=@"C:\PPC-VS10\PPC-KDLVS10\AistLabData\Rdl2.0\";
             _strpath = @"C:\temp\Report\";
            FormDatePeriod(_strperod);
            //data1=DateTime.Parse("01.01.2010");
            //data2=DateTime.Parse("31.05.2010");
            //data3 = DateTime.Parse("01.06.2010");
            _db = new DataClassesLabReportDataContext();
            #region ВЫВОД ДАННЫХ В ОТЧЕТЫ
            switch (stranaliz)
            {
                case "на трихомонады":
                    _lVmochatrihomonRu = (from c in _db.VMOCHATRIHOMON_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VMOCHATRIHOMON_RU>();
                     SetParReport("МочаНаТрихомонады.rdlc");
                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVmochatrihomonRu));
                    break;
                case "биохимия мочи":
                    _lVmohabiohimRu = (from c in _db.VMOHABIOHIM_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VMOHABIOHIM_RU>();
                    SetParReport( "БиохимияМочи.rdlc");
                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVmohabiohimRu));
                    break;
                case "общий":
                    _lVmochaobchRu = (from c in _db.VMOCHAOBCH_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VMOCHAOBCH_RU>();
                    SetParReport("МочаОбщий.rdlc");
                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVmochaobchRu));
                    break;
                case "суточная моча на сахар и белок":
                    _lVmohasaharbelokRu = (from c in _db.VMOHASAHARBELOK_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VMOHASAHARBELOK_RU>();
                    SetParReport("МочаНаСахарБелок.rdlc");
                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVmohasaharbelokRu));
                       break;
                case "по Нечипоренко":
                       _lVmochanehiporRu = (from c in _db.VMOCHANEHIPOR_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VMOCHANEHIPOR_RU>();
                       SetParReport("МочапоНечипоренко.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVmochanehiporRu));
                      break;
                case "по Зимницкому":
                      _lVmohazemnickogoRu = (from c in _db.VMOHAZEMNICKOGO_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VMOHAZEMNICKOGO_RU>();
                      SetParReport("МочапоЗемницкому.rdlc");
                       reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVmohazemnickogoRu));
                     break;
                case "анализ крови общий":
                     _lVkrobanalizRu = (from c in _db.VKROBANALIZ_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VKROBANALIZ_RU>();
                     SetParReport("ОбщийАнализКрови.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVkrobanalizRu));
                    break;
                case "биохимический анализ крови":
                    _lVkrbiohimiiRu = (from c in _db.VKRBIOHIMII_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VKRBIOHIMII_RU>();
                    SetParReport("Биохимиякрови.rdlc");
                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVkrbiohimiiRu));
                       break;
                case "коагулограмма":
                       _lVkrkoagologrammaRu = (from c in _db.VKRKOAGOLOGRAMMA_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VKRKOAGOLOGRAMMA_RU>();
                       SetParReport("Коагулограмма.rdlc");
                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVkrkoagologrammaRu));
                    break;
                case "определение антител":
                    _lVkrifaRu = (from c in _db.VKRIFA_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VKRIFA_RU>();
                    SetParReport("КровьметодомИФА.rdlc");
                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVkrifaRu));
                     break;
                 case "кровь на сахар":
                     _lVkrsaharRu = (from c in _db.VKRSAHAR_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VKRSAHAR_RU>();
                     SetParReport("КровьнаСахар.rdlc");
                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVkrsaharRu));
                      break;
                case "выявление антител к ВИЧ 1 и 2 типов (ИФА)":
                      _lVkrvichRu = (from c in _db.VKRVICH_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VKRVICH_RU>();
                      SetParReport("НаВИЧ.rdlc");
                     reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVkrvichRu));
                       break;
                case "на гемолиз":
                       _lVkrgemolizRu = (from c in _db.VKRGEMOLIZ_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VKRGEMOLIZ_RU>();
                       SetParReport("КровьнаГемолиз.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVkrgemolizRu));
                      break;
                case "на гликемический профиль натощак":
                      _lVkrglikemprRu = (from c in _db.VKRGLIKEMPRs where c.data > _data1 && c.data < _data3 select c).ToList<VKRGLIKEMPR>();
                      SetParReport("НаГликемическийпрофильНатощак.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVkrglikemprRu));
                    break;
                case "на группу и резус фактор":
                    _lVkrgruprezRu = (from c in _db.VKRGRUPREZ_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VKRGRUPREZ_RU>();
                    SetParReport("КровьнаГруппуиРезус.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVkrgruprezRu));
                    break;
                case "исследование кала":
                    _lVkalissledovRu = (from c in _db.VKALISSLEDOV_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VKALISSLEDOV_RU>();
                    SetParReport("Исследованиекала.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVkalissledovRu));
                     break;
                case "Обнаружение клеток красной волчанки(LE-клеток)":
                     _lVkrkrasnvolchRu = (from c in _db.VKRKRASNVOLCH_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VKRKRASNVOLCH_RU>();
                     SetParReport("КраснойВолчанки.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVkrkrasnvolchRu));
                       break;
                case "Иммунологический тест":
                       _lVimuntestRu = (from c in _db.VIMUNTEST_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VIMUNTEST_RU>();
                       SetParReport("Иммунологическийтест.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVimuntestRu));
                    break;
                case "Диагностика сифилиса (RPR,РПГА)":
                    _lVdiagsifilisaRu = (from c in _db.VDIAGSIFILISA_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VDIAGSIFILISA_RU>();
                    SetParReport("Диагнозсифилиса.rdlc");
                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVdiagsifilisaRu));
                    break;
                case "ЦИТОКИНЫ":
                    _lVcitokinRu = (from c in _db.VCITOKIN_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VCITOKIN_RU>();
                    SetParReport("Цитокины.rdlc");
                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVcitokinRu));
                     break;
                case "Исследование ликвора":
                     _lVlikvoraissledRu = (from c in _db.VLIKVORAISSLED_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VLIKVORAISSLED_RU>();
                     SetParReport("ИсследованиеЛиквора.rdlc");
                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVlikvoraissledRu));
                      break;
                case "Анализ эякулята":
                      _lVeakuljtRu = (from c in _db.VEAKULJT_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VEAKULJT_RU>();
                      SetParReport("Эакулят.rdlc");
                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVeakuljtRu));
                      break;
                case "определение АМГФ в сперме":
                      _lVspermamgfRu = (from c in _db.VSPERMAMGF_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VSPERMAMGF_RU>();
                      SetParReport("АМГФвСперме.rdlc");
                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVspermamgfRu));
                    break;
                case "Мазки на флору":
                    _lVmazkinafloruRu = (from c in _db.VMAZKINAFLORU_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VMAZKINAFLORU_RU>();
                    SetParReport("МазкинаФлору.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVmazkinafloruRu));
                     break;
                case "определение в кале новорожденного гемоглобина (проба АПТА)":
                     _lVkalnovgemoglobinRu = (from c in _db.VKALNOVGEMOGLOBIN_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VKALNOVGEMOGLOBIN_RU>();
                     SetParReport("КалНоворГомогл.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVkalnovgemoglobinRu));
                    break;
                case "кал на я/г и простейшие":
                    _lVkalglistRu = (from c in _db.VKALGLIST_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VKALGLIST_RU>();
                    SetParReport("КалнаЯГипростейшие.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVkalglistRu));
                      break;
                case "на углеводы":
                      _lVkalanalizuglevRu = (from c in _db.VKALANALIZUGLEV_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VKALANALIZUGLEV_RU>();
                      SetParReport("КалнаУглеводы.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVkalanalizuglevRu));
                     break;
                case "обнаружение яиц острицы на перианальных складках":
                     _lVkalostricperianalRu = (from c in _db.VKALOSTRICPERIANAL_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VKALOSTRICPERIANAL_RU>();
                     SetParReport("КалОстрицПерионал.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVkalostricperianalRu));
                      break;
                case "Посевы и грибы":
                      _lVposevgribRu = (from c in _db.VPOSEVGRIB_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VPOSEVGRIB_RU>();
                      SetParReport("ПосевыиГрибы.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVposevgribRu));
                     break;
                case "Тесты на беременность":
                     _lVtestberemRu = (from c in _db.VTESTBEREM_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VTESTBEREM_RU>();
                     SetParReport("ТестыНаБеременность.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVtestberemRu));
                      break;
                case "Определение агрегации тромбоцидов, стимулированной индуктором ":
                      _lVopagrtrbiolela2302Ru = (from c in _db.VOPAGRTRBIOLELA230_2_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VOPAGRTRBIOLELA230_2_RU>();
                      SetParReport("ТестНаАгрегациюТромбоцидов.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVopagrtrbiolela2302Ru));
                    break;
                case "на гормоны методом ИФА":
                    _lVkrsuvgormifaRu = (from c in _db.VKRSUVGORMIFA_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VKRSUVGORMIFA_RU>();
                    SetParReport("НаГормонМетодИФА.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVkrsuvgormifaRu));
                     break;
                case "методом ИФА на антитела к ХГЧ и суммарные тела к кардиолипину":
                     _lVkrsuvifaxgchRu = (from c in _db.VKRSUVIFAXGCH_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VKRSUVIFAXGCH_RU>();
                     SetParReport("НаАнтителакХГЧ.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVkrsuvifaxgchRu));
                    break;
                case "определение иммуноглобулинов":
                    _lVkrsimmunigAigMigGigERu = (from c in _db.VKRSIMMUNIgAIgMIgGIgE_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VKRSIMMUNIgAIgMIgGIgE_RU>();
                    SetParReport("ОпредИммуноглобулин.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVkrsimmunigAigMigGigERu));
                    break;
                case "белковых фракций методом электрофореза на УЭФ":
                    _lVkropbfsmuefastraRu = (from c in _db.VKROPBFSMUEFASTRA_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VKROPBFSMUEFASTRA_RU>();
                    SetParReport("БелковыхФракцийнаУЭФ.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVkropbfsmuefastraRu));
                    break;
                case "при нарушении фертильности методом ИФА":
                    _lVkrsissnarfermifaRu = (from c in _db.VKRSISSNARFERMIFA_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VKRSISSNARFERMIFA_RU>();
                    SetParReport("НарФертильностиМетодомИФА.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVkrsissnarfermifaRu));
                    break;
                case "Бактериоскопия биоматериала":
                    _lVbakteriosbiomatRu = (from c in _db.VBAKTERIOSBIOMAT_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VBAKTERIOSBIOMAT_RU>();
                    SetParReport("Биоматериал.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVbakteriosbiomatRu));
                    break;
                case "Исследование соскобов с шейки матки и цервикального канала":
                    _lVspermamgfRu = (from c in _db.VSPERMAMGF_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VSPERMAMGF_RU>();
                      SetParReport("АМГФвСперме.rdlc");
                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVspermamgfRu));
                    break;
                case "Экссудаты и транссудаты":
                    _lVekusudtransudRu = (from c in _db.VEKUSUDTRANSUD_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VEKUSUDTRANSUD_RU>();
                    SetParReport("ЭксудатТранс.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVekusudtransudRu));
                    break;
                case "Миелограмма":
                    _lVmielogrammaRu = (from c in _db.VMIELOGRAMMA_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VMIELOGRAMMA_RU>();
                      SetParReport("Миелограмма.rdlc");
                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVmielogrammaRu));
                    break;
                case "Анализ сока простаты":
                    _lVsokprostatRu = (from c in _db.VSOKPROSTAT_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VSOKPROSTAT_RU>();
                      SetParReport("СокПростаты.rdlc");
                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVsokprostatRu));
                    break;
                case "Мазок на онкоцитологию":
                    _lVcitogrammaRu = (from c in _db.VCITOGRAMMA_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VCITOGRAMMA_RU>();
                    SetParReport("Цитограмма.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVcitogrammaRu));
                    break;
                case "на тест толерантности к глюкозе":
                    _lVkrtesttolerglRu = (from c in _db.VKRTESTTOLERGL_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VKRTESTTOLERGL_RU>();
                    SetParReport("ТолерантнКглюкозе.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVkrtesttolerglRu));
                    break;
                case "РИФ мазка":
                    _lVrifmazkaRu = (from c in _db.VRIFMAZKA_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VRIFMAZKA_RU>();
                    SetParReport("РИФмазка.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVrifmazkaRu));
                    break;
                case "на гомоцистеин":
                    _lVkrgomocisteinRu = (from c in _db.VKRGOMOCISTEIN_RUs where c.data > _data1 && c.data < _data3 select c).ToList<VKRGOMOCISTEIN_RU>();
                    SetParReport("КровьнаГомоцистоин.rdlc");
                      reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVkrgomocisteinRu));
                    break;
                case "Тромбоэластограмма":
                    _lVkrtromboekstogramm = (from c in _db.VKRTROMBOEKSTOGRAMMs where c.data > _data1 && c.data < _data3 select c).ToList<VKRTROMBOEKSTOGRAMM>();
                    SetParReport("Тромбоэкстограмма.rdlc");
                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVkrtromboekstogramm));
                    break;
                case "Эли-П-Комплекс- 12":
                    _lVeli12 = (from c in _db.VELI12s where c.data > _data1 && c.data < _data3 select c).ToList<VELI12>();
                    SetParReport("Элитест12.rdlc");
                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVeli12));
                    break;
                case "Эли-Висцеро-тест-24":
                      _lVeli24 = (from c in _db.VELI24s where c.data > _data1 && c.data < _data3 select c).ToList<VELI24>();
                    SetParReport("Элитест24.rdlc");
                    reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _lVeli24));   
                    break;
                    //lVELI12
            }
            reportViewer2.RefreshReport();
        }
            #endregion

        private void SetParReport(string strrdlc)
        {
            System.IO.Directory.GetCurrentDirectory();
            //string strfilefull = currentDirName + "\\" + "\\Report" + strrdlc;
            string strfilefull = _strpath + strrdlc;
            if (!System.IO.File.Exists(strfilefull))
            {
                _db = new DataClassesLabReportDataContext();
                _db.ReportSave(@strfilefull, strrdlc);
            }
            reportViewer2.LocalReport.ReportPath = strfilefull;
            var p1 = new ReportParameter("dataperiod", _strperod);
            reportViewer2.LocalReport.SetParameters(new[] { p1 });
        }

        private void FormDatePeriod(string strperiod1)
        {
            int pos1 = strperiod1.IndexOf('-');
            if (pos1 > 0)
            {
                string s1 = strperiod1.Substring(0, pos1);
                string s2 = strperiod1.Substring(pos1 + 1);
                _data1 = DateTime.Parse(s1);
                _data2 = DateTime.Parse(s2);
                _data3 = _data2.AddDays(1);
            }
            else
            {
                _data1 = DateTime.Parse(strperiod1);
                _data2 = _data1.AddDays(1);
                _data3 = _data2;
            }
        }
        private void ReportViewer2KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
   
    }
}
