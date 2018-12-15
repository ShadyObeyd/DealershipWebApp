using CarDealership.Models.DataModels.Adds.Tyres;
using CarDealership.Models.DataModels.Contracts;
using CarDealership.Models.DataModels.Tyres.Enums;

namespace CarDealership.Models.DataModels.Tyres
{
    public class Tyre : BaseModel, ISellable
    {
        public string Make { get; set; }

        public int SppedIndex { get; set; }

        public int WeightIndex { get; set; }

        public SeasonType SeasonType { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public decimal Price { get; set; }

        public string Location { get; set; }

        public virtual TyreAdd Add { get; set; }

        public string AddId { get; set; }
    }
}
