using System;

namespace Fridges.Auth.Models
{
    public class UserProfile
    {
        public string Id { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }

        public DateTime SignUpDate { get; set; }

        public DateTime LastSignInDate { get; set; }

        public string JwtToken { get; set; }
    }
}
