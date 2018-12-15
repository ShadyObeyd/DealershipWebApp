using CarDealership.Models.DataModels.Vehicles;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Models.DataModels.Adds.Vehicles
{
    public class MotorcycleAdd : BaseAdd
    {
        private const string MotorcycleIdStr = "MotorcycleId";

        [ForeignKey(MotorcycleIdStr)]
        public virtual Motorcycle Motorcycle { get; set; }

        public string MotorcycleId { get; set; }
    }
}
