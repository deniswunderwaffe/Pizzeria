using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzeria.Infrastructure.Migrations
{
    public partial class ReworkedExtras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderFoodItemExtra_OrderFoodItem_OrderFoodItemId",
                table: "OrderFoodItemExtra");

            migrationBuilder.DropIndex(
                name: "IX_OrderFoodItemExtra_OrderFoodItemId",
                table: "OrderFoodItemExtra");

            migrationBuilder.DropIndex(
                name: "IX_OrderFoodItem_OrderId",
                table: "OrderFoodItem");

            migrationBuilder.DeleteData(
                table: "OrderFoodItemExtra",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "OrderFoodItemId",
                table: "OrderFoodItemExtra");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderFoodItemExtra",
                newName: "OrderId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_OrderFoodItemExtra_OrderId_FoodItemExtraId",
                table: "OrderFoodItemExtra",
                columns: new[] { "OrderId", "FoodItemExtraId" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_OrderFoodItem_OrderId_FoodItemId",
                table: "OrderFoodItem",
                columns: new[] { "OrderId", "FoodItemId" });

            migrationBuilder.InsertData(
                table: "OrderFoodItemExtra",
                columns: new[] { "Id", "FoodItemExtraId", "OrderId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderedAt",
                value: new DateTime(2021, 10, 5, 12, 30, 13, 316, DateTimeKind.Local).AddTicks(1774));

            migrationBuilder.AddForeignKey(
                name: "FK_OrderFoodItemExtra_Orders_OrderId",
                table: "OrderFoodItemExtra",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderFoodItemExtra_Orders_OrderId",
                table: "OrderFoodItemExtra");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_OrderFoodItemExtra_OrderId_FoodItemExtraId",
                table: "OrderFoodItemExtra");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_OrderFoodItem_OrderId_FoodItemId",
                table: "OrderFoodItem");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderFoodItemExtra",
                newName: "Quantity");

            migrationBuilder.AddColumn<int>(
                name: "OrderFoodItemId",
                table: "OrderFoodItemExtra",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "OrderFoodItemExtra",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OrderFoodItemId", "Quantity" },
                values: new object[] { 1, 0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderedAt",
                value: new DateTime(2021, 10, 5, 11, 16, 54, 402, DateTimeKind.Local).AddTicks(488));

            migrationBuilder.CreateIndex(
                name: "IX_OrderFoodItemExtra_OrderFoodItemId",
                table: "OrderFoodItemExtra",
                column: "OrderFoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFoodItem_OrderId",
                table: "OrderFoodItem",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderFoodItemExtra_OrderFoodItem_OrderFoodItemId",
                table: "OrderFoodItemExtra",
                column: "OrderFoodItemId",
                principalTable: "OrderFoodItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
