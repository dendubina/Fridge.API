using System.IO.Abstractions;
using FridgeManager.Shared.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductsService.Contracts;
using ProductsService.Extensions;
using ProductsService.Services;
using ProductsService.Validators;

namespace ProductsService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureHealthChecks();

            services.ConfigureDbContext(Configuration);

            services.ConfigureFluentValidationFromAssemblyContaining<ProductForManipulationValidator>();

            services.AddAutoMapper(typeof(Startup));

            services.ConfigureImageService(Configuration);

            services.ConfigureMessageBroker(Configuration, Environment);

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IFileSystem, FileSystem>();

            services.ConfigureJwtAuth(Configuration.GetSection("AzureAd"));

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
                endpoints.ConfigureHealthChecksOptions("/productsMicroServiceHC");
            });
        }
    }
}
