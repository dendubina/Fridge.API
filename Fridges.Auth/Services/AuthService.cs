using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Fridges.Auth.EF.Entities;
using Fridges.Auth.Models;
using Fridges.Auth.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Fridges.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtOptions _jwtOptions;

        public AuthService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IOptions<JwtOptions> options)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtOptions = options.Value;
        }

        public async Task<UserProfile> SignIn(SignInModel userData)
        {
            var user = await _userManager.FindByNameAsync(userData.UserName);

            if (user is null)
            {
                throw new InvalidOperationException("Login failed: User not found");
            }

            var result = await _signInManager.PasswordSignInAsync(user, userData.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Login failed: Invalid email or password");
            }

            user.LastSignInDate = DateTime.Now;
            await _userManager.UpdateAsync(user);

            return CreateProfile(user);
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

            var createdUser = await _userManager.FindByNameAsync(userData.UserName);

            return CreateProfile(createdUser);
        }

        private JwtSecurityToken GenerateJwtToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Email, user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.Add(_jwtOptions.TokenExpirationTime);

            return new JwtSecurityToken(
                claims: claims,
                expires: expires,
                signingCredentials: credentials
            );
        }

        private UserProfile CreateProfile(ApplicationUser user)
        {
            return new UserProfile
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                LastSignInDate = user.LastSignInDate,
                SignUpDate = user.SignUpDate,
                JwtToken = new JwtSecurityTokenHandler().WriteToken(GenerateJwtToken(user))
            };
        }
    }
}
