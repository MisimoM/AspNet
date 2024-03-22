using Presentation.Models;

namespace Presentation.ViewModels
{
    public class SignInViewModel
    {
        public string Title { get; set; } = "Sign In";

        public SignInModel Form { get; set; } = new SignInModel();

        public string? ErrorMessage { get; set; }
    }
}
