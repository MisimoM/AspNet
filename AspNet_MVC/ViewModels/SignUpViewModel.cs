using AspNet_MVC.Models;

namespace AspNet_MVC.ViewModels
{
	public class SignUpViewModel
	{
		public string Title { get; set; } = "Sign Up";

		public SignUpModel Form { get; set; } = new SignUpModel();


	}
}
