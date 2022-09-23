using System.ComponentModel.DataAnnotations;

namespace Fridges.Auth.Models
{
    public class SignUpModel
    {
        [EmailAddress]
        public string Email { get; set; }

        [MinLength(3)]
        public string UserName { get; set; }

        [Required]
        [Compare("PasswordConfirm")]
        public string Password { get; set; }

        [Required]
        public string PasswordConfirm { get; set; }
    }
}
