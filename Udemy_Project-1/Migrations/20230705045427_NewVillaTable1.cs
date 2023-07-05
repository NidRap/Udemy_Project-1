using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy_Project_1.Migrations
{
    /// <inheritdoc />
    public partial class NewVillaTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Villas",
                table: "Villas");

            migrationBuilder.RenameTable(
                name: "Villas",
                newName: "Villas1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Villas1",
                table: "Villas1",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Villas1",
                table: "Villas1");

            migrationBuilder.RenameTable(
                name: "Villas1",
                newName: "Villas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Villas",
                table: "Villas",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 5, 10, 21, 11, 571, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 5, 10, 21, 11, 571, DateTimeKind.Local).AddTicks(9190));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 5, 10, 21, 11, 571, DateTimeKind.Local).AddTicks(9259));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 5, 10, 21, 11, 571, DateTimeKind.Local).AddTicks(9262));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 5, 10, 21, 11, 571, DateTimeKind.Local).AddTicks(9265));
        }
    }
}
