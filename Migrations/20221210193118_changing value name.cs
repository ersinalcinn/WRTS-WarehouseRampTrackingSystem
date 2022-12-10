using Microsoft.EntityFrameworkCore.Migrations;

namespace wrts.Migrations
{
    public partial class changingvaluename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ramps_Vehicles_Vehiclesvehicle_id",
                table: "Ramps");

            migrationBuilder.RenameColumn(
                name: "vehicle_type_id",
                table: "Vehicles",
                newName: "Vehicle_Type_ID");

            migrationBuilder.RenameColumn(
                name: "vehicle_id",
                table: "Vehicles",
                newName: "Vehicle_ID");

            migrationBuilder.RenameColumn(
                name: "vehicle_id",
                table: "Ramps",
                newName: "Vehicle_ID");

            migrationBuilder.RenameColumn(
                name: "Vehiclesvehicle_id",
                table: "Ramps",
                newName: "VehiclesVehicle_ID");

            migrationBuilder.RenameColumn(
                name: "ramp_id",
                table: "Ramps",
                newName: "Ramp_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Ramps_Vehiclesvehicle_id",
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
                name: "Vehicle_Type_ID",
                table: "Vehicles",
                newName: "vehicle_type_id");

            migrationBuilder.RenameColumn(
                name: "Vehicle_ID",
                table: "Vehicles",
                newName: "vehicle_id");

            migrationBuilder.RenameColumn(
                name: "VehiclesVehicle_ID",
                table: "Ramps",
                newName: "Vehiclesvehicle_id");

            migrationBuilder.RenameColumn(
                name: "Vehicle_ID",
                table: "Ramps",
                newName: "vehicle_id");

            migrationBuilder.RenameColumn(
                name: "Ramp_ID",
                table: "Ramps",
                newName: "ramp_id");

            migrationBuilder.RenameIndex(
                name: "IX_Ramps_VehiclesVehicle_ID",
                table: "Ramps",
                newName: "IX_Ramps_Vehiclesvehicle_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ramps_Vehicles_Vehiclesvehicle_id",
                table: "Ramps",
                column: "Vehiclesvehicle_id",
                principalTable: "Vehicles",
                principalColumn: "vehicle_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
