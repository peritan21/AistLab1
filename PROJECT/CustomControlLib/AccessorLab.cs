using System;
using System.Security.Principal;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using AistLabData;
using System.Diagnostics;
using System.Security.Cryptography;
using System.IO;

namespace CustomControlLib
{
   public class AccessorLab
    {
        #region Функции трансляции строк в   строгие типы
        public static DateTime Trans_Date(System.Data.DataRow row, string strfield)
        {
            DateTime out_date = DateTime.Parse("1900.01.01");
            if (row[strfield].ToString().Length > 0)
            {
                bool bdate_pol = DateTime.TryParse(row[strfield].ToString(), out out_date);
            }
            return out_date;
        }
        public static DateTime Trans_Datestr(string lcstr)
        {
            DateTime out_date = DateTime.Parse("1900.01.01");
            if (lcstr.Length > 0)
            {
                bool booldate_pol = DateTime.TryParse(lcstr, out out_date);
            }
            return out_date;
        }
        public static char Trans_Char(System.Data.DataRow row, string strfields)
        {
            char out_char = char.Parse("0");
            bool bool_int = char.TryParse(row[strfields].ToString(), out out_char);
            return out_char;
        }
        public static int Trans_Int(System.Data.DataRow row, string strfields)
        {
            int out_int = 0;
            if (row == null)
                return out_int;
            bool bool_int = int.TryParse(row[strfields].ToString(), out out_int);
            return out_int;
        }
        public static int Trans_Intstr(string lcstr)
        {
            int out_int = 0;
            bool bool_int = int.TryParse(lcstr, out out_int);
            return out_int;
        }
        public static short Trans_short(System.Data.DataRow row, string strfields)
        {
            short out_short = 0;
            bool bool_int = short.TryParse(row[strfields].ToString(), out out_short);
            return out_short;
        }
        public static short Trans_shortstr(string lcstr)
        {
            short out_shortstr = 0;
            bool bool_shortstr = short.TryParse(lcstr, out  out_shortstr);
            return out_shortstr;
        }
        public static byte Trans_byte(System.Data.DataRow row, string strfields)
        {
            byte out_byte = 0;
            bool bool_int = byte.TryParse(row[strfields].ToString(), out out_byte);
            return out_byte;
        }
        public static byte Trans_bytestr(string lcstr)
        {
            byte out_bytestr = 0;
            bool bool_bytestr = byte.TryParse(lcstr, out  out_bytestr);
            return out_bytestr;
        }
        public static decimal Trans_dec(System.Data.DataRow row, string strfields)
        {
            decimal out_dec = 0;
            bool bool_dec = decimal.TryParse(row[strfields].ToString(), out out_dec);
            return out_dec;
        }
        public static decimal Trans_decstr(string lcstr)
        {
            decimal out_decstr = 0;
            bool bool_bytestr = decimal.TryParse(lcstr, out  out_decstr);
            return out_decstr;
        }
        public static bool Trans_bool(System.Data.DataRow row, string strfield)
        {
            bool retbool = false;
            if (row[strfield].ToString().Length > 0)
            {
                bool boolretbool = bool.TryParse(row[strfield].ToString(), out retbool);
            }
            return retbool;
        }
        public static char Trans_char(System.Data.DataRow row, string strfield)
        {
            char retchar = char.Parse(" ");
            if (row[strfield].ToString().Length > 0)
            {
                bool boolretchar = char.TryParse(row[strfield].ToString(), out retchar);
            }
            return retchar;
        }


        #endregion  
      public  class ClassDecrypt
        {

