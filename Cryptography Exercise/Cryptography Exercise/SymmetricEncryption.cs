using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_Exercise
{
	public class SymmetricEncryption
	{
		public byte[] EncryptData(SymmetricAlgorithm symAlg,string plainData)
		{
			byte[] inBlock = UnicodeEncoding.Unicode.GetBytes(plainData);
			ICryptoTransform xfrm = symAlg.CreateEncryptor();
			byte[] outBlock = xfrm.TransformFinalBlock(inBlock, 0, inBlock.Length);
			Console.WriteLine(outBlock.ToString());
			return outBlock;
		}

		public byte[] DecryptData(byte[] cipherData, byte[] IV, byte[] key)
		{
			SymmetricAlgorithm cryptoAlgorith = SymmetricAlgorithm.Create();
			ICryptoTransform decryptor = cryptoAlgorith.CreateDecryptor(key, IV);
			byte[] plainText = decryptor.TransformFinalBlock(cipherData, 0, cipherData.Length);
			return plainText;
		}

	}
}
