using System.ComponentModel.DataAnnotations;

namespace Fridges.Auth.Models
{
    public class SignInModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
