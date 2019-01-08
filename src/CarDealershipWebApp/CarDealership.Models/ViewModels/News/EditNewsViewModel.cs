using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.ViewModels.News
{
    public class EditNewsViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
