using CarDealership.Models.DataModels.Tyres;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Models.DataModels.Adds.Tyres
{
    public class TyreAdd : BaseAdd
    {
        private const string TyreIdStr = "TyreId";

        [ForeignKey(TyreIdStr)]
        public virtual Tyre Tyre { get; set; }

        public string TyreId { get; set; }
    }
}
