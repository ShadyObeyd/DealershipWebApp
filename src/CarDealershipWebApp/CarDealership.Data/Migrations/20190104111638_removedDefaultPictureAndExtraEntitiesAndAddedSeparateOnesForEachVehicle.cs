using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealership.Data.Migrations
{
    public partial class removedDefaultPictureAndExtraEntitiesAndAddedSeparateOnesForEachVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Extras");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "AccessoryAdds");

            migrationBuilder.DropTable(
                name: "PartAdds");

            migrationBuilder.DropTable(
                name: "RimAdds");

            migrationBuilder.DropTable(
                name: "ServiceAdds");

            migrationBuilder.DropTable(
                name: "TyreAdds");

            migrationBuilder.DropTable(
                name: "Accessories");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Rims");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Tyres");

            migrationBuilder.CreateTable(
                name: "CarExtras",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CarId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarExtras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarExtras_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarPictures",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    CarAddId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarPictures_CarAdds_CarAddId",
                        column: x => x.CarAddId,
                        principalTable: "CarAdds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MotorcycleExtras",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    MotorcycleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorcycleExtras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotorcycleExtras_Motorcycles_MotorcycleId",
                        column: x => x.MotorcycleId,
                        principalTable: "Motorcycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MotorcyclePictures",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    MotorcycleAddId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorcyclePictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotorcyclePictures_MotorcycleAdds_MotorcycleAddId",
                        column: x => x.MotorcycleAddId,
                        principalTable: "MotorcycleAdds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TruckExtras",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TruckId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckExtras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TruckExtras_Trucks_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Trucks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TruckPictures",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    TruckAddId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TruckPictures_TruckAdds_TruckAddId",
                        column: x => x.TruckAddId,
                        principalTable: "TruckAdds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarExtras_CarId",
                table: "CarExtras",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarPictures_CarAddId",
                table: "CarPictures",
                column: "CarAddId");

            migrationBuilder.CreateIndex(
                name: "IX_MotorcycleExtras_MotorcycleId",
                table: "MotorcycleExtras",
                column: "MotorcycleId");

            migrationBuilder.CreateIndex(
                name: "IX_MotorcyclePictures_MotorcycleAddId",
                table: "MotorcyclePictures",
                column: "MotorcycleAddId");

            migrationBuilder.CreateIndex(
                name: "IX_TruckExtras_TruckId",
                table: "TruckExtras",
                column: "TruckId");

            migrationBuilder.CreateIndex(
                name: "IX_TruckPictures_TruckAddId",
                table: "TruckPictures",
                column: "TruckAddId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarExtras");

            migrationBuilder.DropTable(
                name: "CarPictures");

            migrationBuilder.DropTable(
                name: "MotorcycleExtras");

            migrationBuilder.DropTable(
                name: "MotorcyclePictures");

            migrationBuilder.DropTable(
                name: "TruckExtras");

            migrationBuilder.DropTable(
                name: "TruckPictures");

            migrationBuilder.CreateTable(
                name: "Accessories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessoryType = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Extras",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CarId = table.Column<string>(nullable: true),
                    MotorcycleId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
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
                name: "Parts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AddId = table.Column<string>(nullable: true),
                    Category = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
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
                    AddId = table.Column<string>(nullable: true),
                    BoltsCount = table.Column<int>(nullable: false),
                    CarMake = table.Column<string>(nullable: true),
                    CarModel = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    RimMake = table.Column<string>(nullable: true)
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
                    AddId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ServiceType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tyres",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AddId = table.Column<string>(nullable: true),
                    Height = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Make = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    SeasonType = table.Column<int>(nullable: false),
                    SppedIndex = table.Column<int>(nullable: false),
                    WeightIndex = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false)
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
                    AccessoryId = table.Column<string>(nullable: true),
                    AdditionalInfo = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
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
                name: "PartAdds",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AdditionalInfo = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    PartId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
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
                    AdditionalInfo = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    RimId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
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
                    AdditionalInfo = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    ServiceId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
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
                name: "TyreAdds",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AdditionalInfo = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
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
                    AccessoryAddId = table.Column<string>(nullable: true),
                    CarAddId = table.Column<string>(nullable: true),
                    MotorcycleAddId = table.Column<string>(nullable: true),
                    PartAddId = table.Column<string>(nullable: true),
                    RimAddId = table.Column<string>(nullable: true),
                    ServiceAddId = table.Column<string>(nullable: true),
                    TruckAddId = table.Column<string>(nullable: true),
                    TyreAddId = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
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
    }
}
