using Microsoft.EntityFrameworkCore.Migrations;

namespace wrts.Migrations
{
    public partial class fkrampvehicleidremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ramps_Vehicles_VehiclesID",
                table: "Ramps");

            migrationBuilder.DropIndex(
                name: "IX_Ramps_VehiclesID",
                table: "Ramps");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
