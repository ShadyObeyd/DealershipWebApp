using CarDealership.App.Controllers;
using CarDealership.Services;
using CarDealership.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.App.Areas.Administration.Controllers
{
    [Area(Constants.AdministrationArea)]
    [Authorize(Roles = Constants.AdminRole)]
    public class HomeController : BaseController
    {
        private readonly UserService userService;

        public HomeController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = this.userService.GetAllUsers(this.User.Identity.Name);

            return this.View(model);
        }

        // TODO Fix action to work!
        public IActionResult Promote(string userId)
        {
            var user = this.userService.GetUserById(userId);

            this.userService.PromoteUser(user);

            var model = this.userService.GetAllUsers(this.User.Identity.Name);

            return this.View(Constants.IndexView, model);
        }

        // TODO Fix action to work!
        public IActionResult Demote(string userId)
        {
            var user = this.userService.GetUserById(userId);

            this.userService.DemoteAdmin(user);

            var model = this.userService.GetAllUsers(this.User.Identity.Name);

            return this.View(Constants.IndexView, model);
        }
    }
}