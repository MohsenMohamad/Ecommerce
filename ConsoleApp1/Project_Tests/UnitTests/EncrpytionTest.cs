using System;
using System.Security.Cryptography;
using System.Diagnostics;
using Version1.domainLayer;
using System.IO;
using System.Text;
using NUnit.Framework;
using Project_tests;

namespace Project_Tests.UnitTests
{
    public class EncrpytionTest : ATProject
    {
        
        [Test]
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
        
    }
}
