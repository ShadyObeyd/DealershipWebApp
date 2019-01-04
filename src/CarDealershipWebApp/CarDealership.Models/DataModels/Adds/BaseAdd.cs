using System.Collections.Generic;

namespace CarDealership.Models.DataModels.Adds
{
    public class BaseAdd : BaseModel
    {
        public string Title { get; set; }

        public string AdditionalInfo { get; set; }

        public virtual DealershipUser Creator { get; set; }

        public string CreatorId { get; set; }
    }
}