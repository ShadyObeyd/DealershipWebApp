using CarDealership.App.Controllers;
using CarDealership.Models.DataModels;
using CarDealership.Models.ViewModels.News;
using CarDealership.Services;
using CarDealership.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarDealership.App.Areas.Administration.Controllers
{
    [Area(Constants.AdministrationArea)]
    [Authorize(Roles = Constants.AdminRole)]
    public class NewsController : BaseController
    {
        private readonly NewsService newsService;
        private readonly UserManager<DealershipUser> userManager;

        private const string DeleteErrorView = "DeleteError";

        public NewsController(NewsService newsService, UserManager<DealershipUser> userManager)
        {
            this.newsService = newsService;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(NewsCreateViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                var model = this.newsService.GetErrorViewModel(Constants.InvalidNewsInputModelMessage);

                return this.View(Constants.ErrorView, model);
            }

            var userId = this.userManager.GetUserId(HttpContext.User);

            var news = this.newsService.CreateNews(inputModel, userId);

            return this.RedirectToAction(Constants.AllNewsView, Constants.NewsController, new { area = string.Empty});
        }

        public IActionResult Delete(string newsId)
        {
            if (string.IsNullOrEmpty(newsId))
            {
                var model = this.newsService.GetErrorViewModel(Constants.NewsNotFoundMessage);

                return this.View(DeleteErrorView, model);
            }

            try
            {
                this.newsService.DeleteNews(newsId);

                return this.RedirectToAction(Constants.AllNewsView, Constants.NewsController, new { area = string.Empty });
            }
            catch (ArgumentException)
            {
                var model = this.newsService.GetErrorViewModel(Constants.NewsNotFoundMessage);

                return this.View(DeleteErrorView, model);
            }
        }

        [HttpGet]
        public IActionResult Edit(string newsId)
        {
            if (string.IsNullOrEmpty(newsId))
            {
                var model = this.newsService.GetErrorViewModel(Constants.NewsNotFoundMessage);

                return this.View(DeleteErrorView, model);
            }

            try
            {
                var newsToEdit = this.newsService.GetNewsToEdit(newsId);

                return this.View(newsToEdit);
            }
            catch (ArgumentException)
            {
                var model = this.newsService.GetErrorViewModel(Constants.NewsNotFoundMessage);

                return this.View(DeleteErrorView, model);
            }
        }

        [HttpPost]
        public IActionResult Edit(EditNewsViewModel inputModel, string newsId)
        {
            if (!this.ModelState.IsValid || string.IsNullOrEmpty(newsId))
            {
                var errorModel = this.newsService.GetErrorViewModel(Constants.InvalidNewsInputModelMessage);

                return this.View(DeleteErrorView, errorModel);
            }

            try
            {
                this.newsService.EditNews(inputModel, newsId);

                return this.RedirectToAction(Constants.ReadNewsView, Constants.NewsController, new { area = string.Empty, newsId });
            }
            catch (ArgumentException)
            {
                var errorModel = this.newsService.GetErrorViewModel(Constants.InvalidNewsInputModelMessage);

                return this.View(DeleteErrorView, errorModel);
            }
        }

        public IActionResult All()
        {
            return this.RedirectToAction(Constants.AllNewsView, Constants.NewsController, new { area = string.Empty });
        }
    }
}