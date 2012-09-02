using System;
using System.Collections.Generic;
using DevExpress.Skins;

namespace AistLab.MainandLogin
{
    public partial class FormSkins : DevExpress.XtraEditors.XtraForm
    {
        private readonly List<Klasskin> _lskin = new List<Klasskin>();

        public FormSkins()
        {
            InitializeComponent();
        
        }
     public class Klasskin
        {
            public Byte KlasskinID
            { get; set; }
            public String KlasskinIDName
            { get; set; }
            public Klasskin(Byte klasskinID, string klasskinIDName)
            {
                KlasskinID = klasskinID;
                KlasskinIDName = klasskinIDName;
            }
        }
     public string Pskin
     { set; get; }
 
        private void FormSkinsLoad(object sender, EventArgs e)
        {
           byte i=0;
            foreach (SkinContainer cnt in SkinManager.Default.Skins)
            {
              
                   _lskin.Add(new Klasskin(i,cnt.SkinName));
                    i++;
            }
            lookUpEdit1.Properties.DataSource = _lskin;
        }

    
        private void SimpleButton1Click(object sender, EventArgs e)
        {
            Pskin = lookUpEdit1.Text;
        }
    }
}