using CarDealership.Models.DataModels.MappingTables.Vehicles;
using System.Collections.Generic;

namespace CarDealership.Models.DataModels
{
    public class Extra : BaseModel
    {
        public Extra()
            : base()
        {
            this.Vehicles = new HashSet<VehicleExtra>();
        }

        public string Name { get; set; }

        public virtual ICollection<VehicleExtra> Vehicles { get; set; }
    }
}