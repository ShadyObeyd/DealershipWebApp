using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealership.Data.Migrations
{
    public partial class removedPropertyAuthorNameFromNewsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "News");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "News",
                nullable: true);
        }
    }
}
