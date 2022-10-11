
using System.ComponentModel.DataAnnotations;

namespace FridgeManager.AuthMicroService.Models
{
    public class SignUpModel
    {
        [Required]
        [MinLength(3)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Compare("PasswordConfirm")]
        public string Password { get; set; }

        [Required]
        public string PasswordConfirm { get; set; }
    }
}
