﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Security.Cryptography;
using System.IO;

namespace AistLab
{
    class ClassDecrypt1
    {
      
        [DebuggerNonUserCodeAttribute]
        public static string Decrypt1(string str, string keyCrypt)
        {
            string Result;
            try
            {
                CryptoStream Cs = InternalDecrypt1(Convert.FromBase64String(str), keyCrypt);
                StreamReader Sr = new StreamReader(Cs);

                Result = Sr.ReadToEnd();

                Cs.Close();
                Cs.Dispose();

                Sr.Close();
                Sr.Dispose();
            }
            catch (CryptographicException)
            {
                return null;
            }

            return Result;
        }
        public static CryptoStream InternalDecrypt1(byte[] key, string value)
        {
            SymmetricAlgorithm sa = Rijndael.Create();
            ICryptoTransform ct = sa.CreateDecryptor((new PasswordDeriveBytes(value, null)).GetBytes(16), new byte[16]);

            MemoryStream ms = new MemoryStream(key);
            return new CryptoStream(ms, ct, CryptoStreamMode.Read);
        }
        public static string Encrypt(string str, string keyCrypt)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(str), keyCrypt));
        }
        private static byte[] Encrypt(byte[] key, string value)
        {
            SymmetricAlgorithm Sa = Rijndael.Create();
            ICryptoTransform Ct = Sa.CreateEncryptor((new PasswordDeriveBytes(value, null)).GetBytes(16), new byte[16]);

            MemoryStream Ms = new MemoryStream();
            CryptoStream Cs = new CryptoStream(Ms, Ct, CryptoStreamMode.Write);

            Cs.Write(key, 0, key.Length);
            Cs.FlushFinalBlock();

            byte[] Result = Ms.ToArray();

            Ms.Close();
            Ms.Dispose();

            Cs.Close();
            Cs.Dispose();

            Ct.Dispose();

            return Result;
        }
    }
}
