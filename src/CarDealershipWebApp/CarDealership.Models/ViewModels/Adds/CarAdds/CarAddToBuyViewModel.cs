using CarDealership.Models.DataModels.Vehicles.Enums;
using System.Collections.Generic;

namespace CarDealership.Models.ViewModels.Adds.CarAdds
{
    public class CarAddToBuyViewModel
    {
        public string Title { get; set; }

        public string AdditionalInfo { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int YearOfProduction { get; set; }

        public int HorsePower { get; set; }

        public decimal Price { get; set; }

        public string Location { get; set; }

        public string EngineType { get; set; }

        public Transmission Transmission { get; set; }

        public CarCategory Category { get; set; }

        public string OwnerName { get; set; }

        public string OwnerPhone { get; set; }

        public string OwnerEmail { get; set; }

        public ICollection<string> PicturesUrls { get; set; }

        public string CarExtras { get; set; }
    }
}
