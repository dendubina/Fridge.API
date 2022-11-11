using System.Collections.Generic;
using FridgeManager.AuthMicroService.EF.Constants;

namespace FridgeManager.AuthMicroService.Models.DTO
{
    public class UserToReturn
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public UserStatus Status { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
