using CarDealership.App.Controllers;
using CarDealership.Models.DataModels;
using CarDealership.Models.ViewModels.News;
using CarDealership.Services;
using CarDealership.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.App.Areas.Administration.Controllers
{
    [Area(Constants.AdministrationArea)]
    [Authorize(Roles = Constants.AdminRole)]
    public class NewsController : BaseController
    {
        private readonly NewsService newsService;
        private readonly UserManager<DealershipUser> userManager;

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

        public IActionResult Create(NewsCreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(Constants.ErrorView);
            }

            var userId = this.userManager.GetUserId(HttpContext.User);

            var news = this.newsService.CreateNews(model, userId);

            return this.RedirectToAction(Constants.AllNewsView, Constants.NewsController, new { area = ""});
        }
    }
}