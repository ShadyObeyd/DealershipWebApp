using CarDealership.Models.DataModels;
using CarDealership.Models.DataModels.Accessories;
using CarDealership.Models.DataModels.Adds.Accessories;
using CarDealership.Models.DataModels.Adds.Parts;
using CarDealership.Models.DataModels.Adds.Rims;
using CarDealership.Models.DataModels.Adds.Services;
using CarDealership.Models.DataModels.Adds.Tyres;
using CarDealership.Models.DataModels.Adds.Vehicles;
using CarDealership.Models.DataModels.Comments;
using CarDealership.Models.DataModels.News;
using CarDealership.Models.DataModels.Parts;
using CarDealership.Models.DataModels.Rims;
using CarDealership.Models.DataModels.Services;
using CarDealership.Models.DataModels.Tyres;
using CarDealership.Models.DataModels.Vehicles;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Data
{
    public class DealershipDbContext : IdentityDbContext<DealershipUser>
    {
        public DealershipDbContext(DbContextOptions<DealershipDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        public DbSet<CarAdd> CarAdds { get; set; }

        public DbSet<TruckAdd> TruckAdds { get; set; }

        public DbSet<MotorcycleAdd> MotorcycleAdds { get; set; }

        public DbSet<TyreAdd> TyreAdds { get; set; }

        public DbSet<RimAdd> RimAdds { get; set; }

        public DbSet<ServiceAdd> ServiceAdds { get; set; }

        public DbSet<PartAdd> PartAdds { get; set; }

        public DbSet<AccessoryAdd> AccessoryAdds { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Truck> Trucks { get; set; }

        public DbSet<Motorcycle> Motorcycles { get; set; }

        public DbSet<Tyre> Tyres { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Rim> Rims { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<NewsClass> News { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Extra> Extras { get; set; }

        public DbSet<Accessory> Accessories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}