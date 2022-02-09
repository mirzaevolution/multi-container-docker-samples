using System.Security.Cryptography;
using System.Text;

namespace AESCryptoApi.Libs
{
    public class AESCrypto
    {
        private static byte[] _aesKey = new byte[32] { 244, 31, 135, 11, 235, 143, 40, 193, 138, 227, 253, 22, 94, 154, 118, 121, 24, 100, 10, 56, 139, 160, 216, 136, 51, 125, 113, 61, 249, 118, 162, 76 };
        private static byte[] _aesIV = new byte[16] { 89, 30, 232, 9, 237, 41, 151, 53, 174, 202, 2, 53, 103, 153, 116, 96 };
        public static Task<string> Encrypt(string plainText)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            using (Aes aes = Aes.Create())
            {
                aes.Key = _aesKey;
                aes.IV = _aesIV;
                using (ICryptoTransform cryptoTransform = aes.CreateEncryptor())
                {
                    byte[] encryptedBytes = cryptoTransform.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
                    return Task.FromResult(Convert.ToBase64String(encryptedBytes));
                }
            }
        }

        public static Task<string> Decrypt(string cipherTextBase64)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherTextBase64);
            using (Aes aes = Aes.Create())
            {
                aes.Key = _aesKey;
                aes.IV = _aesIV;
                using (ICryptoTransform cryptoTransform = aes.CreateDecryptor())
                {
                    byte[] plainBytes = cryptoTransform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                    return Task.FromResult(Encoding.UTF8.GetString(plainBytes));
                }
            }
        }
    }
}