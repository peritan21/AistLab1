using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CustomControlLib;
using AistLabData;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes.Operations;
using DevExpress.XtraTreeList.Nodes;
using KdlForm;
using System.Configuration;

namespace AistLab.SetOtchet
{
    public partial class FrmOtchOTDGOD : DevExpress.XtraEditors.XtraForm
    {
        private AccessorLab.OTCHETPERIODR_ROTD _kle;
        private DataClassesLabDataContext _dt;  
        private readonly List<AccessorLab.OTCHETPERIODR_ROTD> _lanalizr = new List<AccessorLab.OTCHETPERIODR_ROTD>();
        private  List<AccessorLab.OTCHETPERIODR_ROTD> _lanalizritog = new List<AccessorLab.OTCHETPERIODR_ROTD>();
        private readonly List<AccessorLab.AnalizOtchet> _lanalizotch1 = new List<AccessorLab.AnalizOtchet>();
        private readonly List<AccessorLab.AnalizOtchet> _lanalizotch2 = new List<AccessorLab.AnalizOtchet>();
        private readonly List<AccessorLab.AnalizOtchet> _lanalizotch3 = new List<AccessorLab.AnalizOtchet>();
        private readonly List<AccessorLab.OtchetUslkol> _lotchuslkol = new List<AccessorLab.OtchetUslkol>();
        private List<LABORANT> _labanaliz = new List<LABORANT>();
        private readonly List<AccessorLab.Viborotd> _lotd = new List<AccessorLab.Viborotd>();
        private List<AccessorLab.Viborotd> _lotdvib = new List<AccessorLab.Viborotd>();
        //private AccessorLab.AnalizOtchet _otch;
        private AccessorLab.OtchetUslkol _uslkol;
        private BindingSource _dataSource1;
        private int _tablid1,_otdid1;
        private const char SeparatorChar = ',';
        private const int Parselperiod = 0;
        private StatusProgresbar _statb;
        private  PrintableComponentLink _link;
        private PrintableComponentLink treeViewLink1;
        private PrintingSystem ps; 
        private string strvibotd = "";
        private string strvibotdzapjtaj = "";
        private string strvibotdskobki = "";
        private string strvibotdskobkias = "";
        private string strvibotdcolonki = "";
        private int klID;
        private string reportHeader = "";
        PageHeaderFooter phf ; 
        public FrmOtchOTDGOD()
        {
            InitializeComponent();
           
            //SetFormprindocument();

            // Add custom information to the link's header.
          //  phf.Header.Content.AddRange(new string[] { leftColumn, middleColumn, rightColumn });
            //phf.Header.LineAlignment = BrickAlignment.Far;

            // Specify the control to be printed.
            // Set the paper format.
            // Subscribe to the CreateReportHeaderArea event used to generate the report header.
       
            //_link.CreateDetailFooterArea+=_link_CreateDetailFooterArea;
            _lotd.Clear();
            using (_dt = new DataClassesLabDataContext())
            {
                var res = (from c in _dt.OTDs select new {c.otd_id, c.name_otdsokr, c.name_otd, c.vib});
                foreach (var t in res)
                {
                    int lc1 = t.otd_id;
                    string str1 = t.name_otdsokr;
                    string str2 = t.name_otd;
                    _lotd.Add(new AccessorLab.Viborotd(lc1, str1, str2, false));

                }
            }
            //lookUpEdit1.DataBindings.Add(new Binding("SelectedIndex", _lotd, "crbinterval", true));
        }

