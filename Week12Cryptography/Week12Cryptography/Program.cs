using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Linq;
using System.IO;

namespace Week12Cryptography
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Runs the hash code.
            string input = "This is just a test.";
            returnHashValue(input);

            // Runs the assymmetric encryption code.
            string plainText = "This is another test.";
            assymetricEncryption(plainText);
            

            Console.ReadKey();
        }

        public static string returnHashValue(string input)
        {
            HashAlgorithm test = SHA256.Create();
            byte[] testData = test.ComputeHash(Encoding.Default.GetBytes(input));
            string testDataToString = Convert.ToBase64String(testData);
            Console.WriteLine(testDataToString);

            return testDataToString;
        }

        // Ignore below attempt .
        /*
        public static byte[] symmetricEncryption(byte[] plainText, byte[] IV, byte[] key)
        {
            SymmetricAlgorithm testCryptography = SymmetricAlgorithm.Create();
            ICryptoTransform encrypt = testCryptography.CreateEncryptor(key, IV);
            byte[] cipherText = encrypt.TransformFinalBlock(plainText, 0, plainText.Length);

            return cipherText;
        }

        public static byte[] symmetricDecryption(byte[] cipherData, byte[] IV, byte[] key)
        {
            SymmetricAlgorithm testCryptography = SymmetricAlgorithm.Create();
            ICryptoTransform decrypt = testCryptography.CreateDecryptor(key, IV);
            byte[] plainText = decrypt.TransformFinalBlock(cipherData, 0, cipherData.Length);

            return plainText;
        }
        */

        public static byte[] symmetricEncryption(string plainData, ICryptoTransform encryptor)
        {
            using (var myStream = new MemoryStream())
            using (var cryptography = new CryptoStream(myStream, encryptor, CryptoStreamMode.Write))
            {
                using (var myWriter = new StreamWriter(cryptography))
                {
                    myWriter.Write(plainData);
                }

                return myStream.ToArray();
            }
                
        }

        public static string symmetricDecryption(byte[] sourceData, ICryptoTransform decryptor)
        {
            using (var myStream = new MemoryStream(sourceData))
            using (var cryptography = new CryptoStream(myStream, decryptor, CryptoStreamMode.Read))
            using (var myReader = new StreamReader(cryptography))
            {
                return myReader.ReadToEnd();
            }
        }

        // Ignore below attempt.
        public static string assymetricEncryption(string plainData)
        {
            byte[] encryptedData;
            string decryptedData;
            string myKey ="!";
            string publicKey = "2";

            using (var cryptography = new RSACryptoServiceProvider())
            {
                publicKey = cryptography.ToString();
                myKey = cryptography.ToString();
            }

            using (var cryptography = new RSACryptoServiceProvider())
            {
                // cryptography.FromXmlString(publicKey); .
                encryptedData = cryptography.Encrypt(Encoding.UTF8.GetBytes(plainData), true);
            }
            using (var cryptography = new RSACryptoServiceProvider())
            {
                // cryptography.FromXmlString(myKey); .
                decryptedData = Encoding.UTF8.GetString(cryptography.Decrypt(encryptedData, true));
            }
            Console.WriteLine(encryptedData);
            return decryptedData;
        }
    }
}