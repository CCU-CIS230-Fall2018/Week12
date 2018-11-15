using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week12Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace Week12Cryptography
{
    [TestClass]
    public class Week12CryptographyTests
    {
        [TestMethod]
        public void HashTest()
        {
            string realInput = "This is the real string.";
            string testInput = "This is the real string.";

            string realInputHash = Program.returnHashValue(realInput);
            string testInputHash = Program.returnHashValue(testInput);

            Assert.AreEqual(testInputHash, realInputHash);
        }

        [TestMethod]
        public void SymmetricEncryptionTest()
        {
            string myPlainData = "Let's hope this works";
            byte[] myKey;
            byte[] IV;
            ICryptoTransform encryptor, decryptor;

            using (var acsp = new AesCryptoServiceProvider())
            {
                myKey = acsp.Key;
                IV = acsp.IV;
                encryptor = acsp.CreateEncryptor(myKey, IV);
                decryptor = acsp.CreateDecryptor(myKey, IV);
            }

            byte[] securedData = Program.symmetricEncryption(myPlainData, encryptor);
            string plainData = Program.symmetricDecryption(securedData, decryptor);

            Assert.AreEqual(plainData, myPlainData);
        }  
       
    }
}
