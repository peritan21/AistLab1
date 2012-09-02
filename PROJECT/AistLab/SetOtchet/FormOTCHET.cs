using System;
using AistLabData;

namespace AistLab.SetOtchet
{
    public partial class FormOTCHET : DevExpress.XtraEditors.XtraForm
    {
        private DataClassesLabDataContext _db;
          public FormOTCHET()
        {
            InitializeComponent();
        }
          public DateTime Pdatsel
          {
              set { dateEdit1.EditValue = value; }
              get { return (DateTime)dateEdit1.EditValue; }
          }

          private void SimpleButton1Click(object sender, EventArgs e)
          {
              _db = new DataClassesLabDataContext();
              var res = _db.ANALIZ_OTCHET((byte)Pdatsel.Month, Pdatsel.Year);
              gridControl1.DataSource = res;
          }

          private void SimpleButton2Click(object sender, EventArgs e)
          {
              Close();
          }

    
    }
}