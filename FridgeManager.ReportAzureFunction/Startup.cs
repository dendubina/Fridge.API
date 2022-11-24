using System;
using FridgeManager.ReportAzureFunction;
using FridgeManager.ReportAzureFunction.Extensions;
using FridgeManager.ReportAzureFunction.Models.Options;
using FridgeManager.ReportAzureFunction.Services;
using FridgeManager.ReportAzureFunction.Services.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: WebJobsStartup(typeof(Startup))]
namespace FridgeManager.ReportAzureFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services
                .AddOptions<AdminCredentials>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection(nameof(AdminCredentials)).Bind(settings);
                });

            builder.Services.AddHttpClient("FridgeApi", config =>
            {
                config.BaseAddress = new Uri("https://localhost:5005");
            });

            builder.Services.ConfigureEmailService();
            builder.Services.AddScoped<IAuthTokenAccessor, AuthTokenAccessor>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IReportService, ReportService>();
            builder.Services.AddScoped<IReportGenerator, ReportGenerator>();
        }
    }
}
