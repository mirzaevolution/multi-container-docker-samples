using System.Security.Cryptography;
using System.Text;

namespace AESCryptoApi.Libs
{
    public class SHA256Hasher
    {
        public static Task<string> Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] resultBytes = sha256.ComputeHash(inputBytes);
                string resultBase64String = Convert.ToBase64String(resultBytes);
                return Task.FromResult(resultBase64String);
            }
        }
    }
}
