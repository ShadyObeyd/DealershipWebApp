using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealership.Data.Migrations
{
    public partial class RemovedAuthorNamePropertyFromComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Comments",
                nullable: true);
        }
    }
}
