using Microsoft.EntityFrameworkCore.Migrations;

namespace wrts.Migrations
{
    public partial class fkdeparment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Department_DepartmentID1",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_DepartmentID1",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DepartmentID1",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentID",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_User_DepartmentID",
                table: "User",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Department_DepartmentID",
                table: "User",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Department_DepartmentID",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_DepartmentID",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentID",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID1",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_DepartmentID1",
                table: "User",
                column: "DepartmentID1");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Department_DepartmentID1",
                table: "User",
                column: "DepartmentID1",
                principalTable: "Department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
