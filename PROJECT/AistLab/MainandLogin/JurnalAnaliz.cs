using System;
using System.Collections.Generic;
using AistLab.ReportDDL;
using AistLabData;

namespace AistLab.MainandLogin
{
    public partial class JurnalAnaliz : DevExpress.XtraEditors.XtraForm
    {
        readonly DataClassesLabDataContext _dt = new DataClassesLabDataContext();
        private readonly List<ANALIZMENU> _analizList = new List<ANALIZMENU>();
        private string _stranaliz="";
        private string _strParent = "";
        private ReportServer _rp;
        public JurnalAnaliz()
        {
            InitializeComponent();
            FormMenuAnaliz();
        }
        #region ЗАПОЛНЕНИЕ ПРОВОДНИКА АНАЛИЗОВ
        private void FormMenuAnaliz()
        {
            _analizList.Clear();
            // (Pfullmenuanaliz)
            var res = _dt.ANALIZMENU_GET2(3, 3);
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
                                     TABINDEX = t.TABINDEX,
                                     VIBMENU = t.VIBMENU
                                 };
                    _analizList.Add(an);
                }
            }
            treeList1.RootValue = 3;
            treeList1.DataSource = _analizList;
            treeList1.ExpandAll();
        }
        #endregion

        private void SimpleButton1Click(object sender, EventArgs e)
        {
            switch (_stranaliz)
            {
                case "на трихомонады":
                    //FormRSView frs = new FormRSView();
                    //frs.Text = strParent + "  " + stranaliz;
                    //frs.FormRS(stranaliz);
                    //frs.Show();
                    break;
                case "биохимия мочи":
                    _rp = new ReportServer("/ReportLabProject/БиохимияМочи", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "общий":
                    _rp = new ReportServer("/ReportLabProject/МочаОбщий", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "суточная моча на сахар и белок":
                    _rp = new ReportServer("/ReportLabProject/МочаНаСахарБелок", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "по Нечипоренко":
                    _rp = new ReportServer("/ReportLabProject/МочапоНечипоренко", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "по Зимницкому":
                    _rp = new ReportServer("/ReportLabProject/МочапоЗемницкому", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "анализ крови общий":
                    break;
                case "биохимический анализ крови":
                    _rp = new ReportServer("/ReportLabProject/Биохимиякрови", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "коагулограмма":
                    _rp = new ReportServer("/ReportLabProject/Коагулограмма", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "определение антител":
                    _rp = new ReportServer("/ReportLabProject/КровьметодомИФА", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "кровь на сахар":
                    _rp = new ReportServer("/ReportLabProject/КровьнаСахар", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "выявление антител к ВИЧ 1 и 2 типов (ИФА)":
                    _rp = new ReportServer("/ReportLabProject/НаВИЧ", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "на гемолиз":
                    _rp = new ReportServer("/ReportLabProject/КровьнаГемолиз", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "на гликемический профиль натощак":
                    _rp = new ReportServer("/ReportLabProject/НаГликемическийпрофильНатощак", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "на группу и резус фактор":
                    _rp = new ReportServer("/ReportLabProject/КровьнаГруппуиРезус", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "исследование кала":
                    _rp = new ReportServer("/ReportLabProject/Исследованиекала", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "Обнаружение клеток красной волчанки(LE-клеток)":
                    _rp = new ReportServer("/ReportLabProject/КраснойВолчанки", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "Иммунологический тест":
                    _rp = new ReportServer("/ReportLabProject/Иммунологическийтест", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "Диагностика сифилиса (RPR,РПГА)":
                    _rp = new ReportServer("/ReportLabProject/Диагнозсифилиса", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "ЦИТОКИНЫ":
                    _rp = new ReportServer("/ReportLabProject/Цитограмма", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "Исследование ликвора":
                    _rp = new ReportServer("/ReportLabProject/ИсследованиеЛиквора", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "Анализ эякулята":
                    _rp = new ReportServer("/ReportLabProject/Эакулят", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "определение АМГФ в сперме":
                    _rp = new ReportServer("/ReportLabProject/АМГФвСперме", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "Мазки на флору":
                    _rp = new ReportServer("/ReportLabProject/МазкинаФлору", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "определение в кале новорожденного гемоглобина (проба АПТА)":
                    _rp = new ReportServer("/ReportLabProject/КалНоворГомогл", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "кал на я/г и простейшие":
                    _rp = new ReportServer("/ReportLabProject/КалнаЯГипростейшие", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "на углеводы":
                    _rp = new ReportServer("/ReportLabProject/КалнаУглеводы", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "обнаружение яиц острицы на перианальных складках":
                    //rp = new ReportServer("/ReportLabProject/КалнаУглеводы", strParent + "  " + stranaliz);
                    //rp.Show();
                    break;
                case "Посевы и грибы":
                    _rp = new ReportServer("/ReportLabProject/ПосевыиГрибы", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "Тесты на беременность":
                    _rp = new ReportServer("/ReportLabProject/ТестыНаБеременность", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "Определение агрегации тромбоцидов, стимулированной индуктором ":
                    _rp = new ReportServer("/ReportLabProject/ТестНаАгрегациюТромбоцидов", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "на гормоны методом ИФА":
                    _rp = new ReportServer("/ReportLabProject/НаГормонМетодИФА", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "методом ИФА на антитела к ХГЧ и суммарные тела к кардиолипину":
                    _rp = new ReportServer("/ReportLabProject/НаАнтителакХГЧ", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "определение иммуноглобулинов":
                    _rp = new ReportServer("/ReportLabProject/ОпредИммуноглобулинIgAIgM", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "белковых фракций методом электрофореза на УЭФ":
                    _rp = new ReportServer("/ReportLabProject/БелковыхФракцийнаУЭФ", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "при нарушении фертильности методом ИФА":
                    _rp = new ReportServer("/ReportLabProject/НарФертильностиИФА", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "Бактериоскопия биоматериала":
                    _rp = new ReportServer("/ReportLabProject/Биоматериал", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "Исследование соскобов с шейки матки и цервикального канала":
                    break;
                case "Экссудаты и транссудаты":
                    _rp = new ReportServer("/ReportLabProject/ЭксудатТранс", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "Миелограмма":
                    break;
                case "Анализ сока простаты":
                    _rp = new ReportServer("/ReportLabProject/СокПростаты", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "Мазок на онкоцитологию":
                    _rp = new ReportServer("/ReportLabProject/Цитограмма", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "на тест толерантности к глюкозе":
                    _rp = new ReportServer("/ReportLabProject/ТолерантнКглюкозе", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "РИФ мазка":
                    _rp = new ReportServer("/ReportLabProject/РИФмазка", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "на гомоцистеин":
                    _rp = new ReportServer("/ReportLabProject/КровьнаГомоцистоин", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
            }
 
            //foreach (var t in ANALIZList)
            //{
            //    var res1 = dt.VVIB_ANALIZ(t.Analiz_ID, t.VIBMENU);
            //    var res2 = dt.VUPDATE_ANALIZ();   
            //}
        }

        private void TreeList1FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                _stranaliz = e.Node.GetDisplayText(treeListColumn1);
                //lctypeanaliz = e.Node.Id;
                if (e.Node.ParentNode != null) _strParent = e.Node.ParentNode.GetDisplayText(treeListColumn1);
                else _strParent = "";
                if (_strParent == "Анализ") _strParent = "";
            }
        }
   
 


    }
}