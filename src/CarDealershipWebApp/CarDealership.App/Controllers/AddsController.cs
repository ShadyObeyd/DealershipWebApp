using CarDealership.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.App.Controllers
{
    [Authorize]
    public class AddsController : Controller
    {
        private readonly AddsService addsService;

        public AddsController(AddsService addsService)
        {
            this.addsService = addsService;
        }

        [HttpGet]
        public IActionResult MyAdds()
        {
            var viewModel = this.addsService.GetMyAdds(this.User.Identity.Name);

            return this.View(viewModel);
        }
    }
}