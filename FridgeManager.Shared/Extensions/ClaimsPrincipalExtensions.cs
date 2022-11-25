using System.Linq;
using System.Security.Claims;

namespace FridgeManager.Shared.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserName(this ClaimsPrincipal claimsPrincipal)
            => claimsPrincipal.Claims.First(x => x.Type == "name").Value.ToString();

        public static string GetUserEmail(this ClaimsPrincipal claimsPrincipal)
            => claimsPrincipal.Claims.First(x => x.Type == "preferred_username").Value.ToString();

        public static string GetUserId(this ClaimsPrincipal claimsPrincipal)
            => claimsPrincipal.Claims.First(x => x.Type == "id").Value.ToString();
    }
}