        private void SetFormprindocument(TreeList tree)
        {
            ps = new PrintingSystem();
            // Create a link that will print a control.
         
            tree.ColumnPanelRowHeight = 40;
            //treeList2.ColumnPanelRowHeight = 40;
            //treeList3.ColumnPanelRowHeight = 40;
            //treeList4.ColumnPanelRowHeight = 40;
            //treeList5.ColumnPanelRowHeight = 40;
            //treeList6.ColumnPanelRowHeight = 40;
            //treeList7.ColumnPanelRowHeight = 40;
            _link = new PrintableComponentLink(ps) { Component = tree, PaperKind = System.Drawing.Printing.PaperKind.A4 };
            treeViewLink1 = new PrintableComponentLink(ps) { Component = tree, PaperKind = System.Drawing.Printing.PaperKind.A4, Landscape = true, PageHeaderFooter = true };
            // new TreeViewLink(ps);
            ps.Links.Add(treeViewLink1);
            ps.Links[0] = treeViewLink1;
            //ps.Links.Add(treeViewLink1);//ps.Links[0] = treeViewLink1;
            // _link.Landscape = false;

            //phf = _link.PageHeaderFooter as PageHeaderFooter;
            treeViewLink1.CreateReportHeaderArea += PrintableComponentLink1CreateReportHeaderArea;
            PageHeaderFooter footer = treeViewLink1.PageHeaderFooter as PageHeaderFooter;
            // Clear the PageHeaderFooter's contents.
            footer.Header.Content.Clear();
            //tree.ColumnPanelRowHeight = lchigt;
        }
        private void _link_CreateDetailFooterArea(object sender, CreateAreaEventArgs e)
        {
            
        }
        private void PrintableComponentLink1CreateReportHeaderArea(object sender, CreateAreaEventArgs e)
        {
            //string leftColumn = "Pages: [Page # of Pages #]";
            //string middleColumn = "User: [User Name]";
            //string rightColumn = "Date: [Date Printed]";

            // Create a PageHeaderFooter object and initializing it with
            // the link's PageHeaderFooter.
           

            // Clear the PageHeaderFooter's contents.
            //phf.Header.Content.Clear();

            // Add custom information to the link's header.
            //phf.Header.Content.AddRange(new string[] { leftColumn, middleColumn, rightColumn });
            //phf.Header.LineAlignment = BrickAlignment.Far;

            string strob = datePeriodEdit1.Text;
           reportHeader =
                "Выполняемый в КДЛ БУ «ЦГБ» МЗ СР ЧР перечень лабораторных исследований по отделениям: за период:" + strob;
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
            e.Graph.Font = new Font("Tahoma", 10, FontStyle.Bold);
            var rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
            e.Graph.DrawString(reportHeader, Color.Black, rec, BorderSide.None);
            //BrickGraphics g = ps.Graph;
            //g.Font = new Font("Tahoma", 6, FontStyle.Bold);
            //e.Graph.DrawPageInfo(
        }
        public bool Pviborvse
        {
            set { checkEdit1.Checked = value; }
            get { return checkEdit1.Checked; }
        }
        public string Pdatevibstr
        {
            set { datePeriodEdit1.EditValue = value; }
            get { return datePeriodEdit1.EditValue.ToString(); }}
        private void SimpleButton2Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SimpleButton1Click(object sender, EventArgs e)
        {
            // Формирование отчета
            LoadZapros();
            ClearColambStac();
        }
        private void LoadZapros()
        {
            if (Pdatevibstr.Length == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Вы не выбрали период для формирования отчета ??? ");
                return;
            }
            int kolamb;
            string TABLNAME_;
            //string colAOjen_, colAOmuj_, colAOfpjen_, colAOfpmuj_, colAOxoz_;
            string _colamb,
_Col1     ,
_Col5     ,
_Col6     ,
_Col7     ,
_Col8    ,
_Col9    ,
_Col10  ,
_Col11 ,
_Col12  ,
_Col13  ,
_Col14  ,
_Col15  ,
_Col16  ,
_Col17  ,
_Col18  ,
_Col19  ,
_Col20  ,
_Col21  ,
_Col22  ,
_Col23  ,
_Col24  ,
_Col25  ,
_Col26  ,
_Col27  ,
_Col28  ,
_Col29  ,
_Col30  ,
_Col31  ,
_Col32  ,
_Col45  ,
_Col46  ,
_Col47  ,
_Col48  ,
_Col49  ,
_Col50  ,
_Col51  ,
_Col52  ,
_Col53  ,
_Col54  ,
_Col55  ,
_Col56  ,
_Col57  ,
_Col58  ,
_Col59  ,
_Col60  ,
_Col61  ,
_Col62  ,
_Col63  ,
_Col64  ,
_Col65  ,
_Col66  ,
_Col67  ,
_Col68  ,
_Col69  ,
_Col70  ,
_Col71  ,
_Col72  ,
_Col73  ,
_Col74  ,
_Col75  ,
_Col76  ,
_Col77  ,
_Col78  ,
_Col79,
_Col80,
_Col81,
_Col82,
_Col83,
   _ColItog;
            if (Pviborvse) strvibotd = " ";
            int? kol = 0;
                 _lanalizr.Clear();
            _statb = new StatusProgresbar(Bounds) { Text = @"Загрузка данных с сервера" };
            treeList1.Nodes.Clear();
            treeList2.Nodes.Clear();
            treeList3.Nodes.Clear();
            treeList4.Nodes.Clear();
            treeList5.Nodes.Clear();
            treeList6.Nodes.Clear();
            treeList7.Nodes.Clear();
           _statb.maxbar =200;
            _statb.stepbar = 1;
            _statb.StartPosition = FormStartPosition.CenterScreen;
            _statb.Show();
            using (var con = new SqlConnection(AccessorLab.ClassDecrypt.Decrypt(ConfigurationManager.ConnectionStrings["KDL"].ConnectionString, Resource1.StringLab)))
            {
                var acommand = new SqlCommand("OTCHETPERIOD0PIVOT", con);
                acommand.CommandType = CommandType.StoredProcedure;
                acommand.CommandTimeout = 10*60*1000;
                acommand.Parameters.Add(new SqlParameter("ZAPROS", Pdatevibstr));
                acommand.Parameters.Add(new SqlParameter("VIBOTDZAP", strvibotdzapjtaj));
                acommand.Parameters.Add(new SqlParameter("VIBOTDSKOBKI", strvibotdskobki));
                acommand.Parameters.Add(new SqlParameter("VIBOTDSKOBKIAS", strvibotdskobkias));
                acommand.Parameters.Add(new SqlParameter("VIBOTDCOLONKI", strvibotdcolonki));
                con.Open();
                try
                {
                     metka:
                    SqlDataReader t = acommand.ExecuteReader();
                    while (t.Read())
                    {
                        int analizotchID = int.Parse(t[0].ToString());
                        byte analizLevel = byte.Parse(t[1].ToString());
                        int parentID = 0;
                         int.TryParse(t[2].ToString(),out parentID);
                        int tabindex = 0;
                        int.TryParse(t[3].ToString(), out tabindex);
                        int analizID = 0;
                        int.TryParse(t[4].ToString(), out analizID);
                        string nameStr = t[5] != null ? t[5].ToString() : "";
                        int npunktOtchet = t[6] != null ? int.Parse(t[6].ToString()) : 0;
                        TABLNAME_ = t[7] != null ? t[8].ToString() : "";
                        _colamb = t[8].ToString();
                        _ColItog = t[9].ToString();
                        _Col1  =   t[10].ToString();
                        _Col5  =   t[11].ToString();
                        _Col6  =   t[12].ToString();
                        _Col7  =   t[13].ToString();
                        _Col8  =   t[14].ToString();
                        _Col9  =   t[15].ToString();
                        _Col10=   t[16].ToString();
                        _Col11=   t[17].ToString();
                        _Col12 = t[18].ToString();
                        _Col13 = t[19].ToString();
                        _Col14 = t[20].ToString();
                        _Col15 = t[21].ToString();
                        _Col16 = t[22].ToString();
                        _Col17 = t[23].ToString();
                        _Col18 = t[24].ToString();
                        _Col19 = t[25].ToString();
                        _Col20 = t[26].ToString();
                        _Col21 = t[27].ToString();
                        _Col22 = t[28].ToString();
                        _Col23 = t[29].ToString();
                        _Col24 = t[30].ToString();
                        _Col25 = t[31].ToString();
                        _Col26 = t[32].ToString();
                        _Col27 = t[33].ToString();
                        _Col28 = t[34].ToString();
                        _Col29 = t[35].ToString();
                        _Col30 = t[36].ToString();
                        _Col31 = t[37].ToString();
                        _Col32 = t[38].ToString();
                        _Col45 = t[39].ToString();
                        _Col46 = t[40].ToString();
                        _Col47 = t[41].ToString();
                        _Col48 = t[42].ToString();
                        _Col49 = t[43].ToString();
                        _Col50 = t[44].ToString();
                        _Col51 = t[45].ToString();
                        _Col52 = t[46].ToString();
                        _Col53 = t[47].ToString();
                        _Col54 = t[48].ToString();
                        _Col55 = t[49].ToString();
                        _Col56 = t[50].ToString();
                        _Col57 = t[51].ToString();
                        _Col58 = t[52].ToString();
                        _Col59 = t[53].ToString();
                        _Col60 = t[54].ToString();
                        _Col61 = t[55].ToString();
                        _Col62 = t[56].ToString();
                        _Col63 = t[57].ToString();
                        _Col64 = t[58].ToString();
                        _Col65 = t[59].ToString();
                        _Col66 = t[60].ToString();
                        _Col67 = t[61].ToString();
                        _Col68 = t[62].ToString();
                        _Col69 = t[63].ToString();
                        _Col70 = t[64].ToString();
                        _Col71 = t[65].ToString();
                        _Col72 = t[66].ToString();
                        _Col73 = t[67].ToString();
                        _Col74 = t[68].ToString();
                        _Col75 = t[69].ToString();
                        _Col76 = t[70].ToString();
                        _Col77 = t[71].ToString();
                        _Col78 = t[72].ToString();
                        _Col79 = t[73].ToString();
                        _Col80 = t[74].ToString();
                        _Col81 = t[75].ToString();
                        _Col82 = t[76].ToString();
                        _Col83 = t[77].ToString();
     
                        _lanalizr.Add(new AccessorLab.OTCHETPERIODR_ROTD(analizotchID, analizLevel
                                                                         , parentID
                                                                         , tabindex
                                                                         , analizID
                                                                         , nameStr
                                                                         , npunktOtchet
                                                                         , TABLNAME_
                                                                         , _colamb
                                                                         , _Col1  
                                                                         , _Col5  
                                                                         , _Col6  
                                                                         , _Col7  
                                                                         , _Col8  
                                                                         , _Col9  
                                                                         , _Col10
                                                                         , _Col11
                                                                         , _Col12
                                                                         , _Col13
                                                                         , _Col14
                                                                         , _Col15
                                                                         , _Col16
                                                                         , _Col17
                                                                         , _Col18
                                                                         , _Col19
                                                                         , _Col20
                                                                         , _Col21
                                                                         , _Col22
                                                                         , _Col23
                                                                         , _Col24
                                                                         , _Col25
                                                                         , _Col26
                                                                         , _Col27
                                                                         , _Col28
                                                                         , _Col29
                                                                         , _Col30
                                                                         , _Col31
                                                                         , _Col32
                                                                         , _Col45
                                                                         , _Col46
                                                                         , _Col47
                                                                         , _Col48
                                                                         , _Col49
                                                                         , _Col50
                                                                         , _Col51
                                                                         , _Col52
                                                                         , _Col53
                                                                         , _Col54
                                                                         , _Col55
                                                                         , _Col56
                                                                         , _Col57
                                                                         , _Col58
                                                                         , _Col59
                                                                         , _Col60
                                                                         , _Col61
                                                                         , _Col62
                                                                         , _Col63
                                                                         , _Col64
                                                                         , _Col65
                                                                         , _Col66
                                                                         , _Col67
                                                                         , _Col68
                                                                         , _Col69
                                                                         , _Col70
                                                                         , _Col71
                                                                         , _Col72
                                                                         , _Col73
                                                                         , _Col74
                                                                         , _Col75
                                                                         , _Col76
                                                                         , _Col77
                                                                         , _Col78
                                                                         , _Col79
                                                                         , _Col80
                                                                         , _Col81
                                                                         , _Col82
                                                                         , _Col83
                                                                         ,_ColItog
                                                                         ,false
                                          ));
                        _statb.ProgresBar.PerformStep();
                        _statb.ProgresBar.Update();
                    }
                    _statb.maxbar = 0;
                    _statb.Close();
                    aNLOTCHETTREEBindingSource.DataSource = _lanalizr;
                    _lanalizritog = _lanalizr.Where(x => x.analizotch_id == 1000).ToList<AccessorLab.OTCHETPERIODR_ROTD>();

                    this.treeList1.DataSource = aNLOTCHETTREEBindingSource;
                    treeList1.ExpandAll();
                    this.treeList2.DataSource = aNLOTCHETTREEBindingSource;
                    treeList2.ExpandAll();
                    this.treeList3.DataSource = aNLOTCHETTREEBindingSource;
                    treeList3.ExpandAll();
                    this.treeList4.DataSource = aNLOTCHETTREEBindingSource;
                    treeList4.ExpandAll();
                    this.treeList5.DataSource = aNLOTCHETTREEBindingSource;
                    treeList5.ExpandAll();
                    this.treeList6.DataSource = aNLOTCHETTREEBindingSource;
                    treeList6.ExpandAll();
                    this.treeList7.DataSource = aNLOTCHETTREEBindingSource;
                    treeList7.ExpandAll();
                   
                    //   Убираем колонки с пустыми значениями     treeList1                 
                    if (_lanalizritog[0]._Col1 == "") treeList1.Columns[1].Visible = false;
                    if (_lanalizritog[0]._Col5 == "") treeList1.Columns[2].Visible = false;
                    if (_lanalizritog[0]._Col6 == "") treeList1.Columns[3].Visible = false;
                    if (_lanalizritog[0]._Col7 == "") treeList1.Columns[4].Visible = false;
                    if (_lanalizritog[0]._Col8 == "") treeList1.Columns[5].Visible = false;
                    if (_lanalizritog[0]._Col9 == "") treeList1.Columns[6].Visible = false;
                    if (_lanalizritog[0]._Col10 == "") treeList1.Columns[7].Visible = false;
                    if (_lanalizritog[0]._Col11 == "") treeList1.Columns[8].Visible = false;
                    if (_lanalizritog[0]._Col12 == "") treeList1.Columns[9].Visible = false;
                    if (_lanalizritog[0]._Col13 == "") treeList1.Columns[10].Visible = false;
                    //   Убираем колонки с пустыми значениями     treeList2                 
                    if (_lanalizritog[0]._Col14 == "") treeList2.Columns[1].Visible = false;
                    if (_lanalizritog[0]._Col15 == "") treeList2.Columns[2].Visible = false;
                    if (_lanalizritog[0]._Col16 == "") treeList2.Columns[3].Visible = false;
                    if (_lanalizritog[0]._Col17 == "") treeList2.Columns[4].Visible = false;
                    if (_lanalizritog[0]._Col18 == "") treeList2.Columns[5].Visible = false;
                    if (_lanalizritog[0]._Col19 == "") treeList2.Columns[6].Visible = false;
                    if (_lanalizritog[0]._Col20 == "") treeList2.Columns[7].Visible = false;
                    if (_lanalizritog[0]._Col21 == "") treeList2.Columns[8].Visible = false;
                    if (_lanalizritog[0]._Col22 == "") treeList2.Columns[9].Visible = false;
                    if (_lanalizritog[0]._Col23 == "") treeList2.Columns[10].Visible = false;
                    //   Убираем колонки с пустыми значениями     treeList3                 
                    if (_lanalizritog[0]._Col24 == "") treeList3.Columns[1].Visible = false;
                    if (_lanalizritog[0]._Col25 == "") treeList3.Columns[2].Visible = false;
                    if (_lanalizritog[0]._Col26 == "") treeList3.Columns[3].Visible = false;
                    if (_lanalizritog[0]._Col27 == "") treeList3.Columns[4].Visible = false;
                    if (_lanalizritog[0]._Col28 == "") treeList3.Columns[5].Visible = false;
                    if (_lanalizritog[0]._Col29 == "") treeList3.Columns[6].Visible = false;
                    if (_lanalizritog[0]._Col30 == "") treeList3.Columns[7].Visible = false;
                    if (_lanalizritog[0]._Col31 == "") treeList3.Columns[8].Visible = false;
                    if (_lanalizritog[0]._Col32 == "") treeList3.Columns[9].Visible = false;
                    if (_lanalizritog[0]._Col45 == "") treeList3.Columns[10].Visible = false;
                    //   Убираем колонки с пустыми значениями     treeList4                 
                    if (_lanalizritog[0]._Col46 == "") treeList4.Columns[1].Visible = false;
                    if (_lanalizritog[0]._Col47 == "") treeList4.Columns[2].Visible = false;
                    if (_lanalizritog[0]._Col48 == "") treeList4.Columns[3].Visible = false;
                    if (_lanalizritog[0]._Col49 == "") treeList4.Columns[4].Visible = false;
                    if (_lanalizritog[0]._Col50 == "") treeList4.Columns[5].Visible = false;
                    if (_lanalizritog[0]._Col51 == "") treeList4.Columns[6].Visible = false;
                    if (_lanalizritog[0]._Col52 == "") treeList4.Columns[7].Visible = false;
                    if (_lanalizritog[0]._Col53 == "") treeList4.Columns[8].Visible = false;
                    if (_lanalizritog[0]._Col54 == "") treeList4.Columns[9].Visible = false;
                    if (_lanalizritog[0]._Col55 == "") treeList4.Columns[10].Visible = false;
                    //   Убираем колонки с пустыми значениями     treeList5                 
                    if (_lanalizritog[0]._Col56 == "") treeList5.Columns[1].Visible = false;
                    if (_lanalizritog[0]._Col57 == "") treeList5.Columns[2].Visible = false;
                    if (_lanalizritog[0]._Col58 == "") treeList5.Columns[3].Visible = false;
                    if (_lanalizritog[0]._Col59 == "") treeList5.Columns[4].Visible = false;
                    if (_lanalizritog[0]._Col60 == "") treeList5.Columns[5].Visible = false;
                    if (_lanalizritog[0]._Col61 == "") treeList5.Columns[6].Visible = false;
                    if (_lanalizritog[0]._Col62 == "") treeList5.Columns[7].Visible = false;
                    if (_lanalizritog[0]._Col63 == "") treeList5.Columns[8].Visible = false;
                    if (_lanalizritog[0]._Col64 == "") treeList5.Columns[9].Visible = false;
                    if (_lanalizritog[0]._Col65 == "") treeList5.Columns[10].Visible = false;
                    //   Убираем колонки с пустыми значениями     treeList6                 
                    if (_lanalizritog[0]._Col66 == "") treeList6.Columns[1].Visible = false;
                    if (_lanalizritog[0]._Col67 == "") treeList6.Columns[2].Visible = false;
                    if (_lanalizritog[0]._Col68 == "") treeList6.Columns[3].Visible = false;
                    if (_lanalizritog[0]._Col69 == "") treeList6.Columns[4].Visible = false;
                    if (_lanalizritog[0]._Col70 == "") treeList6.Columns[5].Visible = false;
                    if (_lanalizritog[0]._Col71 == "") treeList6.Columns[6].Visible = false;
                    if (_lanalizritog[0]._Col72 == "") treeList6.Columns[7].Visible = false;
                    if (_lanalizritog[0]._Col73 == "") treeList6.Columns[8].Visible = false;
                    if (_lanalizritog[0]._Col74 == "") treeList6.Columns[9].Visible = false;
                    if (_lanalizritog[0]._Col75 == "") treeList6.Columns[10].Visible = false;
                    //   Убираем колонки с пустыми значениями     treeList7                 
                    if (_lanalizritog[0]._Col76 == "") treeList7.Columns[1].Visible = false;
                    if (_lanalizritog[0]._Col77 == "") treeList7.Columns[2].Visible = false;
                    if (_lanalizritog[0]._Col78 == "") treeList7.Columns[3].Visible = false;
                    if (_lanalizritog[0]._Col79 == "") treeList7.Columns[4].Visible = false;
                    if (_lanalizritog[0]._Col80 == "") treeList7.Columns[5].Visible = false;
                    if (_lanalizritog[0]._Col81 == "") treeList7.Columns[6].Visible = false;
                    if (_lanalizritog[0]._Col82 == "") treeList7.Columns[7].Visible = false;
                    if (_lanalizritog[0]._Col83 == "") treeList7.Columns[8].Visible = false;
                 


                  //  if (_lanalizritog.Where(x => x._Col1 == "") == null)  treeList1.Columns[1].Visible = false;
                  
                }catch (Exception ex)
                {
                    DialogResult result = MessageBox.Show(ex.Message, ex.Source);

                    // goto metka;
                }
                finally
                {
                    con.Close();

                }}

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            int lchigt =treeList1 .ColumnPanelRowHeight;
            
        
            const string strfile = "kdl.rtf";
            int intvibpage = imageComboBoxEdit2.SelectedIndex;
            if        (intvibpage == 0) SetFormprindocument(treeList1);
            else if (intvibpage == 1) SetFormprindocument(treeList2);
            else if (intvibpage == 2) SetFormprindocument(treeList3);
            else if (intvibpage == 3) SetFormprindocument(treeList4);
            else if (intvibpage == 4) SetFormprindocument(treeList5);
            else if (intvibpage == 5) SetFormprindocument(treeList6);
            else if (intvibpage == 6) SetFormprindocument(treeList7);
            _link.CreateReportHeaderArea += PrintableComponentLink1CreateReportHeaderArea;
            _link.CreateDocument();
            treeViewLink1.PrintingSystem.ExportToRtf(strfile);

            if (intvibpage == 0)       treeList1.ColumnPanelRowHeight = lchigt;
            else if (intvibpage == 1) treeList2.ColumnPanelRowHeight = lchigt;
            else if (intvibpage == 2) treeList3.ColumnPanelRowHeight = lchigt;
            else if (intvibpage == 3) treeList4.ColumnPanelRowHeight = lchigt;
            else if (intvibpage == 4) treeList5.ColumnPanelRowHeight = lchigt;
            else if (intvibpage == 5) treeList6.ColumnPanelRowHeight = lchigt;
            else if (intvibpage == 6) treeList7.ColumnPanelRowHeight = lchigt;
            //const string strfile = "kdl.xlsx";
            //_link.PrintingSystem.ExportToXlsx(strfile);

            System.Diagnostics.Process.Start(strfile);
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            // Generate the report.
           // treeList1.Columns[1].Visible = false;
         //   ps.Links[0].CreateDocument();
            //treeViewLink1.CreateReportHeaderArea += PrintableComponentLink1CreateReportHeaderArea;
           // treeList1.ShowPrintPreview();
           int  lchigt = treeList1.ColumnPanelRowHeight;
            int intvibpage = imageComboBoxEdit2.SelectedIndex;
            if (intvibpage == 0) SetFormprindocument(treeList1);
            else if (intvibpage ==1) SetFormprindocument(treeList2);
            else if (intvibpage == 2) SetFormprindocument(treeList3);
            else if (intvibpage == 3) SetFormprindocument(treeList4);
            else if (intvibpage == 4) SetFormprindocument(treeList5);
            else if (intvibpage == 5) SetFormprindocument(treeList6);
            else if (intvibpage == 6) SetFormprindocument(treeList7);
           treeViewLink1.CreateDocument();
            treeViewLink1.ShowPreview();


            if (intvibpage == 0) treeList1.ColumnPanelRowHeight = lchigt;
            else if (intvibpage == 1) treeList2.ColumnPanelRowHeight = lchigt;
            else if (intvibpage == 2) treeList3.ColumnPanelRowHeight = lchigt;
            else if (intvibpage == 3) treeList4.ColumnPanelRowHeight = lchigt;
            else if (intvibpage == 4) treeList5.ColumnPanelRowHeight = lchigt;
            else if (intvibpage == 5) treeList6.ColumnPanelRowHeight = lchigt;
            else if (intvibpage == 6) treeList7.ColumnPanelRowHeight = lchigt;
          //  treeList1.ShowPrintPreview();
           //ps.PreviewFormEx.Owner = this;
           //ps.PreviewFormEx.Show();

            //link.PrintingSystem.ExportToRtf(@"c:\PPC-KDL\kdl.rtf"); 
            // Show the report.
          //  _link.ShowPreview();
        }

