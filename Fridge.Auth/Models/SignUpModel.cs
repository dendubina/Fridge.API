
using System.ComponentModel.DataAnnotations;

namespace FridgeManager.AuthMicroService.Models
{
    public class SignUpModel
    {
        [MinLength(3)]
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Compare("PasswordConfirm")]
        public string Password { get; set; }

        [Required]
        public string PasswordConfirm { get; set; }
    }
}
