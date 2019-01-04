using CarDealership.Models.DataModels.Adds.Vehicles;
using CarDealership.Models.DataModels.Extras;
using CarDealership.Models.DataModels.Vehicles.Enums;
using System.Collections.Generic;

namespace CarDealership.Models.DataModels.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck() 
            : base()
        {
            this.Extras = new HashSet<TruckExtra>();
        }

        public int SeatsCount { get; set; }

        public int AxisCount { get; set; }

        public int LoadCapacity { get; set; } // In Kg.

        public TruckCategory Category { get; set; }

        public virtual TruckAdd Add { get; set; }

        public string AddId { get; set; }

        public virtual ICollection<TruckExtra> Extras { get; set; }
    }
}