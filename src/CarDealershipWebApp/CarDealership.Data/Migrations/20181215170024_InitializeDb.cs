using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealership.Data.Migrations
{
    public partial class InitializeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisteredOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Accessories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessoryType = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    YearOfProduction = table.Column<int>(nullable: false),
                    HorsePower = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    EngineType = table.Column<int>(nullable: false),
                    Transmission = table.Column<int>(nullable: false),
                    IsSold = table.Column<bool>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    AddId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motorcycles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    YearOfProduction = table.Column<int>(nullable: false),
                    HorsePower = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    EngineType = table.Column<int>(nullable: false),
                    Transmission = table.Column<int>(nullable: false),
                    IsSold = table.Column<bool>(nullable: false),
                    CubicCentimetres = table.Column<int>(nullable: false),
                    CoolingType = table.Column<int>(nullable: false),
                    EngineKind = table.Column<int>(nullable: false),
                    AddId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorcycles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    AuthorName = table.Column<string>(nullable: true),
                    PublishedOn = table.Column<DateTime>(nullable: false),
                    AuthorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    AddId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rims",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CarMake = table.Column<string>(nullable: true),
                    CarModel = table.Column<string>(nullable: true),
                    RimMake = table.Column<string>(nullable: true),
                    BoltsCount = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    AddId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ServiceType = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    AddId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    YearOfProduction = table.Column<int>(nullable: false),
                    HorsePower = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    EngineType = table.Column<int>(nullable: false),
                    Transmission = table.Column<int>(nullable: false),
                    IsSold = table.Column<bool>(nullable: false),
                    SeatsCount = table.Column<int>(nullable: false),
                    AxisCount = table.Column<int>(nullable: false),
                    LoadCapacity = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    AddId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tyres",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    SppedIndex = table.Column<int>(nullable: false),
                    WeightIndex = table.Column<int>(nullable: false),
                    SeasonType = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    AddId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tyres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessoryAdds",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    AdditionalInfo = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    AccessoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoryAdds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessoryAdds_Accessories_AccessoryId",
                        column: x => x.AccessoryId,
                        principalTable: "Accessories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccessoryAdds_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarAdds",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    AdditionalInfo = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    CarId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarAdds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarAdds_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarAdds_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MotorcycleAdds",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    AdditionalInfo = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    MotorcycleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorcycleAdds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotorcycleAdds_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MotorcycleAdds_Motorcycles_MotorcycleId",
                        column: x => x.MotorcycleId,
                        principalTable: "Motorcycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    AuthorName = table.Column<string>(nullable: true),
                    PublishedOn = table.Column<DateTime>(nullable: false),
                    NewsId = table.Column<string>(nullable: true),
                    AuthorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PartAdds",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    AdditionalInfo = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    PartId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartAdds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartAdds_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartAdds_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RimAdds",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    AdditionalInfo = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    RimId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RimAdds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RimAdds_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RimAdds_Rims_RimId",
                        column: x => x.RimId,
                        principalTable: "Rims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceAdds",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    AdditionalInfo = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ServiceId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceAdds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceAdds_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceAdds_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Extras",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CarId = table.Column<string>(nullable: true),
                    MotorcycleId = table.Column<string>(nullable: true),
                    TruckId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Extras_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Extras_Motorcycles_MotorcycleId",
                        column: x => x.MotorcycleId,
                        principalTable: "Motorcycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Extras_Trucks_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Trucks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TruckAdds",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    AdditionalInfo = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    TruckId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckAdds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TruckAdds_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TruckAdds_Trucks_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Trucks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TyreAdds",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    AdditionalInfo = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    TyreId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TyreAdds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TyreAdds_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TyreAdds_Tyres_TyreId",
                        column: x => x.TyreId,
                        principalTable: "Tyres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    AccessoryAddId = table.Column<string>(nullable: true),
                    CarAddId = table.Column<string>(nullable: true),
                    MotorcycleAddId = table.Column<string>(nullable: true),
                    PartAddId = table.Column<string>(nullable: true),
                    RimAddId = table.Column<string>(nullable: true),
                    ServiceAddId = table.Column<string>(nullable: true),
                    TruckAddId = table.Column<string>(nullable: true),
                    TyreAddId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_AccessoryAdds_AccessoryAddId",
                        column: x => x.AccessoryAddId,
                        principalTable: "AccessoryAdds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pictures_CarAdds_CarAddId",
                        column: x => x.CarAddId,
                        principalTable: "CarAdds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pictures_MotorcycleAdds_MotorcycleAddId",
                        column: x => x.MotorcycleAddId,
                        principalTable: "MotorcycleAdds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pictures_PartAdds_PartAddId",
                        column: x => x.PartAddId,
                        principalTable: "PartAdds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pictures_RimAdds_RimAddId",
                        column: x => x.RimAddId,
                        principalTable: "RimAdds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pictures_ServiceAdds_ServiceAddId",
                        column: x => x.ServiceAddId,
                        principalTable: "ServiceAdds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pictures_TruckAdds_TruckAddId",
                        column: x => x.TruckAddId,
                        principalTable: "TruckAdds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pictures_TyreAdds_TyreAddId",
                        column: x => x.TyreAddId,
                        principalTable: "TyreAdds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessoryAdds_AccessoryId",
                table: "AccessoryAdds",
                column: "AccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessoryAdds_CreatorId",
                table: "AccessoryAdds",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CarAdds_CarId",
                table: "CarAdds",
                column: "CarId",
                unique: true,
                filter: "[CarId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CarAdds_CreatorId",
                table: "CarAdds",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_NewsId",
                table: "Comments",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_Extras_CarId",
                table: "Extras",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Extras_MotorcycleId",
                table: "Extras",
                column: "MotorcycleId");

            migrationBuilder.CreateIndex(
                name: "IX_Extras_TruckId",
                table: "Extras",
                column: "TruckId");

            migrationBuilder.CreateIndex(
                name: "IX_MotorcycleAdds_CreatorId",
                table: "MotorcycleAdds",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_MotorcycleAdds_MotorcycleId",
                table: "MotorcycleAdds",
                column: "MotorcycleId",
                unique: true,
                filter: "[MotorcycleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_News_AuthorId",
                table: "News",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_PartAdds_CreatorId",
                table: "PartAdds",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PartAdds_PartId",
                table: "PartAdds",
                column: "PartId",
                unique: true,
                filter: "[PartId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_AccessoryAddId",
                table: "Pictures",
                column: "AccessoryAddId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_CarAddId",
                table: "Pictures",
                column: "CarAddId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_MotorcycleAddId",
                table: "Pictures",
                column: "MotorcycleAddId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_PartAddId",
                table: "Pictures",
                column: "PartAddId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_RimAddId",
                table: "Pictures",
                column: "RimAddId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_ServiceAddId",
                table: "Pictures",
                column: "ServiceAddId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_TruckAddId",
                table: "Pictures",
                column: "TruckAddId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_TyreAddId",
                table: "Pictures",
                column: "TyreAddId");

            migrationBuilder.CreateIndex(
                name: "IX_RimAdds_CreatorId",
                table: "RimAdds",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_RimAdds_RimId",
                table: "RimAdds",
                column: "RimId",
                unique: true,
                filter: "[RimId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAdds_CreatorId",
                table: "ServiceAdds",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAdds_ServiceId",
                table: "ServiceAdds",
                column: "ServiceId",
                unique: true,
                filter: "[ServiceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TruckAdds_CreatorId",
                table: "TruckAdds",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TruckAdds_TruckId",
                table: "TruckAdds",
                column: "TruckId",
                unique: true,
                filter: "[TruckId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TyreAdds_CreatorId",
                table: "TyreAdds",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TyreAdds_TyreId",
                table: "TyreAdds",
                column: "TyreId",
                unique: true,
                filter: "[TyreId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Extras");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "AccessoryAdds");

            migrationBuilder.DropTable(
                name: "CarAdds");

            migrationBuilder.DropTable(
                name: "MotorcycleAdds");

            migrationBuilder.DropTable(
                name: "PartAdds");

            migrationBuilder.DropTable(
                name: "RimAdds");

            migrationBuilder.DropTable(
                name: "ServiceAdds");

            migrationBuilder.DropTable(
                name: "TruckAdds");

            migrationBuilder.DropTable(
                name: "TyreAdds");

            migrationBuilder.DropTable(
                name: "Accessories");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Motorcycles");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Rims");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Trucks");

            migrationBuilder.DropTable(
                name: "Tyres");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegisteredOn",
                table: "AspNetUsers");
        }
    }
}
