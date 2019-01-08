using CarDealership.Data;
using CarDealership.Models.DataModels.News;
using CarDealership.Models.ViewModels.Comments;
using CarDealership.Models.ViewModels.Errors;
using CarDealership.Models.ViewModels.News;
using CarDealership.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealership.Services
{
    public class NewsService
    {
        private readonly DealershipDbContext db;

        public NewsService(DealershipDbContext db)
        {
            this.db = db;
        }

        public NewsClass GetNewsById(string newsId)
        {
            this.CheckInputParameter(newsId);

            return this.db.News.FirstOrDefault(n => n.Id == newsId);
        }

        public List<AllNewsViewModel> GetAllNews()
        {
            return this.db.News.Select(n => new AllNewsViewModel
            {
                Id = n.Id,
                Title = n.Title,
                AuthorName = n.Author.UserName
            })
            .ToList();
        }

        public List<NewsIndexViewModel> GetIndexModel()
        {
            return this.db.News.OrderByDescending(n => n.PublishedOn).Take(Constants.NewsCountToDisplay).Select(n => new NewsIndexViewModel
            {
                Id = n.Id,
                Content = n.Content,
                Title = n.Title
            }).ToList();
        }

        public NewsClass CreateNews(NewsCreateViewModel inputModel, string authorId)
        {
            var news = new NewsClass
            {
                Title = inputModel.Title,
                Content = inputModel.Content,
                PublishedOn = DateTime.Now,
                AuthorId = authorId
            };

            this.db.News.Add(news);
            this.db.SaveChanges();

            return news;
        }

        public ErrorViewModel GetErrorViewModel(string message)
        {
            return new ErrorViewModel
            {
                Message = message
            };
        }

        public ReadNewsViewModel GetReadModel(string newsId)
        {
            this.CheckInputParameter(newsId);

            return this.db.News.Where(n => n.Id == newsId).Select(n => new ReadNewsViewModel
            {
                Id = n.Id,
                AuthorName = n.Author.UserName,
                Content = n.Content,
                Title = n.Title,
                Comments = this.db.Comments.Where(c => c.NewsId == n.Id).Select(c => new CommentViewModel
                {
                    Id = c.Id,
                    Author = c.Author.UserName,
                    Content = c.Content
                })
                .ToList()
            })
            .FirstOrDefault();
        }

        public void DeleteNews(string newsId)
        {
            this.CheckInputParameter(newsId);

            var news = this.db.News.FirstOrDefault(n => n.Id == newsId);

            var newsComments = this.db.Comments.Where(c => c.NewsId == news.Id);

            this.db.Comments.RemoveRange(newsComments);
            this.db.News.Remove(news);
            this.db.SaveChanges();
        }

        public EditNewsViewModel GetNewsToEdit(string newsId)
        {
            this.CheckInputParameter(newsId);

            var news = this.db.News.Where(n => n.Id == newsId).Select(n => new EditNewsViewModel
            {
                Id = n.Id,
                Title = n.Title,
                Content = n.Content
            }).FirstOrDefault();

            return news;
        }

        public void EditNews(EditNewsViewModel inputModel, string newsId)
        {
            this.CheckInputParameter(newsId);

            var news = this.db.News.FirstOrDefault(n => n.Id == newsId);

            news.Content = inputModel.Content;
            news.Title = inputModel.Title;

            this.db.News.Update(news);
            this.db.SaveChanges();
        }

        private void CheckInputParameter(string parameter)
        {
            if (!this.db.News.Any(n => n.Id == parameter))
            {
                throw new ArgumentException();
            }
        }
    }
}