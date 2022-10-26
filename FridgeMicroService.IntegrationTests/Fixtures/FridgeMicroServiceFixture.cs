using System;
using System.Net.Http;
using System.Net.Http.Json;
using FridgeManager.FridgesMicroService.DTO.Fridges;

namespace FridgeMicroService.IntegrationTests.Fixtures
{
    public class FridgeMicroServiceFixture : IDisposable
    {
        public string FridgeToUpdateId => "859e4d86-bd70-49f5-6927-08dab71f5042";

        public HttpClient FridgeServiceClient { get; } = new() { BaseAddress = new Uri("https://localhost:5003") };

        public void Dispose()
        {
            FridgeServiceClient.DeleteAsync("/api/fridges/purge").GetAwaiter().GetResult();
            FridgeServiceClient.PutAsJsonAsync($"/api/fridges/{FridgeToUpdateId}/purge", CreateFridgeToPurge()).GetAwaiter().GetResult();

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
