using System;

namespace FridgeManager.AuthMicroService.Options
{
    public class JwtOptions
    {
        public TimeSpan TokenExpirationTime { get; set; }
    }
}
