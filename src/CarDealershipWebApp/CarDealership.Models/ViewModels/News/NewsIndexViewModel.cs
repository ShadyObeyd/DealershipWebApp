namespace CarDealership.Models.ViewModels.News
{
    public class NewsIndexViewModel
    {
        private const string ThreeDots = "...";

        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string PartialContent => this.Content.Length == 50 ? this.Content : this.Content.Substring(0, 50) + ThreeDots;
    }
}
