using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AquariumFishTracker.Migrations
{
    public partial class AddTankUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Tanks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Fish",
                type: "nvarchar(450)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Fish");
        }
    }
}
