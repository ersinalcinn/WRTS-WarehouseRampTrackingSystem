using Microsoft.EntityFrameworkCore.Migrations;

namespace wrts.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ramps_Vehicles_VehiclesVehicle_ID",
                table: "Ramps");

            migrationBuilder.DropIndex(
                name: "IX_Ramps_VehiclesVehicle_ID",
                table: "Ramps");

            migrationBuilder.DropColumn(
                name: "VehiclesVehicle_ID",
                table: "Ramps");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehiclesVehicle_ID",
                table: "Ramps",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ramps_VehiclesVehicle_ID",
                table: "Ramps",
                column: "VehiclesVehicle_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ramps_Vehicles_VehiclesVehicle_ID",
                table: "Ramps",
                column: "VehiclesVehicle_ID",
                principalTable: "Vehicles",
                principalColumn: "Vehicle_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