        private void ClearColambStac()
        {
            _statb = new StatusProgresbar(Bounds) { Text = @"Чистка итоговых значений" };
            _statb.maxbar = 200;
            _statb.stepbar = 1;
            _statb.StartPosition = FormStartPosition.CenterScreen;
            _statb.Show();
            treeList1.Nodes.GetEnumerator();
            TreeListColumn colamb = treeList1.Columns["colamb"];

            var operation = new TreeListExceedLimitOperation(colamb);
            treeList1.NodesIterator.DoOperation(operation);
            _statb.maxbar = 0;
            _statb.Close();}

        public class TreeListExceedLimitOperation : TreeListOperation
        {

            private readonly TreeListColumn _colamb;
           
            public TreeListExceedLimitOperation( TreeListColumn colamb0               )
            {
                _colamb = colamb0;
            }
            public override void Execute(TreeListNode node)
            {
                if (node.HasChildren)
                {
                    node.SetValue(_colamb, "");
                }
              
            }
          
        }

        private void imageComboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (imageComboBoxEdit1.SelectedIndex)
            {
                case 0:
                    {
                        datePeriodEdit1.Properties.OptionsSelection.MultiselectBehaviour = MultiselectBehaviour.Disabled;
                        datePeriodEdit1.Properties.OptionsSelection.ShowWeekLevel = false;
                        datePeriodEdit1.Properties.OptionsSelection.LowLevel = ViewLevel.Years;
                        datePeriodEdit1.Properties.OptionsSelection.HightLevel = ViewLevel.Years;
                        datePeriodEdit1.Properties.ShowWeekNumbers = false; ;
                    }
                    break;
                case 1:
                    {
                        datePeriodEdit1.Properties.OptionsSelection.MultiselectBehaviour = MultiselectBehaviour.Intersection;
                        datePeriodEdit1.Properties.OptionsSelection.ShowWeekLevel = false;
                        datePeriodEdit1.Properties.OptionsSelection.LowLevel = ViewLevel.Months;
                        datePeriodEdit1.Properties.OptionsSelection.HightLevel = ViewLevel.Months;
                        datePeriodEdit1.Properties.ShowWeekNumbers = false;
                    }
                    break;
                case 2:
                    {
                        datePeriodEdit1.Properties.OptionsSelection.MultiselectBehaviour = MultiselectBehaviour.Intersection;
                        datePeriodEdit1.Properties.OptionsSelection.ShowWeekLevel = false;
                        datePeriodEdit1.Properties.OptionsSelection.LowLevel = ViewLevel.Days;
                        datePeriodEdit1.Properties.OptionsSelection.HightLevel = ViewLevel.Days;
                        datePeriodEdit1.Properties.ShowWeekNumbers = false;
                    }
                    break;
            }
        }
        int _k = 0;
        private void SimpleButton5Click(object sender, EventArgs e)
        {
            // выбор отделения


            if (_k > 0)
            {
                XtraMessageBox.Show("Вы уже выбрали отделения. Запустите задание заново ??? ");
                return;}
            foreach (var z in _lotd)
            {
                z.Vib = false;
            }
            //_lotd.Add(new AccessorLab.Viborotd(100 , "Роддом", "Роддом", false));
            var fr1 = new FormOtdvibor {Lotd = _lotd};
            fr1.InitLookup();
            if (DialogResult.OK == fr1.ShowDialog())
            {
                _lotdvib.Clear();
                _lotdvib = fr1.LotdVib;
                FormStringVIB(_lotdvib);
                SetVibColumn(_lotdvib);
            }
        }

