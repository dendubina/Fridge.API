using FridgeManager.ReportAzureFunction.Models.Options;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FridgeManager.ReportAzureFunction.Extensions
{
    internal static class ServiceExtensions
    {
        public static void ConfigureEmailService(this IServiceCollection services)
        {
            services
                .AddOptions<EmailOptions>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection(nameof(EmailOptions)).Bind(settings);
                });

            services.AddScoped<ISmtpClient>(_ => new SmtpClient());
        }
    }
}
