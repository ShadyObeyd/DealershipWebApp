using CarDealership.Models.DataModels.Vehicles;
using System.Collections.Generic;

namespace CarDealership.Models.DataModels
{
    public class Extra : BaseModel
    {
        public string Name { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}