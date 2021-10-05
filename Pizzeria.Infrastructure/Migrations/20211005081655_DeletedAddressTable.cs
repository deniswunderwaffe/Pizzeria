using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzeria.Infrastructure.Migrations
{
    public partial class DeletedAddressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryAddress");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Address",
                value: "DELIVERY ADDRESS");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DesiredDeliveryDateTime", "OrderedAt" },
                values: new object[] { new DateTime(2021, 10, 5, 2, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 10, 5, 11, 16, 54, 402, DateTimeKind.Local).AddTicks(488) });

            migrationBuilder.UpdateData(
                table: "PromotionalCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2022, 1, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_PromotionalCodes_Code",
                table: "PromotionalCodes",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PromotionalCodes_Code",
                table: "PromotionalCodes");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.CreateTable(
                name: "DeliveryAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apartment = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryAddress_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DeliveryAddress",
                columns: new[] { "Id", "Apartment", "CustomerId", "Street" },
                values: new object[] { 1, 5, 1, "Test Street" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DesiredDeliveryDateTime", "OrderedAt" },
                values: new object[] { new DateTime(2021, 10, 4, 2, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 10, 4, 10, 15, 7, 716, DateTimeKind.Local).AddTicks(895) });

            migrationBuilder.UpdateData(
                table: "PromotionalCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAddress_CustomerId",
                table: "DeliveryAddress",
                column: "CustomerId");
        }
    }
}
