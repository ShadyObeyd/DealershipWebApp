using CarDealership.Models.DataModels.Parts.Enums;

namespace CarDealership.Models.DataModels.Parts
{
    public class Part : BaseModel
    {
        public string Name { get; set; }

        public PartCategory Category { get; set; }
    }
}