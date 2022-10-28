using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FridgeManager.FridgesMicroService.DTO.Fridges;
using FridgeMicroService.IntegrationTests.Configuration;
using Xunit;

namespace FridgeMicroService.IntegrationTests.Fixtures
{
    public class FridgeMicroServiceFixture : IAsyncLifetime
    {
        public string FridgeToUpdateId { get; private set; }

        public HttpClient FridgeServiceClient { get; } = new();

        public Task InitializeAsync()
        {
            FridgeServiceClient.BaseAddress = new Uri(ConfigurationAccessor.Config["BasePath"]);
            FridgeToUpdateId = ConfigurationAccessor.Config["FridgeIdToUpdate"];

            return Task.CompletedTask;
        }

        public async Task DisposeAsync()
        {
            await FridgeServiceClient.DeleteAsync("/api/fridges/purge");
            await FridgeServiceClient.PutAsJsonAsync($"/api/fridges/{FridgeToUpdateId}/purge", CreateFridgeToPurge());

            FridgeServiceClient.Dispose();
        }

        private static FridgeForUpdateDto CreateFridgeToPurge()
            => new()
            {
                Name = "TestFridgeToUpdate",
                OwnerName = "TestOwner",
                ModelName = "TestModelName",
                ModelYear = 9999,
            };
    }
}
