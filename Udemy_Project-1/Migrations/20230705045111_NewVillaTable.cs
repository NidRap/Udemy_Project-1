using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Udemy_Project_1.Migrations
{
    /// <inheritdoc />
    public partial class NewVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Villas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    sqft = table.Column<int>(type: "int", nullable: false),
                    occupancy = table.Column<int>(type: "int", nullable: false),
                    imgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amenity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedTime", "Details", "Name", "Rate", "UpdatedTime", "imgUrl", "occupancy", "sqft" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 7, 5, 10, 21, 11, 571, DateTimeKind.Local).AddTicks(9173), "ahbsdjcnnnnnnnnnnm jxnsjncd xjnjx", "Royal Villa", 100.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "httss jnc", 4, 100 },
                    { 2, "", new DateTime(2023, 7, 5, 10, 21, 11, 571, DateTimeKind.Local).AddTicks(9190), "ahbsdjcnnnnnnnnnnm jxnsjncd xjnjx", "Royal Villa2", 100.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "httss jnc", 4, 100 },
                    { 3, "", new DateTime(2023, 7, 5, 10, 21, 11, 571, DateTimeKind.Local).AddTicks(9259), "ahbsdjcnnnnnnnnnnm jxnsjncd xjnjx", "Royal Villa3", 100.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "httss jnc", 4, 100 },
                    { 4, "", new DateTime(2023, 7, 5, 10, 21, 11, 571, DateTimeKind.Local).AddTicks(9262), "ahbsdjcnnnnnnnnnnm jxnsjncd xjnjx", "Royal Villa4", 100.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "httss jnc", 4, 100 },
                    { 5, "", new DateTime(2023, 7, 5, 10, 21, 11, 571, DateTimeKind.Local).AddTicks(9265), "ahbsdjcnnnnnnnnnnm jxnsjncd xjnjx", "Royal Villa5", 100.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "httss jnc", 4, 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Villas");
        }
    }
}
