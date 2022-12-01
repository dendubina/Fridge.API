using System;

namespace FridgeManager.AuthMicroService.Models.DTO
{
    public class UserToUpdate
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public bool MailingConfirmed { get; set; }
    }
}
