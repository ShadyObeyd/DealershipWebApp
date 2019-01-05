using CarDealership.Data;
using CarDealership.Models.DataModels.Adds.Vehicles;
using CarDealership.Models.DataModels.Extras;
using CarDealership.Models.DataModels.Pictures;
using CarDealership.Models.DataModels.Vehicles;
using CarDealership.Models.DataModels.Vehicles.Enums;
using CarDealership.Models.ViewModels.Adds.CarAdds;
using CarDealership.Models.ViewModels.Errors;
using CarDealership.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarDealership.Services
{
    public class CarAddsService
    {
        private readonly DealershipDbContext db;

        private const char CommaSeparator = ',';
        private const string PictureSuffix = ".jpg";

        public CarAddsService(DealershipDbContext db)
        {
            this.db = db;
        }

        public EngineType GetCarEngineType(string modelEngineType)
        {
            if (modelEngineType == Constants.GasolineAndLpgEngineTypeInput)
            {
                modelEngineType = Constants.GasolineAndLpgEngineTypeCorrection;
            }

            if (!Enum.TryParse(modelEngineType, out EngineType engineType))
            {
                throw new ArgumentException();
            }

            return engineType;
        }

        public Transmission GetCarTransmissionType(string carTransmission)
        {
            if (!Enum.TryParse(carTransmission, out Transmission transmission))
            {
                throw new ArgumentException();
            }

            return transmission;
        }

        public CarCategory GetCarCategory(string carCategory)
        {
            if (!Enum.TryParse(carCategory, out CarCategory category))
            {
                throw new ArgumentException();
            }

            return category;
        }

        public ICollection<CarExtra> CreateCarExtras(string carExtrasInput)
        {
            var extrasTokens = carExtrasInput.Split(CommaSeparator, StringSplitOptions.RemoveEmptyEntries).Select(e => e.Trim()).ToArray();

            List<CarExtra> carExtras = new List<CarExtra>();

            foreach (var extraStr in extrasTokens)
            {
                CarExtra carExtra = new CarExtra
                {
                    Name = extraStr
                };

                carExtras.Add(carExtra);
            }

            return carExtras;
        }

        public ErrorViewModel GetErrorViewModel(string message)
        {
            return new ErrorViewModel
            {
                Message = message
            };
        }

        public Car CreateCar(CarAddInputModel model, EngineType engineType, Transmission transmission, CarCategory carCategory, ICollection<CarExtra> extras)
        {
            var car = new Car
            {
                Color = model.CarColor,
                EngineType = engineType,
                HorsePower = model.CarHorsePower,
                Location = model.CarLocation,
                Make = model.CarMake,
                Model = model.CarModel,
                YearOfProduction = model.CarYearOfProduction,
                Price = model.CarPrice,
                Transmission = transmission,
                Category = carCategory,
                Extras = extras
            };

            this.db.Cars.Add(car);
            this.db.SaveChanges();

            return car;
        }

        public CarAdd CreateCarAdd(CarAddInputModel model, string carId, string creatorId)
        {
            if (string.IsNullOrEmpty(carId))
            {
                throw new ArgumentException();
            }

            List<CarPicture> carPictures = new List<CarPicture>();

            foreach (var picture in model.Pictures)
            {
                if (!picture.FileName.EndsWith(PictureSuffix))
                {
                    throw new InvalidOperationException();
                }

                string pictureDirectory = Directory.GetCurrentDirectory() + "\\" + Constants.RootDirectory + "\\" + "images" + "\\" + "CarImages";

                var directory = Directory.CreateDirectory(pictureDirectory).ToString();

                var path = Path.Combine(directory, picture.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    picture.CopyTo(stream);
                }

                var carPicture = new CarPicture
                {
                    Url = path
                };

                carPictures.Add(carPicture);
            }

            var carAdd = new CarAdd
            {
                Title = model.Title,
                CarId = carId,
                AdditionalInfo = model.AdditionalInfo,
                CreatorId = creatorId,
                Pictures = carPictures
            };

            this.db.CarAdds.Add(carAdd);
            this.db.SaveChanges();

            return carAdd;
        }
    }
}