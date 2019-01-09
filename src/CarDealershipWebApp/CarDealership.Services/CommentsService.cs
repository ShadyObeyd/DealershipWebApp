using CarDealership.Data;
using CarDealership.Models.DataModels.Comments;
using CarDealership.Models.ViewModels.Errors;
using System;
using System.Linq;

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
            if (!this.db.News.Any(n => n.Id == newsId))
            {
                throw new ArgumentException();
            }

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

        public void DeleteComment(string commentId)
        {
            var comment = this.db.Comments.FirstOrDefault(c => c.Id == commentId);

            if (comment == null)
            {
                throw new ArgumentException();
            }

            this.db.Comments.Remove(comment);
            this.db.SaveChanges();
        }

        public ErrorViewModel GetErrorModel(string message)
        {
            return new ErrorViewModel
            {
                Message = message
            };
        }

        public void EditComment(string commentId, string content)
        {
            var comment = this.db.Comments.FirstOrDefault(c => c.Id == commentId);

            if (comment == null)
            {
                throw new ArgumentException();
            }

            comment.Content = content;

            this.db.Comments.Update(comment);
            this.db.SaveChanges();
        }
    }
}