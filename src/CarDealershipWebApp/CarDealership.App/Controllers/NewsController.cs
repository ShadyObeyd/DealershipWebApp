using CarDealership.Services;
using CarDealership.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarDealership.App.Controllers
{
    public class NewsController : BaseController
    {
        private readonly NewsService newsService;

        public NewsController(NewsService newsService)
        {
            this.newsService = newsService;
        }

        public IActionResult All()
        {
            var model = this.newsService.GetAllNews();

            return this.View(model);
        }

        public IActionResult Read(string newsId)
        {
            if (string.IsNullOrEmpty(newsId))
            {
                var errorModel = this.newsService.GetErrorViewModel(Constants.NewsNotFoundMessage);

                return this.View(Constants.ErrorView, errorModel);
            }

            try
            {
                var model = this.newsService.GetReadModel(newsId);

                return this.View(model);
            }
            catch (ArgumentException)
            {
                var errorModel = this.newsService.GetErrorViewModel(Constants.NewsNotFoundMessage);

                return this.View(Constants.ErrorView, errorModel);
            }
        }
    }
}