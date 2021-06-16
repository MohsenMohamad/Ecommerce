using System;
using System.Security.Cryptography;
using NUnit.Framework;
using Version1.domainLayer;

namespace TestProject.UnitTests
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
