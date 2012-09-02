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
        #region ���������� ���������� ��������
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
                case "�� �����������":
                    //FormRSView frs = new FormRSView();
                    //frs.Text = strParent + "  " + stranaliz;
                    //frs.FormRS(stranaliz);
                    //frs.Show();
                    break;
                case "�������� ����":
                    _rp = new ReportServer("/ReportLabProject/������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "�����":
                    _rp = new ReportServer("/ReportLabProject/���������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "�������� ���� �� ����� � �����":
                    _rp = new ReportServer("/ReportLabProject/����������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "�� �����������":
                    _rp = new ReportServer("/ReportLabProject/�����������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "�� ����������":
                    _rp = new ReportServer("/ReportLabProject/����������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "������ ����� �����":
                    break;
                case "������������� ������ �����":
                    _rp = new ReportServer("/ReportLabProject/�������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "�������������":
                    _rp = new ReportServer("/ReportLabProject/�������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "����������� �������":
                    _rp = new ReportServer("/ReportLabProject/���������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "����� �� �����":
                    _rp = new ReportServer("/ReportLabProject/������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "��������� ������� � ��� 1 � 2 ����� (���)":
                    _rp = new ReportServer("/ReportLabProject/�����", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "�� �������":
                    _rp = new ReportServer("/ReportLabProject/��������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "�� ������������� ������� �������":
                    _rp = new ReportServer("/ReportLabProject/�����������������������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "�� ������ � ����� ������":
                    _rp = new ReportServer("/ReportLabProject/�������������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "������������ ����":
                    _rp = new ReportServer("/ReportLabProject/����������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "����������� ������ ������� ��������(LE-������)":
                    _rp = new ReportServer("/ReportLabProject/���������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "���������������� ����":
                    _rp = new ReportServer("/ReportLabProject/��������������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "����������� �������� (RPR,����)":
                    _rp = new ReportServer("/ReportLabProject/���������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "��������":
                    _rp = new ReportServer("/ReportLabProject/����������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "������������ �������":
                    _rp = new ReportServer("/ReportLabProject/�������������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "������ ��������":
                    _rp = new ReportServer("/ReportLabProject/�������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "����������� ���� � ������":
                    _rp = new ReportServer("/ReportLabProject/�����������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "����� �� �����":
                    _rp = new ReportServer("/ReportLabProject/������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "����������� � ���� �������������� ����������� (����� ����)":
                    _rp = new ReportServer("/ReportLabProject/��������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "��� �� �/� � ����������":
                    _rp = new ReportServer("/ReportLabProject/������������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "�� ��������":
                    _rp = new ReportServer("/ReportLabProject/�������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "����������� ��� ������� �� ������������ ��������":
                    //rp = new ReportServer("/ReportLabProject/�������������", strParent + "  " + stranaliz);
                    //rp.Show();
                    break;
                case "������ � �����":
                    _rp = new ReportServer("/ReportLabProject/������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "����� �� ������������":
                    _rp = new ReportServer("/ReportLabProject/�������������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "����������� ��������� �����������, ��������������� ���������� ":
                    _rp = new ReportServer("/ReportLabProject/��������������������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "�� ������� ������� ���":
                    _rp = new ReportServer("/ReportLabProject/����������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "������� ��� �� �������� � ��� � ��������� ���� � ������������":
                    _rp = new ReportServer("/ReportLabProject/��������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "����������� ����������������":
                    _rp = new ReportServer("/ReportLabProject/�������������������IgAIgM", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "�������� ������� ������� ������������� �� ���":
                    _rp = new ReportServer("/ReportLabProject/��������������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "��� ��������� ������������ ������� ���":
                    _rp = new ReportServer("/ReportLabProject/������������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "�������������� ������������":
                    _rp = new ReportServer("/ReportLabProject/�����������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "������������ �������� � ����� ����� � ������������� ������":
                    break;
                case "��������� � �����������":
                    _rp = new ReportServer("/ReportLabProject/������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "�����������":
                    break;
                case "������ ���� ��������":
                    _rp = new ReportServer("/ReportLabProject/�����������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "����� �� �������������":
                    _rp = new ReportServer("/ReportLabProject/����������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "�� ���� ������������� � �������":
                    _rp = new ReportServer("/ReportLabProject/�����������������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "��� �����":
                    _rp = new ReportServer("/ReportLabProject/��������", _strParent + "  " + _stranaliz);
                    _rp.Show();
                    break;
                case "�� �����������":
                    _rp = new ReportServer("/ReportLabProject/������������������", _strParent + "  " + _stranaliz);
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
                if (_strParent == "������") _strParent = "";
            }
        }
   
 


    }
}