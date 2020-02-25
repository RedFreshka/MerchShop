using Microsoft.EntityFrameworkCore.Migrations;

namespace MerchShop.Migrations
{
    public partial class changeuserprofile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "UserProfiles",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "UserProfiles",
                maxLength: 75,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "UserProfiles",
                newName: "FullName");
        }
    }
}
