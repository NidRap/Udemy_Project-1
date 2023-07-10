using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy_Project_1.Migrations
{
    /// <inheritdoc />
    public partial class AddvillaNumberToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaNumber",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    SpclDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumber", x => x.VillaNo);
                });

            migrationBuilder.UpdateData(
                table: "Villas1",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 5, 21, 14, 39, 618, DateTimeKind.Local).AddTicks(5531));

            migrationBuilder.UpdateData(
                table: "Villas1",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 5, 21, 14, 39, 618, DateTimeKind.Local).AddTicks(5608));

            migrationBuilder.UpdateData(
                table: "Villas1",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 5, 21, 14, 39, 618, DateTimeKind.Local).AddTicks(5611));

            migrationBuilder.UpdateData(
                table: "Villas1",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 5, 21, 14, 39, 618, DateTimeKind.Local).AddTicks(5613));

            migrationBuilder.UpdateData(
                table: "Villas1",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 5, 21, 14, 39, 618, DateTimeKind.Local).AddTicks(5615));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumber");

            migrationBuilder.UpdateData(
                table: "Villas1",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 5, 10, 24, 27, 307, DateTimeKind.Local).AddTicks(8149));

            migrationBuilder.UpdateData(
                table: "Villas1",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 5, 10, 24, 27, 307, DateTimeKind.Local).AddTicks(8164));

            migrationBuilder.UpdateData(
                table: "Villas1",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 5, 10, 24, 27, 307, DateTimeKind.Local).AddTicks(8166));

            migrationBuilder.UpdateData(
                table: "Villas1",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 5, 10, 24, 27, 307, DateTimeKind.Local).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "Villas1",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 5, 10, 24, 27, 307, DateTimeKind.Local).AddTicks(8170));
        }
    }
}
