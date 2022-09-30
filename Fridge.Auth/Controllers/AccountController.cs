﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Fridge.Auth.Models;
using Fridge.Auth.Services;

namespace Fridge.Auth.Controllers
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
            try
            {
                return Ok(await _authService.SignIn(model));
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
                return Ok(await _authService.SignUp(model));
            }
            catch (InvalidOperationException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                return ValidationProblem(ModelState);
            }
        }
    }
}