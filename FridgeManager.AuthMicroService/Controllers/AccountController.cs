using System;
using System.Threading.Tasks;
using FridgeManager.AuthMicroService.Models;
using FridgeManager.AuthMicroService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FridgeManager.AuthMicroService.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
            => _authService = authService;

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            try
            {
                return Ok(await _authService.SignInAsync(model));
            }
            catch (InvalidOperationException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                return ValidationProblem(ModelState);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            try
            {
                return Ok(await _authService.SignUpAsync(model));
            }
            catch (InvalidOperationException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                return ValidationProblem(ModelState);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmEmail(EmailConfirmModel model)
        {
            try
            {
                await _authService.ConfirmEmailAsync(model);
                return Ok();
            }
            catch (InvalidOperationException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                return ValidationProblem(ModelState);
            }
        }
    }
}
