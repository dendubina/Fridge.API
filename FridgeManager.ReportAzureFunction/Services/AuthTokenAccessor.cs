using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FridgeManager.ReportAzureFunction.Models.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using FridgeManager.ReportAzureFunction.Services.Interfaces;

namespace FridgeManager.ReportAzureFunction.Services
{
    internal class AuthTokenAccessor : IAuthTokenAccessor
    {
        private readonly HttpClient _fridgeApiClient;
        private readonly AdminCredentials _adminCredentials;

        public AuthTokenAccessor(IHttpClientFactory factory, IOptions<AdminCredentials> credentials)
        {
            _fridgeApiClient = factory.CreateClient("FridgeApi");
            _adminCredentials = credentials.Value;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            /*var response = await _fridgeApiClient.PostAsync("/signin", JsonContent.Create(new { _adminCredentials.Email, _adminCredentials.Password }));

            var data = (JObject)JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());

            return data.SelectToken("jwtToken").Value<string>();*/

            return
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJwcmVmZXJyZWRfdXNlcm5hbWUiOiJyZWFAbWFpbC5ydSIsIm5hbWUiOiJyZWEiLCJyb2xlIjpbIkFkbWluIiwiVXNlciJdLCJleHAiOjE2NjkzOTkyMzN9.j98mQOISp3KMI8B7_GLP1q_493R1B8o06pLdB_UzGk4";
        }
    }
}
