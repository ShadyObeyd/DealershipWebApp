using CarDealership.Models.DataModels.Comments;
using System;
using System.Collections.Generic;

namespace CarDealership.Models.DataModels.News
{
    public class NewsClass : BaseModel
    {
        public NewsClass()
            : base()
        {
            this.Comments = new HashSet<Comment>();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishedOn { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual DealershipUser Author { get; set; }

        public string AuthorId { get; set; }
    }
}