using System;
using System.Security.Cryptography;
using System.Text;

namespace CryptographyExercise
{
    public class AsymmetricEncryptionator
    {

        public static string EncryptTarget(string target)
        {
            string encryptionString = target;
            string publicKey;
            string privateKey;
            byte[] encryptedTarget;
            string decryptedTarget;

            // Innitiate keys.
            using (var csp = new RSACryptoServiceProvider())
            {
                privateKey = csp.ToXmlString(true);
                publicKey = csp.ToXmlString(false);
            }

            // Encryption target with public key.
            using (var csp = new RSACryptoServiceProvider())
            {
                csp.FromXmlString(publicKey);

                encryptedTarget = csp.Encrypt(Encoding.UTF8.GetBytes(encryptionString), true);
            }

            // Decrypts target using the private key.
            using (var csp = new RSACryptoServiceProvider())
            {
                csp.FromXmlString(privateKey);

                decryptedTarget = Encoding.UTF8.GetString(csp.Decrypt(encryptedTarget, true));
            }

            return decryptedTarget;
        }
    }
}
