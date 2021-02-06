using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastuture
{
    public static class Encyptor
    {
        public static string Encrypt(string cleantext, string key)
        {
            PasswordDeriveBytes passwordivebyte = new PasswordDeriveBytes(Encoding.UTF8.GetBytes(key),
            new byte[] { 0x10, 0x65, 0x55, 0x44, 0x33, 0x25 });
            MemoryStream ms = new MemoryStream();
            Rijndael rijndeal = Rijndael.Create();
            rijndeal.Key = passwordivebyte.GetBytes(32);
            rijndeal.IV = passwordivebyte.GetBytes(16);
            CryptoStream cs = new CryptoStream(ms, rijndeal.CreateEncryptor(), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cs);
            sw.Write(cleantext);
            sw.Flush();
            sw.Close();
            byte[] end = ms.ToArray();
            return Convert.ToBase64String(end);
        }

        public static string Decrypt(string EncrptText, string key)
        {
            string text;
            try
            {
                PasswordDeriveBytes passwordivebyte = new PasswordDeriveBytes(Encoding.UTF8.GetBytes(key),
                new byte[] { 0x10, 0x65, 0x55, 0x44, 0x33, 0x25 });
                MemoryStream MS = new MemoryStream(Convert.FromBase64String(EncrptText));
                Rijndael rg = Rijndael.Create();
                rg.Key = passwordivebyte.GetBytes(32);
                rg.IV = passwordivebyte.GetBytes(16);
                CryptoStream CS = new CryptoStream(MS, rg.CreateDecryptor(), CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(CS);
                text = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {
                text = string.Empty;
            }
            return text;
        }
    }
}
