using CarDealership.Data;
using CarDealership.Models.ViewModels.Adds;
using CarDealership.Models.ViewModels.Adds.CarAdds;
using CarDealership.Models.ViewModels.Adds.MotorcycleAdds;
using CarDealership.Models.ViewModels.Adds.TruckAdds;
using System.Linq;

namespace CarDealership.Services
{
    public class AddsService
    {
        private readonly DealershipDbContext db;

        public AddsService(DealershipDbContext db)
        {
            this.db = db;
        }

        public MyAddsViewModel GetMyAdds(string username)
        {
            var carAdds = this.db.CarAdds.Where(ca => ca.Creator.UserName == username)
                .Select(ca => new ViewCarAddsViewModel
                {
                    Id = ca.Id,
                    AdditionalInfo = ca.AdditionalInfo,
                    PictureUrl = this.db.CarPictures.FirstOrDefault(p => p.CarAddId == ca.Id).Url,
                    Title = ca.Title
                })
                .ToList();

            var truckAdds = this.db.TruckAdds.Where(ta => ta.Creator.UserName == username).Select(ta => new ViewTruckAddsViewModel
            {
                Id = ta.Id,
                AdditionalInfo = ta.AdditionalInfo,
                PictureUrl = this.db.TruckPictures.FirstOrDefault(p => p.TruckAddId == ta.Id).Url,
                Title = ta.Title
            })
            .ToList();

            var bikeAdds = this.db.MotorcycleAdds.Where(ma => ma.Creator.UserName == username)
                .Select(ma => new ViewMotorcycleAddsViewModel
                {
                    Id = ma.Id,
                    Title = ma.Title,
                    AdditionalInfo = ma.AdditionalInfo,
                    PictureUrl = this.db.MotorcyclePictures.FirstOrDefault(p => p.MotorcycleAddId == ma.Id).Url
                })
                .ToList();

            var model = new MyAddsViewModel
            {
                CarAdds = carAdds,
                TruckAdds = truckAdds,
                MotorcycleAdds = bikeAdds
            };

            return model;
        }
    }
}
