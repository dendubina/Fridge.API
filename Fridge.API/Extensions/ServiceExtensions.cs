using FridgeManager.FridgesMicroService.Contracts;
using FridgeManager.FridgesMicroService.EF;
using FridgeManager.FridgesMicroService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FridgeManager.FridgesMicroService.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("LocalDb")));
        }

        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddDbContextCheck<AppDbContext>("Fridges Micro Service DbContext");
        }
    }
}
