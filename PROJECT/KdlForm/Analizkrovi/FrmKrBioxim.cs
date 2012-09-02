using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using AistLabData;

namespace KdlForm.Analizkrovi
{
    public partial class FrmKrBioxim : DevExpress.XtraEditors.XtraForm
    {
        private readonly BindingSource _dataSource1;
        private string _strText;
        public FrmKrBioxim(BindingSource dataSource)
        {
            _dataSource1 = dataSource;
            InitializeComponent();
            dateEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            timeEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "data", true));
            tabSpinEdit1.DataBindings.Add(new Binding("Editvalue", dataSource, "bilirubob", true));
            tabSpinEdit2.DataBindings.Add(new Binding("Editvalue", dataSource, "bilirubpram", true));
            tabSpinEdit3.DataBindings.Add(new Binding("Editvalue", dataSource, "bilirubnepram", true));
            tabSpinEdit4.DataBindings.Add(new Binding("Editvalue", dataSource, "acat", true));
            tabSpinEdit5.DataBindings.Add(new Binding("Editvalue", dataSource, "alat", true));
            tabSpinEdit6.DataBindings.Add(new Binding("Editvalue", dataSource, "mohevina", true));
            tabSpinEdit7.DataBindings.Add(new Binding("Editvalue", dataSource, "obbelok", true));
            tabSpinEdit8.DataBindings.Add(new Binding("Editvalue", dataSource, "kreateninqen", true));
            tabSpinEdit9.DataBindings.Add(new Binding("Editvalue", dataSource, "mohkisqen", true));
            tabSpinEdit10.DataBindings.Add(new Binding("Editvalue", dataSource, "jelezo", true));
            tabSpinEdit11.DataBindings.Add(new Binding("Editvalue", dataSource, "oqcc", true));
            tabSpinEdit12.DataBindings.Add(new Binding("Editvalue", dataSource, "nqcc", true));
            tabSpinEdit13.DataBindings.Add(new Binding("Editvalue", dataSource, "koefnastransqelqen", true));
         //   tabImageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "crbkahmet", true));
            tabImageComboBoxEdit5.DataBindings.Add(new Binding("SelectedIndex", dataSource, "crbinterval", true));
            tabSpinEdit14.DataBindings.Add(new Binding("Editvalue", dataSource, "crbkolihmet", true));
          //  tabImageComboBoxEdit2.DataBindings.Add(new Binding("SelectedIndex", dataSource, "rfkahmet", true));
            tabSpinEdit15.DataBindings.Add(new Binding("Editvalue", dataSource, "rfkolihmet", true));
          //  tabImageComboBoxEdit3.DataBindings.Add(new Binding("SelectedIndex", dataSource, "aclokahmet", true));
            tabSpinEdit16.DataBindings.Add(new Binding("Editvalue", dataSource, "aclokolihmet", true));
            tabSpinEdit17.DataBindings.Add(new Binding("Editvalue", dataSource, "glykoza", true));
            tabSpinEdit18.DataBindings.Add(new Binding("Editvalue", dataSource, "timolovapr", true));
            tabSpinEdit19.DataBindings.Add(new Binding("Editvalue", dataSource, "helohfosfatqen", true));
            tabSpinEdit20.DataBindings.Add(new Binding("Editvalue", dataSource, "alfaamilaza", true));
            tabSpinEdit21.DataBindings.Add(new Binding("Editvalue", dataSource, "magnimuq", true));
            tabSpinEdit22.DataBindings.Add(new Binding("Editvalue", dataSource, "hlorid", true));
            tabSpinEdit23.DataBindings.Add(new Binding("Editvalue", dataSource, "kreatinkinqen", true));
            tabSpinEdit24.DataBindings.Add(new Binding("Editvalue", dataSource, "fosforneorg", true));
            tabSpinEdit25.DataBindings.Add(new Binding("Editvalue", dataSource, "kalii", true));
            tabSpinEdit26.DataBindings.Add(new Binding("Editvalue", dataSource, "natrii", true));
            tabSpinEdit27.DataBindings.Add(new Binding("Editvalue", dataSource, "kalciionizirov", true));
            tabSpinEdit28.DataBindings.Add(new Binding("Editvalue", dataSource, "holesterin", true));
            tabSpinEdit29.DataBindings.Add(new Binding("Editvalue", dataSource, "triglicerid", true));
            tabSpinEdit30.DataBindings.Add(new Binding("Editvalue", dataSource, "hclvpahc", true));
            tabSpinEdit31.DataBindings.Add(new Binding("Editvalue", dataSource, "hclpnpbhc", true));
            tabSpinEdit32.DataBindings.Add(new Binding("Editvalue", dataSource, "hclponpprebhc", true));
            tabSpinEdit33.DataBindings.Add(new Binding("Editvalue", dataSource, "indaterogqen20let30", true));
            //tabSpinEdit34.DataBindings.Add(new Binding("Editvalue", dataSource, "indateroglicsibc", true));
            tabSpinEdit35.DataBindings.Add(new Binding("Editvalue", dataSource, "ggtvsuvorotki", true));
            tabImageComboBoxEdit4.DataBindings.Add(new Binding("SelectedIndex", dataSource, "pktprokalcitonin", true));
    
