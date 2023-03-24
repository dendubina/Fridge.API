using System;

namespace AuthService.Options
{
    public class JwtOptions
    {
        public TimeSpan TokenExpirationTime { get; set; }
    }
}
