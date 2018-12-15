using CarDealership.Models.DataModels.Adds.Vehicles;
using CarDealership.Models.DataModels.Vehicles.Enums;
using System.Collections.Generic;

namespace CarDealership.Models.DataModels.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle() : base()
        {
            this.Extras = new HashSet<Extra>();
        }

        public int CubicCentimetres { get; set; }

        public CoolingType CoolingType { get; set; }

        public EngineKind EngineKind { get; set; }

        public virtual MotorcycleAdd Add { get; set; }

        public string AddId { get; set; }

        public virtual ICollection<Extra> Extras { get; set; }
    }
}
