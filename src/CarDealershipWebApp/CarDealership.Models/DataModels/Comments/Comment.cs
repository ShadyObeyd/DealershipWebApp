using System;
using CarDealership.Models.DataModels.News;

namespace CarDealership.Models.DataModels.Comments
{
    public class Comment : BaseModel
    {
        public string Content { get; set; }

        public string AuthorName { get; set; }

        public DateTime PublishedOn { get; set; }

        public virtual NewsClass News { get; set; }

        public int NewsId { get; set; }
    }
}