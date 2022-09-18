using System.Threading.Tasks;
using Contracts.Interfaces;
using Entities.DTO.User;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Fridge.API.Extensions;

namespace Fridge.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IValidator<UserSignInDto> _signInValidator;
        private readonly IValidator<UserSignUpDto> _signUpValidator;

        public AccountController(IAuthService authService, IValidator<UserSignInDto> signInValidator, IValidator<UserSignUpDto> signUpValidator)
        {
            _authService = authService;
            _signInValidator = signInValidator;
            _signUpValidator = signUpValidator;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInDto user)
        {
            var result = await _signInValidator.ValidateAsync(user);

            if (!result.IsValid)
            {
               result.AddToModelState(ModelState);

               return ValidationProblem(ModelState);
            }

            var profile = await _authService.SignIn(user);

            return Ok(profile);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignUpDto user)
        {
            var result = await _signUpValidator.ValidateAsync(user);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);

                return ValidationProblem(ModelState);
            }

            var profile = await _authService.SignUp(user);

            return Ok(profile);
        }
    }
}
