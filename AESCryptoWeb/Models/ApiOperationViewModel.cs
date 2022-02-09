namespace AESCryptoWeb.Models
{
    public class ApiOperationViewModel<T>
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
        public T Result { get; set; }
    }
}