        private void FormStringVIB(IEnumerable<AccessorLab.Viborotd> lvibotd)
        {
            strvibotd = Strotdvib(_lotdvib);
            strvibotdzapjtaj = Strotdvibzapjtaj(_lotdvib);
            strvibotdskobki = Strotdvibskobki(_lotdvib);
            strvibotdskobkias = StrotdvibskobkiAS(_lotdvib);
            strvibotdcolonki = Strotdvibcolonki(_lotdvib);
        }

        private void SetVibColumn(IEnumerable<AccessorLab.Viborotd> lvibotd)
        {
            _k = 0;
            FormStringVIB(lvibotd);
            int s = 0;
            foreach (var t in lvibotd)
            {
                switch (s/10)
                {
                    case 0:
                        {
                            //AutoRowHeight включено 
                            TreeListColumn column;
                          
                            column = treeList1.Columns.Add();
                            column.FieldName = "_Col" + t.OtdId.ToString();
                            column.Caption = t.NameOtdsokr;
                            column.VisibleIndex = treeList1.Columns.Count + 1;
                        }
                        break;
                    case 1:
                        {
                            TreeListColumn column;
                                column = treeList2.Columns.Add();
                                column.FieldName = "_Col" + t.OtdId.ToString();
                                column.Caption = t.NameOtdsokr;
                                column.VisibleIndex = treeList2.Columns.Count + 1;
                        }
                        break;
                    case 2:
                        {
                            TreeListColumn column;
                            column = treeList3.Columns.Add();
                            column.FieldName = "_Col" + t.OtdId.ToString();
                            column.Caption = t.NameOtdsokr;
                            column.VisibleIndex = treeList3.Columns.Count + 1;
                        }
                        break;
                    case 3:
                        {
                            TreeListColumn column;
                            column = treeList4.Columns.Add();
                            column.FieldName = "_Col" + t.OtdId.ToString();
                            column.Caption = t.NameOtdsokr;
                            column.VisibleIndex = treeList4.Columns.Count + 1;
                        }
                        break;
                    case 4:
                        {
                            TreeListColumn column;
                            column = treeList5.Columns.Add();
                            column.FieldName = "_Col" + t.OtdId.ToString();
                            column.Caption = t.NameOtdsokr;
                            column.VisibleIndex = treeList5.Columns.Count + 1;
                        }
                        break;
                    case 5:
                        {
                            TreeListColumn column;
                            column = treeList6.Columns.Add();
                            column.FieldName = "_Col" + t.OtdId.ToString();
                            column.Caption = t.NameOtdsokr;
                            column.VisibleIndex = treeList6.Columns.Count + 1;
                        }
                        break;
                    case 6:
                        {
                            TreeListColumn column;
                            column = treeList7.Columns.Add();
                            column.FieldName = "_Col" + t.OtdId.ToString();
                            column.Caption = t.NameOtdsokr;
                            column.VisibleIndex = treeList7.Columns.Count + 1;
                        }
                        break;
                }
                s++;
            }
            //if (Pviborvse)
            //{
            //    column = treeList1.Columns.Add();
            //    column.FieldName = "ColItog";
            //    column.Caption = "Итого:";
            //    column.VisibleIndex = treeList1.Columns.Count + 1;
            //    FormStringVIB(lvibotd);
            //}
        }

