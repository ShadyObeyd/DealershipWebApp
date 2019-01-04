﻿using CarDealership.Models.DataModels.Pictures;
using CarDealership.Models.DataModels.Vehicles;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Models.DataModels.Adds.Vehicles
{
    public class TruckAdd : BaseAdd
    {
        private const string TruckIdStr = "TruckId";

        public TruckAdd()
            : base()
        {
            this.Pictures = new HashSet<TruckPicture>();
        }

        [ForeignKey(TruckIdStr)]
        public virtual Truck Truck { get; set; }

        public string TruckId { get; set; }

        public virtual ICollection<TruckPicture> Pictures { get; set; }
    }
}