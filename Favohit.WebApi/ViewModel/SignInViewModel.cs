using System.ComponentModel.DataAnnotations;

namespace Favohit.WebApi.ViewModel
{
    public class SignInViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}