        private string Strotdvib(IEnumerable<AccessorLab.Viborotd> lvibotd )
        {
           return lvibotd.Aggregate("", (current, v) => current + (v.OtdId.ToString() + " "));
        }
        private string Strotdvibzapjtaj(IEnumerable<AccessorLab.Viborotd> lvibotd)
        {
            string strreturn=lvibotd.Aggregate("", (current, v) => current + (v.OtdId.ToString() + ","));
            return strreturn.Substring(0, strreturn.Length - 1);
        }
        private string Strotdvibskobki(IEnumerable<AccessorLab.Viborotd> lvibotd)
        {
            string strreturn = lvibotd.Aggregate("", (current, v) => current + ("["+v.OtdId.ToString() + "],"));
            return strreturn.Substring(0, strreturn.Length - 1);
        }
        private string StrotdvibskobkiAS(IEnumerable<AccessorLab.Viborotd> lvibotd)
        {
            //string str1 = lvibotd.Aggregate("", (current, v) => current + ("Col" + v.OtdId.ToString() + " int ,"));
            string strreturn = lvibotd.Aggregate("", (current, v) => current + ("[" + v.OtdId.ToString() + "]  AS Col" + v.OtdId.ToString() + ","));
            return strreturn.Substring(0, strreturn.Length - 1);
        }
        private string Strotdvibcolonki(IEnumerable<AccessorLab.Viborotd> lvibotd)
        {
            //string str1 = lvibotd.Aggregate("", (current, v) => current + ("Col" + v.OtdId.ToString() + " int ,"));
            string strreturn = lvibotd.Aggregate("", (current, v) => current + ( "Col" + v.OtdId.ToString() + ","));
            return strreturn.Substring(0, strreturn.Length - 1);
        }
        private void CheckEdit1CheckedChanged(object sender, EventArgs e)
        {
            bool vibvse = checkEdit1.Checked;
            simpleButton5.Visible = !vibvse;
            if (vibvse)
            {
                _lotdvib = _lotd;
                SetVibColumn(_lotdvib);
            }
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            // Определение строки отчета
            if (e.Node != null)
            {
                _kle = (AccessorLab.OTCHETPERIODR_ROTD) aNLOTCHETTREEBindingSource[treeList1.FocusedNode.Id];
                if (_kle != null)
                {
                    klID = Convert.ToInt32(_kle.analizotch_id);
                 }
             }
        }
       private void treeList1_FocusedColumnChanged(object sender, DevExpress.XtraTreeList.FocusedColumnChangedEventArgs e)
        {
            // определение колонки отчета
            //Col1,Col5,Col6,Col7,Col8,Col9,Col10,Col11,Col12,Col13,Col14,Col15,Col16,Col17,Col18,Col19,Col20,Col21,Col22,Col23,Col24,Col25,Col26,Col27,Col28,Col29,Col30,Col31,Col32,Col45,Col46,Col47,Col48,Col49,Col50,Col51,Col52,Col53,Col54,Col55,Col56,Col57,Col58,Col59,Col60,Col61,Col62,Col63,Col64,Col65,Col66,Col67,Col68,Col69,Col70,Col71,Col72,Col73,Col74,Col75,Col76,Col77,Col78,Col79
           if (e.Column !=null)
           {
               TreeListColumn column = e.Column;
               string strfield = column.FieldName;
               int.TryParse(strfield.Substring(4), out  _otdid1);
              }
        }

