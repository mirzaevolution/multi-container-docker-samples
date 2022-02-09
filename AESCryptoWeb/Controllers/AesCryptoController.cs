using AESCryptoWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AESCryptoWeb.Controllers
{
    public class AesCryptoController : Controller
    {
        private readonly HttpClient _httpClient;

        public AesCryptoController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Api");
        }

        [HttpPost]
        public async Task<IActionResult> Encrypt(EncryptRequest request)
        {
            bool success = true;
            string error = string.Empty;
            string result = string.Empty;

            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync<EncryptRequest>("/api/AESCrypto/Encrypt", request);

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        EncryptResponse encryptResponse = JsonConvert.DeserializeObject<EncryptResponse>(
                            await response.Content.ReadAsStringAsync()
                        );
                        result = encryptResponse.CipherTextBase64;
                    }
                    catch (Exception ex)
                    {
                        success = false;
                        error = ex.Message;
                    }
                }
            }
            return Json(new ApiOperationViewModel<string>
            {
                Error = error,
                IsSuccess = success,
                Result = result
            });
        }


        [HttpPost]
        public async Task<IActionResult> Decrypt(DecryptRequest request)
        {
            bool success = true;
            string error = string.Empty;
            string result = string.Empty;

            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync<DecryptRequest>("/api/AESCrypto/Decrypt", request);

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        DecryptResponse decryptResponse = JsonConvert.DeserializeObject<DecryptResponse>(
                            await response.Content.ReadAsStringAsync()
                        );
                        result = decryptResponse.PlainText;
                    }
                    catch (Exception ex)
                    {
                        success = false;
                        error = ex.Message;
                    }
                }
            }
            return Json(new ApiOperationViewModel<string>
            {
                Error = error,
                IsSuccess = success,
                Result = result
            });
        }
    }
}
