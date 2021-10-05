using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzeria.Infrastructure.Migrations
{
    public partial class CheckConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderedAt",
                value: new DateTime(2021, 10, 5, 12, 56, 2, 252, DateTimeKind.Local).AddTicks(9381));

            migrationBuilder.AddCheckConstraint(
                name: "quantity_constraint",
                table: "OrderFoodItem",
                sql: "[quantity] > 0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "quantity_constraint",
                table: "OrderFoodItem");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderedAt",
                value: new DateTime(2021, 10, 5, 12, 30, 13, 316, DateTimeKind.Local).AddTicks(1774));
        }
    }
}