       private void simpleButton6_Click(object sender, EventArgs e)
       {
           // Вывод анализов по колонке
           var frviewotd=new FormOtdGODVIEW();
           frviewotd._otdvib = _otdid1;
           frviewotd._klevib = _kle;
           frviewotd._labanalizt = _labanaliz;
           frviewotd._periodvib = Pdatevibstr;
            frviewotd.Show();
       }

//       private void simpleButton7_Click(object sender, EventArgs e)
//       {
//           var resvib = from c in _lanalizr where c.vib select c;
//           var list = new List<AccessorLab.OTCHETPERIODR_ROTD>();
//           foreach (AccessorLab.OTCHETPERIODR_ROTD rotd in resvib)
//           {
//               list.Add(rotd);
//           }
//           int lccountvib = list.Count;
//         //  int lccolumn1, lccolumn2, lccolumn3, lccolumn4, lccolumn5;
//           aNLOTCHETTREEBindingSource.DataSource = list;
//           treeList1.DataSource = null;
//           treeList1.DataSource = aNLOTCHETTREEBindingSource.DataSource;
//          treeList1.ExpandAll();
//         // ClearColambStac();
//#region  Убираем колонки с нулевыми значениями
//               foreach (var t in _lotdvib)
//               {
//                   string intcolumn ="Col" + t.OtdId;
//                   switch (intcolumn)
//                   {
//                       case "Col1":
//                          int lccolumn1 = list.Where(c => int.Parse(c.Col1) == 0).Count();
//                           if (lccolumn1 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col2":
//                          int lccolumn2 = list.Where(c => int.Parse(c.Col2) == 0).Count();
//                           if (lccolumn2 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col3":
//                           int lccolumn3 = list.Where(c => int.Parse(c.Col3) == 0).Count();
//                           if (lccolumn3 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col4":
//                           int lccolumn4 = list.Where(c => int.Parse(c.Col4) == 0).Count();
//                           if (lccolumn4 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col5":
//                          int lccolumn5 = list.Where(c => int.Parse(c.Col5) == 0).Count();
//                           if (lccolumn5 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col6":
//                           int lccolumn6 = list.Where(c => int.Parse(c.Col6) == 0).Count();
//                           if (lccolumn6 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col7":
//                           int lccolumn7 = list.Where(c => int.Parse(c.Col7) == 0).Count();
//                           if (lccolumn7 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col8":
//                          int lccolumn8 = list.Where(c => int.Parse(c.Col8) == 0).Count();
//                           if (lccolumn8 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col9":
//                           int lccolumn9 = list.Where(c => int.Parse(c.Col9) == 0).Count();
//                           if (lccolumn9 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col10":
//                          int lccolumn10 = list.Where(c => int.Parse(c.Col10) == 0).Count();
//                           if (lccolumn10== lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col11":
//                           int lccolumn11 = list.Where(c => int.Parse(c.Col11) == 0).Count();
//                           if (lccolumn11 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col12":
//                           int lccolumn12 = list.Where(c => int.Parse(c.Col12) == 0).Count();
//                           if (lccolumn12 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col13":
//                           int lccolumn13 = list.Where(c => int.Parse(c.Col13) == 0).Count();
//                           if (lccolumn13 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col16":
//                            int lccolumn16 = list.Where(c => int.Parse(c.Col16) == 0).Count();
//                           if (lccolumn16 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col17":
//                           int lccolumn17 = list.Where(c => int.Parse(c.Col17) == 0).Count();
//                           if (lccolumn17 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col18":
//                           int lccolumn18 = list.Where(c => int.Parse(c.Col18) == 0).Count();
//                           if (lccolumn18 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col19":
//                           int lccolumn19 = list.Where(c => int.Parse(c.Col19) == 0).Count();
//                           if (lccolumn19 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col21":
//                           int lccolumn21 = list.Where(c => int.Parse(c.Col21) == 0).Count();
//                           if (lccolumn21 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col23":
//                           int lccolumn23 = list.Where(c => int.Parse(c.Col23) == 0).Count();
//                           if (lccolumn23 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col24":
//                           int lccolumn24 = list.Where(c => int.Parse(c.Col24) == 0).Count();
//                           if (lccolumn24 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col25":
//                           int lccolumn25 = list.Where(c => int.Parse(c.Col25) == 0).Count();
//                           if (lccolumn25 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col26":
//                           int lccolumn26 = list.Where(c => int.Parse(c.Col26) == 0).Count();
//                           if (lccolumn26 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col35":
//                           int lccolumn35 = list.Where(c => int.Parse(c.Col35) == 0).Count();
//                           if (lccolumn35 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col36":
//                           int lccolumn36 = list.Where(c => int.Parse(c.Col36) == 0).Count();
//                           if (lccolumn36 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col37":
//                           int lccolumn37 = list.Where(c => int.Parse(c.Col37) == 0).Count();
//                           if (lccolumn37 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col38":
//                           int lccolumn38 = list.Where(c => int.Parse(c.Col38) == 0).Count();
//                           if (lccolumn38 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col39":
//                           int lccolumn39 = list.Where(c => int.Parse(c.Col39) == 0).Count();
//                           if (lccolumn39 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col42":
//                           int lccolumn42 = list.Where(c => int.Parse(c.Col42) == 0).Count();
//                           if (lccolumn42 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col43":
//                           int lccolumn43 = list.Where(c => int.Parse(c.Col43) == 0).Count();
//                           if (lccolumn43 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col44":
//                           int lccolumn44 = list.Where(c => int.Parse(c.Col44) == 0).Count();
//                           if (lccolumn44 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col45":
//                           int lccolumn45 = list.Where(c => int.Parse(c.Col45) == 0).Count();
//                           if (lccolumn45 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col46":
//                          int lccolumn46 = list.Where(c => int.Parse(c.Col46) == 0).Count();
//                           if (lccolumn46 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col47":
//                           int lccolumn47 = list.Where(c => int.Parse(c.Col47) == 0).Count();
//                           if (lccolumn47 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col48":
//                           int lccolumn48 = list.Where(c => int.Parse(c.Col48) == 0).Count();
//                           if (lccolumn48 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                       case "Col49":
//                           int lccolumn49 = list.Where(c => int.Parse(c.Col49) == 0).Count();
//                           if (lccolumn49 == lccountvib)
//                           {
//                               GetValueintcolumn(intcolumn);
//                           }
//                           break;
//                   }
//               }
 
//#endregion
//               int lccolumn100 = list.Where(c => int.Parse(c.Colroddom) == 0).Count();
//               if (lccolumn100 == lccountvib)
//               {
//                   GetValueintcolumn("Colroddom");
//               }
//               treeList1.Columns[1].Visible = false;
//              treeList1.OptionsView.ShowRowFooterSummary = true;
//               foreach (TreeListColumn t1 in treeList1.Columns)
//               {
//                   if (t1.Visible == true)
//                   {
//                       if (t1.FieldName != "NameStr")
//                           t1.RowFooterSummary = SummaryItemType.Sum;
//                   }
//               }
//           //gridControl1
//           //gridControl1.DataSource = list;
//           //gridControl1.Visible = true;
//           //var view = gridControl1.MainView as ColumnView;
//           // var fieldNames = new string[] {"ProductID", "ProductName", "QuantityPerUnit", "UnitPrice"};
//           //if (view != null)
//           //{
//           //    view.Columns.Clear();
//           //    for (int i = 0; i < fieldNames.Length; i++)
//           //    {
//           //        DevExpress.XtraGrid.Columns.GridColumn column = view.Columns.AddField(fieldNames[i]);
//           //        column.VisibleIndex = i;
//           //    }
//           //}
//       }

