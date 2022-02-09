using System.ComponentModel.DataAnnotations;

namespace AESCryptoApi.Models
{
    public class DecryptRequest
    {
        [Required]
        public string CipherTextBase64 { get; set; }
    }
}
