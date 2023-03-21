using System;
using Microsoft.AspNetCore.Identity;

namespace AuthService.EF.Entities
{
    public class UserRole : IdentityUserRole<Guid>
    {
        public ApplicationUser User { get; set; }

        public ApplicationRole Role { get; set; }
    }
}
