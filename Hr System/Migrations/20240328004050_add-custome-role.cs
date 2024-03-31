using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hr_System.Migrations
{
    /// <inheritdoc />
    public partial class addcustomerole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rolePermissions_AspNetRoles_RoleId",
                table: "rolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rolePermissions",
                table: "rolePermissions");

            migrationBuilder.RenameTable(
                name: "rolePermissions",
                newName: "RolePermissions");

            migrationBuilder.RenameIndex(
                name: "IX_rolePermissions_RoleId",
                table: "RolePermissions",
                newName: "IX_RolePermissions_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolePermissions",
                table: "RolePermissions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_AspNetRoles_RoleId",
                table: "RolePermissions",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_AspNetRoles_RoleId",
                table: "RolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolePermissions",
                table: "RolePermissions");

            migrationBuilder.RenameTable(
                name: "RolePermissions",
                newName: "rolePermissions");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermissions_RoleId",
                table: "rolePermissions",
                newName: "IX_rolePermissions_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rolePermissions",
                table: "rolePermissions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_rolePermissions_AspNetRoles_RoleId",
                table: "rolePermissions",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
