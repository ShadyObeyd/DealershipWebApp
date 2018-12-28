using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.ViewModels.News
{
    public class NewsCreateViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
