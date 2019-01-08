using CarDealership.Data;
using CarDealership.Models.ViewModels.News;
using CarDealership.Services;
using CarDealership.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace CarDealership.Tests
{
    public class NewsServiceTests
    {
        private const string NewsTitle = "Some Title";
        private const string NewsContent = "This is news content.";
        private const string NewsAuthorId = "ASDASFAWE";
        private const string NewsId = "ADVASDad";

        private NewsService GetNewsService()
        {
            var guid = new Guid().ToString();

            var options = new DbContextOptionsBuilder<DealershipDbContext>()
                .UseInMemoryDatabase(databaseName: guid)
                .Options;

            var db = new DealershipDbContext(options);

            return new NewsService(db);
        }

        private NewsCreateViewModel GetNewsCreateInputModel()
        {
            return new NewsCreateViewModel
            {
                Title = NewsTitle,
                Content = NewsContent
            };
        }
        
        [Fact]
        public void CreateNewsWorksCorrectly()
        {
            var service = this.GetNewsService();

            var inputModel = this.GetNewsCreateInputModel();

            var news = service.CreateNews(inputModel, NewsAuthorId);

            Assert.True(news.Title == NewsTitle);
            Assert.True(news.Content == NewsContent);
        }

        [Fact]
        public void CreateNewsSaveNewsInDb()
        {
            var options = new DbContextOptionsBuilder<DealershipDbContext>()
                   .UseInMemoryDatabase(databaseName: "Create_News")
                   .Options;

            var db = new DealershipDbContext(options);

            var service = new NewsService(db);

            var inputModel = this.GetNewsCreateInputModel();

            var news = service.CreateNews(inputModel, NewsAuthorId);

            Assert.True(db.News.Count() == 1);
            Assert.True(db.News.First().Title == NewsTitle);
        }

        [Fact]
        public void GetNewsByIdWorksCorrectly()
        {
            var service = this.GetNewsService();

            var inputModel = this.GetNewsCreateInputModel();

            var news = service.CreateNews(inputModel, NewsAuthorId);

            var wantedNews = service.GetNewsById(news.Id);

            Assert.True(wantedNews.AuthorId == NewsAuthorId);
            Assert.True(wantedNews.Id == news.Id);
        }

        [Fact]
        public void GetAllNewsWorksCorrectly()
        {
            var options = new DbContextOptionsBuilder<DealershipDbContext>()
                   .UseInMemoryDatabase(databaseName: "Get_All_News")
                   .Options;

            var db = new DealershipDbContext(options);

            var service = new NewsService(db);

            var inputModel = this.GetNewsCreateInputModel();

            var news = service.CreateNews(inputModel, NewsAuthorId);

            var wantedNews = service.GetAllNews();

            Assert.True(wantedNews.Count() == 1);
            Assert.True(wantedNews.First().Id == news.Id);
        }

        [Fact]
        public void GetIndexModelWorksCorrectly()
        {
            var service = this.GetNewsService();

            var inputModel = this.GetNewsCreateInputModel();

            for (int i = 0; i < 10; i++)
            {
                var news = service.CreateNews(inputModel, NewsAuthorId);
            }

            var wantedNews = service.GetIndexModel();

            Assert.True(wantedNews.Count() == Constants.NewsCountToDisplay);
        }

        [Fact]
        public void GetErrorModelDisplaysTheCorrectMessage()
        {
            var service = this.GetNewsService();

            var errorModel = service.GetErrorViewModel(Constants.NewsNotFoundMessage);

            Assert.True(errorModel.Message == Constants.NewsNotFoundMessage);
        }

        [Fact]
        public void GetReadModelReturnsTheCorrectNews()
        {
            var service = this.GetNewsService();

            var inputModel = this.GetNewsCreateInputModel();

            var news = service.CreateNews(inputModel, NewsAuthorId);

            var wantedNews = service.GetReadModel(news.Id);

            Assert.True(wantedNews.Id == news.Id);
        }

        [Fact]
        public void DeleteNewsRemovesTheCorrectNewsFromDb()
        {
            var options = new DbContextOptionsBuilder<DealershipDbContext>()
                   .UseInMemoryDatabase(databaseName: "Delete_News")
                   .Options;

            var db = new DealershipDbContext(options);

            var service = new NewsService(db);

            var inputModel = this.GetNewsCreateInputModel();

            var news = service.CreateNews(inputModel, NewsAuthorId);

            Assert.True(db.News.Count() == 1);

            service.DeleteNews(news.Id);

            Assert.True(db.News.Count() == 0);
        }
    }
}