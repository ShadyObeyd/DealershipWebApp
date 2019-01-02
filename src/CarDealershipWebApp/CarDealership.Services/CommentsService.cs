using CarDealership.Data;
using CarDealership.Models.DataModels.Comments;
using Microsoft.AspNetCore.Identity;
using System;

namespace CarDealership.Services
{
    public class CommentsService
    {
        private readonly DealershipDbContext db;

        public CommentsService(DealershipDbContext db)
        {
            this.db = db;
        }

        public Comment Create(string authorId, string newsId, string content)
        {
            var comment = new Comment
            {
                AuthorId = authorId,
                NewsId = newsId,
                Content = content,
                PublishedOn = DateTime.Now
            };

            this.db.Comments.Add(comment);
            this.db.SaveChanges();

            return comment;
        }
    }

    public class UserManager
    {
    }
}
