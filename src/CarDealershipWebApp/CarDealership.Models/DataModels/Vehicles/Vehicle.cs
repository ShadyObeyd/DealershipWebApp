using CarDealership.Models.DataModels.Contracts;
using CarDealership.Models.DataModels.Vehicles.Enums;
using System.Collections.Generic;

namespace CarDealership.Models.DataModels.Vehicles
{
    public abstract class Vehicle : BaseModel, ISellable
    {
        public Vehicle() 
            : base()
        {
            this.IsSold = false;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int YearOfProduction { get; set; }

        public int HorsePower { get; set; }

        public decimal Price { get; set; }

        public string Location { get; set; }

        public EngineType EngineType { get; set; }

        public Transmission Transmission { get; set; }

        public bool IsSold { get; set; }
    }
}