using CarDealership.Models.DataModels.Accessories;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Models.DataModels.Adds.Accessories
{
    public class AccessoryAdd : BaseAdd
    {
        private const string AccessoryIdStr = "AccessoryId";

        [ForeignKey(AccessoryIdStr)]
        public virtual Accessory Accessory { get; set; }

        public string AccessoryId { get; set; }
    }
}
