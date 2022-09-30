using System.ComponentModel.DataAnnotations;

namespace FridgeManager.AuthMicroService.Models
{
    public class SignInModel
    {
        [MinLength(3)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
