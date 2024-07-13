using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace damnoshApi.Migrations
{
    /// <inheritdoc />
    public partial class portfolip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Stocks_StockId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e141bee-b5e0-4e4a-8aa7-5fb9c0480e3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "721ee433-55c2-4986-95c5-1ff7d99f83f8");

            migrationBuilder.DropColumn(
                name: "Risk",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Stocks",
                newName: "Stock");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Command");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_StockId",
                table: "Command",
                newName: "IX_Command_StockId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stock",
                table: "Stock",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Command",
                table: "Command",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Portfolio",
                columns: table => new
                {
                    AppuserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolio", x => new { x.AppuserId, x.StockId });
                    table.ForeignKey(
                        name: "FK_Portfolio_AspNetUsers_AppuserId",
                        column: x => x.AppuserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portfolio_Stock_StockId",
                        column: x => x.StockId,
                        principalTable: "Stock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "33728a43-f6e9-43e3-af79-5e72e90da30e", null, "User", "USER" },
                    { "5d599724-647f-4156-ac1f-3ed5cde79273", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_StockId",
                table: "Portfolio",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Command_Stock_StockId",
                table: "Command",
                column: "StockId",
                principalTable: "Stock",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Command_Stock_StockId",
                table: "Command");

            migrationBuilder.DropTable(
                name: "Portfolio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stock",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Command",
                table: "Command");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33728a43-f6e9-43e3-af79-5e72e90da30e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d599724-647f-4156-ac1f-3ed5cde79273");

            migrationBuilder.RenameTable(
                name: "Stock",
                newName: "Stocks");

            migrationBuilder.RenameTable(
                name: "Command",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Command_StockId",
                table: "Comments",
                newName: "IX_Comments_StockId");

            migrationBuilder.AddColumn<int>(
                name: "Risk",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6e141bee-b5e0-4e4a-8aa7-5fb9c0480e3b", null, "Admin", "ADMIN" },
                    { "721ee433-55c2-4986-95c5-1ff7d99f83f8", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Stocks_StockId",
                table: "Comments",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id");
        }
    }
}
