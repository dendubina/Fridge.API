using System;
using System.Text;
using FridgeManager.AuthMicroService.Services.Interfaces;
using System.Threading.Tasks;
using FridgeManager.AuthMicroService.Options;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace FridgeManager.AuthMicroService.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailOptions _options;
        private readonly ISmtpClient _client;

        public EmailService(IOptions<EmailOptions> options, ISmtpClient client)
        {
            _options = options.Value;
            _client = client;
        }

        public async Task SendConfirmationEmailAsync(string receiverEmail, Guid userId, string token)
        {

            await _client.ConnectAsync(_options.Host, _options.Port);
            await _client.AuthenticateAsync(_options.UserName, _options.Password);

            var confirmationUrl = $"{_options.RedirectBaseAddress}/?userId={userId}&emailToken={token}";

            var message = new MimeMessage
            {
                From = { new MailboxAddress(Encoding.UTF8, _options.FromName, _options.UserName) },
                To = { new MailboxAddress(Encoding.UTF8, receiverEmail, receiverEmail) },
                Subject = "Email confirmation",
                Body = new BodyBuilder { HtmlBody = $"Please, confirm email following the link: <a href='{confirmationUrl}'>{confirmationUrl}</a>" }.ToMessageBody()
            };

            await _client.SendAsync(message);
            await _client.DisconnectAsync(quit: true);
        }
    }
}
