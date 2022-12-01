using System;
using FridgeManager.ReportAzureFunction;
using FridgeManager.ReportAzureFunction.Extensions;
using FridgeManager.ReportAzureFunction.Models.Options;
using FridgeManager.ReportAzureFunction.Services;
using FridgeManager.ReportAzureFunction.Services.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;

[assembly: WebJobsStartup(typeof(Startup))]
namespace FridgeManager.ReportAzureFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient("FridgeApi", config =>
            {
                config.BaseAddress = new Uri("https://localhost:5005");
            });

            builder.Services.ConfigureEmailService();

            builder.Services.ConfigureReportGenerator();

            builder.Services.AddScoped<IReportService, ReportService>();
            builder.Services.AddScoped<IFridgeService, FridgeService>();
        }
    }
}
