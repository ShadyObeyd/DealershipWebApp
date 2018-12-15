using CarDealership.Models.DataModels.Vehicles;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Models.DataModels.Adds.Vehicles
{
    public class CarAdd : BaseAdd
    {
        private const string CarIdStr = "CarId";

        [ForeignKey(CarIdStr)]
        public virtual Car Car { get; set; }

        public string CarId { get; set; }
    }
}
