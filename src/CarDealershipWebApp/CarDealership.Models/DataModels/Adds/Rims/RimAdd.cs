using CarDealership.Models.DataModels.Rims;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Models.DataModels.Adds.Rims
{
    public class RimAdd : BaseAdd
    {
        private const string RimIdStr = "RimId";

        [ForeignKey(RimIdStr)]
        public virtual Rim Rim { get; set; }

        public string RimId { get; set; }
    }
}
