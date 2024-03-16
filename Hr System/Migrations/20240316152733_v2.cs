using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hr_System.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeneralSettingId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GeneralSettingId",
                table: "Employees",
                column: "GeneralSettingId",
                unique: true,
                filter: "[GeneralSettingId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_GeneralSettings_GeneralSettingId",
                table: "Employees",
                column: "GeneralSettingId",
                principalTable: "GeneralSettings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_GeneralSettings_GeneralSettingId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_GeneralSettingId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "GeneralSettingId",
                table: "Employees");
        }
    }
}
