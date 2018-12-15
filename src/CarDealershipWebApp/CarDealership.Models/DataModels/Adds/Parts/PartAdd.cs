using CarDealership.Models.DataModels.Parts;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Models.DataModels.Adds.Parts
{
    public class PartAdd : BaseAdd
    {
        private const string PartIdStr = "PartId";

        [ForeignKey(PartIdStr)]
        public virtual Part Part { get; set; }

        public string PartId { get; set; }
    }
}
