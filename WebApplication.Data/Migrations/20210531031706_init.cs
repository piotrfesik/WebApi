using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfigurationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laptops_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfigurationItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConfigurationTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfigurationItems_ConfigurationTypes_ConfigurationTypeId",
                        column: x => x.ConfigurationTypeId,
                        principalTable: "ConfigurationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaptopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItem_Laptops_LaptopId",
                        column: x => x.LaptopId,
                        principalTable: "Laptops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LaptopConfiguration",
                columns: table => new
                {
                    LaptopId = table.Column<int>(type: "int", nullable: false),
                    ConfigurationItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaptopConfiguration", x => new { x.LaptopId, x.ConfigurationItemId });
                    table.ForeignKey(
                        name: "FK_LaptopConfiguration_ConfigurationItems_ConfigurationItemId",
                        column: x => x.ConfigurationItemId,
                        principalTable: "ConfigurationItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LaptopConfiguration_Laptops_LaptopId",
                        column: x => x.LaptopId,
                        principalTable: "Laptops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Cost", "Name" },
                values: new object[,]
                {
                    { 1, 349.87m, "Dell" },
                    { 2, 345.67m, "Toshiba" },
                    { 3, 456.76m, "HP" }
                });

            migrationBuilder.InsertData(
                table: "ConfigurationTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { 1, "Ram" },
                    { 2, "Hdd" },
                    { 3, "Color" },
                    { 4, "Cpu" }
                });

            migrationBuilder.InsertData(
                table: "ConfigurationItems",
                columns: new[] { "Id", "ConfigurationTypeId", "Cost", "Name" },
                values: new object[,]
                {
                    { 1, 1, 45.67m, "8GB" },
                    { 2, 1, 87.88m, "16GB" },
                    { 3, 2, 123.34m, "500GB" },
                    { 4, 2, 200m, "1TB" },
                    { 5, 3, 50.76m, "Red" },
                    { 6, 3, 34.56m, "Blue" }
                });

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "Id", "BrandId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Laptop 1" },
                    { 2, 2, "Laptop 2" }
                });

            migrationBuilder.InsertData(
                table: "LaptopConfiguration",
                columns: new[] { "ConfigurationItemId", "LaptopId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 5, 1 },
                    { 1, 2 },
                    { 3, 2 },
                    { 5, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_LaptopId",
                table: "BasketItem",
                column: "LaptopId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationItems_ConfigurationTypeId",
                table: "ConfigurationItems",
                column: "ConfigurationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LaptopConfiguration_ConfigurationItemId",
                table: "LaptopConfiguration",
                column: "ConfigurationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_BrandId",
                table: "Laptops",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItem");

            migrationBuilder.DropTable(
                name: "LaptopConfiguration");

            migrationBuilder.DropTable(
                name: "ConfigurationItems");

            migrationBuilder.DropTable(
                name: "Laptops");

            migrationBuilder.DropTable(
                name: "ConfigurationTypes");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
