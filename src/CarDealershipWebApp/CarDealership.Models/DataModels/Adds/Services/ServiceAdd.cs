using CarDealership.Models.DataModels.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Models.DataModels.Adds.Services
{
    public class ServiceAdd : BaseAdd
    {
        private const string ServiceIdStr = "ServiceId";

        [ForeignKey(ServiceIdStr)]
        public virtual Service Service { get; set; }

        public string ServiceId { get; set; }
    }
}