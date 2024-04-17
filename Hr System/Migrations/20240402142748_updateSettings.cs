using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hr_System.Migrations
{
    /// <inheritdoc />
    public partial class updateSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralSettings_Employees_EmployeeId",
                table: "GeneralSettings");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralSettings_Employees_EmployeeId",
                table: "GeneralSettings",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralSettings_Employees_EmployeeId",
                table: "GeneralSettings");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralSettings_Employees_EmployeeId",
                table: "GeneralSettings",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