            [DebuggerNonUserCodeAttribute]
            public static string Decrypt(string str, string keyCrypt)
            {
                string Result;
                try
                {
                    CryptoStream Cs = InternalDecrypt(Convert.FromBase64String(str), keyCrypt);
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
            public static CryptoStream InternalDecrypt(byte[] key, string value)
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
        public class OTCHETPERIODR_ROTD
        {

            //private int _analizotch_id;

            //private byte _Analiz_Level;

            //private int _Parent_ID;

            //private int _TABINDEX;

            //private int _Analiz_ID;

            //private string _NameStr;

            //private int _kolstac;

            private string _TABLNAME;

            public int analizotch_id {get; set;}
            public byte Analiz_Level {get; set;}
            public int Parent_ID {get; set;}
            public int TABINDEX {get; set;}
            public int Analiz_ID {get; set;}
            public string NameStr {get; set;}
            public int NpunktOtchet { get; set; }
            public string TABLNAME {get; set;}
            public string colamb { get; set; }
            public string _Col1  { get; set; }
            public string _Col5  { get; set; }
            public string _Col6  { get; set; }
            public string _Col7  { get; set; }
            public string _Col8  { get; set; }
            public string _Col9  { get; set; }
            public string _Col10{ get; set; }
            public string _Col11{ get; set; }
            public string _Col12{ get; set; }
            public string _Col13 { get; set; }
            public string _Col14 { get; set; }
            public string _Col15 { get; set; }
            public string _Col16 { get; set; }
            public string _Col17 { get; set; }
            public string _Col18 { get; set; }
            public string _Col19 { get; set; }
            public string _Col20 { get; set; }
            public string _Col21 { get; set; }
            public string _Col22 { get; set; }
            public string _Col23 { get; set; }
            public string _Col24 { get; set; }
            public string _Col25 { get; set; }
            public string _Col26 { get; set; }
            public string _Col27 { get; set; }
            public string _Col28 { get; set; }
            public string _Col29 { get; set; }
            public string _Col30 { get; set; }
            public string _Col31 { get; set; }
            public string _Col32 { get; set; }
            public string _Col45 { get; set; }
            public string _Col46 { get; set; }
            public string _Col47 { get; set; }
            public string _Col48 { get; set; }
            public string _Col49 { get; set; }
            public string _Col50 { get; set; }
            public string _Col51{ get; set; }
            public string _Col52{ get; set; }
            public string _Col53{ get; set; }
            public string _Col54{ get; set; }
            public string _Col55{ get; set; }
            public string _Col56{ get; set; }
            public string _Col57{ get; set; }
            public string _Col58{ get; set; }
            public string _Col59{ get; set; }
            public string _Col60 { get; set; }
            public string _Col61 { get; set; }
            public string _Col62 { get; set; }
            public string _Col63 { get; set; }
            public string _Col64 { get; set; }
            public string _Col65 { get; set; }
            public string _Col66 { get; set; }
            public string _Col67 { get; set; }
            public string _Col68 { get; set; }
            public string _Col69 { get; set; }
            public string _Col70 { get; set; }
            public string _Col71 { get; set; }
            public string _Col72 { get; set; }
            public string _Col73 { get; set; }
            public string _Col74 { get; set; }
            public string _Col75 { get; set; }
            public string _Col76 { get; set; }
            public string _Col77 { get; set; }
            public string _Col78 { get; set; }
            public string _Col79 { get; set; }
            public string _Col80 { get; set; }
            public string _Col81 { get; set; }
            public string _Col82 { get; set; }
            public string _Col83 { get; set; }
            public string ColItog { get; set; }
            public bool vib { get; set; }
            public OTCHETPERIODR_ROTD(
      int _analizotch_id
     , byte _Analiz_Level
     , int _Parent_ID
     , int _TABINDEX
     , int _Analiz_ID
     , string _NameStr
     , int _NpunktOtchet
     , string _TABLNAME
     , string _colamb
     , string Col1  
     , string Col5  
     , string Col6  
     , string Col7  
     , string Col8  
     , string Col9  
     , string Col10
     , string Col11
     , string Col12
     , string Col13
     , string Col14
     , string Col15
     , string Col16
     , string Col17
     , string Col18
     , string Col19
     , string Col20
     , string Col21
     , string Col22
     , string Col23
     , string Col24
     , string Col25
     , string Col26
     , string Col27
     , string Col28
     , string Col29
     , string Col30
     , string Col31
     , string Col32
     , string Col45
     , string Col46
     , string Col47
     , string Col48
     , string Col49
     , string Col50
     , string Col51
     , string Col52
     , string Col53
     , string Col54
     , string Col55
     , string Col56
     , string Col57
     , string Col58
     , string Col59
     , string Col60
     , string Col61
     , string Col62
     , string Col63
     , string Col64
     , string Col65
     , string Col66
     , string Col67
     , string Col68
     , string Col69
     , string Col70
     , string Col71
     , string Col72
     , string Col73
     , string Col74
     , string Col75
     , string Col76
     , string Col77
     , string Col78
     , string Col79
     , string Col80
     , string Col81
     , string Col82
     , string Col83
     , string _ColItog
     ,bool _vib
                )
            {
                analizotch_id = _analizotch_id;
                Analiz_Level = _Analiz_Level;
                Parent_ID = _Parent_ID;
                TABINDEX = _TABINDEX;
                Analiz_ID = _Analiz_ID;
                NameStr = _NameStr;
                NpunktOtchet = _NpunktOtchet;
                TABLNAME = _TABLNAME;
                colamb = _colamb;
                _Col1 = Col1;
                _Col5 = Col5;
                _Col6 = Col6;
                _Col7 = Col7;
                _Col8 = Col8;
                _Col9 = Col9;
                _Col10 = Col10;
                _Col11 = Col11;
                _Col12 = Col12;
                _Col13 = Col13;
                _Col14 = Col14;
                _Col15 = Col15;
                _Col16 = Col16;
                _Col17 = Col17;
                _Col18 = Col18;
                _Col19 = Col19;
                _Col20 = Col20;
                _Col21 = Col21;
                _Col22 = Col22;
                _Col23 = Col23;
                _Col24 = Col24;
                _Col25 = Col25;
                _Col26 = Col26;
                _Col27 = Col27;
                _Col28 = Col28;
                _Col29 = Col29;
                _Col30 = Col30;
                _Col31 = Col31;
                _Col32 = Col32;
                _Col45 = Col45;
                _Col46 = Col46;
                _Col47 = Col47;
                _Col48 = Col48;
                _Col49 = Col49;
                _Col50 = Col50;
                _Col51 = Col51;
                _Col52 = Col52;
                _Col53 = Col53;
                _Col54 = Col54;
                _Col55 = Col55;
                _Col56 = Col56;
                _Col57 = Col57;
                _Col58 = Col58;
                _Col59 = Col59;
                _Col60 = Col60;
                _Col61 = Col61;
                _Col62 = Col62;
                _Col63 = Col63;
                _Col64 = Col64;
                _Col65 = Col65;
                _Col66 = Col66;
                _Col67 = Col67;
                _Col68 = Col68;
                _Col69 = Col69;
                _Col70 = Col70;
                _Col71 = Col71;
                _Col72 = Col72;
                _Col73 = Col73;
                _Col74 = Col74;
                _Col75 = Col75;
                _Col76 = Col76;
                _Col77 = Col77;
                _Col78 = Col78;
                _Col79 = Col79;
                _Col80 = Col80;
                _Col81 = Col81;
                _Col82 = Col82;
                _Col83 = Col83;
               ColItog = _ColItog;
                vib = _vib;
            }
        }
       
         public class OTCHETPERIODR_R
        {

            private int _analizotch_id;

            private byte _Analiz_Level;

            private int _Parent_ID;

            private int _TABINDEX;

            private int _Analiz_ID;

            private string _NameStr;

            private int _kolstac;

            private string _TABLNAME;

            private string _colamb;

            private string _colstac;
            public int analizotch_id
            {
                get { return this._analizotch_id; }
                set { this._analizotch_id = value; }
            }
            public byte Analiz_Level
            {
                get { return this._Analiz_Level; }
                set { this._Analiz_Level = value; }
            }
            public int Parent_ID
            {
                get { return this._Parent_ID; }
                set { this._Parent_ID = value; }
            }

            public int TABINDEX
            {
                get { return this._TABINDEX; }
                set { this._TABINDEX = value; }
            }
            public int Analiz_ID
            {
                get { return this._Analiz_ID; }
                set { this._Analiz_ID = value; }
            }
            public string NameStr
            {
                get { return this._NameStr; }
                set { this._NameStr = value; }
            }


            public int NpunktOtchet { get; set; }

            public string Uslivie { get; set; }

            public int kolamb { get; set; }public int kolstac
            {
                get { return this._kolstac; }
                set { this._kolstac = value; }
            }

            public string TABLNAME
            {
                get { return this._TABLNAME; }
                set { this._TABLNAME = value; }

            }

            public string colamb
            {
                get { return this._colamb; }
                set { this._colamb = value; }
            }

            public string colstac
            {
                get { return this._colstac; }
                set { this._colstac = value; }

            }
            public OTCHETPERIODR_R(
      int _analizotch_id
     , byte _Analiz_Level
     , int _Parent_ID
     , int _TABINDEX
     , int _Analiz_ID
     , string _NameStr
     , int _NpunktOtchet
     , string _Uslivie
     , int _kolamb
     , int _kolstac
     , string _TABLNAME
     ,string _colamb
     , string _colstac)
            {
                analizotch_id = _analizotch_id;
                Analiz_Level = _Analiz_Level;
                Parent_ID = _Parent_ID;
                TABINDEX = _TABINDEX;
                Analiz_ID = _Analiz_ID;
                NameStr = _NameStr;
                NpunktOtchet = _NpunktOtchet;
                Uslivie = _Uslivie;
                kolamb = _kolamb;
                kolstac = _kolstac;
                TABLNAME = _TABLNAME;
                colamb = _colamb;
                colstac = _colstac;
            }
        }
        public class OTCHETPERIODR_RI
        {

            private int _analizotch_id;

            private byte _Analiz_Level;

            private int _Parent_ID;

            private int _TABINDEX;

            private int _Analiz_ID;

            private string _NameStr;

            private int _kolstac;

            private string _TABLNAME;

            private string _colamb;

            private string _colstac;
            private string _colitog;
            public int analizotch_id
            {
                get { return this._analizotch_id; }
                set { this._analizotch_id = value; }
            }
            public byte Analiz_Level
            {
                get { return this._Analiz_Level; }
                set { this._Analiz_Level = value; }
            }
            public int Parent_ID
            {
                get { return this._Parent_ID; }
                set { this._Parent_ID = value; }
            }

            public int TABINDEX
            {
                get { return this._TABINDEX; }
                set { this._TABINDEX = value; }
            }
            public int Analiz_ID
            {
                get { return this._Analiz_ID; }
                set { this._Analiz_ID = value; }
            }
            public string NameStr
            {
                get { return this._NameStr; }
                set { this._NameStr = value; }
            }


            public int NpunktOtchet { get; set; }

            public string Uslivie { get; set; }

            public int kolamb { get; set; }
            public int kolstac
            {
                get { return this._kolstac; }
                set { this._kolstac = value; }
            }

            public string TABLNAME
            {
                get { return this._TABLNAME; }
                set { this._TABLNAME = value; }

            }

            public string colamb
            {
                get { return this._colamb; }
                set { this._colamb = value; }
            }

            public string colstac
            {
                get { return this._colstac; }
                set { this._colstac = value; }

            }
                  public string colitog
            {
                get { return this._colitog; }
                set { this._colitog = value; }

            }
            public OTCHETPERIODR_RI(
      int _analizotch_id
     , byte _Analiz_Level
     , int _Parent_ID
     , int _TABINDEX
     , int _Analiz_ID
     , string _NameStr
     , int _NpunktOtchet
     , string _Uslivie
     , int _kolamb
     , int _kolstac
     , string _TABLNAME
     , string _colamb
     , string _colstac
     , string _colitog )
            {
                analizotch_id = _analizotch_id;
                Analiz_Level = _Analiz_Level;
                Parent_ID = _Parent_ID;
                TABINDEX = _TABINDEX;
                Analiz_ID = _Analiz_ID;
                NameStr = _NameStr;
                NpunktOtchet = _NpunktOtchet;
                Uslivie = _Uslivie;
                kolamb = _kolamb;
                kolstac = _kolstac;
                TABLNAME = _TABLNAME;
                colamb = _colamb;
                colstac = _colstac;
                colitog = _colitog;
            }
        }
        #region КЛАССЫ ДЛЯ Lookup
        public class Viborlaborant
        {
            public int Laborantid { get; set; }
            public string Fio { get; set; }
            public string Dlg { get; set; }
            public bool Vib { get; set; }
            public Viborlaborant(int Laborantid_, string Fio_, string Dlg_, bool Vib_)
            {
                Laborantid = Laborantid_;
                Fio = Fio_;
                Dlg = Dlg_;
                Vib = Vib_;
            }
        }
        public class Vrachlaborant
        {
            public int Laborantid { get; set; }
            public string Fio { get; set; }
            public byte Vib { get; set; }
            public Vrachlaborant(int Laborantid_, string Fio_,  byte Vib_)
            {
                Laborantid = Laborantid_;
                Fio = Fio_;
                Vib = Vib_;
            }
        }
        public class Viborotd
        {
            public int OtdId { get; set; }
            public string NameOtdsokr { get; set; }
            public string NameOtd { get; set; }
            public bool Vib { get; set; }
            public Viborotd(int otdId, string nameOtdsokr, string nameOtd, bool vib)
            {
                OtdId = otdId;
                NameOtdsokr = nameOtdsokr;
                NameOtd = nameOtd;
                Vib = vib;
            }
        }
        public class AnalizOtchet
        {
            public int noomer { get; set; }
            public System.String fio { get; set; }
            public int nomer { get; set; }
            public System.String name_otd { get; set; }
            public System.DateTime data { get; set; }
            public byte priznakstac { get; set; }
            public int tab_id { get; set; }
            public AnalizOtchet(int noomer_, string fio_,int nomer_, string name_otd_, DateTime data_, byte priznakstac_, int tab_id_)
            {
                noomer = noomer_;
                fio = fio_;
                nomer = nomer_;
                name_otd = name_otd_;
                data = data_;
                priznakstac = priznakstac_;
                tab_id = tab_id_;
            }
        }
        public class AnalizOtchetFMVMP
        {
            public int noomer { get; set; }
            public String fio { get; set; }
            public String lfio { get; set; }
            public String name_otdsokr { get; set; }
            public DateTime data { get; set; }
            public string analzname { get; set; }
            public string namefield { get; set; }
            public AnalizOtchetFMVMP(int noomer_, string fio_, string lfio_, string name_otdsokr_, DateTime data_, string analzname_, string namefield_)
            {
                noomer = noomer_;
                fio = fio_;
                lfio = lfio_;
                name_otdsokr = name_otdsokr_;
                data = data_;
                analzname = analzname_;
                namefield = namefield_;
            }
        }
        public class VUJVRIF
        {
            public System.String NAME { get; set; }
            public System.String name_otdsokr { get; set; }
            public int KOL { get; set; }
            public int KOLPOL { get; set; }
            public VUJVRIF(string NAME_, string name_otdsokr_, int KOL_, int KOLPOL_)
            {
                NAME = NAME_;
                name_otdsokr = name_otdsokr_;
                KOL = KOL_;
                KOLPOL = KOLPOL_;
            }
        }
        public class OtchetUslkol
        {
            public int analotchetusl_id { get; set; }
            public System.String NAME { get; set; }
            public System.String TABLNAME { get; set; }
            public System.String TABL_ID { get; set; }
            public int kolstac { get; set; }
            public int kolamb { get; set; }
            public OtchetUslkol(int analotchetusl_id_, string NAME_, string TABLNAME_, string   TABL_ID_, int  kolstac_, int kolamb_)
            {
                analotchetusl_id = analotchetusl_id_;
                NAME = NAME_;
                TABLNAME=TABLNAME_;
               TABL_ID=TABL_ID_;
                kolstac = kolstac_;
                kolamb = kolamb_;
            }
        }
        public class AnalizOtchetUsl
        {
            public int analotchetusl_id { get; set; }
            public int analizotch_id { get; set; }
            public int Analiz_ID { get; set; }
            public System.String NAME { get; set; }
            public System.String Uslivie { get; set; }

            public AnalizOtchetUsl(int analotchetusl_id_, int analizotch_id_, int Analiz_ID_, string NAME_, string Uslivie_)
            {
                analotchetusl_id = analotchetusl_id_;
                analizotch_id = analizotch_id_;
                Analiz_ID = Analiz_ID_;
                NAME = NAME_;
                Uslivie = Uslivie_;
            }
        }
        public class FullOtchet
        {
            public int analiz_id { get; set; }
            public System.String fio { get; set; }
            public System.String name_otd { get; set; }
            public System.DateTime data { get; set; }
            public byte priznakstac { get; set; }
            public int tab_id { get; set; }
            public System.String name { get; set; }
            public System.String analizst { get; set; }
            public System.String nametable { get; set; }
            public FullOtchet(int analiz_id_,string fio_, string name_otd_, DateTime data_, byte priznakstac_,
                int tab_id_, string name_, string analizst_, string nametable_)
            {
                analiz_id = analiz_id_;
                fio = fio_;
                name_otd = name_otd_;
                data = data_;
                priznakstac = priznakstac_;
                tab_id = tab_id_;
                name = name_;
                analizst = analizst_;
                nametable = nametable_;
            }
        }
        public class AnalizRod
        {
            public System.String n_history
            { get; set; }
            public System.String fio
            { get; set; }
            public System.DateTime data
            { get; set; }
            public AnalizRod(string n_history_, string fio_,DateTime data_)
            {
                n_history = n_history_;
                fio = fio_;
                data = data_;
            }
        }
        public class ProfilOTD
        {
            public Byte profotd_id
            { get; set; }
            public System.String profotd_Name
            { get; set; }
            public ProfilOTD(Byte profotd_id_, string profotd_Name_)
            {
                profotd_id = profotd_id_;
                profotd_Name = profotd_Name_;
            }
        }
        public class Klasskin
        {
            public Byte klasskin_id
            { get; set; }
            public System.String klasskin_id_Name
            { get; set; }
            public Klasskin(Byte klasskin_id_, string klasskin_id_Name_)
            {
                klasskin_id = klasskin_id_;
                klasskin_id_Name = klasskin_id_Name_;
            }
        }
        public class Gemoliz
        {
            public Byte gemoliz
            { get; set; }
            public System.String gemoliz_Name
            { get; set; }
            public Gemoliz(Byte gemoliz_, string gemoliz_Name_)
            {
                gemoliz = gemoliz_;
                gemoliz_Name = gemoliz_Name_;
            }
        }
        public class Prozrahnost
        {
            public Byte prozrahnost
            { get; set; }
            public System.String prozrahnost_Name
            { get; set; }
            public Prozrahnost(Byte prozrahnost_, string prozrahnost_Name_)
            {
                prozrahnost = prozrahnost_;
                prozrahnost_Name = prozrahnost_Name_;
            }
        }
        public class Cvet
        {
            public Byte cvet
            { get; set; }
            public System.String cvet_Name
            { get; set; }
            public Cvet(Byte cvet_, string cvet_Name_)
            {
                cvet = cvet_;
                cvet_Name = cvet_Name_;
            }
        }
        public class Pandi
        {
            public Byte pandi
            { get; set; }
            public System.String pandi_Name
            { get; set; }
            public Pandi(Byte pandi_, string pandi_Name_)
            {
                pandi = pandi_;
                pandi_Name = pandi_Name_;
            }
        }
        public class Likvorogramma
        {
            public Byte likvorogramma
            { get; set; }
            public System.String likvorogramma_Name
            { get; set; }
            public Likvorogramma(Byte likvorogramma_, string likvorogramma_Name_)
            {
                likvorogramma = likvorogramma_;
                likvorogramma_Name = likvorogramma_Name_;
            }
        }
        public class Tkscs
        {
            public Byte tkscs
            { get; set; }
            public System.String tkscs_Name
            { get; set; }
            public Tkscs(Byte tkscs_, string tkscs_Name_)
            {
                tkscs = tkscs_;
                tkscs_Name = tkscs_Name_;
            }
        }
        public class Rpr
        {
            public Byte rpr
            { get; set; }
            public System.String rpr_Name
            { get; set; }
            public Rpr(Byte rpr_, string rpr_Name_)
            {
                rpr = rpr_;
                rpr_Name = rpr_Name_;
            }
        }
        public class Gruppakrovi
        {
            public Byte gr_krovi
            { get; set; }
            public System.String Name_krov
            { get; set; }
            public Gruppakrovi(Byte gr_krovi_, string Name_krov_)
            {
                gr_krovi = gr_krovi_;
                Name_krov = Name_krov_;
            }
        }
        public class Rezusfaktor
        {
            public Byte rezus
            { get; set; }
            public System.String Name_rezus
            { get; set; }
            public Rezusfaktor(Byte rezus_, string Name_rezus_)
            {
                rezus = rezus_;
                Name_rezus = Name_rezus_;
            }
        }
        public class Antitela
        {
            public Byte antitela
            { get; set; }
            public System.String Name_antitela
            { get; set; }
            public Antitela(Byte antitela_, string Name_antitela_)
            {
                antitela = antitela_;
                Name_antitela = Name_antitela_;
            }
        }
#endregion

    }
}
