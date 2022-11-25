using FridgeManager.ReportAzureFunction.Models.Options;
using FridgeManager.ReportAzureFunction.Services;
using FridgeManager.ReportAzureFunction.Services.Interfaces;
using GemBox.Document;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FridgeManager.ReportAzureFunction.Extensions;

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

    public static void ConfigureReportGenerator(this IServiceCollection services)
    {
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        ComponentInfo.FreeLimitReached += (_, e) => e.FreeLimitReachedAction = FreeLimitReachedAction.ContinueAsTrial;

        services.AddScoped<IReportGenerator, ReportGenerator>();
    }
}