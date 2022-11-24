using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FridgeManager.AuthMicroService.EF.Constants;
using FridgeManager.AuthMicroService.EF.Entities;
using FridgeManager.AuthMicroService.Extensions;
using FridgeManager.AuthMicroService.Models;
using FridgeManager.AuthMicroService.Models.Request;
using FridgeManager.AuthMicroService.Options;
using FridgeManager.AuthMicroService.Services.Interfaces;
using FridgeManager.Shared.Models;
using FridgeManager.Shared.Models.Constants;
using MassTransit;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FridgeManager.AuthMicroService.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IConfirmationMessageService _emailService;        
        private readonly JwtOptions _jwtOptions;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtOptions> jwtOptions, IEmailService emailService, IPublishEndpoint publishEndpoint)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _publishEndpoint = publishEndpoint;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<UserProfile> SignInAsync(SignInModel userData)
        {
            var user = await _userManager.FindByEmailAsync(userData.Email);

            if (user is null || user.Status == UserStatus.Blocked)
            {
                throw new InvalidOperationException("User not found");
            }

            var result = await _signInManager.PasswordSignInAsync(user, userData.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Invalid user name or password");
            }
            
            return await CreateProfile(user);
        }

        public async Task<UserProfile> SignUpAsync(SignUpModel userData)
        {
            var userToCreate = new ApplicationUser
            {
                UserName = userData.UserName,
                Email = userData.Email,
                Status = UserStatus.Active,
                MailingConfirmed = true,
            };

            var result = await _userManager.CreateAsync(userToCreate, userData.Password);

            if (!result.Succeeded)
            {
                var message = result.GetErrorMessage();

                throw new InvalidOperationException(message);
            }

            await _userManager.AddDefaultRolesAsync(userToCreate);

            var createdUser = await _userManager.FindByEmailAsync(userData.Email);

            await _publishEndpoint.Publish(CreateSharedUser(createdUser, ActionType.Create));
            await _emailService.SendEmailConfirmationMessageAsync(createdUser);

            return await CreateProfile(createdUser);
        }

        public async Task ConfirmEmailAsync(EmailConfirmModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId.ToString());

            if (user is null)
            {
                throw new InvalidOperationException("User not found");
            }

            var result = await _userManager.ConfirmEmailAsync(user, model.Token);

            if (!result.Succeeded)
            {
                var message = result.GetErrorMessage();

                throw new InvalidOperationException(message);
            }

            await _publishEndpoint.Publish(CreateSharedUser(user, ActionType.Update));
        }

        private async Task<UserProfile> CreateProfile(ApplicationUser user)
            => new UserProfile
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                JwtToken = new JwtSecurityTokenHandler().WriteToken(await GenerateJwtTokenAsync(user))
            };

        private SharedUser CreateSharedUser(ApplicationUser user, ActionType actionType)
            => new SharedUser
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                MailingConfirmed = user.MailingConfirmed,
                ActionType = actionType,
            };

        private async Task<JwtSecurityToken> GenerateJwtTokenAsync(ApplicationUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET", EnvironmentVariableTarget.Machine)));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.Add(_jwtOptions.TokenExpirationTime);

            return new JwtSecurityToken(
                claims: await GetClaimsAsync(user),
                expires: expires,
                signingCredentials: credentials
            );
        }

        private async Task<IEnumerable<Claim>> GetClaimsAsync(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new("preferred_username", user.Email),
                new("name", user.UserName),
                new("id", user.Id.ToString()),
            };

            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim("role", role)));

            return claims;
        }
    }
}
