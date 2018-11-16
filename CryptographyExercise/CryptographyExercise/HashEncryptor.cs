using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CryptographyExercise
{
    public class HashEncryptor
    {
        public static byte[] HashThatStuff(string target)
        {
            string codeKey = target;
            byte[] data = Encoding.UTF8.GetBytes(codeKey);
            byte[] hashedTarget = SHA256.Create().ComputeHash(data);

            return hashedTarget;
        }
    }
}
