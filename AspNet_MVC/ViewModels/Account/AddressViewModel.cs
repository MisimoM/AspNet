using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.Account
{
    public class AddressViewModel
    {
        [Required(ErrorMessage = "\u26A0 Address is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Address line 1", Prompt = "Enter your address line")]
        public string AddressLine_1 { get; set; } = null!;
        
        [DataType(DataType.Text)]
        [Display(Name = "Address line 2 (optional)", Prompt = "Enter your second address line")]
        public string? AddressLine_2 { get; set;}
        
        [Required(ErrorMessage = "\u26A0 Postal code is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Postal Code", Prompt = "Enter your postal code")]
        public string PostalCode { get; set; } = null!;

        [Required(ErrorMessage = "\u26A0 city is required")]
        [DataType(DataType.Text)]
        [Display(Name = "City", Prompt = "Enter your city")]
        public string City { get; set; } = null!;
    }
}
