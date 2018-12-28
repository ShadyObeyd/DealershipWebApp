using CarDealership.App.Controllers;
using CarDealership.Services;
using CarDealership.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpGet]
        public IActionResult Index()
        {
            var model = this.userService.GetAllUsers(this.User.Identity.Name);

            return this.View(model);
        }

        public IActionResult Promote(string userId)
        {
            var user = this.userService.GetUserById(userId);

            try
            {
                this.userService.PromoteUser(user);
            }
            catch (ArgumentException)
            {
                var errorModel = userService.GetErrorModel();

                return this.View(Constants.ErrorView, errorModel);
            }

            var model = this.userService.GetAllUsers(this.User.Identity.Name);

            return this.View(Constants.IndexView, model);
        }

        public IActionResult Demote(string userId)
        {
            var user = this.userService.GetUserById(userId);

            try
            {
                this.userService.DemoteAdmin(user);
            }
            catch (ArgumentException)
            {
                var errorModel = this.userService.GetErrorModel();

                return this.View(Constants.ErrorView, errorModel);
            }

            this.userService.DemoteAdmin(user);

            var model = this.userService.GetAllUsers(this.User.Identity.Name);

            return this.View(Constants.IndexView, model);
        }
    }
}