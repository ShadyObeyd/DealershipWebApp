﻿using CarDealership.Models.DataModels.Vehicles;

namespace CarDealership.Models.DataModels.MappingTables.Vehicles
{
    public class VehicleExtra
    {
        public string VehicleId { get; set; }

        public string ExtraId { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        public virtual Extra Extra { get; set; }
    }
}