using CarDealership.Models.DataModels.Contracts;
using CarDealership.Models.DataModels.Services.Enums;

namespace CarDealership.Models.DataModels.Services
{
    public class Service : BaseModel, ISellable
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ServiceType ServiceType { get; set; }
    }
}
