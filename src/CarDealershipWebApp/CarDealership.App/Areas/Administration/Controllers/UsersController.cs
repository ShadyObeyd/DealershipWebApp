using CarDealership.App.Controllers;
using CarDealership.Services;
using CarDealership.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.App.Areas.Administration.Controllers
{
    [Area(Constants.AdministrationArea)]
    [Authorize(Roles = Constants.AdminRole)]
    public class UsersController : BaseController
    {
        private readonly UserService userService;

        public UsersController(UserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            var model = this.userService.GetAllUsers(this.User.Identity.Name);

            return this.View(model);
        }
    }
}