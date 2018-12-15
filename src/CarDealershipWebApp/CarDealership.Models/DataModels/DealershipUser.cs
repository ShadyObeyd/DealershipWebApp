using CarDealership.Models.DataModels.Adds.Parts;
using CarDealership.Models.DataModels.Adds.Rims;
using CarDealership.Models.DataModels.Adds.Services;
using CarDealership.Models.DataModels.Adds.Tyres;
using CarDealership.Models.DataModels.Adds.Vehicles;
using CarDealership.Models.DataModels.Comments;
using CarDealership.Models.DataModels.News;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace CarDealership.Models.DataModels
{
    public class DealershipUser : IdentityUser
    {
        public DealershipUser()
        {
            this.CarAdds = new HashSet<CarAdd>();
            this.TruckAdds = new HashSet<TruckAdd>();
            this.MotorcycleAdds = new HashSet<MotorcycleAdd>();
            this.PartAdds = new HashSet<PartAdd>();
            this.RimAdds = new HashSet<RimAdd>();
            this.TyreAdds = new HashSet<TyreAdd>();
            this.ServiceAdds = new HashSet<ServiceAdd>();
            this.News = new HashSet<NewsClass>();
            this.Comments = new HashSet<Comment>();
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime RegisteredOn { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<CarAdd> CarAdds { get; set; }

        public virtual ICollection<TruckAdd> TruckAdds { get; set; }

        public virtual ICollection<MotorcycleAdd> MotorcycleAdds { get; set; }

        public virtual ICollection<PartAdd> PartAdds { get; set; }

        public virtual ICollection<RimAdd> RimAdds { get; set; }

        public virtual ICollection<TyreAdd> TyreAdds { get; set; }

        public virtual ICollection<ServiceAdd> ServiceAdds { get; set; }

        public virtual ICollection<NewsClass> News { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}