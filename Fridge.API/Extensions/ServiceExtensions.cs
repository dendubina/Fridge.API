using System;
using FridgeManager.FridgesMicroService.Contracts;
using FridgeManager.FridgesMicroService.EF;
using FridgeManager.FridgesMicroService.Services;
using FridgeManager.FridgesMicroService.Services.Consumers;
using MassTransit;
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

        public static void ConfigureMassTransit(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<ProductConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("user");
                        h.Password("user");
                    });

                    cfg.UseMessageRetry(r => r.Interval(100, TimeSpan.FromSeconds(1)));

                    cfg.ConfigureEndpoints(context);
                });
            });

            services.AddOptions<MassTransitHostOptions>().Configure(options =>
            {
                options.WaitUntilStarted = true;
                options.StartTimeout = TimeSpan.FromSeconds(5);
            });
        }
    }
}