            tabSpinEdit42.DataBindings.Add(new Binding("Editvalue", dataSource, "kalciiobchi", true));
            tabSpinEdit41.DataBindings.Add(new Binding("Editvalue", dataSource, "iga", true));
            tabSpinEdit40.DataBindings.Add(new Binding("Editvalue", dataSource, "igm", true));
            tabSpinEdit39.DataBindings.Add(new Binding("Editvalue", dataSource, "igg", true));
            tabSpinEdit38.DataBindings.Add(new Binding("Editvalue", dataSource, "hba1c", true));
            tabSpinEdit37.DataBindings.Add(new Binding("Editvalue", dataSource, "ferritin", true));
            tabSpinEdit36.DataBindings.Add(new Binding("Editvalue", dataSource, "transferrin", true));
            richTextBox1.DataBindings.Add(new Binding("Text", dataSource, "prochee", true));
        }
        public List<LABORANT> Llabanaliz { get; set; }
        public string PZAGOLOVOK0 { get; set; }
        public void InitLookup()
        {
            lookUpEdit1.Properties.DataSource = Llabanaliz;
            lookUpEdit1.DataBindings.Add(new Binding("Editvalue", _dataSource1, "labanaliz", true));
        }

        private void FrmKrBioxim_KeyUp(object sender, KeyEventArgs e)
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
            _strText = Text;
            simpleButton1.Visible = false;
            simpleButton2.Visible = false;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
            simpleButton1.Visible = true;
            simpleButton2.Visible = true;
            Text = _strText;
        }
        private void OnDrawPage(object sender, PrintPageEventArgs e)
        {
            ClassGrafiksReport.PrintToGraphics(e.Graphics, e.MarginBounds, PZAGOLOVOK0, this,12);
        }
        //public void PrintToGraphics(Graphics graphics, Rectangle bounds)
        //{
        //    //this.Text = "";
        //    // const  string HELLO_WORLD = "HELLO WORLD ";  // this.Text;
        //    //HELLO_WORLD = PZAGOLOVOK0;  // this.Text;
        //    this.Text = "";
        //    var messageSize = graphics.MeasureString(PZAGOLOVOK0, Font);
        //    Bitmap bitmap0 = new Bitmap((int)messageSize.Width, (int)messageSize.Height);
        //    this.DrawToBitmap(bitmap0, new Rectangle(0, 0, bitmap0.Width, bitmap0.Height));//    Rectangle target0 = new Rectangle(0, 0, bitmap0.Width, bitmap0.Height);
        //    PointF p = new PointF(10, 5);
        //    //PointF p = new PointF((ClientSize.Width - messageSize.Width) / 2,
        //    // (ClientSize.Height - messageSize.Height) / 2);
        //    graphics.DrawString(PZAGOLOVOK0, Font, SystemBrushes.WindowText, p);
        //    //SettargetRazmer(bounds, target0, bitmap0);
        //    double xScale0 = (double)bitmap0.Width / bounds.Width;
        //    double yScale0 = (double)bitmap0.Height / bounds.Height;
        //    if (xScale0 < yScale0)
        //        target0.Width = (int)(xScale0 * target0.Width / yScale0);
        //    else
        //        target0.Height = (int)(yScale0 * target0.Height / xScale0);
        //    //==
        //    graphics.PageUnit = GraphicsUnit.Display;
        //    graphics.DrawImage(bitmap0, target0);
        //    //  this.Text = "";
        //    Bitmap bitmap = new Bitmap(this.Width, this.Height);
        //    this.DrawToBitmap(bitmap, new Rectangle(0, bitmap0.Height + 12, bitmap.Width, bitmap.Height));
        //    Rectangle target = new Rectangle(0, 0, bounds.Width, bounds.Height + 12);
        //    // SettargetRazmer(bounds, target, bitmap);
        //    double xScale = (double)bitmap.Width / bounds.Width;
        //    double yScale = (double)bitmap.Height / bounds.Height;
        //    if (xScale < yScale)
        //        target.Width = (int)(xScale * target.Width / yScale);
        //    else
        //        target.Height = (int)(yScale * target.Height / xScale);
        //    graphics.PageUnit = GraphicsUnit.Display;
        //    graphics.DrawImage(bitmap, target);
        
        //} 

       
