using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hr_System.Migrations
{
    /// <inheritdoc />
    public partial class updategeneralSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Weekend1",
                table: "GeneralSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Weekend2",
                table: "GeneralSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weekend1",
                table: "GeneralSettings");

            migrationBuilder.DropColumn(
                name: "Weekend2",
                table: "GeneralSettings");
        }
    }
}
