using System;
using CarDealership.Models.DataModels.News;

namespace CarDealership.Models.DataModels.Comments
{
    public class Comment : BaseModel
    {
        public string Content { get; set; }

        public DateTime PublishedOn { get; set; }

        public virtual NewsClass News { get; set; }

        public string NewsId { get; set; }

        public virtual DealershipUser Author { get; set; }

        public string AuthorId { get; set; }
    }
}