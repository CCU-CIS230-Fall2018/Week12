using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_Exercise
{
	class Program
	{
		static void Main(string[] args)
		{
			AesCryptoServiceProvider aesCSP = new AesCryptoServiceProvider();
			SymmetricEncryption Encryptor = new SymmetricEncryption();
			aesCSP.GenerateKey();
			aesCSP.GenerateIV();

			byte[] cipher = Encryptor.EncryptData(aesCSP, "Hello mom");
			string someString = Encoding.ASCII.GetString(cipher);
			Console.WriteLine(someString);

		}
	}
}
