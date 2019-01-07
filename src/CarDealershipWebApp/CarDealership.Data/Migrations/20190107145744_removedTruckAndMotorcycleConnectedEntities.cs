using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealership.Data.Migrations
{
    public partial class removedTruckAndMotorcycleConnectedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MotorcycleExtras");

            migrationBuilder.DropTable(
                name: "MotorcyclePictures");

            migrationBuilder.DropTable(
                name: "TruckExtras");

            migrationBuilder.DropTable(
                name: "TruckPictures");

            migrationBuilder.DropTable(
                name: "MotorcycleAdds");

            migrationBuilder.DropTable(
                name: "TruckAdds");

            migrationBuilder.DropTable(
                name: "Motorcycles");

            migrationBuilder.DropTable(
                name: "Trucks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motorcycles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AddId = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    CoolingType = table.Column<int>(nullable: false),
                    CubicCentimetres = table.Column<int>(nullable: false),
                    EngineKind = table.Column<int>(nullable: false),
                    EngineType = table.Column<int>(nullable: false),
                    HorsePower = table.Column<int>(nullable: false),
                    IsSold = table.Column<bool>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Transmission = table.Column<int>(nullable: false),
                    YearOfProduction = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorcycles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AddId = table.Column<string>(nullable: true),
                    AxisCount = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    EngineType = table.Column<int>(nullable: false),
                    HorsePower = table.Column<int>(nullable: false),
                    IsSold = table.Column<bool>(nullable: false),
                    LoadCapacity = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    SeatsCount = table.Column<int>(nullable: false),
                    Transmission = table.Column<int>(nullable: false),
                    YearOfProduction = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotorcycleAdds",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AdditionalInfo = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    MotorcycleId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
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
                name: "MotorcycleExtras",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MotorcycleId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
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
                name: "TruckAdds",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AdditionalInfo = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
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
                name: "MotorcyclePictures",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MotorcycleAddId = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
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
                name: "TruckPictures",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TruckAddId = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
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
                name: "IX_MotorcycleExtras_MotorcycleId",
                table: "MotorcycleExtras",
                column: "MotorcycleId");

            migrationBuilder.CreateIndex(
                name: "IX_MotorcyclePictures_MotorcycleAddId",
                table: "MotorcyclePictures",
                column: "MotorcycleAddId");

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
                name: "IX_TruckExtras_TruckId",
                table: "TruckExtras",
                column: "TruckId");

            migrationBuilder.CreateIndex(
                name: "IX_TruckPictures_TruckAddId",
                table: "TruckPictures",
                column: "TruckAddId");
        }
    }
}
