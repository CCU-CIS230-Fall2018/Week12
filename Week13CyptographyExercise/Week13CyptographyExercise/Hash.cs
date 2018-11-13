using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Week13CyptographyExercise
{
    public class Hash
    {
        public static byte[] HashData(string text)
        {
            byte[] data = Encoding.UTF8.GetBytes(text);
            byte[] hashData = SHA256.Create().ComputeHash(data);

            return hashData;
        }
    }
}
