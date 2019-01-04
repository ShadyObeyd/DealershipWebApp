using CarDealership.Models.DataModels.Vehicles;

namespace CarDealership.Models.DataModels.Extras
{
    public class CarExtra : BaseExtra
    {
        public virtual Car Car { get; set; }

        public string CarId { get; set; }
    }
}
