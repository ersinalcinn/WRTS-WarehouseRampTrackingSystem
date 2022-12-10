using Microsoft.EntityFrameworkCore.Migrations;

namespace wrts.Migrations
{
    public partial class key_ramp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vehicle_ID",
                table: "Ramps",
                newName: "Vehicles_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vehicles_ID",
                table: "Ramps",
                newName: "Vehicle_ID");
        }
    }
}
