﻿namespace FridgeManager.AuthMicroService.Models.Request
{
    public class SignUpModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }
    }
}
