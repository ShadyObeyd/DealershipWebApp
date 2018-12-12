using CarDealership.Models.DataModels.Contracts;
using CarDealership.Models.DataModels.Parts.Enums;

namespace CarDealership.Models.DataModels.Parts
{
    public class Part : BaseModel, ISellable
    {
        public string Name { get; set; }

        public PartCategory Category { get; set; }

        public decimal PriceFrom { get; set; }

        public decimal PriceTo { get; set; }

        public string Location { get; set; }
    }
}