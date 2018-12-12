using CarDealership.Models.DataModels.Accessories.Enums;
using CarDealership.Models.DataModels.Contracts;

namespace CarDealership.Models.DataModels.Accessories
{
    public class Accessory : BaseModel, ISellable
    {
        public AccessoryType AccessoryType { get; set; }
    }
}
