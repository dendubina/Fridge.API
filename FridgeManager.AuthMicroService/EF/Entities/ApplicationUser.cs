using System;
using FridgeManager.AuthMicroService.EF.Constants;
using Microsoft.AspNetCore.Identity;

namespace FridgeManager.AuthMicroService.EF.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public UserStatus Status { get; set; }

        public DateTime SignUpDate { get; set; }

        public DateTime LastSignInDate { get; set; }
    }
}
