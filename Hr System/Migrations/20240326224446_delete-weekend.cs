using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hr_System.Migrations
{
    /// <inheritdoc />
    public partial class deleteweekend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weekends");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weekends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneralSettingsId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weekends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weekends_GeneralSettings_GeneralSettingsId",
                        column: x => x.GeneralSettingsId,
                        principalTable: "GeneralSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weekends_GeneralSettingsId",
                table: "Weekends",
                column: "GeneralSettingsId");
        }
    }
}
