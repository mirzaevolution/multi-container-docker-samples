using Microsoft.AspNetCore.Mvc;
using Profile.Api.Services;
using System.Threading.Tasks;

namespace Profile.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilesController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;
        public UserProfilesController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _userProfileService.GetAll();
            return Ok(response);
        }
    }
}
