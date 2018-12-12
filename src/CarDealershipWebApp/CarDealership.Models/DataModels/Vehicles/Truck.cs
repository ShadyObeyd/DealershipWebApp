using CarDealership.Models.DataModels.Vehicles.Enums;

namespace CarDealership.Models.DataModels.Vehicles
{
    public class Truck
    {
        public int SeatsCount { get; set; }

        public TruckCategory Category { get; set; }
    }
}