using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using FridgeManager.ReportAzureFunction.Models;
using FridgeManager.ReportAzureFunction.Services.Interfaces;

namespace FridgeManager.ReportAzureFunction.Services
{
    internal class FridgeService : IFridgeService
    {
        private readonly HttpClient _fridgeApiClient;

        public FridgeService(IHttpClientFactory factory)
        {
            _fridgeApiClient = factory.CreateClient("FridgeApi");
        }

        public async Task<IEnumerable<Fridge>> GetUserFridges(User user)
        {            
            var response = await _fridgeApiClient.GetAsync($"/api/fridges?ownerEmail={user.Email}");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await response.Content.ReadFromJsonAsync<IEnumerable<Fridge>>(options);
        }
    }
}
