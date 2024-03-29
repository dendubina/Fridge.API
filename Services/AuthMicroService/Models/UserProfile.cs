﻿using System;

namespace AuthService.Models
{
    public class UserProfile
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public DateTime LastSignInDate  { get; set; }

        public DateTime SignUpDate { get; set; }

        public string JwtToken { get; set; }
    }
}
