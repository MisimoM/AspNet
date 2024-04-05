﻿namespace WebApi.DTOs
{
    public class SubscriberDto
    {
        public string Email { get; set; } = null!;
        public bool DailyNewsletter { get; set; }
        public bool AdvertisingUpdates { get; set; }
        public bool WeekInReview { get; set; }
        public bool EventUpdates { get; set; }
        public bool StartupsWeekly { get; set; }
        public bool Podcasts { get; set; }
    }
}
