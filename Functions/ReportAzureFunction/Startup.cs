using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ReportAzureFunction;
using ReportAzureFunction.Extensions;
using ReportAzureFunction.Services;
using ReportAzureFunction.Services.Interfaces;

[assembly: WebJobsStartup(typeof(Startup))]
namespace ReportAzureFunction
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
