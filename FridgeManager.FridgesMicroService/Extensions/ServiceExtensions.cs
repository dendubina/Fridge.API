using System;
using FridgeManager.FridgesMicroService.Contracts;
using FridgeManager.FridgesMicroService.EF;
using FridgeManager.FridgesMicroService.Services;
using FridgeManager.FridgesMicroService.Services.Consumers;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            => services.AddScoped<IUnitOfWork, UnitOfWork>();

        public static void ConfigureHealthChecks(this IServiceCollection services)
            => services
                .AddHealthChecks()
                .AddDbContextCheck<AppDbContext>("Fridges Micro Service DbContext");

        public static void ConfigureMessageBroker(this IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<ProductConsumer>();
                x.AddConsumer<UsersConsumer>();

                if (env.IsDevelopment())
                {
                    x.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host("localhost", "/", h =>
                        {
                            h.Username("user");
                            h.Password("user");
                        });

                        cfg.UseMessageRetry(r => r.Interval(10, TimeSpan.FromSeconds(10)));

                        cfg.ConfigureEndpoints(context);
                    });
                }
                else
                {
                    x.UsingAzureServiceBus((context, cfg) =>
                    {
                        cfg.Host(config["BusEndpoint"]);
                        cfg.UseMessageRetry(r => r.Interval(10, TimeSpan.FromSeconds(10)));
                        cfg.ConfigureEndpoints(context);
                    });
                }
                
            });

            /*services.AddOptions<MassTransitHostOptions>().Configure(options =>
            {
                options.WaitUntilStarted = true;
                options.StartTimeout = TimeSpan.FromSeconds(5);
            });*/
        }
    }
}
