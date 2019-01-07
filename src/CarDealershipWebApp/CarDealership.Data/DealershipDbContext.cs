using CarDealership.Models.DataModels;
using CarDealership.Models.DataModels.Adds.Vehicles;
using CarDealership.Models.DataModels.Comments;
using CarDealership.Models.DataModels.Extras;
using CarDealership.Models.DataModels.News;
using CarDealership.Models.DataModels.Pictures;
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
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        public DbSet<CarAdd> CarAdds { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<NewsClass> News { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<CarExtra> CarExtras { get; set; }

        public DbSet<CarPicture> CarPictures { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}