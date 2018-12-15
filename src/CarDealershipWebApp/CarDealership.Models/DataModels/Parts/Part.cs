using CarDealership.Models.DataModels.Adds.Parts;
using CarDealership.Models.DataModels.Contracts;
using CarDealership.Models.DataModels.Parts.Enums;

namespace CarDealership.Models.DataModels.Parts
{
    public class Part : BaseModel, ISellable
    {
        public string Name { get; set; }

        public PartCategory Category { get; set; }

        public decimal Price { get; set; }

        public string Location { get; set; }

        public virtual PartAdd Add { get; set; }

        public string AddId { get; set; }
    }
}