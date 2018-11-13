using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Week13CyptographyExercise
{
    public class Asymetric
    {
        public static string Encrypt (string textToEncrypt)
        {
            byte[] encryptedData;
            string decryptedData;
            string privateKey;
            string publicKey;

            using (var rsa = new RSACryptoServiceProvider())
            {
                publicKey = rsa.ToXmlString(false);
                privateKey = rsa.ToXmlString(true);
            }
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey);
                encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes(textToEncrypt), true);
            }
            using(var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKey);
                decryptedData = Encoding.UTF8.GetString(rsa.Decrypt(encryptedData, true));
            }
            return decryptedData;
        }
    }
}
