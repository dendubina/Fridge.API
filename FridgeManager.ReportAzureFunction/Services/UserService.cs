using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FridgeManager.ReportAzureFunction.Models;
using FridgeManager.ReportAzureFunction.Services.Interfaces;
using Newtonsoft.Json;

namespace FridgeManager.ReportAzureFunction.Services
{
    internal class UserService : IUserService
    {
        private readonly HttpClient _fridgeApiClient;
        private readonly IAuthTokenAccessor _tokenAccessor;

        public UserService(IHttpClientFactory factory, IAuthTokenAccessor tokenAccessor)
        {
            _tokenAccessor = tokenAccessor;
            _fridgeApiClient = factory.CreateClient("FridgeApi");
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var accessToken = await _tokenAccessor.GetAccessTokenAsync();
            _fridgeApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _fridgeApiClient.GetAsync("api/users");

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<User>>(json);
        }
    }
}
