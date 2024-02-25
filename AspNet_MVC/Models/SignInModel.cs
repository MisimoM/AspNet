using System.ComponentModel.DataAnnotations;

namespace AspNet_MVC.Models
{
    public class SignInModel
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address", Prompt = "Enter your email address")]
        [Required]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "**********")]
        [Required]
        public string Password { get; set; } = null!;

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
