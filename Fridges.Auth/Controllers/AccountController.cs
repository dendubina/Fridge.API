using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Fridges.Auth.Models;
using Fridges.Auth.Services;

namespace Fridges.Auth.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            UserProfile profile;

            try
            {
                profile = await _authService.SignIn(model);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return ValidationProblem(ModelState);
            }

            return Ok(profile);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            UserProfile profile;

            try
            {
                profile = await _authService.SignUp(model);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return ValidationProblem(ModelState);
            }

            return Ok(profile);
        }
    }
}
