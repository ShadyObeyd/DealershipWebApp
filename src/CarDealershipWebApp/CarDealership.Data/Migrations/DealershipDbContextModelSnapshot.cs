﻿// <auto-generated />
using System;
using CarDealership.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarDealership.Data.Migrations
{
    [DbContext(typeof(DealershipDbContext))]
    partial class DealershipDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarDealership.Models.DataModels.Adds.Vehicles.CarAdd", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalInfo");

                    b.Property<string>("CarId");

                    b.Property<string>("CreatorId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique()
                        .HasFilter("[CarId] IS NOT NULL");

                    b.HasIndex("CreatorId");

                    b.ToTable("CarAdds");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.Adds.Vehicles.MotorcycleAdd", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalInfo");

                    b.Property<string>("CreatorId");

                    b.Property<string>("MotorcycleId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("MotorcycleId")
                        .IsUnique()
                        .HasFilter("[MotorcycleId] IS NOT NULL");

                    b.ToTable("MotorcycleAdds");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.Adds.Vehicles.TruckAdd", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalInfo");

                    b.Property<string>("CreatorId");

                    b.Property<string>("Title");

                    b.Property<string>("TruckId");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("TruckId")
                        .IsUnique()
                        .HasFilter("[TruckId] IS NOT NULL");

                    b.ToTable("TruckAdds");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.Comments.Comment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorId");

                    b.Property<string>("Content");

                    b.Property<string>("NewsId");

                    b.Property<DateTime>("PublishedOn");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("NewsId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.DealershipUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("MiddleName");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<DateTime>("RegisteredOn");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.Extras.CarExtra", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CarId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("CarExtras");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.Extras.MotorcycleExtra", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MotorcycleId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("MotorcycleId");

                    b.ToTable("MotorcycleExtras");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.Extras.TruckExtra", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("TruckId");

                    b.HasKey("Id");

                    b.HasIndex("TruckId");

                    b.ToTable("TruckExtras");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.News.NewsClass", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("PublishedOn");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.Pictures.CarPicture", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CarAddId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("CarAddId");

                    b.ToTable("CarPictures");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.Pictures.MotorcyclePicture", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MotorcycleAddId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("MotorcycleAddId");

                    b.ToTable("MotorcyclePictures");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.Pictures.TruckPicture", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TruckAddId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("TruckAddId");

                    b.ToTable("TruckPictures");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.Vehicles.Car", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddId");

                    b.Property<int>("Category");

                    b.Property<string>("Color");

                    b.Property<int>("EngineType");

                    b.Property<int>("HorsePower");

                    b.Property<bool>("IsSold");

                    b.Property<string>("Location");

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.Property<decimal>("Price");

                    b.Property<int>("Transmission");

                    b.Property<int>("YearOfProduction");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.Vehicles.Motorcycle", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddId");

                    b.Property<string>("Color");

                    b.Property<int>("CoolingType");

                    b.Property<int>("CubicCentimetres");

                    b.Property<int>("EngineKind");

                    b.Property<int>("EngineType");

                    b.Property<int>("HorsePower");

                    b.Property<bool>("IsSold");

                    b.Property<string>("Location");

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.Property<decimal>("Price");

                    b.Property<int>("Transmission");

                    b.Property<int>("YearOfProduction");

                    b.HasKey("Id");

                    b.ToTable("Motorcycles");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.Vehicles.Truck", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddId");

                    b.Property<int>("AxisCount");

                    b.Property<int>("Category");

                    b.Property<string>("Color");

                    b.Property<int>("EngineType");

                    b.Property<int>("HorsePower");

                    b.Property<bool>("IsSold");

                    b.Property<int>("LoadCapacity");

                    b.Property<string>("Location");

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.Property<decimal>("Price");

                    b.Property<int>("SeatsCount");

                    b.Property<int>("Transmission");

                    b.Property<int>("YearOfProduction");

                    b.HasKey("Id");

                    b.ToTable("Trucks");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.Adds.Vehicles.CarAdd", b =>
                {
                    b.HasOne("CarDealership.Models.DataModels.Vehicles.Car", "Car")
                        .WithOne("Add")
                        .HasForeignKey("CarDealership.Models.DataModels.Adds.Vehicles.CarAdd", "CarId");

                    b.HasOne("CarDealership.Models.DataModels.DealershipUser", "Creator")
                        .WithMany("CarAdds")
                        .HasForeignKey("CreatorId");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.Adds.Vehicles.MotorcycleAdd", b =>
                {
                    b.HasOne("CarDealership.Models.DataModels.DealershipUser", "Creator")
                        .WithMany("MotorcycleAdds")
                        .HasForeignKey("CreatorId");

                    b.HasOne("CarDealership.Models.DataModels.Vehicles.Motorcycle", "Motorcycle")
                        .WithOne("Add")
                        .HasForeignKey("CarDealership.Models.DataModels.Adds.Vehicles.MotorcycleAdd", "MotorcycleId");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.Adds.Vehicles.TruckAdd", b =>
                {
                    b.HasOne("CarDealership.Models.DataModels.DealershipUser", "Creator")
                        .WithMany("TruckAdds")
                        .HasForeignKey("CreatorId");

                    b.HasOne("CarDealership.Models.DataModels.Vehicles.Truck", "Truck")
                        .WithOne("Add")
                        .HasForeignKey("CarDealership.Models.DataModels.Adds.Vehicles.TruckAdd", "TruckId");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.Comments.Comment", b =>
                {
                    b.HasOne("CarDealership.Models.DataModels.DealershipUser", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorId");

                    b.HasOne("CarDealership.Models.DataModels.News.NewsClass", "News")
                        .WithMany("Comments")
                        .HasForeignKey("NewsId");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.Extras.CarExtra", b =>
                {
                    b.HasOne("CarDealership.Models.DataModels.Vehicles.Car", "Car")
                        .WithMany("Extras")
                        .HasForeignKey("CarId");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.Extras.MotorcycleExtra", b =>
                {
                    b.HasOne("CarDealership.Models.DataModels.Vehicles.Motorcycle", "Motorcycle")
                        .WithMany("Extras")
                        .HasForeignKey("MotorcycleId");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.Extras.TruckExtra", b =>
                {
                    b.HasOne("CarDealership.Models.DataModels.Vehicles.Truck", "Truck")
                        .WithMany("Extras")
                        .HasForeignKey("TruckId");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.News.NewsClass", b =>
                {
                    b.HasOne("CarDealership.Models.DataModels.DealershipUser", "Author")
                        .WithMany("News")
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.Pictures.CarPicture", b =>
                {
                    b.HasOne("CarDealership.Models.DataModels.Adds.Vehicles.CarAdd", "CarAdd")
                        .WithMany("Pictures")
                        .HasForeignKey("CarAddId");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.Pictures.MotorcyclePicture", b =>
                {
                    b.HasOne("CarDealership.Models.DataModels.Adds.Vehicles.MotorcycleAdd", "MotorcycleAdd")
                        .WithMany("Pictures")
                        .HasForeignKey("MotorcycleAddId");
                });

            modelBuilder.Entity("CarDealership.Models.DataModels.Pictures.TruckPicture", b =>
                {
                    b.HasOne("CarDealership.Models.DataModels.Adds.Vehicles.TruckAdd", "TruckAdd")
                        .WithMany("Pictures")
                        .HasForeignKey("TruckAddId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CarDealership.Models.DataModels.DealershipUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CarDealership.Models.DataModels.DealershipUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarDealership.Models.DataModels.DealershipUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CarDealership.Models.DataModels.DealershipUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
