using CarDealership.Models.ViewModels.Comments;
using System.Collections.Generic;

namespace CarDealership.Models.ViewModels.News
{
    public class ReadNewsViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorName { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }
    }
}