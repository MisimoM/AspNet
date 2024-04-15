using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.Account
{
    public class BasicInfoViewModel
    {
        [Required(ErrorMessage = " Enter your first name")]
        [DataType(DataType.Text)]
        [Display(Name = "First name", Prompt = "Enter your first name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = " Enter your last name")]
        [DataType(DataType.Text)]
        [Display(Name = "Last name", Prompt = "Enter your last name")]
        public string LastName { get; set; } = null!;

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address", Prompt = "Enter your email address")]
        [RegularExpression(@"^(?=.{1,100}$)[a-zA-Z0-9._%+-]{1,64}@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "\u26A0 Invalid email format")]
        [Required(ErrorMessage = "\u26A0  Email is required")]
        public string Email { get; set; } = null!;

        [DataType(DataType.Text)]
        [Display(Name = "Phone", Prompt = "Enter your phone")]
        public string? Phone { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Bio", Prompt = "Add a short bio...")]
        public string? Bio { get; set; }
    }
}
