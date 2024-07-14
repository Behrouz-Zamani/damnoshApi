using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace damnoshApi.Migrations
{
    /// <inheritdoc />
    public partial class CoomentToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33728a43-f6e9-43e3-af79-5e72e90da30e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d599724-647f-4156-ac1f-3ed5cde79273");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Command",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a0fa14d-fd8c-46e8-ae23-0a06cb4ec8ca", null, "Admin", "ADMIN" },
                    { "a4fb21f6-371d-4d51-8431-73ebb0222725", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Command_AppUserId",
                table: "Command",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Command_AspNetUsers_AppUserId",
                table: "Command",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Command_AspNetUsers_AppUserId",
                table: "Command");

            migrationBuilder.DropIndex(
                name: "IX_Command_AppUserId",
                table: "Command");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a0fa14d-fd8c-46e8-ae23-0a06cb4ec8ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4fb21f6-371d-4d51-8431-73ebb0222725");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Command");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "33728a43-f6e9-43e3-af79-5e72e90da30e", null, "User", "USER" },
                    { "5d599724-647f-4156-ac1f-3ed5cde79273", null, "Admin", "ADMIN" }
                });
        }
    }
}
