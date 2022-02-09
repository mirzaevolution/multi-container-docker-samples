using System.ComponentModel.DataAnnotations;

namespace AESCryptoWeb.Models
{
    public class DecryptRequest
    {
        [Required]
        public string CipherTextBase64 { get; set; }
    }
}
