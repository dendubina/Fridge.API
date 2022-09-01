using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Entities.DTO.User;
using Entities.Models;
using Entities.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AuthService
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtOptions _jwtOptions;

        public AuthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IOptions<JwtOptions> jwtOptions)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<UserProfile> SignIn(UserSignInDto userData)
        {
            var user = await _userManager.FindByNameAsync(userData.UserName);

            var result = await _signInManager.PasswordSignInAsync(user, userData.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new ArgumentException("Invalid user name or password", nameof(UserSignInDto));
            }

            return new UserProfile
            {
                Id = user.Id,
                UserName = user.UserName,
                JwtToken = new JwtSecurityTokenHandler().WriteToken(await GenerateJwtToken(user))
            };
        }

        public async Task<UserProfile> SignUp(UserSignUpDto user)
        {
            var result = await _userManager.CreateAsync(new IdentityUser(user.UserName), user.Password);

            if (!result.Succeeded)
            {
                var message = string.Join(Environment.NewLine, result.Errors.Select(x => x.Description));

                throw new ArgumentException(message, nameof(UserSignInDto));
            }

            var createdUser = await _userManager.FindByNameAsync(user.UserName);
            await _userManager.AddToRoleAsync(createdUser, "user");

            return new UserProfile
            {
                Id = createdUser.Id,
                UserName = createdUser.UserName,
                JwtToken = new JwtSecurityTokenHandler().WriteToken(await GenerateJwtToken(createdUser))
            };
        }

        public Task<bool> ValidateSignIn(UserSignInDto user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidateSignUp(UserSignUpDto user)
        {
            throw new NotImplementedException();
        }

        private async Task<JwtSecurityToken> GenerateJwtToken(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
            };

            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.JwtSecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_jwtOptions.JwtExpireDays);

            return new JwtSecurityToken(
                issuer: _jwtOptions.JwtIssuer,
                audience: _jwtOptions.JwtAudience,
                claims: claims,
                expires: expires,
                signingCredentials: credentials
            );
        }
    }
}
