using System.ComponentModel.DataAnnotations;

namespace AESCryptoApi.Models
{
    public class EncryptRequest
    {
        [Required]
        public string PlainText { get; set; }
    }
}
