using CarDealership.Utilities;

namespace CarDealership.Models.ViewModels.News
{
    public class NewsIndexViewModel
    {
        private const int ContentLenght = 100;

        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string PartialContent => this.GetPartialContent();

        private string GetPartialContent()
        {
            if (this.Content.Length <= ContentLenght)
            {
                return this.Content;
            }
            else
            {
                return this.Content.Substring(0, ContentLenght) + Constants.ThreeDots;
            }
        }
    }
}
