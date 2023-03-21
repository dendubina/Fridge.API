using AuthService.Extensions;
using AuthService.Services;
using AuthService.Services.Interfaces;
using AuthService.Validators;
using FridgeManager.Shared.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AuthService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAuthService, Services.AuthService>();
            services.AddScoped<IUserService, UserService>();

            services.ConfigureSqlContext(Configuration);

            services.ConfigureHealthChecks();

            services.ConfigureIdentity(Configuration);

            services.ConfigureJwtAuth();

            services.ConfigureEmailService(Configuration);

            services.AddControllers();

            services.ConfigureFluentValidationFromAssemblyContaining<ChangeStatusModelValidator>();

            services.ConfigureMessageBroker(Configuration, Environment);

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
