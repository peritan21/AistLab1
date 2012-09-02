using System;
using System.Linq;
using System.Windows.Forms;
using AistLab.MainandLogin;
using AistLabData;
using CustomControlLib;

namespace AistLab
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static readonly DataClassesLabDataContext Dt = new DataClassesLabDataContext();static string _hidid = "";
        [STAThread]
        static void Main()
        {
            //if (kdlsimple.kldsimple0())
            //{
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
                var lf = new LoginForm {Lakusherrmm = Dt.GetTable<LABORANT>().ToList<LABORANT>()};
                lf.InitLookup();
            if (lf.ShowDialog() == DialogResult.OK)
            {
                var fm = new MainXtraForm();
                _hidid = lf.StrLoginUservmeds;
                if (fm.Registracij(int.Parse(_hidid), lf.StrLoginPass)) Application.Run(fm);
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
            //}
        }
    
    }
}
