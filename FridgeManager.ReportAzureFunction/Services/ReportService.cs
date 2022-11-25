using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FridgeManager.ReportAzureFunction.Models;
using FridgeManager.ReportAzureFunction.Models.Options;
using FridgeManager.ReportAzureFunction.Services.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace FridgeManager.ReportAzureFunction.Services
{
    internal class ReportService : IReportService, IDisposable
    {
        private readonly IReportGenerator _reportGenerator;
        private readonly ISmtpClient _smtpClient;
        private readonly EmailOptions _emailOptions;

        public ReportService(IReportGenerator reportGenerator, IOptions<EmailOptions> emailOptions, ISmtpClient smtpClient)
        {
            _emailOptions = emailOptions.Value;
            _reportGenerator = reportGenerator;

            _smtpClient = smtpClient;
            _smtpClient.Connect(_emailOptions.Host, _emailOptions.Port);
            _smtpClient.Authenticate(_emailOptions.UserName, _emailOptions.Password);
        }

        public async Task SendReportAsync(User user, IEnumerable<Fridge> userFridges)
        {
            var message = new MimeMessage
            {
                From = { new MailboxAddress(Encoding.UTF8, _emailOptions.FromName, _emailOptions.UserName) },
                To = { new MailboxAddress(Encoding.UTF8, user.UserName, user.Email) },
                Subject = "Weekly fridges report"
            };

            using var report = _reportGenerator.GenerateReport(user, userFridges);

            var attachment = new MimePart(report.MediaType, report.SubMediaType)
            {
                Content = new MimeContent(report.Content),
                FileName = "Weekly report.pdf"
            };

            message.Body = attachment;

            await _smtpClient.SendAsync(message);
        }

        public void Dispose()
        {
            _smtpClient.DisconnectAsync(quit: true);
            _smtpClient.Dispose();
        }
    }
}
