using FridgeManager.AuthMicroService.Extensions;
using FridgeManager.AuthMicroService.Services;
using FridgeManager.AuthMicroService.Services.Interfaces;
using FridgeManager.AuthMicroService.Validators;
using FridgeManager.Shared.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FridgeManager.AuthMicroService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();

            services.ConfigureSqlContext(Configuration);

            services.ConfigureHealthChecks();

            services.ConfigureIdentity(Configuration);

            services.ConfigureJwtAuth();

            services.ConfigureEmailService(Configuration);

            services.AddControllers();

            services.ConfigureFluentValidationFromAssemblyContaining<ChangeStatusModelValidator>();

            services.ConfigureSwagger();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fridge.Auth v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.ConfigureHealthChecksOptions("/authMicroServiceHC");
            });
        }
    }
}
