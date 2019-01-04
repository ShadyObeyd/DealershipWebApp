using CarDealership.Models.DataModels.Vehicles;

namespace CarDealership.Models.DataModels.Extras
{
    public class TruckExtra : BaseExtra
    {
        public virtual Truck Truck { get; set; }

        public string TruckId { get; set; }
    }
}
