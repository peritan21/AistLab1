using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AistLab.MainandLogin
{
    public partial class FormOTDNAME : XtraForm
    {
        public FormOTDNAME(BindingSource dataSource)
        {
            InitializeComponent();
            textEdit4.DataBindings.Add(new Binding("Text", dataSource, "name_otdsokr", true));
            textEdit1.DataBindings.Add(new Binding("Text", dataSource, "name_otd", true));
            textEdit2.DataBindings.Add(new Binding("Text", dataSource, "kod_otd", true));
            imageComboBoxEdit7.DataBindings.Add(new Binding("SelectedIndex", dataSource, "priznakstac", true));
            imageComboBoxEdit1.DataBindings.Add(new Binding("SelectedIndex", dataSource, "xozraschet", true));
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
                        TextBoxValidat(cb, 250);
                        break;
                    case "textEdit4":
                        TextBoxValidat(cb, 15);
                        break;
                    }
            }
        
        }
    }
}