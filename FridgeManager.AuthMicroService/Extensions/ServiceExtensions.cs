using FridgeManager.AuthMicroService.EF;
using FridgeManager.AuthMicroService.EF.Entities;
using FridgeManager.AuthMicroService.Options;
using FridgeManager.AuthMicroService.Services;
using FridgeManager.AuthMicroService.Services.Interfaces;
using MailKit.Net.Smtp;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FridgeManager.AuthMicroService.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(opts =>
                opts.UseSqlServer(config.GetConnectionString("LocalDb")));
        }

        public static void ConfigureHealthChecks(this IServiceCollection services)
            => services
                .AddHealthChecks()
                .AddDbContextCheck<AppDbContext>("Auth Micro Service DbContext");

        public static void ConfigureIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<JwtOptions>(config.GetSection(nameof(JwtOptions)));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                options.User.RequireUniqueEmail = true;
            });
        }

        public static void ConfigureEmailService(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<EmailOptions>(config.GetSection(nameof(EmailOptions)));

            services.AddScoped<ISmtpClient, SmtpClient>();
            services.AddScoped<IEmailService, EmailService>();
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
