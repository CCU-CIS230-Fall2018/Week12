using System;
using System.Reflection;
using Cryptography;
using System.Linq;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace CryptographyTests
{
    [TestClass]
    public class DigitalSigningTest
    {
        [TestMethod]
        public void DigitalSignTest()
        {
            RealPerson person1 = new RealPerson();
            person1.Password = "Friend";
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            binaryFormatter.Serialize(memoryStream, person1.Password);
            byte[] binaryArray = memoryStream.ToArray();
            SHA1 crypto = new SHA1CryptoServiceProvider();
            byte[] hash = crypto.ComputeHash(binaryArray);
            memoryStream.Write(hash, 0, hash.Length);
            memoryStream.Seek(0, SeekOrigin.Begin);
            string passwordReturned = (String)binaryFormatter.Deserialize(memoryStream);
            Assert.AreEqual(person1.Password, passwordReturned);
        }
    }
}
