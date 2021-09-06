using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzeria.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<bool>(type: "bit", nullable: false),
                    PaymentOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfPersons = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FoundationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlcoholicDrinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Concentration = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlcoholicDrinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlcoholicDrinks_Drinks_Id",
                        column: x => x.Id,
                        principalTable: "Drinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SodaDrinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsSugarFree = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SodaDrinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SodaDrinks_Drinks_Id",
                        column: x => x.Id,
                        principalTable: "Drinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDrink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    DrinkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDrink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDrink_Drinks_DrinkId",
                        column: x => x.DrinkId,
                        principalTable: "Drinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDrink_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderPizza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PizzaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPizza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPizza_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPizza_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PizzaIngredient",
                columns: table => new
                {
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaIngredient", x => new { x.PizzaId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_PizzaIngredient_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaIngredient_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "Brand", "Name" },
                values: new object[] { 1, "CocaCola", "Classic" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "Email", "Name", "NumberOfPersons", "OrderedAt", "PaymentOption", "Phone", "Priority" },
                values: new object[] { 1, "moscow", "test@mail.ru", "Den", null, new DateTime(2021, 9, 6, 15, 35, 4, 972, DateTimeKind.Local).AddTicks(8571), "Cash", "1234567890", true });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Name", "Price", "Type" },
                values: new object[] { 1, "Rancho", 100, "American" });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "Country", "FoundationDate", "Name" },
                values: new object[] { 1, "Moldova", new DateTime(2021, 9, 6, 0, 0, 0, 0, DateTimeKind.Local), "Provider" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "ProviderId", "Type" },
                values: new object[] { 1, "Ingredient", 1, "American" });

            migrationBuilder.InsertData(
                table: "OrderDrink",
                columns: new[] { "Id", "DrinkId", "OrderId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "OrderPizza",
                columns: new[] { "Id", "OrderId", "PizzaId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "SodaDrinks",
                columns: new[] { "Id", "IsSugarFree" },
                values: new object[] { 1, false });

            migrationBuilder.InsertData(
                table: "PizzaIngredient",
                columns: new[] { "IngredientId", "PizzaId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_ProviderId",
                table: "Ingredients",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDrink_DrinkId",
                table: "OrderDrink",
                column: "DrinkId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDrink_OrderId",
                table: "OrderDrink",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizza_OrderId",
                table: "OrderPizza",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizza_PizzaId",
                table: "OrderPizza",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaIngredient_IngredientId",
                table: "PizzaIngredient",
                column: "IngredientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlcoholicDrinks");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "OrderDrink");

            migrationBuilder.DropTable(
                name: "OrderPizza");

            migrationBuilder.DropTable(
                name: "PizzaIngredient");

            migrationBuilder.DropTable(
                name: "SodaDrinks");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
