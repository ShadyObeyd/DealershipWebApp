using CarDealership.Models.DataModels.Adds.Rims;
using CarDealership.Models.DataModels.Contracts;

namespace CarDealership.Models.DataModels.Rims
{
    public class Rim : BaseModel, ISellable
    {
        public string CarMake { get; set; }

        public string CarModel { get; set; }

        public string RimMake { get; set; }

        public int BoltsCount { get; set; }

        public decimal Price { get; set; }

        public string Location { get; set; }

        public virtual RimAdd Add { get; set; }

        public string AddId { get; set; }
    }
}
