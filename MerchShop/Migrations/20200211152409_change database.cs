using Microsoft.EntityFrameworkCore.Migrations;


namespace MerchShop.Migrations
{
    public partial class changedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "UserProfiles",
                newName: "FullName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "UserProfiles",
                newName: "Lastname");

            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "UserProfiles",
                maxLength: 75,
                nullable: false,
                defaultValue: "");
        }
    }
}
