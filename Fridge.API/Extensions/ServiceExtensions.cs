using Contracts.Interfaces;
using Entities.EF;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using zFridge.API.Validators.Products;

namespace zFridge.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureFluentValidation(this IServiceCollection services)
        {
            ValidatorOptions.Global.LanguageManager.Enabled = false;

            services.AddValidatorsFromAssemblyContaining<ProductForCreateDtoValidator>();
        }
            
    }
}
