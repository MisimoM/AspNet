using AspNet_MVC.Models;

namespace AspNet_MVC.ViewModels
{
    public class SignInViewModel
    {
        public string Title { get; set; } = "Sign In";

        public SignInModel Form { get; set; } = new SignInModel();

        public string? ErrorMessage { get; set; }
    }
}
