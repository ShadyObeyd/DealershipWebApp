using CarDealership.Models.ViewModels.Adds.CarAdds;
using CarDealership.Services;
using CarDealership.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarDealership.App.Controllers
{
    public class CarAddsController : BaseController
    {
        private readonly CarAddsService carAddsService;
        private readonly UserService userService;

        private const string ViewAddErrorView = "ViewAddErrorView";
        private const string SellCarErrorView = "SellCarErrorView";

        public CarAddsController(CarAddsService carAddsService, UserService userService)
        {
            this.carAddsService = carAddsService;
            this.userService = userService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
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

                var carAddId = this.carAddsService.CreateCarAdd(model, carId, userId).Id;

                var viewModel = this.carAddsService.GetViewAddModel(carAddId);

                return this.View(Constants.ViewAddView, viewModel);
            }
            catch (ArgumentException)
            {
                var errorModel = this.carAddsService.GetErrorViewModel(Constants.CarAddInputErrorMessage);

                return this.View(Constants.ErrorView, errorModel);
            }
            catch (InvalidOperationException)
            {
                var errorModel = this.carAddsService.GetErrorViewModel(Constants.PictureNotValidMessage);

                return this.View(Constants.ErrorView, errorModel);
            }
        }

        [HttpGet]
        public IActionResult Search()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Search(CarSelectInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            try
            {
                var viewModel = this.carAddsService.GetAddsAccordingToCriteria(inputModel);

                return this.View(Constants.ViewAddsView, viewModel);
            }
            catch (ArgumentException)
            {
                var errorModel = this.carAddsService.GetErrorViewModel(Constants.CarAddInputErrorMessage);

                return this.View(Constants.ErrorView, errorModel);
            }
        }

        public IActionResult ViewAdd(string addId)
        {
            if (string.IsNullOrEmpty(addId))
            {
                var errorModel = this.carAddsService.GetErrorViewModel(Constants.AddNotFoundMessage);

                return this.View(ViewAddErrorView, errorModel);
            }

            try
            {
                var viewModel = this.carAddsService.GetViewAddModel(addId);

                return this.View(viewModel);
            }
            catch (ArgumentException)
            {
                var errorModel = this.carAddsService.GetErrorViewModel(Constants.AddNotFoundMessage);

                return this.View(ViewAddErrorView, errorModel);
            }
        }

        [Authorize]
        public IActionResult Sell(string addId)
        {
            if (string.IsNullOrEmpty(addId))
            {
                var errorModel = this.carAddsService.GetErrorViewModel(Constants.AddNotFoundMessage);
            }

            try
            {
                this.carAddsService.SellCar(addId);

                return this.RedirectToAction(Constants.MyAddsView, Constants.AddsController);
            }
            catch (ArgumentException)
            {
                var errorModel = this.carAddsService.GetErrorViewModel(Constants.AddNotFoundMessage);

                return this.View(SellCarErrorView, errorModel);
            }
        }
    }
}