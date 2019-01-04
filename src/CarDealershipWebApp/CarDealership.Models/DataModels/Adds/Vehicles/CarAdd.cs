using CarDealership.Models.DataModels.Pictures;
using CarDealership.Models.DataModels.Vehicles;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Models.DataModels.Adds.Vehicles
{
    public class CarAdd : BaseAdd
    {
        private const string CarIdStr = "CarId";

        public CarAdd()
            : base()
        {
            this.Pictures = new HashSet<CarPicture>();
        }

        [ForeignKey(CarIdStr)]
        public virtual Car Car { get; set; }

        public string CarId { get; set; }

        public virtual ICollection<CarPicture> Pictures { get; set; }
    }
}