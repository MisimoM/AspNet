namespace Presentation.ViewModels.Account
{
    public class SecurityViewModel
    {
        public string CurrentPassword { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
        public string ConfirmPassword { get; set;} = null!;
    }
}
