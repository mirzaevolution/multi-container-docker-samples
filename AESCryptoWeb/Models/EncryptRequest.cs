using System.ComponentModel.DataAnnotations;

namespace AESCryptoWeb.Models
{
    public class EncryptRequest
    {
        [Required]
        public string PlainText { get; set; }
    }
}
