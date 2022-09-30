using System.IO.Abstractions;
using FridgeManager.ProductsMicroService.Contracts;
using FridgeManager.ProductsMicroService.EF;
using FridgeManager.ProductsMicroService.Models.Options;
using FridgeManager.ProductsMicroService.Services;
using FridgeManager.ProductsMicroService.Validators;
using FridgeManager.Shared.Extensions;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FridgeManager.ProductsMicroService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            services.AddDbContext<ProductsContext>(opts =>
                opts.UseSqlServer(Configuration.GetConnectionString("LocalDb")));

            services.ConfigureFluentValidationFromAssemblyContaining<ProductForManipulationValidator>();

            services.AddAutoMapper(typeof(Startup));

            services.Configure<ImageServiceOptions>(Configuration.GetSection(nameof(ImageServiceOptions)));
            services.AddScoped<IFileSystem, FileSystem>();
            services.AddScoped<IImageService, ImageService>();

            services.AddMassTransit(x =>
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
            });

            services.ConfigureJwtAuth();

            services.AddControllers();
            
            services.ConfigureSwagger();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fridge.ProductsService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Add("Cache-Control", "public, max-age=3600");
                }
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
