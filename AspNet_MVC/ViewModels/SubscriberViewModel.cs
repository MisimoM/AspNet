using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels
{
    public class SubscriberViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address", Prompt = "Enter your email address")]
        [RegularExpression(@"^(?=.{1,100}$)[a-zA-Z0-9._%+-]{1,64}@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "\u26A0 Invalid email format")]
        [Required(ErrorMessage = "\u26A0  Email is required")]
        public string Email { get; set; } = null!;
        public bool DailyNewsletter { get; set; }
        public bool AdvertisingUpdates { get; set; }
        public bool WeekInReview { get; set; }
        public bool EventUpdates { get; set; }
        public bool StartupsWeekly { get; set; }
        public bool Podcasts { get; set; }
    }
}
