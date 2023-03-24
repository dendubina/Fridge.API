using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace AuthService.EF.Entities
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
