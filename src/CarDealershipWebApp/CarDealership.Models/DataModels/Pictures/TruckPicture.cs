using CarDealership.Models.DataModels.Adds.Vehicles;

namespace CarDealership.Models.DataModels.Pictures
{
    public class TruckPicture : BasePicture
    {
        public virtual TruckAdd TruckAdd { get; set; }

        public string TruckAddId { get; set; }
    }
}
