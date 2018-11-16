using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CryptographyExercise;
using System.Security.Cryptography;
using System.Text;

namespace CryptoTests
{
    [TestClass]
    public class HashTests
    {
        [TestMethod]
        public void IsHashable()
        {
            string testMessage = "Too many secrets..";

            byte[] testMessagehashed = HashEncryptor.HashThatStuff(testMessage);
            byte[] data = Encoding.UTF8.GetBytes(testMessage);
            byte[] hashCode = SHA256.Create().ComputeHash(data);

            Assert.IsTrue(testMessagehashed.SequenceEqual(hashCode));
        }
    }
}
