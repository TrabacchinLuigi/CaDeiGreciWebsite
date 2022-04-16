using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaDeiGreciWebsite.Data.Menu.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Menu");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Show = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesPriceKind",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesPriceKind", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriesPriceKind_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Menu",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Show = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Menu",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    MenuPriceKindId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_CategoriesPriceKind_MenuPriceKindId",
                        column: x => x.MenuPriceKindId,
                        principalSchema: "Menu",
                        principalTable: "CategoriesPriceKind",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prices_Items_MenuItemId",
                        column: x => x.MenuItemId,
                        principalSchema: "Menu",
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesPriceKind_CategoryId",
                schema: "Menu",
                table: "CategoriesPriceKind",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                schema: "Menu",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_MenuItemId",
                schema: "Menu",
                table: "Prices",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_MenuPriceKindId",
                schema: "Menu",
                table: "Prices",
                column: "MenuPriceKindId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "CategoriesPriceKind",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "Items",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "Menu");
        }
    }
}
