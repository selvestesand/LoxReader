using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MM.MPT.Common
{
    public class Crypto
    {
        #region Settings

        private const string _ivHex = "A29B1E68EB8596B82C881F3E0F22E78B";
        private const string _keyHex = "01A17DE497A4044C5F348A2B2245D8F5C1085F61C365BDFCD9DA7174DE59FB52";

        private static readonly object Locker = new object();

        private static ICryptoTransform _crypto;
        private static ICryptoTransform _decrypto;

        public static byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x%2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }

        #endregion

        public static AesManaged GetNewAesManaged()
        {
            byte[] ivArr = HexStringToByteArray(_ivHex);
            byte[] keyArr = HexStringToByteArray(_keyHex);

            var aesManaged = new AesManaged
            {
                KeySize = 256,
                BlockSize = 128,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                IV = ivArr,
                Key = keyArr
            };

            return aesManaged;
        }

        public static string EncryptString(string clearText)
        {
            string hex = string.Empty;

            if (!string.IsNullOrEmpty(clearText))
            {
                lock (Locker)
                {
                    using (var aesManaged = GetNewAesManaged())
                    {
                        using (_crypto = aesManaged.CreateEncryptor())
                        {
                            byte[] plainText = Encoding.UTF8.GetBytes(clearText);
                            byte[] cipherText = _crypto.TransformFinalBlock(plainText, 0, plainText.Length);
                            hex = BitConverter.ToString(cipherText).Replace("-", string.Empty);
                        }
                    }
                }
            }

            return hex;
        }

        public static string DecryptString(string encryptedText)
        {
            var retVal = string.Empty;

            if (string.IsNullOrEmpty(encryptedText))
            {
                return retVal;
            }

            lock (Locker)
            {
                using (var aesManaged = GetNewAesManaged())
                {
                    using (_decrypto = aesManaged.CreateDecryptor())
                    {
                        byte[] encryptedBytesFromHex = HexStringToByteArray(encryptedText);
                        byte[] decryptedBytes = _decrypto.TransformFinalBlock(encryptedBytesFromHex, 0,
                            encryptedBytesFromHex.Length);
                        retVal = Encoding.UTF8.GetString(decryptedBytes);
                    }
                }
            }

            return retVal;
        }
    }
}