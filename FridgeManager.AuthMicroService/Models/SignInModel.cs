using System.ComponentModel.DataAnnotations;

namespace FridgeManager.AuthMicroService.Models
{
    public class SignInModel
    {
        [Required]
        [MinLength(3)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
