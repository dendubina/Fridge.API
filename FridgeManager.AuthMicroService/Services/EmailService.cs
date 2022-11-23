using System;
using System.Text;
using FridgeManager.AuthMicroService.Services.Interfaces;
using System.Threading.Tasks;
using FridgeManager.AuthMicroService.EF.Entities;
using FridgeManager.AuthMicroService.Options;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MimeKit;

namespace FridgeManager.AuthMicroService.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailOptions _options;
        private readonly ISmtpClient _client;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmailService(IOptions<EmailOptions> options, ISmtpClient client, UserManager<ApplicationUser> userManager)
        {
            _options = options.Value;
            _client = client;
            _userManager = userManager;
        }

        public async Task SendEmailConfirmationMessageAsync(ApplicationUser user)
        {

            await _client.ConnectAsync(_options.Host, _options.Port);
            await _client.AuthenticateAsync(_options.UserName, _options.Password);

            var confirmationUrl = $"{_options.RedirectBaseAddress}/?userId={user.Id}&emailToken={await _userManager.GenerateEmailConfirmationTokenAsync(user)}";

            var message = new MimeMessage
            {
                From = { new MailboxAddress(Encoding.UTF8, _options.FromName, _options.UserName) },
                To = { new MailboxAddress(Encoding.UTF8, user.UserName, user.Email) },
                Subject = "Email confirmation",
                Body = new BodyBuilder { HtmlBody = $"Please, confirm email following the link: <a href='{confirmationUrl}'>{confirmationUrl}</a>" }.ToMessageBody()
            };

            await _client.SendAsync(message);
            await _client.DisconnectAsync(quit: true);
        }
    }
}
