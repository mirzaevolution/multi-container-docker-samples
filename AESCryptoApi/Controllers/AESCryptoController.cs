using AESCryptoApi.Libs;
using AESCryptoApi.Models;
using Microsoft.AspNetCore.Mvc;
namespace AESCryptoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AESCryptoController : ControllerBase
    {

        [HttpPost(nameof(Encrypt))]
        [ProducesDefaultResponseType(typeof(EncryptResponse))]
        public async Task<IActionResult> Encrypt([FromBody] EncryptRequest request)
        {
            if (ModelState.IsValid)
            {

                string result = await AESCrypto.Encrypt(request.PlainText);
                return Ok(new EncryptResponse
                {
                    CipherTextBase64 = result
                });
            }
            return BadRequest(ModelState);
        }

        [HttpPost(nameof(Decrypt))]
        [ProducesDefaultResponseType(typeof(DecryptResponse))]
        public async Task<IActionResult> Decrypt([FromBody] DecryptRequest request)
        {
            if (ModelState.IsValid)
            {
                string result = await AESCrypto.Decrypt(request.CipherTextBase64);
                return Ok(new DecryptResponse
                {
                    PlainText = result
                });
            }
            return BadRequest(ModelState);
        }

    }
}
