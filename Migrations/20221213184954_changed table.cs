using Microsoft.EntityFrameworkCore.Migrations;

namespace wrts.Migrations
{
    public partial class changedtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Vehicles_VehiclesVehicleID",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_VehiclesVehicleID",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "VehiclesVehicleID",
                table: "Department");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehiclesVehicleID",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Department_VehiclesVehicleID",
                table: "Department",
                column: "VehiclesVehicleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Vehicles_VehiclesVehicleID",
                table: "Department",
                column: "VehiclesVehicleID",
                principalTable: "Vehicles",
                principalColumn: "VehicleID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
