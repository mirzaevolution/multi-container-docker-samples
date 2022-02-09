using AESCryptoApi.Libs;
using AESCryptoApi.Models.Requests;
using AESCryptoApi.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AESCryptoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashController : ControllerBase
    {
        [HttpPost(nameof(SHA256))]
        [ProducesDefaultResponseType(typeof(HashResponse))]
        public async Task<IActionResult> SHA256([FromBody] HashRequest request)
        {
            if (ModelState.IsValid)
            {
                string result = await SHA256Hasher.Hash(request.Input);
                return Ok(new HashResponse
                {
                    HashedResultBase64 = result
                });
            }
            return BadRequest(ModelState);
        }
    }
}
