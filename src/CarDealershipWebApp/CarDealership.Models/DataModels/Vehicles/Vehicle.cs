using CarDealership.Models.DataModels.MappingTables.Vehicles;
using CarDealership.Models.DataModels.Vehicles.Enums;
using System.Collections.Generic;

namespace CarDealership.Models.DataModels.Vehicles
{
    public abstract class Vehicle : BaseModel
    {
        public Vehicle() 
            : base()
        {
            this.Extras = new HashSet<VehicleExtra>();
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public decimal PriceFrom { get; set; }

        public decimal PriceTo { get; set; }

        public string Color { get; set; }

        public int YearOfProduction { get; set; }

        public int HorsePower { get; set; }

        public string Location { get; set; }

        public EngineType EngineType { get; set; }

        public Transmission Transmission { get; set; }

        public virtual ICollection<VehicleExtra> Extras { get; set; }
    }
}