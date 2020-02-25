using Microsoft.EntityFrameworkCore.Migrations;

namespace MerchShop.Migrations
{
    public partial class updatetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Middlename",
                table: "UserProfiles");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Middlename",
                table: "UserProfiles",
                maxLength: 75,
                nullable: false,
                defaultValue: "");
        }
    }
}
