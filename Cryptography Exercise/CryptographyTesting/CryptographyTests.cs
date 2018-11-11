using System;
using System.Security.Cryptography;
using System.Text;
using Cryptography_Exercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptographyTesting
{
	[TestClass]
	public class CryptographyTests
	{
		[TestMethod]
		public void SymmetricTest()
		{
			AesCryptoServiceProvider aesCSP = new AesCryptoServiceProvider();
			SymmetricEncryption Encryptor = new SymmetricEncryption();
			aesCSP.GenerateKey();
			aesCSP.GenerateIV();

			string before = "Disareal";
			byte[] cipher = Encryptor.EncryptData(aesCSP, before);
			string after = Encryptor.DecryptData(aesCSP, cipher);
			Assert.AreEqual(before, after);
		}
		[TestMethod]
		public void HashTest()
		{
			// What google says the SHA256 hash value of "Hello World" is
			string googleCode = "a591a6d40bf420404a011733cfb7b190d62c65bf0bcda32b57b277d9ad9f146e";


			string hashText = "Hello World";
			using (SHA256 hash = SHA256.Create())
			{
				Hashing hasher = new Hashing();
				string hashCode = hasher.GetHash(hash, hashText);
				Assert.AreEqual(googleCode, hashCode);
			}
			
		}
	}

}