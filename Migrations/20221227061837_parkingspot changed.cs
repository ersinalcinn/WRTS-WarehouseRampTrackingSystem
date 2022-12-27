using Microsoft.EntityFrameworkCore.Migrations;

namespace wrts.Migrations
{
    public partial class parkingspotchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParkStatusID",
                table: "ParkingSpot");

            migrationBuilder.AddColumn<string>(
                name: "ParkStatus",
                table: "ParkingSpot",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParkStatus",
                table: "ParkingSpot");

            migrationBuilder.AddColumn<int>(
                name: "ParkStatusID",
                table: "ParkingSpot",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
