using CarDealership.Models.DataModels.Adds.Vehicles;

namespace CarDealership.Models.DataModels.Pictures
{
    public class CarPicture : BasePicture
    {
        public virtual CarAdd CarAdd { get; set; }

        public string CarAddId { get; set; }
    }
}
