using CarDealership.Models.DataModels.Contracts;
using CarDealership.Models.DataModels.Parts.Enums;

namespace CarDealership.Models.DataModels.Parts
{
    public class Part : BaseModel, ISellable
    {
        public string Name { get; set; }

        public PartCategory Category { get; set; }
    }
}