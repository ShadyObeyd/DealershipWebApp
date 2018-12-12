using CarDealership.Models.DataModels.Vehicles.Enums;

namespace CarDealership.Models.DataModels.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public int CubicCentimetres { get; set; }

        public CoolingType CoolingType { get; set; }

        public EngineKind EngineKind { get; set; }
    }
}
