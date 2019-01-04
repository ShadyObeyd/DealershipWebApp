using Microsoft.AspNetCore.Mvc;

namespace CarDealership.App.Controllers
{
    public class CarAddsController : BaseController
    {
        public IActionResult Create()
        {
            return this.View();
        }
    }
}