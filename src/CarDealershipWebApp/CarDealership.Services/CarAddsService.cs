using CarDealership.Data;
using CarDealership.Models.DataModels.Adds.Vehicles;
using CarDealership.Models.DataModels.Extras;
using CarDealership.Models.DataModels.Vehicles;
using CarDealership.Models.DataModels.Vehicles.Enums;
using CarDealership.Models.ViewModels.Adds.CarAdds;
using CarDealership.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealership.Services
{
    public class CarAddsService
    {
        private readonly DealershipDbContext db;

        private const char CommaSeparator = ',';

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

            var carAdd = new CarAdd
            {
                Title = model.Title,
                CarId = carId,
                AdditionalInfo = model.AdditionalInfo,
                CreatorId = creatorId
            };

            this.db.CarAdds.Add(carAdd);
            this.db.SaveChanges();

            return carAdd;
        }
    }
}