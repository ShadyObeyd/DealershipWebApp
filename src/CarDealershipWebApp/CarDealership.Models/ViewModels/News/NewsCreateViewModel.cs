using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.ViewModels.News
{
    public class NewsCreateViewModel
    {
        private const int TitleMaxSymbols = 50;

        [Required]
        [MaxLength(TitleMaxSymbols)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
