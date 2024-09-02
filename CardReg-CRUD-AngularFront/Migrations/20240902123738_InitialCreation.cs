using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CardReg_CRUD_AngularFront.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HolderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpireMonth = table.Column<int>(type: "int", nullable: false),
                    ExpireYear = table.Column<int>(type: "int", nullable: false),
                    CVC = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CVC", "CardNumber", "ExpireMonth", "ExpireYear", "HolderName" },
                values: new object[,]
                {
                    { new Guid("31f18d7c-2058-40a5-9ade-3234b18234b6"), 456, "5234567890123456", 2, 2025, "Anna Svensson" },
                    { new Guid("36fa4f1f-c94d-4f86-83f3-f15c383884e3"), 123, "39483843499999", 1, 2026, "Ermin Husic" },
                    { new Guid("6efcca8c-599e-47f5-a0ef-cb15dbc77f56"), 321, "4000056655665556", 4, 2027, "Caroline Lindberg" },
                    { new Guid("99cc1a5b-0dec-4dc2-9b87-de3456b0fba1"), 789, "6011123456789012", 3, 2024, "Björn Karlsson" },
                    { new Guid("b2ac5c39-b602-4042-b654-174cfd586ce8"), 654, "3566002020360505", 5, 2023, "David Ek" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
