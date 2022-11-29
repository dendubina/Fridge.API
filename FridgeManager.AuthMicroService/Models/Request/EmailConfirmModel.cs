using System;

namespace FridgeManager.AuthMicroService.Models.Request
{
    public class EmailConfirmModel
    {
        public Guid UserId { get; set; }

        public string Token { get; set; }
    }
}
