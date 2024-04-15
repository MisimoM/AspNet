using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.Account
{
    public class SecurityViewModel
    {
        [DataType(DataType.Password)]
        [Display(Name = "Current password", Prompt = "**********")]
        [Required(ErrorMessage = "\u26A0  Current password is required")]
        public string CurrentPassword { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "**********")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+])[a-zA-Z\d!@#$%^&*()_+]{8,}$", ErrorMessage = "\u26A0  Your password needs at least 8 characters and an uppercase character and a number (0-9) and a special character (!@#$%^&*)")]
        [Required(ErrorMessage = "\u26A0  New password is required")]
        public string NewPassword { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password", Prompt = "**********")]
        [Required(ErrorMessage = "\u26A0  Confirm your password")]
        [Compare(nameof(NewPassword), ErrorMessage = "\u26A0 Passwords does not match")]
        public string ConfirmPassword { get; set;} = null!;
    }
}
