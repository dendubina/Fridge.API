using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductsService.Contracts;
using ProductsService.EF;
using ProductsService.Models.Options;
using ProductsService.Services;

namespace ProductsService.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config)
            => services.AddDbContext<ProductsContext>(opts =>
                opts.UseSqlServer(config.GetConnectionString("LocalDb")));

        public static void ConfigureHealthChecks(this IServiceCollection services)
            => services
                .AddHealthChecks()
                .AddDbContextCheck<ProductsContext>("Products Micro Service DbContext");

        public static void ConfigureImageService(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<ImageServiceOptions>(config.GetSection(nameof(ImageServiceOptions)));

            services.AddScoped<IImageService, ImageService>();
        }

        public static void ConfigureMessageBroker(this IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
        {
            services.AddMassTransit(x =>
            {
                if (env.IsDevelopment())
                {
                    x.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host("localhost", "/", h =>
                        {
                            h.Username("user");
                            h.Password("user");
                        });
                        cfg.ConfigureEndpoints(context);
                    });
                }
                else
                {
                    x.UsingAzureServiceBus((context, cfg) =>
                    {
                        cfg.Host(config["BusEndpoint"]);
                        cfg.ConfigureEndpoints(context);
                    });
                }
            });

            /* services.AddOptions<MassTransitHostOptions>().Configure(options =>
             {
                 options.WaitUntilStarted = true;
                 options.StartTimeout = TimeSpan.FromSeconds(5);
             });*/
        }
    }
}
