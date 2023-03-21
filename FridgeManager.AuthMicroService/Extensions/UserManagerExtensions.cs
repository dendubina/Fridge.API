using System.Threading.Tasks;
using AuthService.EF.Constants;
using AuthService.EF.Entities;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Extensions
{
    public static class UserManagerExtensions
    {
        public static Task AddDefaultRolesAsync(this UserManager<ApplicationUser> userManager, ApplicationUser user)
            => userManager.AddToRolesAsync(user, new[] { RoleNames.Admin.ToString(), RoleNames.User.ToString() });
    }
}
