using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;



namespace Libreria.Seguridad
{
    
    public sealed class Rijndael
    {
        #region Key
        
        private static byte[] _objTempKey = null;

        private static byte[] GetKey()
        {
            if (_objTempKey == null)
            {
                _objTempKey = ASCIIEncoding.UTF8.GetBytes(System.Configuration.ConfigurationSettings.AppSettings["ProvadaK"].ToString());//'(RegistroWindows.Leer(RegistroWindows.OptionKey.Key));
            }
            return _objTempKey;
        }

        #endregion
        public static string Encriptar(string strEncriptar, string strIV)
        {
            ASCIIEncoding textConverter = new ASCIIEncoding();
            RijndaelManaged myRijndael = new RijndaelManaged();
            byte[] toEncrypt;
            byte[] key;
            byte[] IV;

            try
            {
                IV = textConverter.GetBytes((strIV + "GZd/SxJlLn|b2l79").Substring(0, 16));
                key = textConverter.GetBytes("qa54ivdmLCpuo5zgof1obtHy3cZqCyiO");

                ICryptoTransform encryptor = myRijndael.CreateEncryptor(key, IV);
                MemoryStream msEncrypt = new MemoryStream();
                CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

                toEncrypt = textConverter.GetBytes(strEncriptar);
                csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
                csEncrypt.FlushFinalBlock();

                return Convert.ToBase64String(msEncrypt.ToArray()).Replace("+", "|");
            }
            catch (Exception ee)
            {
                string aaa = ee.Message;
                return "";
            }

        }
        public static string Desencriptar(string strDesEncriptar, string strIV)
        {
            ASCIIEncoding textConverter = new ASCIIEncoding();
            RijndaelManaged myRijndael = new RijndaelManaged();
            byte[] encrypted;
            byte[] key;
            byte[] IV;

            try
            {
                IV = textConverter.GetBytes((strIV + "GZd/SxJlLn|b2l79").Substring(0, 16));
                key = textConverter.GetBytes("qa54ivdmLCpuo5zgof1obtHy3cZqCyiO");

                encrypted = Convert.FromBase64String(strDesEncriptar.Replace("|", "+"));

                ICryptoTransform decryptor = myRijndael.CreateDecryptor(key, IV);
                MemoryStream msDecrypt = new MemoryStream();
                CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write);

                csDecrypt.Write(encrypted, 0, encrypted.Length);
                csDecrypt.FlushFinalBlock();

                return textConverter.GetString(msDecrypt.ToArray());

            }
            catch
            {
                return "";
            }

        }

        #region Encriptar

        public static byte[] Encriptar(string strEncriptar)
        {
            return Encriptar(strEncriptar, GetKey());
        }


        public static byte[] Encriptar(string strEncriptar, byte[] bytKey)
        {
            ASCIIEncoding textConverter = new ASCIIEncoding();
            System.Security.Cryptography.Rijndael myRijndael = RijndaelManaged.Create();
            byte[] toEncrypt;
            byte[] temp = null;
            byte[] returnValue = null;

            try
            {
                myRijndael.Key = bytKey;
                toEncrypt = textConverter.GetBytes(strEncriptar);

                temp = myRijndael.CreateEncryptor().TransformFinalBlock(toEncrypt, 0, toEncrypt.Length);
                returnValue = new byte[myRijndael.IV.Length + temp.Length];
                Array.Copy(myRijndael.IV, 0, returnValue, 0, myRijndael.IV.Length);
                Array.Copy(temp, 0, returnValue, myRijndael.IV.Length, temp.Length);
            }
            catch (Exception ee)
            {
                string aaa = ee.Message;
            }

            return returnValue;

        }

        #endregion

        #region Desencriptar

        public static string Desencriptar(byte[] bytDesEncriptar)
        {
            return Desencriptar(bytDesEncriptar, GetKey());
        }

        public static string Desencriptar(byte[] bytDesEncriptar, byte[] bytKey)
        {
            ASCIIEncoding textConverter = new ASCIIEncoding();
            System.Security.Cryptography.Rijndael myRijndael = RijndaelManaged.Create();
            byte[] temp = null;
            byte[] toDecrypt = null;
            string returnValue = string.Empty;

            if (bytDesEncriptar == null)
                return string.Empty;

            try
            {
                temp = new byte[myRijndael.IV.Length];
                toDecrypt = new byte[bytDesEncriptar.Length - temp.Length];

                Array.Copy(bytDesEncriptar, temp, temp.Length);
                Array.Copy(bytDesEncriptar, temp.Length, toDecrypt, 0, bytDesEncriptar.Length - temp.Length);
                myRijndael.IV = temp;
                myRijndael.Key = bytKey;

                returnValue = textConverter.GetString(myRijndael.CreateDecryptor().TransformFinalBlock(toDecrypt, 0, toDecrypt.Length));

            }
            catch (Exception ee)
            {
                string aaa = ee.Message;
            }

            return returnValue;
        }

        #endregion
    }
}
