using CarDealership.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.App.Controllers
{
    public class HomeController : BaseController
    {
        private readonly NewsService newsService;

        public HomeController(NewsService newsService)
        {
            this.newsService = newsService;
        }

        public IActionResult Index()
        {
            var model = newsService.GetIndexModel();

            return View(model);
        }
    }
}