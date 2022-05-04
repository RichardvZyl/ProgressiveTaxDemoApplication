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
                    { 1, 0, new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4146), new TimeSpan(0, 0, 0, 0, 0)), 10 },
                    { 2, 8351, new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4148), new TimeSpan(0, 0, 0, 0, 0)), 15 },
                    { 3, 33951, new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4148), new TimeSpan(0, 0, 0, 0, 0)), 25 },
                    { 4, 82251, new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4149), new TimeSpan(0, 0, 0, 0, 0)), 28 },
                    { 5, 171151, new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4149), new TimeSpan(0, 0, 0, 0, 0)), 33 },
                    { 6, 372951, new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4150), new TimeSpan(0, 0, 0, 0, 0)), 35 }
                });

            migrationBuilder.InsertData(
                table: "TaxCalculationType",
                columns: new[] { "Id", "LastUpdated", "PostalCode", "TaxType" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4169), new TimeSpan(0, 0, 0, 0, 0)), "7441", 0 },
                    { 2, new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4170), new TimeSpan(0, 0, 0, 0, 0)), "A100", 1 },
                    { 3, new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4171), new TimeSpan(0, 0, 0, 0, 0)), "7000", 2 },
                    { 4, new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4171), new TimeSpan(0, 0, 0, 0, 0)), "1000", 0 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "LastUpdated", "PostalCode", "Salary" },
                values: new object[,]
                {
                    { new Guid("2310db8a-c813-45f1-bd76-7e95a748d70b"), "example@example.com", new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(3950), new TimeSpan(0, 0, 0, 0, 0)), "7441", 1000000m },
                    { new Guid("ceb06110-9fd7-4a77-bdb0-1268d76e4c18"), "test@example.com", new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4111), new TimeSpan(0, 0, 0, 0, 0)), "7000", 10000m },
                    { new Guid("d0be9e66-9541-4c06-b4ce-8b3c3e145b31"), "test@test.com", new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(3963), new TimeSpan(0, 0, 0, 0, 0)), "A100", 130000m },
                    { new Guid("e941d7a4-4d46-4f09-8d52-a6585279998b"), "example@test.com", new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4113), new TimeSpan(0, 0, 0, 0, 0)), "1000", 100000m }
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
