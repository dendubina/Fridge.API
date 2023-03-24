using FridgeManager.Shared.Extensions;
using FridgesService.Extensions;
using FridgesService.Validators.Fridge;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace FridgesService
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

            services.ConfigureSqlContext(Configuration);

            services.ConfigureUnitOfWork();

            services.AddAutoMapper(typeof(Startup));

            services.ConfigureJwtAuth(Configuration.GetSection("AzureAd"));

            services.AddControllers();
            
            services.ConfigureFluentValidationFromAssemblyContaining<FridgeForCreationDtoValidator>();

            services.ConfigureMessageBroker(Configuration, Environment);

            services.ConfigureRedis(Configuration);

            services.ConfigureSwagger();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fridge.API v1"));
            }

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.ConfigureHealthChecksOptions("/fridgesMicroServiceHC");
            });
        }
    }
}
