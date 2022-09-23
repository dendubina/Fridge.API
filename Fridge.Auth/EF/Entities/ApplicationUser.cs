using System;
using Microsoft.AspNetCore.Identity;

namespace Fridge.Auth.EF.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime SignUpDate { get; set; }

        public DateTime LastSignInDate { get; set; }
    }
}
