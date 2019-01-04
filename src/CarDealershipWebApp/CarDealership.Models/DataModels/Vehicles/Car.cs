using CarDealership.Models.DataModels.Adds.Vehicles;
using CarDealership.Models.DataModels.Extras;
using CarDealership.Models.DataModels.Vehicles.Enums;
using System.Collections.Generic;

namespace CarDealership.Models.DataModels.Vehicles
{
    public class Car : Vehicle
    {
        public Car() 
            : base()
        {
            this.Extras = new HashSet<CarExtra>();
        }

        public CarCategory Category { get; set; }

        public virtual CarAdd Add { get; set; }

        public string AddId { get; set; }

        public virtual ICollection<CarExtra> Extras { get; set; }
    }
}