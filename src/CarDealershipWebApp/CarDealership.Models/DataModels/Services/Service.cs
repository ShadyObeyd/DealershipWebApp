using CarDealership.Models.DataModels.Adds.Services;
using CarDealership.Models.DataModels.Contracts;
using CarDealership.Models.DataModels.Services.Enums;

namespace CarDealership.Models.DataModels.Services
{
    public class Service : BaseModel, ISellable
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ServiceType ServiceType { get; set; }

        public decimal Price { get; set; }

        public string Location { get; set; }

        public virtual ServiceAdd Add { get; set; }

        public string AddId { get; set; }
    }
}