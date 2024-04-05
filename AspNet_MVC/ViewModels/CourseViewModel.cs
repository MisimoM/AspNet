namespace Presentation.ViewModels
{
    public class CourseViewModel
    {
        public string ImgUrl { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public double Price { get; set; }
        public double? DiscountPrice { get; set; }
        public bool BestSeller { get; set; }
        public int Hours { get; set; }
        public int LikesCount { get; set; }
        public int LikePercentage { get; set; }
    }
}
