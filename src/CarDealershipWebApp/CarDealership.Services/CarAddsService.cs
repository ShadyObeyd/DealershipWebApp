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
        private const decimal PriceMinValue = 1m;
        private const decimal PriceMaxValue = decimal.MaxValue;
        private const string Slash = "\\";
        private const string ImagesFolderName = "images";
        private const string CarImagesFolerName = "CarImages";
        private const string CarExtrasJoinPattern = ", ";

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

                var pictureDirectory = Directory.GetCurrentDirectory() + Slash + Constants.RootDirectory + Slash + ImagesFolderName + Slash + CarImagesFolerName;

                var directory = Directory.CreateDirectory(pictureDirectory).ToString();

                var path = Path.Combine(directory, picture.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    picture.CopyTo(stream);
                }

                var carPicture = new CarPicture
                {
                    Url = Slash + ImagesFolderName + Slash + CarImagesFolerName + Slash + picture.FileName
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

        public List<ViewAddsModel> GetAddsAccordingToCriteria(CarSelectInputModel inputModel)
        {
            if (inputModel.StartingPrice < PriceMinValue)
            {
                inputModel.StartingPrice = PriceMinValue;
            }

            if (inputModel.StartingYear < Constants.YearMinValue)
            {
                inputModel.StartingYear = Constants.YearMinValue;
            }

            if (inputModel.EndYear == 0)
            {
                inputModel.EndYear = DateTime.Now.Year;
            }

            if (inputModel.EndPrice == PriceMinValue)
            {
                inputModel.EndPrice = PriceMaxValue;
            }

            if (string.IsNullOrEmpty(inputModel.Location))
            {
                return this.db.CarAdds
                .Where(ca => ca.Car.Make == inputModel.Make &&
                             ca.Car.Model == inputModel.Model &&
                             ca.Car.Price >= inputModel.StartingPrice &&
                             ca.Car.Price <= inputModel.EndPrice &&
                             ca.Car.YearOfProduction >= inputModel.StartingYear &&
                             ca.Car.YearOfProduction <= inputModel.EndYear &&
                             ca.Car.HorsePower == inputModel.HorsePower &&
                             ca.Car.Transmission == this.GetCarTransmissionType(inputModel.Transmission) &&
                             ca.Car.EngineType == this.GetCarEngineType(inputModel.EngineType) &&
                             ca.Car.Category == this.GetCarCategory(inputModel.Category) &&
                             ca.Car.IsSold == false)
                .Select(ca => new ViewAddsModel
                {
                    Id = ca.Id,
                    Title = ca.Title,
                    PictureUrl = this.db.CarPictures.FirstOrDefault(p => p.CarAddId == ca.Id).Url,
                    AdditionalInfo = ca.AdditionalInfo
                })
                .ToList();
            }
            else
            {
                return this.db.CarAdds
                .Where(ca => ca.Car.Make == inputModel.Make &&
                             ca.Car.Model == inputModel.Model &&
                             ca.Car.Price >= inputModel.StartingPrice &&
                             ca.Car.Price <= inputModel.EndPrice &&
                             ca.Car.YearOfProduction >= inputModel.StartingYear &&
                             ca.Car.YearOfProduction <= inputModel.EndYear &&
                             ca.Car.HorsePower == inputModel.HorsePower &&
                             ca.Car.Transmission == this.GetCarTransmissionType(inputModel.Transmission) &&
                             ca.Car.EngineType == this.GetCarEngineType(inputModel.EngineType) &&
                             ca.Car.Category == this.GetCarCategory(inputModel.Category) &&
                             ca.Car.Location == inputModel.Location &&
                             ca.Car.IsSold == false)
                .Select(ca => new ViewAddsModel
                {
                    Id = ca.Id,
                    Title = ca.Title,
                    PictureUrl = this.db.CarPictures.FirstOrDefault(p => p.CarAddId == ca.Id).Url,
                    AdditionalInfo = ca.AdditionalInfo
                })
                .ToList();
            }
        }

        public CarAddToBuyViewModel GetViewAddModel(string addId)
        {
            if (!this.db.CarAdds.Any(ca => ca.Id == addId))
            {
                throw new ArgumentException();
            }

            var carId = this.db.CarAdds.FirstOrDefault(ca => ca.Id == addId).CarId;

            var engineType = this.db.Cars.FirstOrDefault(c => c.Id == carId).EngineType.ToString();

            if (engineType == Constants.GasolineAndLpgEngineTypeCorrection)
            {
                engineType = Constants.GasolineAndLpgEngineTypeInput;
            }

            var picturesUrls = this.db.CarPictures.Where(p => p.CarAddId == addId).Select(p => p.Url).ToList();

            var addModel = this.db.CarAdds.Where(ca => ca.Id == addId).Select(ca => new CarAddToBuyViewModel
            {
                Category = ca.Car.Category,
                Color = ca.Car.Color,
                EngineType = engineType,
                HorsePower = ca.Car.HorsePower,
                Location = ca.Car.Location,
                Make = ca.Car.Make,
                Model = ca.Car.Model,
                Price = ca.Car.Price,
                Transmission = ca.Car.Transmission,
                YearOfProduction = ca.Car.YearOfProduction,
                OwnerName = ca.Creator.UserName,
                OwnerEmail = ca.Creator.Email,
                OwnerPhone = ca.Creator.PhoneNumber,
                Title = ca.Title,
                AdditionalInfo = ca.AdditionalInfo,
                PicturesUrls = picturesUrls,
                CarExtras = string.Join(CarExtrasJoinPattern, ca.Car.Extras.Select(c => c.Name).ToList())
            })
            .FirstOrDefault();

            return addModel;
        }
    }
}