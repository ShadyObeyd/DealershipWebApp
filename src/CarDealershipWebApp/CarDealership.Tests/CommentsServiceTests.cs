using CarDealership.Data;
using CarDealership.Models.ViewModels.News;
using CarDealership.Services;
using CarDealership.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace CarDealership.Tests
{
    public class CommentsServiceTests
    {
        private const string AuthorId = "AdASFASDFEFZ";
        private const string Content = "This is a comment content";

        private NewsCreateViewModel GetNewsCreateInputModel()
        {
            return new NewsCreateViewModel
            {
                Title = "This is a title",
                Content = "This is news content!"
            };
        }

        [Fact]
        public void CreateCommentWorksCorrectly()
        {
            var options = new DbContextOptionsBuilder<DealershipDbContext>()
                .UseInMemoryDatabase(databaseName: "Create_Comment")
                .Options;

            var db = new DealershipDbContext(options);

            var newsService = new NewsService(db);
            var commentsService = new CommentsService(db);

            var news = newsService.CreateNews(GetNewsCreateInputModel(), AuthorId);

            var comment = commentsService.Create(AuthorId, news.Id, Content);

            Assert.True(db.News.First().Comments.Count() == 1);
            Assert.True(db.Comments.Count() == 1);
            Assert.True(db.Comments.First().Id == comment.Id);
        }

        [Fact]
        public void DeleteCommentDeletesTheWriteComment()
        {
            var options = new DbContextOptionsBuilder<DealershipDbContext>()
                .UseInMemoryDatabase(databaseName: "Delete_Comment")
                .Options;

            var db = new DealershipDbContext(options);

            var newsService = new NewsService(db);
            var commentsService = new CommentsService(db);

            var news = newsService.CreateNews(GetNewsCreateInputModel(), AuthorId);

            Assert.True(news.Comments.Count() == 0);

            var comment = commentsService.Create(AuthorId, news.Id, Content);

            Assert.True(news.Comments.Count() == 1);

            commentsService.DeleteComment(comment.Id);

            Assert.True(news.Comments.Count() == 0);
        }

        [Fact]
        public void GetErrorModelReturnsTheCorrectMessage()
        {
            var options = new DbContextOptionsBuilder<DealershipDbContext>()
                .UseInMemoryDatabase(databaseName: "Delete_Comment")
                .Options;

            var db = new DealershipDbContext(options);

            var commentsService = new CommentsService(db);

            var errorModel = commentsService.GetErrorModel(Constants.CommentErrorMessage);

            Assert.True(errorModel.Message == Constants.CommentErrorMessage);
        }
    }
}