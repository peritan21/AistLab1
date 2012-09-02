using System;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.AnalizKala
{
    public partial class FrmAnalKalUgkGrid : DevExpress.XtraEditors.XtraForm
    {
        private KALANALIZUGLEV _kl;
        private readonly BindingSource _dataSource;
        private string _strNomer="";
        public FrmAnalKalUgkGrid()
        {
          
            InitializeComponent();
            _dataSource = kALANALIZUGLEVBindingSource;
            dataDateEdit.DataBindings.Add(new Binding("Editvalue", _dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource, "data", true));
            tabImageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", _dataSource, "cvet", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource, "cvetkol", true));
            tabImageComboBoxEdit2.DataBindings.Add(new Binding("SelectedIndex", _dataSource, "zelenbezo", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", _dataSource, "zelenbezokol1", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", _dataSource, "zelenbezokol2", true));
            tabImageComboBoxEdit3.DataBindings.Add(new Binding("SelectedIndex", _dataSource, "zelenso", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", _dataSource, "zelensokol1", true));
            tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", _dataSource, "zelensokol2", true));
            tabImageComboBoxEdit4.DataBindings.Add(new Binding("SelectedIndex", _dataSource, "olovkjelt", true));
            tabSpinEdit6.DataBindings.Add(new Binding("Editvalue", _dataSource, "olovkjeltkol1", true));
            tabSpinEdit7.DataBindings.Add(new Binding("Editvalue", _dataSource, "olovkjeltkol2", true));
            tabImageComboBoxEdit5.DataBindings.Add(new Binding("SelectedIndex", _dataSource, "oranj", true));
            tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", _dataSource, "oranjkol1", true));
            tabSpinEdit9.DataBindings.Add(new Binding("Editvalue", _dataSource, "oranjkol2", true));
            tabImageComboBoxEdit6.DataBindings.Add(new Binding("SelectedIndex", _dataSource, "svkrasn", true));
            tabSpinEdit10.DataBindings.Add(new Binding("Editvalue", _dataSource, "svkrasnkol", true));
        }
        public int PpacientID
        { get; set; }
        public int PlaborantID
        { get; set; }
        public int Potd
        { get; set; }
       
            // Вызов N истории
       public void InitSQLData()
        {
           //db = new DataClassesLabDataContext();
           //var res = (from c in db.KALANALIZUGLEVs where c.pacient_id == Ppacient_id && c.otd == Potd select c);
           // this.kALANALIZUGLEVBindingSource.DataSource = res;

           _kl = new KALANALIZUGLEV
                     {data = DateTime.Now, pacient_id = PpacientID, laborant_id = PlaborantID, otd = Potd};

           kALANALIZUGLEVBindingSource.DataSource = _kl;
            labelControl2.Text = @"Можно вводить данные анализа для: " + _strNomer;
            tabImageComboBoxEdit1.Focus();
        }

        private void SimpleButton1Click(object sender, EventArgs e)
        {
           var db = new DataClassesLabDataContext();
            db.KALANALIZUGLEVs.InsertOnSubmit(_kl);
              try
            {
                // ConflictMode is an optional parameter.
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                labelControl2.Text = @"Данные анализа успешно записаны !!!";
            }
            catch (ChangeConflictException)
            {
                // Get conflict information, and take actions
                // that are appropriate for your application.
                // See MSDN Article How to: Manage Change Conflicts (LINQ to SQL).
                labelControl2.Text = @"Приозошла ошибка записи анализа на сервер???!";
            }
            tabTextBox11.Focus();
        }
    
        private void SimpleButton25Click(object sender, EventArgs e)
        {
            //var da = new DataClassesAistDataContext();
            //_strNomer = tabTextBox11.Text;
            //var resfio = (from c in da.PACIENTs where c.n_history == _strNomer  select c);
            //foreach (var t in resfio)
            //{
            //    textEdit1.Text = t.fio;
            //    PpacientID = t.pacient_id;
            //}
            //InitSQLData();
        }

        private void SimpleButton2Click(object sender, EventArgs e)
        {
            Close();
        }

     
       
    }
}