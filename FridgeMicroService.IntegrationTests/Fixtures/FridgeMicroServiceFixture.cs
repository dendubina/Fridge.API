using System;
using System.Net.Http;

namespace FridgeMicroService.IntegrationTests.Fixtures
{
    public class FridgeMicroServiceFixture : IDisposable
    {
        public HttpClient FridgeServiceClient { get; } = new() { BaseAddress = new Uri("https://localhost:5003") };

        public void Dispose()
        {
           // throw new NotImplementedException();
        }
    }
}
