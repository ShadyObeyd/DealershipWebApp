using CarDealership.Models.DataModels.Pictures;
using CarDealership.Models.DataModels.Vehicles;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Models.DataModels.Adds.Vehicles
{
    public class MotorcycleAdd : BaseAdd
    {
        public MotorcycleAdd()
            : base()
        {
            this.Pictures = new HashSet<MotorcyclePicture>();
        }

        private const string MotorcycleIdStr = "MotorcycleId";

        [ForeignKey(MotorcycleIdStr)]
        public virtual Motorcycle Motorcycle { get; set; }

        public string MotorcycleId { get; set; }

        public virtual ICollection<MotorcyclePicture> Pictures { get; set; }
    }
}