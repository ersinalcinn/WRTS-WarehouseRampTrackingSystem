using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace wrts.Migrations
{
    public partial class WRTS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    vehicle_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vehicle_type_id = table.Column<int>(type: "int", nullable: false),
                    company_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    waybill_number = table.Column<int>(type: "int", nullable: false),
                    driver_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    driver_surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    driver_language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    citizenship_number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    arrival_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    departure_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vehicle_status = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.vehicle_id);
                });

            migrationBuilder.CreateTable(
                name: "Ramps",
                columns: table => new
                {
                    ramp_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vehicle_id = table.Column<int>(type: "int", nullable: false),
                    Vehiclesvehicle_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ramps", x => x.ramp_id);
                    table.ForeignKey(
                        name: "FK_Ramps_Vehicles_Vehiclesvehicle_id",
                        column: x => x.Vehiclesvehicle_id,
                        principalTable: "Vehicles",
                        principalColumn: "vehicle_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ramps_Vehiclesvehicle_id",
                table: "Ramps",
                column: "Vehiclesvehicle_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ramps");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
