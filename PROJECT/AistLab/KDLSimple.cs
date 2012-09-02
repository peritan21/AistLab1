using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using AistLabData;
using CustomControlLib;

namespace AistLab
{
    public static class kdlsimple
    {

        public static bool kldsimple0()
        {
            bool bool123 = false;
            IntPtr logonToken = LogonUser();
            IntPtrConstructor(logonToken);
            WindowsIdentity identity = new WindowsIdentity(logonToken);
            IdentityReferenceCollection groups = identity.Groups;
            string strmochaencrypt = AccessorLab.ClassDecrypt.Encrypt(groups[0].ToString(), Resource1.StringLab);
            using (DataClassesLabDataContext db = new DataClassesLabDataContext())
            {
                int res = db.VUJVLAEMCHESOTKA1(strmochaencrypt);
                bool123 = (res==0);
            }
            return bool123;
        }
        private static void IntPtrConstructor(IntPtr logonToken)
        {
            WindowsIdentity identity = new WindowsIdentity(logonToken);
            //Console.WriteLine("Created a Windows identity object named " + identity.Name + ".");
        }
        private static IntPtr LogonUser()
        {
            IntPtr token = WindowsIdentity.GetCurrent().Token;
            //Console.WriteLine("Token number is: " + token.ToString());
            return token;
        }
    }
}
