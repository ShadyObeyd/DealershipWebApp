using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealership.Data.Migrations
{
    public partial class addedTypePropertyToAdds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "TyreAdds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "TruckAdds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "ServiceAdds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "RimAdds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "PartAdds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "MotorcycleAdds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "CarAdds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "AccessoryAdds",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "TyreAdds");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "TruckAdds");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ServiceAdds");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "RimAdds");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "PartAdds");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "MotorcycleAdds");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "CarAdds");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "AccessoryAdds");
        }
    }
}
