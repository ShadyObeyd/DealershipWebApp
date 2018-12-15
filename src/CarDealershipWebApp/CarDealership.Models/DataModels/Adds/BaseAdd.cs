using System.Collections.Generic;

namespace CarDealership.Models.DataModels.Adds
{
    public class BaseAdd : BaseModel
    {
        public BaseAdd() 
            : base()
        {
            this.Pictures = new HashSet<Picture>();
        }

        public string Title { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public string AdditionalInfo { get; set; }

        public virtual DealershipUser Creator { get; set; }

        public string CreatorId { get; set; }
    }
}