using CarDealership.Models.DataModels.Vehicles.Enums;

namespace CarDealership.Models.DataModels.Vehicles
{
    public class Car : Vehicle
    {
        public CarCategory Category { get; set; }
    }
}