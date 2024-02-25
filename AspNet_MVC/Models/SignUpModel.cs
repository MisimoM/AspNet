using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AspNet_MVC.Models
{
	public class SignUpModel
	{
		[DataType(DataType.Text)]
		[Display(Name = "First name", Prompt = "Enter your first name")]
		[Required(ErrorMessage = "\u26A0  First name is required")]
		public string FirstName { get; set; } = null!;

		[DataType(DataType.Text)]
		[Display(Name = "Last name", Prompt = "Enter your last name")]
		[Required(ErrorMessage = "\u26A0  Last name is required")]
		public string LastName { get; set; } = null!;

		[DataType(DataType.EmailAddress)]
		[Display(Name = "Email address", Prompt = "Enter your email address")]
		[RegularExpression(@"^(?=.{1,100}$)[a-zA-Z0-9._%+-]{1,64}@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "\u26A0 Invalid email format")]
		[Required(ErrorMessage = "\u26A0  Email is required")]
		public string Email { get; set; } = null!;

		[DataType(DataType.Password)]
		[Display(Name = "Password", Prompt = "**********")]
		[RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+])[a-zA-Z\d!@#$%^&*()_+]{8,}$", ErrorMessage = "\u26A0  Your password needs at least 8 characters and an uppercase character and a number (0-9) and a special character (!@#$%^&*)")]
		[Required(ErrorMessage = "\u26A0  Password is required")]
		public string Password { get; set; } = null!;

		[DataType(DataType.Password)]
		[Display(Name = "Confirm Password", Prompt = "**********")]
		[Required(ErrorMessage = "\u26A0  Confirm your password")]
		[Compare(nameof(Password), ErrorMessage = "\u26A0 Passwords does not match")]
		public string ConfirmPassword { get; set; } = null!;

		[Display(Name = "I agree to the Terms & Conditions.")]
		[CheckBoxRequired(ErrorMessage = "\u26A0  Confirm the Terms and Conditions")]
		public bool TermsAndConditions { get; set; } = false;
	}

	public class CheckBoxRequired : ValidationAttribute
	{
		public override bool IsValid(object? value) => value is bool b && b;
    }
}
