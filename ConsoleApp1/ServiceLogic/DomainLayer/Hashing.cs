using System.Security.Cryptography;
using System.Text;

namespace ServiceLogic.domainLayer
{
    public static class Hashing
    {
        /// <summary>
        /// Compute hash as bytes from input string
        /// </summary>
        /// <param name="inputString">string to hash</param>
        /// <returns>hashed string represented as byte array</returns>
        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        /// <summary>
        ///
        /// Convert string to hash string
        ///A sha256 is 256 bits long -- as its name indicates. 
        ///If you are using an hexadecimal representation, each digit codes for 4 bits ;
        ///so you need 64 digits to represent 256 bits -- so, you need a varchar(64) ,
        ///or a char(64) , as the length is always the same, not varying at all.
        /// </summary>
        /// <param name="inputString">the string to hash</param>
        /// <returns>64 long string representation of the hashed input string</returns>
        public static string GetHashString(string inputString)
        {
            var sb = new StringBuilder();
            foreach (var b in GetHash(inputString))
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }
    }
}