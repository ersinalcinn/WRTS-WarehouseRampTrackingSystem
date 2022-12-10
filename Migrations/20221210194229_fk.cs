using Microsoft.EntityFrameworkCore.Migrations;

namespace wrts.Migrations
{
    public partial class fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehiclesFkVehicle_ID",
                table: "Ramps",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ramps_VehiclesFkVehicle_ID",
                table: "Ramps",
                column: "VehiclesFkVehicle_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ramps_Vehicles_VehiclesFkVehicle_ID",
                table: "Ramps",
                column: "VehiclesFkVehicle_ID",
                principalTable: "Vehicles",
                principalColumn: "Vehicle_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ramps_Vehicles_VehiclesFkVehicle_ID",
                table: "Ramps");

            migrationBuilder.DropIndex(
                name: "IX_Ramps_VehiclesFkVehicle_ID",
                table: "Ramps");

            migrationBuilder.DropColumn(
                name: "VehiclesFkVehicle_ID",
                table: "Ramps");
        }
    }
}
