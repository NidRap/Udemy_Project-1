using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy_Project_1.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyTOVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VillaId",
                table: "VillaNumber",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Villas1",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 6, 10, 40, 8, 986, DateTimeKind.Local).AddTicks(830));

            migrationBuilder.UpdateData(
                table: "Villas1",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 6, 10, 40, 8, 986, DateTimeKind.Local).AddTicks(847));

            migrationBuilder.UpdateData(
                table: "Villas1",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 6, 10, 40, 8, 986, DateTimeKind.Local).AddTicks(850));

            migrationBuilder.UpdateData(
                table: "Villas1",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 6, 10, 40, 8, 986, DateTimeKind.Local).AddTicks(853));

            migrationBuilder.UpdateData(
                table: "Villas1",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2023, 7, 6, 10, 40, 8, 986, DateTimeKind.Local).AddTicks(855));

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumber_VillaId",
                table: "VillaNumber",
                column: "VillaId");

            migrationBuilder.AddForeignKey(
                name: "FK_VillaNumber_Villas1_VillaId",
                table: "VillaNumber",
                column: "VillaId",
                principalTable: "Villas1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaNumber_Villas1_VillaId",
                table: "VillaNumber");

            migrationBuilder.DropIndex(
                name: "IX_VillaNumber_VillaId",
                table: "VillaNumber");

            migrationBuilder.DropColumn(
                name: "VillaId",
                table: "VillaNumber");

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
    }
}
