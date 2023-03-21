using System.IO;
using Microsoft.Extensions.Configuration;

namespace FridgeService.IntegrationTests.Configuration
{
    public static class ConfigurationAccessor
    {
        public static IConfiguration Config { get; }

        static ConfigurationAccessor()
        {
            Config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.tests.json", optional: false, reloadOnChange: true)
                .Build();
        }
    }
}
