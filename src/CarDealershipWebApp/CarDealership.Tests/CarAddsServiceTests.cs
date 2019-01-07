using CarDealership.Data;
using CarDealership.Models.DataModels;
using CarDealership.Models.DataModels.Adds.Vehicles;
using CarDealership.Models.DataModels.Vehicles;
using CarDealership.Models.DataModels.Vehicles.Enums;
using CarDealership.Models.ViewModels.Adds.CarAdds;
using CarDealership.Models.ViewModels.Errors;
using CarDealership.Services;
using CarDealership.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace CarDealership.Tests
{
    public class CarAddsServiceTests
    {
        [Fact]
        public void GetCarEngineWorksCorectly()
        {
            var options = new DbContextOptionsBuilder<DealershipDbContext>()
                .UseInMemoryDatabase(databaseName: "Get_Car_Engine")
                .Options;

            var db = new DealershipDbContext(options);

            var service = new CarAddsService(db);

            var inputString = "Gasoline";

            var engineType = service.GetCarEngineType(inputString);

            Assert.True((int)engineType == 3);
            Assert.True(engineType.ToString() == inputString);

            inputString = "Diesel";

            engineType = service.GetCarEngineType(inputString);

            Assert.True((int)engineType == 2);
            Assert.True(engineType.ToString() == inputString);

            inputString = "GasolineAndLPG";

            engineType = service.GetCarEngineType(inputString);

            Assert.True((int)engineType == 4);
            Assert.True(engineType.ToString() == inputString);

            inputString = "Electric";

            engineType = service.GetCarEngineType(inputString);

            Assert.True((int)engineType == 5);
            Assert.True(engineType.ToString() == inputString);

            inputString = "Hybrid";

            engineType = service.GetCarEngineType(inputString);

            Assert.True((int)engineType == 6);
            Assert.True(engineType.ToString() == inputString);
        }

        [Fact]
        public void GetCarTransmissionWorksCorectly()
        {
            var options = new DbContextOptionsBuilder<DealershipDbContext>()
                .UseInMemoryDatabase(databaseName: "Get_Car_Transmission")
                .Options;

            var db = new DealershipDbContext(options);

            var service = new CarAddsService(db);

            var inputString = "Manual";

            var engineType = service.GetCarTransmissionType(inputString);

            Assert.True((int)engineType == 2);
            Assert.True(engineType.ToString() == inputString);

            inputString = "Automatic";

            engineType = service.GetCarTransmissionType(inputString);

            Assert.True((int)engineType == 3);
            Assert.True(engineType.ToString() == inputString);

            inputString = "SemiAutomatic";

            engineType = service.GetCarTransmissionType(inputString);

            Assert.True((int)engineType == 4);
            Assert.True(engineType.ToString() == inputString);
        }

        [Fact]
        public void GetCarCategoryWorksCorectly()
        {
            var options = new DbContextOptionsBuilder<DealershipDbContext>()
                .UseInMemoryDatabase(databaseName: "Get_Car_Category")
                .Options;

            var db = new DealershipDbContext(options);

            var service = new CarAddsService(db);

            var inputString = "Saloon";

            var engineType = service.GetCarCategory(inputString);

            Assert.True((int)engineType == 1);
            Assert.True(engineType.ToString() == inputString);

            inputString = "OffRoad";

            engineType = service.GetCarCategory(inputString);

            Assert.True((int)engineType == 2);
            Assert.True(engineType.ToString() == inputString);

            inputString = "Van";

            engineType = service.GetCarCategory(inputString);

            Assert.True((int)engineType == 3);
            Assert.True(engineType.ToString() == inputString);

            inputString = "Estate";

            engineType = service.GetCarCategory(inputString);

            Assert.True((int)engineType == 4);
            Assert.True(engineType.ToString() == inputString);

            inputString = "Sports";

            engineType = service.GetCarCategory(inputString);

            Assert.True((int)engineType == 5);
            Assert.True(engineType.ToString() == inputString);

            inputString = "Cabriolet";

            engineType = service.GetCarCategory(inputString);

            Assert.True((int)engineType == 6);
            Assert.True(engineType.ToString() == inputString);
        }

        [Fact]
        public void CreateCarExtrasWorksCorrectly()
        {
            var options = new DbContextOptionsBuilder<DealershipDbContext>()
                .UseInMemoryDatabase(databaseName: "Create_Car_Extras")
                .Options;

            var db = new DealershipDbContext(options);

            var service = new CarAddsService(db);

            var carExtras = "CD Player, Electric windows, electric mirrors, AC";

            var extras = service.CreateCarExtras(carExtras).ToList();

            Assert.True(extras.Count == 4);

            Assert.True(extras[0].Name == "CD Player");
            Assert.True(extras[1].Name == "Electric windows");
            Assert.True(extras[2].Name == "electric mirrors");
            Assert.True(extras[3].Name == "AC");

            carExtras = "CD Player Electric windows electric mirrors AC";

            extras = service.CreateCarExtras(carExtras).ToList();

            Assert.True(extras.Count == 1);
            Assert.True(extras[0].Name == "CD Player Electric windows electric mirrors AC");
        }

        [Fact]
        public void GetErrorViewModelWorksCorrectly()
        {
            var options = new DbContextOptionsBuilder<DealershipDbContext>()
                .UseInMemoryDatabase(databaseName: "Get_Error_Model")
                .Options;

            var db = new DealershipDbContext(options);

            var service = new CarAddsService(db);

            var errorModel = new ErrorViewModel
            {
                Message = Constants.AddNotFoundMessage
            };

            Assert.True(errorModel.Message == Constants.AddNotFoundMessage);
        }

        [Fact]
        public void CreateCarWorksAndSavesCarInDb()
        {
            var options = new DbContextOptionsBuilder<DealershipDbContext>()
                .UseInMemoryDatabase(databaseName: "Create_Car")
                .Options;

            var db = new DealershipDbContext(options);

            var service = new CarAddsService(db);

            var inputModel = new CarAddInputModel
            {
                CarMake = "Opel",
                CarModel = "Vectra",
                CarCategory = "Saloon",
                CarColor = "White",
                CarEngineType = "Gasoline / LPG",
                CarExtras = "CD Player, Electric windows, electric mirrors, AC",
                CarHorsePower = 130,
                CarLocation = "Nqkude",
                CarPrice = 5000m,
                CarTransmission = "Manual",
                CarYearOfProduction = 2006
            };

            var engineType = service.GetCarEngineType(inputModel.CarEngineType);
            var transmission = service.GetCarTransmissionType(inputModel.CarTransmission);
            var category = service.GetCarCategory(inputModel.CarCategory);
            var extras = service.CreateCarExtras(inputModel.CarExtras);

            var car = service.CreateCar(inputModel, engineType, transmission, category, extras);

            Assert.True(db.Cars.Count() == 1);
            Assert.True(db.CarExtras.Count() == 4);
            Assert.True(db.Cars.First().Make == inputModel.CarMake);
            Assert.True((int)db.Cars.First().EngineType == 4);
            Assert.True(db.Cars.First().EngineType.ToString() == Constants.GasolineAndLpgEngineTypeCorrection);
        }

        [Fact]
        public void CreateCarAddWorksCorrectlyAndSavesInDb()
        {
            var options = new DbContextOptionsBuilder<DealershipDbContext>()
                .UseInMemoryDatabase(databaseName: "Create_Car_Add")
                .Options;

            var db = new DealershipDbContext(options);

            var service = new CarAddsService(db);

            var imageMock = new Mock<IFormFile>();

            var content = "Fake file";

            var fileName = "text.jpg";

            var memoryStream = new MemoryStream();

            var writer = new StreamWriter(memoryStream);

            writer.Write(content);
            writer.Flush();

            memoryStream.Position = 0;

            imageMock.Setup(_ => _.OpenReadStream()).Returns(memoryStream);
            imageMock.Setup(_ => _.FileName).Returns(fileName);
            imageMock.Setup(_ => _.Length).Returns(memoryStream.Length);

            var fakeImage = imageMock.Object;

            var inputModel = new CarAddInputModel
            {
                CarMake = "Opel",
                CarModel = "Vectra",
                CarCategory = "Saloon",
                CarColor = "White",
                CarEngineType = "Gasoline / LPG",
                CarExtras = "CD Player, Electric windows, electric mirrors, AC",
                CarHorsePower = 130,
                CarLocation = "Nqkude",
                CarPrice = 5000m,
                CarTransmission = "Manual",
                CarYearOfProduction = 2006,
                Title = "Opel Vectra; Good Quality",
                AdditionalInfo = "The car is ina great shape! You can drive it anywhere without a problem!",
                Pictures = new List<IFormFile>() { fakeImage }
            };

            var engineType = service.GetCarEngineType(inputModel.CarEngineType);
            var transmission = service.GetCarTransmissionType(inputModel.CarTransmission);
            var category = service.GetCarCategory(inputModel.CarCategory);
            var extras = service.CreateCarExtras(inputModel.CarExtras);

            var car = service.CreateCar(inputModel, engineType, transmission, category, extras);

            var carAdd = service.CreateCarAdd(inputModel, car.Id, "1");

            Assert.True(db.CarAdds.Count() == 1);
            Assert.True(db.CarAdds.First().CarId == car.Id);
            Assert.True(db.CarAdds.First().CreatorId == "1");
        }

        [Fact]
        public void GetAddsAccordingToCriteriaWorksCorrectly()
        {
            var options = new DbContextOptionsBuilder<DealershipDbContext>()
                .UseInMemoryDatabase(databaseName: "Get_Car_Adds")
                .Options;

            var db = new DealershipDbContext(options);

            var service = new CarAddsService(db);

            var imageMock = new Mock<IFormFile>();

            var content = "Fake file";

            var fileName = "text.jpg";

            var memoryStream = new MemoryStream();

            var writer = new StreamWriter(memoryStream);

            writer.Write(content);
            writer.Flush();

            memoryStream.Position = 0;

            imageMock.Setup(_ => _.OpenReadStream()).Returns(memoryStream);
            imageMock.Setup(_ => _.FileName).Returns(fileName);
            imageMock.Setup(_ => _.Length).Returns(memoryStream.Length);

            var fakeImage = imageMock.Object;

            var inputModel = new CarAddInputModel
            {
                CarMake = "Opel",
                CarModel = "Vectra",
                CarCategory = "Saloon",
                CarColor = "White",
                CarEngineType = "Gasoline / LPG",
                CarExtras = "CD Player, Electric windows, electric mirrors, AC",
                CarHorsePower = 130,
                CarLocation = "Nqkude",
                CarPrice = 5000m,
                CarTransmission = "Manual",
                CarYearOfProduction = 2006,
                Title = "Opel Vectra; Good Quality",
                AdditionalInfo = "The car is ina great shape! You can drive it anywhere without a problem!",
                Pictures = new List<IFormFile>() { fakeImage }
            };

            var engineType = service.GetCarEngineType(inputModel.CarEngineType);
            var transmission = service.GetCarTransmissionType(inputModel.CarTransmission);
            var category = service.GetCarCategory(inputModel.CarCategory);
            var extras = service.CreateCarExtras(inputModel.CarExtras);

            var car = service.CreateCar(inputModel, engineType, transmission, category, extras);

            var carAdd = service.CreateCarAdd(inputModel, car.Id, "1");

            var carSelectModel = new CarSelectInputModel
            {
                Category = "Saloon",
                EndPrice = decimal.MaxValue,
                EndYear = 2019,
                EngineType = "Gasoline / LPG",
                HorsePower = 130,
                Location = "Nqkude",
                Make = "Opel",
                Model = "Vectra",
                StartingPrice = 4000m,
                StartingYear = 2000,
                Transmission = "Manual"
            };

            var getCars = service.GetAddsAccordingToCriteria(carSelectModel);

            Assert.True(getCars.Count() == 1);
        }

        [Fact]
        public void GetViewAddModelWorksCorrectly()
        {
            var options = new DbContextOptionsBuilder<DealershipDbContext>()
                .UseInMemoryDatabase(databaseName: "Get_View_Add")
                .Options;

            var db = new DealershipDbContext(options);

            var service = new CarAddsService(db);

            var imageMock = new Mock<IFormFile>();

            var content = "Fake file";

            var fileName = "text.jpg";

            var memoryStream = new MemoryStream();

            var writer = new StreamWriter(memoryStream);

            writer.Write(content);
            writer.Flush();

            memoryStream.Position = 0;

            imageMock.Setup(_ => _.OpenReadStream()).Returns(memoryStream);
            imageMock.Setup(_ => _.FileName).Returns(fileName);
            imageMock.Setup(_ => _.Length).Returns(memoryStream.Length);

            var fakeImage = imageMock.Object;

            var inputModel = new CarAddInputModel
            {
                CarMake = "Opel",
                CarModel = "Vectra",
                CarCategory = "Saloon",
                CarColor = "White",
                CarEngineType = "Gasoline / LPG",
                CarExtras = "CD Player, Electric windows, electric mirrors, AC",
                CarHorsePower = 130,
                CarLocation = "Nqkude",
                CarPrice = 5000m,
                CarTransmission = "Manual",
                CarYearOfProduction = 2006,
                Title = "Opel Vectra; Good Quality",
                AdditionalInfo = "The car is ina great shape! You can drive it anywhere without a problem!",
                Pictures = new List<IFormFile>() { fakeImage }
            };

            var engineType = service.GetCarEngineType(inputModel.CarEngineType);
            var transmission = service.GetCarTransmissionType(inputModel.CarTransmission);
            var category = service.GetCarCategory(inputModel.CarCategory);
            var extras = service.CreateCarExtras(inputModel.CarExtras);

            var car = service.CreateCar(inputModel, engineType, transmission, category, extras);

            var carAdd = service.CreateCarAdd(inputModel, car.Id, "1");

            var getViewAddModel = service.GetViewAddModel(carAdd.Id);

            Assert.True(getViewAddModel.Id == carAdd.Id);
            Assert.True(getViewAddModel.Make == "Opel");
        }

        [Fact]
        public void SellCarWorksCorrectly()
        {
            var options = new DbContextOptionsBuilder<DealershipDbContext>()
                .UseInMemoryDatabase(databaseName: "Sell_Car")
                .Options;

            var db = new DealershipDbContext(options);

            var service = new CarAddsService(db);

            var imageMock = new Mock<IFormFile>();

            var content = "Fake file";

            var fileName = "text.jpg";

            var memoryStream = new MemoryStream();

            var writer = new StreamWriter(memoryStream);

            writer.Write(content);
            writer.Flush();

            memoryStream.Position = 0;

            imageMock.Setup(_ => _.OpenReadStream()).Returns(memoryStream);
            imageMock.Setup(_ => _.FileName).Returns(fileName);
            imageMock.Setup(_ => _.Length).Returns(memoryStream.Length);

            var fakeImage = imageMock.Object;

            var inputModel = new CarAddInputModel
            {
                CarMake = "Opel",
                CarModel = "Vectra",
                CarCategory = "Saloon",
                CarColor = "White",
                CarEngineType = "Gasoline / LPG",
                CarExtras = "CD Player, Electric windows, electric mirrors, AC",
                CarHorsePower = 130,
                CarLocation = "Nqkude",
                CarPrice = 5000m,
                CarTransmission = "Manual",
                CarYearOfProduction = 2006,
                Title = "Opel Vectra; Good Quality",
                AdditionalInfo = "The car is ina great shape! You can drive it anywhere without a problem!",
                Pictures = new List<IFormFile>() { fakeImage }
            };

            var engineType = service.GetCarEngineType(inputModel.CarEngineType);
            var transmission = service.GetCarTransmissionType(inputModel.CarTransmission);
            var category = service.GetCarCategory(inputModel.CarCategory);
            var extras = service.CreateCarExtras(inputModel.CarExtras);

            var car = service.CreateCar(inputModel, engineType, transmission, category, extras);

            var carAdd = service.CreateCarAdd(inputModel, car.Id, "1");

            Assert.True(carAdd.Car.IsSold == false);

            service.SellCar(carAdd.Id);

            Assert.True(carAdd.Car.IsSold == true);
        }

        [Fact]
        public void GetMyAddsWorksCorrectly()
        {
            var options = new DbContextOptionsBuilder<DealershipDbContext>()
                .UseInMemoryDatabase(databaseName: "Get_My_Adds")
                .Options;

            var db = new DealershipDbContext(options);

            var userMock = new Mock<DealershipUser>();

            userMock.Setup(u => u.Id).Returns("1");
            userMock.Setup(u => u.UserName).Returns("Pesho");

            var service = new CarAddsService(db);

            var imageMock = new Mock<IFormFile>();

            var content = "Fake file";

            var fileName = "text.jpg";

            var memoryStream = new MemoryStream();

            var writer = new StreamWriter(memoryStream);

            writer.Write(content);
            writer.Flush();

            memoryStream.Position = 0;

            imageMock.Setup(_ => _.OpenReadStream()).Returns(memoryStream);
            imageMock.Setup(_ => _.FileName).Returns(fileName);
            imageMock.Setup(_ => _.Length).Returns(memoryStream.Length);

            var fakeImage = imageMock.Object;

            var inputModel = new CarAddInputModel
            {
                CarMake = "Opel",
                CarModel = "Vectra",
                CarCategory = "Saloon",
                CarColor = "White",
                CarEngineType = "Gasoline / LPG",
                CarExtras = "CD Player, Electric windows, electric mirrors, AC",
                CarHorsePower = 130,
                CarLocation = "Nqkude",
                CarPrice = 5000m,
                CarTransmission = "Manual",
                CarYearOfProduction = 2006,
                Title = "Opel Vectra; Good Quality",
                AdditionalInfo = "The car is ina great shape! You can drive it anywhere without a problem!",
                Pictures = new List<IFormFile>() { fakeImage }
            };

            var engineType = service.GetCarEngineType(inputModel.CarEngineType);
            var transmission = service.GetCarTransmissionType(inputModel.CarTransmission);
            var category = service.GetCarCategory(inputModel.CarCategory);
            var extras = service.CreateCarExtras(inputModel.CarExtras);

            var car = service.CreateCar(inputModel, engineType, transmission, category, extras);

            var carAdd = service.CreateCarAdd(inputModel, car.Id, "1");

            userMock.Setup(u => u.CarAdds).Returns(new List<CarAdd> { carAdd });

            var fakeUser = userMock.Object;

            db.Users.Add(fakeUser);
            db.SaveChanges();

            var myAdds = service.GetMyAdds("Pesho");

            Assert.True(myAdds.Count() == 1);
        }
    }
}