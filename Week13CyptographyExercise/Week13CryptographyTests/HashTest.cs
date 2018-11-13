using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week13CyptographyExercise;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace Week13CryptographyTests
{
    [TestClass]
    public class HashTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string text = "Attack at dawn";

            byte[] hashData = Hash.HashData(text);

            byte[] testBites = Encoding.UTF8.GetBytes(text);
            byte[] testHash = SHA256.Create().ComputeHash(testBites);

            Assert.IsTrue(hashData.SequenceEqual(testHash));
        }
    }
}
