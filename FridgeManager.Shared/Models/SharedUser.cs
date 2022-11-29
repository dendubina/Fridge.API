using System;
using FridgeManager.Shared.Models.Constants;

namespace FridgeManager.Shared.Models
{
    public class SharedUser
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool MailingConfirmed { get; set; }

        public ActionType ActionType { get; set; }
    }
}
