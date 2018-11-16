using System;
using System.Reflection;
using Cryptography;
using System.Linq;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptographyTests
{
    [TestClass]
    public class HashTest
    {
        [TestMethod]
        public void HashTester()
        {
            RealPerson person1 = new RealPerson();
            var personHash = person1.GetHashCode();
            person1.Password = "Friend";
            var passwordHash = person1.Password.GetHashCode();
            Assert.IsTrue(Program.SafetyCheck(person1, personHash,passwordHash));
        }

        [TestMethod]
        public void HackerHashTester()
        {
            RealPerson person1 = new RealPerson();
            HackPerson person2 = new HackPerson();
            var fakeHash = person2.GetHashCode();
            person1.Password = "Friend";
            var passwordHash = person1.Password.GetHashCode();
            Assert.IsFalse(Program.SafetyCheck(person1, fakeHash, passwordHash));
        }
    }
}