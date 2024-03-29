﻿namespace AuthService.Options
{
    public class EmailOptions
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FromName { get; set; }

        public string RedirectBaseAddress { get; set; }
    }
}
