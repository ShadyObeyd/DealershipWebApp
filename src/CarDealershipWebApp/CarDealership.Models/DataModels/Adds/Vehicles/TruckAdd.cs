using CarDealership.Models.DataModels.Vehicles;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Models.DataModels.Adds.Vehicles
{
    public class TruckAdd : BaseAdd
    {
        private const string TruckIdStr = "TruckId";

        [ForeignKey(TruckIdStr)]
        public virtual Truck Truck { get; set; }

        public string TruckId { get; set; }
    }
}