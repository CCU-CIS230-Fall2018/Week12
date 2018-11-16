using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    public class Program
    {
        static void Main(string[] args)
        {
            RealPerson person1 = new RealPerson();
            var personHash = person1.GetHashCode();
            Console.WriteLine("The real person hashcode:" + personHash);
            HackPerson person2 = new HackPerson();
            var hackHash = person2.GetHashCode();
            Console.WriteLine("Fake person hashcode:" + hackHash);
            person1.Password = "Friend";
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            binaryFormatter.Serialize(memoryStream, person1.Password);
            byte[] binaryArray = memoryStream.ToArray();
            SHA1 crypto = new SHA1CryptoServiceProvider();
            byte[] hash = crypto.ComputeHash(binaryArray);
            string byteList = "";
            foreach (byte i in hash)
            {
                byteList += i.ToString(); 
            }
            Console.WriteLine("Password as a digital signature:" + byteList);
            memoryStream.Write(hash, 0, hash.Length);
            memoryStream.Seek(0, SeekOrigin.Begin);
            string passwordReturned = (String)binaryFormatter.Deserialize(memoryStream);
            Console.WriteLine("Returned back to original password: " + passwordReturned);
        }


        public static bool SafetyCheck(RealPerson person, int personHash, int passwordHash)
        {
            string correctPassword = "Friend";
            if (correctPassword.GetHashCode() == passwordHash.GetHashCode() && person.GetHashCode() == personHash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
