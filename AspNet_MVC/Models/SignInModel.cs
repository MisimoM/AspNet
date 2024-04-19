using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class SignInModel
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address", Prompt = "Enter your email address")]
        [Required(ErrorMessage = "\u26A0 Email address is required")]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "**********")]
        [Required(ErrorMessage = "\u26A0 Password is required")]
        public string Password { get; set; } = null!;

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