        private void GetValueintcolumn(string intcolumn)
        {
            foreach (TreeListColumn t1 in treeList1.Columns)
            {
                if (t1.FieldName == intcolumn) t1.Visible = false;
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
       {
           foreach (var z in _lanalizr)
           {
               z.vib = false;
           }
            aNLOTCHETTREEBindingSource.DataSource = _lanalizr;
           treeList1.DataSource = null;
           treeList1.DataSource = aNLOTCHETTREEBindingSource.DataSource;
           treeList1.ExpandAll();
           treeList1.OptionsView.ShowRowFooterSummary = false;
           foreach (TreeListColumn t1 in treeList1.Columns)
           {
               if (t1.Visible == false) t1.Visible = true;
           }
           treeList1.Columns[1].Visible = true;

       }

        private void FrmOtchOTDGOD_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                PrintFormkrobch();
            }
        }
        private void PrintFormkrobch()
        {

            //var printDialog1 = new PrintDialog();simpleButton1.Visible = false;simpleButton2.Visible = false;
            printDocument1.PrintPage += OnDrawPage;
            simpleButton1.Visible = false;
            simpleButton2.Visible = false;
            string strText = Text;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
            simpleButton1.Visible = true;
            simpleButton2.Visible = true;
            Text = strText;
        }
       private void OnDrawPage(object sender, PrintPageEventArgs e)
        {
            string strob1 = datePeriodEdit1.Text;
            reportHeader =
                 "Выполняемый в КДЛ БУ «ЦГБ» МЗ СР ЧР перечень лабораторных исследований по отделениям: за период:" + strob1;
            PrintToGraphics(e.Graphics, e.MarginBounds, reportHeader, this, 32);
        }
        private static void PrintToGraphics(Graphics graphics, Rectangle bounds, string pzagol0, DevExpress.XtraEditors.XtraForm _form1, int smechenie)
        {
            //this.Text = "";
            // const  string HELLO_WORLD = "HELLO WORLD ";  // this.Text;
            //HELLO_WORLD = PZAGOLOVOK0;  // this.Text;
            _form1.Text = "";
            var messageSize = graphics.MeasureString(pzagol0, _form1.Font);
            Bitmap bitmap0 = new Bitmap((int)messageSize.Width, (int)messageSize.Height);
            _form1.DrawToBitmap(bitmap0, new Rectangle(0, 0, bitmap0.Width, bitmap0.Height));

            Rectangle target0 = new Rectangle(0, 0, bitmap0.Width, bitmap0.Height);
            PointF p = new PointF(10, 5);
            //PointF p = new PointF((ClientSize.Width - messageSize.Width) / 2,
            // (ClientSize.Height - messageSize.Height) / 2);
            graphics.DrawString(pzagol0, _form1.Font, SystemBrushes.WindowText, p);
            //SettargetRazmer(bounds, target0, bitmap0);
            double xScale0 = (double)bitmap0.Width / bounds.Width;
            double yScale0 = (double)bitmap0.Height / bounds.Height;
            if (xScale0 < yScale0)
                target0.Width = (int)(xScale0 * target0.Width / yScale0);
            else
                target0.Height = (int)(yScale0 * target0.Height / xScale0);
            //==
            graphics.PageUnit = GraphicsUnit.Display;
            graphics.DrawImage(bitmap0, target0);
            //  this.Text = "";
            Bitmap bitmap = new Bitmap(_form1.Width, _form1.Height);
            _form1.DrawToBitmap(bitmap, new Rectangle(0, bitmap0.Height + smechenie, bitmap.Width, bitmap.Height));
            Rectangle target = new Rectangle(0, 0, bounds.Width, bounds.Height + smechenie);
            // SettargetRazmer(bounds, target, bitmap);
            double xScale = (double)bitmap.Width / bounds.Width;
            double yScale = (double)bitmap.Height / bounds.Height;
            if (xScale < yScale)
                target.Width = (int)(xScale * target.Width / yScale);
            else
                target.Height = (int)(yScale * target.Height / xScale);
            graphics.PageUnit = GraphicsUnit.Display;
            graphics.DrawImage(bitmap, target);

        } 
    }
}