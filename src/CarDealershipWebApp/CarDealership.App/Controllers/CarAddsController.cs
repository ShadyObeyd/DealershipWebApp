using CarDealership.Models.DataModels.Vehicles.Enums;
using CarDealership.Models.ViewModels.Adds.CarAdds;
using CarDealership.Services;
using CarDealership.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarDealership.App.Controllers
{
    [Authorize]
    public class CarAddsController : BaseController
    {
        private readonly CarAddsService carAddsService;
        private readonly UserService userService;

        public CarAddsController(CarAddsService carAddsService, UserService userService)
        {
            this.carAddsService = carAddsService;
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CarAddInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                var engineType = this.carAddsService.GetCarEngineType(model.CarEngineType);

                var transmission = this.carAddsService.GetCarTransmissionType(model.CarTransmission);

                var carCategory = this.carAddsService.GetCarCategory(model.CarCategory);

                var extras = this.carAddsService.CreateCarExtras(model.CarExtras);

                var carId = this.carAddsService.CreateCar(model, engineType, transmission, carCategory, extras).Id;

                var userId = this.userService.GetUserByUsername(this.User.Identity.Name).Id;

                var carAdd = this.carAddsService.CreateCarAdd(model, carId, userId);

                return this.View(Constants.UploadPicturesView);
            }
            catch (ArgumentException)
            {
                return this.View(model);
            }
        }
    }
}