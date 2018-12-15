using CarDealership.Models.DataModels.Accessories.Enums;
using CarDealership.Models.DataModels.Contracts;
using CarDealership.Models.DataModels.Vehicles;

namespace CarDealership.Models.DataModels.Accessories
{
    public class Accessory : BaseModel, ISellable
    {
        public AccessoryType AccessoryType { get; set; }

        public decimal Price { get; set; }

        public string Location { get; set; }
    }
}
