using CarDealership.Models.DataModels.Adds.Vehicles;

namespace CarDealership.Models.DataModels.Pictures
{
    public class MotorcyclePicture : BasePicture
    {
        public virtual MotorcycleAdd MotorcycleAdd { get; set; }

        public string MotorcycleAddId { get; set; }
    }
}
