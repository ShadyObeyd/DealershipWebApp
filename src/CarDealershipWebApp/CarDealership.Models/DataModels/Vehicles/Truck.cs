using CarDealership.Models.DataModels.Vehicles.Enums;

namespace CarDealership.Models.DataModels.Vehicles
{
    public class Truck
    {
        public int SeatsCount { get; set; }

        public int AxisCount { get; set; }

        public int LoadCapacity { get; set; } // In Kg.

        public TruckCategory Category { get; set; }
    }
}