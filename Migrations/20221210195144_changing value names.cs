using Microsoft.EntityFrameworkCore.Migrations;

namespace wrts.Migrations
{
    public partial class changingvaluenames : Migration
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

            migrationBuilder.RenameColumn(
                name: "Vehicle_Type_ID",
                table: "Vehicles",
                newName: "VehicleTypeID");

            migrationBuilder.RenameColumn(
                name: "Vehicle_ID",
                table: "Vehicles",
                newName: "VehicleID");

            migrationBuilder.RenameColumn(
                name: "Vehicles_ID",
                table: "Ramps",
                newName: "VehiclesID");

            migrationBuilder.RenameColumn(
                name: "Ramp_ID",
                table: "Ramps",
                newName: "RampID");

            migrationBuilder.CreateIndex(
                name: "IX_Ramps_VehiclesID",
                table: "Ramps",
                column: "VehiclesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ramps_Vehicles_VehiclesID",
                table: "Ramps",
                column: "VehiclesID",
                principalTable: "Vehicles",
                principalColumn: "VehicleID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ramps_Vehicles_VehiclesID",
                table: "Ramps");

            migrationBuilder.DropIndex(
                name: "IX_Ramps_VehiclesID",
                table: "Ramps");

            migrationBuilder.RenameColumn(
                name: "VehicleTypeID",
                table: "Vehicles",
                newName: "Vehicle_Type_ID");

            migrationBuilder.RenameColumn(
                name: "VehicleID",
                table: "Vehicles",
                newName: "Vehicle_ID");

            migrationBuilder.RenameColumn(
                name: "VehiclesID",
                table: "Ramps",
                newName: "Vehicles_ID");

            migrationBuilder.RenameColumn(
                name: "RampID",
                table: "Ramps",
                newName: "Ramp_ID");

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
