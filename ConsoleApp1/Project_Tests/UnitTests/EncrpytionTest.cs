using System;
using System.Security.Cryptography;
using System.Diagnostics;
using Version1.domainLayer;
using System.IO;
using NUnit.Framework;

namespace Project_Tests.UnitTests
{
    public class EncrpytionTest
    {

        public static void Encrypted()
        {

            try
            {
                using (AesManaged aes = new AesManaged())
                {
                    byte[] encrypted = Hashing.GetHash("password");
                    Assert.True(encrypted != null && !encrypted.Equals(""));
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        
        public static void Decrypted()
        {
            try
            {
                using (AesManaged aes = new AesManaged())
                {
                    byte[] encrypted = Hashing.GetHash("password");
                    var str = System.Text.Encoding.Default.GetString(encrypted);
                    string decrypted = Hashing.GetHashString(str);
                    Assert.True(decrypted.Equals("password"));
                   
                }
            }
            catch
            {
                throw new Exception();
            }

        }

        /*
        private static string Decrypt(byte[] encrypted, byte[] key, byte[] iV)
        {
            string message = null;
            using (AesManaged aes = new AesManaged())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream(encrypted))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                            message = sr.ReadToEnd();
                    }
                }
            }
            return message;
        }

        private static byte[] Encrypt(string message, byte[] key, byte[] iV)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException($"'{nameof(message)}' cannot be null or empty.", nameof(message));
            }

            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (iV is null)
            {
                throw new ArgumentNullException(nameof(iV));
            }

            byte[] encrypted;
            using (AesManaged aes = new AesManaged())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(message);
                        encrypted = ms.ToArray();
                    }
                }

            }


            return encrypted;
        }*/

    }
}
