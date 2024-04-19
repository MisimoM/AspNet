namespace Presentation.ViewModels.Account
{
    public class AccountViewModel
    {
        public ProfileViewModel Profile { get; set; } = null!;
        public DetailsViewModel Details { get; set; } = null!;
        public SecurityViewModel Security { get; set; } = null!;
    }
}
