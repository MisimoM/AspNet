using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.Account
{
    public class AddressViewModel
    {
        [Required(ErrorMessage = " Enter your address line")]
        [DataType(DataType.Text)]
        [Display(Name = "Address line 1", Prompt = "Enter your address line")]
        public string AddressLine_1 { get; set; } = null!;
        
        [DataType(DataType.Text)]
        [Display(Name = "Address line 2", Prompt = "Enter your second address line")]
        public string AddressLine_2 { get; set;} = null!;
        
        [Required(ErrorMessage = " Enter your postal code")]
        [DataType(DataType.Text)]
        [Display(Name = "Postal Code", Prompt = "Enter your postal code")]
        public string PostalCode { get; set; } = null!;

        [Required(ErrorMessage = " Enter your city")]
        [DataType(DataType.Text)]
        [Display(Name = "City", Prompt = "Enter your city")]
        public string City { get; set; } = null!;
    }
}
