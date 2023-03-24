using System;
using System.Collections.Generic;
using AuthService.EF.Constants;
using Microsoft.AspNetCore.Identity;

namespace AuthService.EF.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public UserStatus Status { get; set; }

        public bool MailingConfirmed { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
