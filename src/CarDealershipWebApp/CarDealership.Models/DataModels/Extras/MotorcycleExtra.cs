using CarDealership.Models.DataModels.Vehicles;

namespace CarDealership.Models.DataModels.Extras
{
    public class MotorcycleExtra : BaseExtra
    {
        public virtual Motorcycle Motorcycle { get; set; }

        public string MotorcycleId { get; set; }
    }
}
