using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarDealership.App.Models;

namespace CarDealership.App.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}