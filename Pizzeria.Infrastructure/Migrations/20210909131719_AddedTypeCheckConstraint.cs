using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzeria.Infrastructure.Migrations
{
    public partial class AddedTypeCheckConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderedAt",
                value: new DateTime(2021, 9, 9, 16, 17, 18, 706, DateTimeKind.Local).AddTicks(1826));

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 1,
                column: "FoundationDate",
                value: new DateTime(2021, 9, 9, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddCheckConstraint(
                name: "pizzaType_constraint",
                table: "Pizzas",
                sql: "type IN('American','Italian','Japanese')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "pizzaType_constraint",
                table: "Pizzas");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderedAt",
                value: new DateTime(2021, 9, 6, 15, 35, 4, 972, DateTimeKind.Local).AddTicks(8571));

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 1,
                column: "FoundationDate",
                value: new DateTime(2021, 9, 6, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
