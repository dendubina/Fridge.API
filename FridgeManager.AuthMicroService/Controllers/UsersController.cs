using System.Threading.Tasks;
using FridgeManager.AuthMicroService.EF.Constants;
using FridgeManager.AuthMicroService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FridgeManager.AuthMicroService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = nameof(RoleNames.Admin))]
        [HttpGet]
        public async Task<IActionResult> Test()
        {
            return Ok("something");
        }
    }
}