/*
        private void spinEdit1_Validated(object sender, EventArgs e)
        {
            SpinEdit cb = sender as SpinEdit;
            if (cb != null)
            {
                switch (cb.Name)
                {
                    case "spinEdit1":    // билирубин общий
                        ValidatSpin(cb,0, 21);
                        break;
                    case "spinEdit2":     // билирубин прямой
                        ValidatSpin(cb,0, 4);
                        break;
                    case "spinEdit3":      // билирубин непрямой
                        ValidatSpin(cb, 0, 4);
                        break;
                    case "spinEdit4":     // АСАТ
                        ValidatSpin(cb, 0, 40);
                        break;
                    case "spinEdit5":     // АЛАТ
                        ValidatSpin(cb, 0, 41);
                        break;
                    case "spinEdit6":     // Мочевина  
                        ValidatSpin(cb, 0, 7);
                        break;
                    case "spinEdit7":     // Общий белок
                        ValidatSpin(cb, 0, 81);
                        break;
                    case "spinEdit8":     // Креатинин жен
                        ValidatSpin(cb, 0, 97);
                        break;
                     case "spinEdit11":     // Мочевая кислота  mohkisqen
                        ValidatSpin(cb, 0, 350);
                        break;
                    case "spinEdit12":     // ОЖСС
                        ValidatSpin(cb, 0, 72);
                        break;
                    case "spinEdit13":     // НЖСС
                        ValidatSpin(cb, 0, 43);
                        break;
                    case "spinEdit15":     // Коэфициент насыщения трансферином
                        ValidatSpin(cb, 0, 50);
                        break;
                    case "spinEdit16":     // СРБ количественный
                        ValidatSpin(cb, 0, 5);
                        break;
                    case "spinEdit17":     //  РФ количественный
                        ValidatSpin(cb, 0, 30);
                        break;
                    case "spinEdit18":     // АСЛ -О  количественный
                        ValidatSpin(cb, 0, 200);
                        break;
                    case "spinEdit19":     //  Глюкоза
                        ValidatSpin(cb, 0, 7);
                        break;
                    case "spinEdit20":     //  Тимоловая проба
                        ValidatSpin(cb, 0, 4);
                        break;
                    case "spinEdit22":     //  Щелочная фосфатаза :
                        ValidatSpin(cb, 0, 240);
                        break;
                    case "spinEdit23":     // Альфа-амилаза:
                        ValidatSpin(cb, 0, 86);
                        break;
                    case "spinEdit25":     //  Магний :
                        ValidatSpin(cb, 0, 200);
                        break;
                    case "spinEdit27":     //  Хлориды:
                        ValidatSpin(cb, 0, 105);
                        break;
                    case "spinEdit29":     // Креатинкиназа :
                        ValidatSpin(cb, 0, 2);
                        break;
                    case "spinEdit30":     // Фосфор неорганич.:
                        ValidatSpin(cb, 0, 2);
                        break;
                    case "spinEdit31":     // Калий:
                        ValidatSpin(cb, 0, 6);
                        break;
                    case "spinEdit32":     //  Натрий:
                        ValidatSpin(cb, 0, 145);
                        break;
                    case "spinEdit33":     //  Кальций ионизиров.:
                        ValidatSpin(cb, 0, 2);
                        break;
                    case "spinEdit34":     // Холестерин:
                        ValidatSpin(cb, 0, 7);
                        break;
                    case "spinEdit35":     // Триглицериды:
                        ValidatSpin(cb, 0, 3);
                        break;
                    case "spinEdit36":     // ХС ЛПВП(а-ХС):
                        ValidatSpin(cb, 0, 200);
                        break;
                    case "spinEdit37":     // ХС ЛПНП(в-ХС):
                        ValidatSpin(cb, 0, 200);
                        break;
                    case "spinEdit38":     //  ХС ЛПОНП(пре-в-ХС):
                        ValidatSpin(cb, 0, 200);
                        break;
                    case "spinEdit41":     //  Индекс атерогенности :
                        ValidatSpin(cb, 0, 3);
                        break;
                    case "spinEdit42":     // Индекс атерогенности У лиц с ИБС:
                        ValidatSpin(cb, 0, 200);
                        break;
                    case "spinEdit43":     // Опред. ГГТ в сыворотки:
                        ValidatSpin(cb, 0, 200);
                        break;
                }
   
            }
        }
    
        private void ValidatSpin(SpinEdit se,decimal d1, decimal d2)
        {
            if (ageLess(se,d1))
            {
                // Введенное значение меньше d1
                errorProvider1.SetError(se, "Введите значение, большее или равное" + d1);
            }
            else if (ageMore(se,d2))
            {
                /// Введенное значение больше d2
                errorProvider1.SetError(se, "Введите значение, меньшее или равное " + d2);
           }
            else
            {
                // Все правильно, удаляем сообщение с надписи
                errorProvider1.SetError(se, "");
            }
        }
        private bool ageLess(SpinEdit sp, decimal dc1)
        {
            //Возраст меньше 2
            return (sp.Value < dc1);
        }
        private bool ageMore(SpinEdit sp,decimal dc2)
        {
            //Возраст больше 25
            return (sp.Value > dc2);
        }
 */ 
    }
}