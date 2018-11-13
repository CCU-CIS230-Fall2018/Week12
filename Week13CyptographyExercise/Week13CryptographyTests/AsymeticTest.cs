using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week13CyptographyExercise;

namespace Week13CryptographyTests
{
    [TestClass]
    public class AsymeticTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string message = "Attack at Dawn!";

            string decryptedMessage = Asymetric.Encrypt(message);

            Assert.AreEqual(message, decryptedMessage);
        }
    }
}
