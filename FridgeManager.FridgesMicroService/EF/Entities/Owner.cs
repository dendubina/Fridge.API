using System;

namespace FridgeManager.FridgesMicroService.EF.Entities
{
    public class Owner
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool MailingConfirmed { get; set; }
    }
}
