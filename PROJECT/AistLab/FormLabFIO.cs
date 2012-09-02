using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AistLab
{
    public partial class FormLabFIO : XtraForm
    {
        public FormLabFIO(BindingSource dataSource)
        {
            InitializeComponent();
            textEdit1.DataBindings.Add(new Binding("Text", dataSource, "fio1", true));
            textEdit2.DataBindings.Add(new Binding("Text", dataSource, "fio2", true));
            textEdit3.DataBindings.Add(new Binding("Text", dataSource, "fio3", true));
            textEdit4.DataBindings.Add(new Binding("Text", dataSource, "dlg", true));
        }
        private bool LenMore(TextEdit sp, int dc1)
        {
            //Возраст меньше 2
            return (sp.Text.Length > dc1);
        }
        private void TextBoxValidat(TextEdit sp,int lclen)
        {
            if (LenMore(sp, lclen))
            {
                // Введенное значение текста больше допустимой длины
                errorProvider1.SetError(sp, "Длина вводимого текста должна быть меньше или равна " + lclen);
            }
            else  errorProvider1.SetError(sp,"");
        }
        private void TextEdit1Validated(object sender, EventArgs e)
        {
            var cb = sender as TextEdit;
            if (cb != null)
            {
                switch (cb.Name)
                {
                    case "textEdit1":
                        TextBoxValidat(cb, 20);
                        break;
                    case "textEdit2":
                        TextBoxValidat(cb, 20);
                        break;
                    case "textEdit3":
                        TextBoxValidat(cb, 20);
                        break;
                    case "textEdit4":
                        TextBoxValidat(cb, 20);
                        break;
                }
            }
        
        }


    
    }
}