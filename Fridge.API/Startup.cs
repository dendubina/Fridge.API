using FridgeManager.FridgesMicroService.EF;
using FridgeManager.FridgesMicroService.Extensions;
using FridgeManager.FridgesMicroService.Validators.Fridge;
using FridgeManager.Shared.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FridgeManager.FridgesMicroService
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
            services.ConfigureHealthChecks();

            services.ConfigureCors();

            services.ConfigureSqlContext(Configuration);

            services.ConfigureUnitOfWork();

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
            
            services.ConfigureFluentValidationFromAssemblyContaining<FridgeForCreationDtoValidator>();

            services.ConfigureMassTransit();

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

            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();

            app.UseCors();

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
