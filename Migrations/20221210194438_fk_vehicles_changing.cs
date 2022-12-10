using Microsoft.EntityFrameworkCore.Migrations;

namespace wrts.Migrations
{
    public partial class fk_vehicles_changing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ramps_Vehicles_VehiclesFkVehicle_ID",
                table: "Ramps");

            migrationBuilder.RenameColumn(
                name: "VehiclesFkVehicle_ID",
                table: "Ramps",
                newName: "VehiclesVehicle_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Ramps_VehiclesFkVehicle_ID",
                table: "Ramps",
                newName: "IX_Ramps_VehiclesVehicle_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ramps_Vehicles_VehiclesVehicle_ID",
                table: "Ramps",
                column: "VehiclesVehicle_ID",
                principalTable: "Vehicles",
                principalColumn: "Vehicle_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ramps_Vehicles_VehiclesVehicle_ID",
                table: "Ramps");

            migrationBuilder.RenameColumn(
                name: "VehiclesVehicle_ID",
                table: "Ramps",
                newName: "VehiclesFkVehicle_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Ramps_VehiclesVehicle_ID",
                table: "Ramps",
                newName: "IX_Ramps_VehiclesFkVehicle_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ramps_Vehicles_VehiclesFkVehicle_ID",
                table: "Ramps",
                column: "VehiclesFkVehicle_ID",
                principalTable: "Vehicles",
                principalColumn: "Vehicle_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
