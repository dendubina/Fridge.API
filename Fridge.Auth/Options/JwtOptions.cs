using System;

namespace Fridge.Auth.Options
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }
        public TimeSpan TokenExpirationTime { get; set; }
    }
}
