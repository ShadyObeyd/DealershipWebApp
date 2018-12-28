using CarDealership.App.Controllers;
using CarDealership.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.App.Areas.Administration.Controllers
{
    [Area(Constants.AdministrationArea)]
    [Authorize(Roles = Constants.AdminRole)]
    public class NewsController : BaseController
    {
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }
    }
}