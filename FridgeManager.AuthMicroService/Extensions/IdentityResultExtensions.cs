using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Extensions
{
    public static class IdentityResultExtensions
    {
        public static string GetErrorMessage(this IdentityResult identityResult)
            => string.Join(Environment.NewLine, identityResult.Errors.Select(x => x.Description));
    }
}
