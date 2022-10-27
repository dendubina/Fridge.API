using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FridgeManager.FridgesMicroService.DTO.Fridges;
using Xunit;

namespace FridgeMicroService.IntegrationTests.Fixtures
{
    public class FridgeMicroServiceFixture : IAsyncLifetime
    {
        public string FridgeToUpdateId => "859e4d86-bd70-49f5-6927-08dab71f5042";

        public HttpClient FridgeServiceClient { get; } = new() { BaseAddress = new Uri("https://localhost:5003") };

        public Task InitializeAsync()
            => Task.CompletedTask;

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
