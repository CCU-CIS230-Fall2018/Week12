using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CryptographyExercise;

namespace CryptoTests
{
    [TestClass]
    public class AsymmTests
    {
        [TestMethod]
        public void AsymmetricEncryptTest()
        {
            string testMessage = "Too many secrets..";

            string testMessageEncrypted = AsymmetricEncryptionator.EncryptTarget(testMessage);

            //Prove message is secured but still the original.
            Assert.AreEqual(testMessage, testMessageEncrypted);
        }
    }
}
