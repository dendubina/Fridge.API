using System;

namespace Fridges.Auth.Options
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }

        public TimeSpan TokenExpirationTime { get; set; }
    }
}
