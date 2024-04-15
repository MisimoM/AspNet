namespace Presentation.ViewModels.Account
{
    public class DetailsViewModel
    {
        public BasicInfoViewModel BasicInfo { get; set; } = null!;
        public AddressViewModel? Address { get; set; }
    }
}
