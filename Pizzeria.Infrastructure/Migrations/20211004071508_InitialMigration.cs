using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzeria.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromotionalCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    MaximumUses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionalCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apartment = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FoodCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodItems_FoodCategories_FoodCategoryId",
                        column: x => x.FoodCategoryId,
                        principalTable: "FoodCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    DesiredDeliveryDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    OrderIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Note = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    IsCash = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PromotionalCodeId = table.Column<int>(type: "int", nullable: true),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PromotionalCodes_PromotionalCodeId",
                        column: x => x.PromotionalCodeId,
                        principalTable: "PromotionalCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodItemExtras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FoodItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItemExtras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodItemExtras_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderFoodItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodItemId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderFoodItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderFoodItem_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderFoodItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderFoodItemExtra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodItemExtraId = table.Column<int>(type: "int", nullable: false),
                    OrderFoodItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderFoodItemExtra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderFoodItemExtra_FoodItemExtras_FoodItemExtraId",
                        column: x => x.FoodItemExtraId,
                        principalTable: "FoodItemExtras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderFoodItemExtra_OrderFoodItem_OrderFoodItemId",
                        column: x => x.OrderFoodItemId,
                        principalTable: "OrderFoodItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Name", "Phone" },
                values: new object[] { 1, "seed@mail.ru", "Denis", "069353632" });

            migrationBuilder.InsertData(
                table: "FoodCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pizza" },
                    { 3, "Snack" },
                    { 2, "Drink" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Confirmed" },
                    { 3, "Delivered" }
                });

            migrationBuilder.InsertData(
                table: "PromotionalCodes",
                columns: new[] { "Id", "Code", "Discount", "ExpirationDate", "IsActive", "MaximumUses", "Name" },
                values: new object[] { 1, "MP100", 5m, new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Local), true, 1000, "Discount" });

            migrationBuilder.InsertData(
                table: "DeliveryAddress",
                columns: new[] { "Id", "Apartment", "CustomerId", "Street" },
                values: new object[] { 1, 5, 1, "Test Street" });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "Description", "FoodCategoryId", "Name", "Price" },
                values: new object[] { 1, "Best pizza", 1, "Margarita", 100m });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "DesiredDeliveryDateTime", "Note", "OrderStatusId", "OrderedAt", "PromotionalCodeId", "TotalPrice" },
                values: new object[] { 1, 1, new DateTime(2021, 10, 4, 2, 0, 0, 0, DateTimeKind.Local), "Second floor", 1, new DateTime(2021, 10, 4, 10, 15, 7, 716, DateTimeKind.Local).AddTicks(895), 1, 100m });

            migrationBuilder.InsertData(
                table: "FoodItemExtras",
                columns: new[] { "Id", "Description", "FoodItemId", "Name", "Price" },
                values: new object[] { 1, "Best pizza", 1, "Margarita", 10m });

            migrationBuilder.InsertData(
                table: "OrderFoodItem",
                columns: new[] { "Id", "FoodItemId", "OrderId", "Quantity" },
                values: new object[] { 1, 1, 1, 0 });

            migrationBuilder.InsertData(
                table: "OrderFoodItemExtra",
                columns: new[] { "Id", "FoodItemExtraId", "OrderFoodItemId", "Quantity" },
                values: new object[] { 1, 1, 1, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Phone",
                table: "Customers",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAddress_CustomerId",
                table: "DeliveryAddress",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItemExtras_FoodItemId",
                table: "FoodItemExtras",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_FoodCategoryId",
                table: "FoodItems",
                column: "FoodCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFoodItem_FoodItemId",
                table: "OrderFoodItem",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFoodItem_OrderId",
                table: "OrderFoodItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFoodItemExtra_FoodItemExtraId",
                table: "OrderFoodItemExtra",
                column: "FoodItemExtraId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFoodItemExtra_OrderFoodItemId",
                table: "OrderFoodItemExtra",
                column: "OrderFoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PromotionalCodeId",
                table: "Orders",
                column: "PromotionalCodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryAddress");

            migrationBuilder.DropTable(
                name: "OrderFoodItemExtra");

            migrationBuilder.DropTable(
                name: "FoodItemExtras");

            migrationBuilder.DropTable(
                name: "OrderFoodItem");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "FoodCategories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "PromotionalCodes");
        }
    }
}
