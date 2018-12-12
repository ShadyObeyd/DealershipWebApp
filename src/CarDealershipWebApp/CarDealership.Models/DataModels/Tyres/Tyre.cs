using CarDealership.Models.DataModels.Contracts;

namespace CarDealership.Models.DataModels.Tyres
{
    public class Tyre : BaseModel, ISellable
    {
        public string Make { get; set; }

        public int SppedIndex { get; set; }

        public int WeightIndex { get; set; }
    }
}
