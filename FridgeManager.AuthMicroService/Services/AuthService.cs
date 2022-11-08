using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FridgeManager.AuthMicroService.EF.Constants;
using FridgeManager.AuthMicroService.EF.Entities;
using FridgeManager.AuthMicroService.Models;
using FridgeManager.AuthMicroService.Options;
using FridgeManager.AuthMicroService.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FridgeManager.AuthMicroService.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtOptions _jwtOptions;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtOptions> jwtOptions)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<UserProfile> SignIn(SignInModel userData)
        {
            var user = await _userManager.FindByNameAsync(userData.UserName);

            if (user is null || user.Status == UserStatuses.Blocked)
            {
                throw new InvalidOperationException("User not found");
            }

            var result = await _signInManager.PasswordSignInAsync(user, userData.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Invalid user name or password");
            }

            user.LastSignInDate = DateTime.Now;
            await _userManager.UpdateAsync(user);

            return await CreateProfile(user);
        }

        public async Task<UserProfile> SignUp(SignUpModel userData)
        {
            var userToCreate = new ApplicationUser
            {
                UserName = userData.UserName,
                Email = userData.Email,
                SignUpDate = DateTime.Now,
                LastSignInDate = DateTime.Now,
            };

            var result = await _userManager.CreateAsync(userToCreate, userData.Password);

            if (!result.Succeeded)
            {
                var message = string.Join(Environment.NewLine, result.Errors.Select(x => x.Description));

                throw new InvalidOperationException(message);
            }

            return await CreateProfile(await _userManager.FindByNameAsync(userData.UserName));
        }

        private async Task<UserProfile> CreateProfile(ApplicationUser user)
        {
            return new UserProfile
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                SignUpDate = user.SignUpDate,
                LastSignInDate = user.LastSignInDate,
                JwtToken = new JwtSecurityTokenHandler().WriteToken(await GenerateJwtToken(user))
            };
        }

        private async Task<JwtSecurityToken> GenerateJwtToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Email, user.Email),
            };

            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET", EnvironmentVariableTarget.Machine)));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.Add(_jwtOptions.TokenExpirationTime);

            return new JwtSecurityToken(
                claims: claims,
                expires: expires,
                signingCredentials: credentials
            );
        }
    }
}
