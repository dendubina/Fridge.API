using System;
using System.Linq;
using System.Net.Http;
using FridgeManager.AuthMicroService;
using FridgeManager.AuthMicroService.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace AuthMicroService.Tests.Integration_tests.Fixtures
{
    public class AuthWebAppFixture : IDisposable
    {
        private readonly WebApplicationFactory<Startup> _authAppFactory;

        public HttpClient AuthAppClient { get; }

        public Mock<IAuthService> AuthServiceMock { get; } = new();

        public AuthWebAppFixture()
        {
            _authAppFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var authService = services.First(x => x.ServiceType == typeof(IAuthService));

                        services.Remove(authService);

                        services.AddScoped(_ => AuthServiceMock.Object);
                    });
                });

            AuthAppClient = _authAppFactory.CreateClient();
        }

        public void Dispose()
        {
            AuthAppClient.Dispose();
            _authAppFactory.Dispose();
        }
    }
}
