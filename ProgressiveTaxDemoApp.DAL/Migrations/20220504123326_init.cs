using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgressiveTaxDemoApp.Database.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgressiveTax",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressiveTax", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxCalculationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TaxType = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxCalculationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "DECIMAL(9,2)", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProgressiveTax",
                columns: new[] { "Id", "From", "LastUpdated", "Rate" },
                values: new object[,]
                {
                    { 1, 0, new DateTimeOffset(new DateTime(2022, 5, 4, 12, 33, 25, 790, DateTimeKind.Unspecified).AddTicks(4790), new TimeSpan(0, 0, 0, 0, 0)), 10 },
                    { 2, 8351, new DateTimeOffset(new DateTime(2022, 5, 4, 12, 33, 25, 790, DateTimeKind.Unspecified).AddTicks(4792), new TimeSpan(0, 0, 0, 0, 0)), 15 },
                    { 3, 33951, new DateTimeOffset(new DateTime(2022, 5, 4, 12, 33, 25, 790, DateTimeKind.Unspecified).AddTicks(4793), new TimeSpan(0, 0, 0, 0, 0)), 25 },
                    { 4, 82251, new DateTimeOffset(new DateTime(2022, 5, 4, 12, 33, 25, 790, DateTimeKind.Unspecified).AddTicks(4793), new TimeSpan(0, 0, 0, 0, 0)), 28 },
                    { 5, 171151, new DateTimeOffset(new DateTime(2022, 5, 4, 12, 33, 25, 790, DateTimeKind.Unspecified).AddTicks(4794), new TimeSpan(0, 0, 0, 0, 0)), 33 },
                    { 6, 372951, new DateTimeOffset(new DateTime(2022, 5, 4, 12, 33, 25, 790, DateTimeKind.Unspecified).AddTicks(4795), new TimeSpan(0, 0, 0, 0, 0)), 35 }
                });

            migrationBuilder.InsertData(
                table: "TaxCalculationType",
                columns: new[] { "Id", "LastUpdated", "PostalCode", "TaxType" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 5, 4, 12, 33, 25, 790, DateTimeKind.Unspecified).AddTicks(4816), new TimeSpan(0, 0, 0, 0, 0)), "7441", 0 },
                    { 2, new DateTimeOffset(new DateTime(2022, 5, 4, 12, 33, 25, 790, DateTimeKind.Unspecified).AddTicks(4818), new TimeSpan(0, 0, 0, 0, 0)), "A100", 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 5, 4, 12, 33, 25, 790, DateTimeKind.Unspecified).AddTicks(4819), new TimeSpan(0, 0, 0, 0, 0)), "7000", 2 },
                    { 4, new DateTimeOffset(new DateTime(2022, 5, 4, 12, 33, 25, 790, DateTimeKind.Unspecified).AddTicks(4819), new TimeSpan(0, 0, 0, 0, 0)), "1000", 0 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "LastUpdated", "PostalCode", "Salary" },
                values: new object[,]
                {
                    { new Guid("11693434-356a-484d-93ed-e4d94c91ad73"), "test@example.com", new DateTimeOffset(new DateTime(2022, 5, 4, 12, 33, 25, 790, DateTimeKind.Unspecified).AddTicks(4755), new TimeSpan(0, 0, 0, 0, 0)), "7000", 10000m },
                    { new Guid("2d1a9d29-a2e3-4a4b-9745-2f557d34a439"), "example@example.com", new DateTimeOffset(new DateTime(2022, 5, 4, 12, 33, 25, 790, DateTimeKind.Unspecified).AddTicks(4743), new TimeSpan(0, 0, 0, 0, 0)), "7441", 1000000m },
                    { new Guid("6bb18f27-8148-4144-9d5a-601cc3f4d3eb"), "example@test.com", new DateTimeOffset(new DateTime(2022, 5, 4, 12, 33, 25, 790, DateTimeKind.Unspecified).AddTicks(4756), new TimeSpan(0, 0, 0, 0, 0)), "1000", 100000m },
                    { new Guid("f43eef22-1d53-4760-adb4-a8e62faf6efa"), "test@test.com", new DateTimeOffset(new DateTime(2022, 5, 4, 12, 33, 25, 790, DateTimeKind.Unspecified).AddTicks(4753), new TimeSpan(0, 0, 0, 0, 0)), "A100", 130000m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgressiveTax");

            migrationBuilder.DropTable(
                name: "TaxCalculationType");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
