using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaDeiGreciWebsite.Data.Menu.Migrations
{
    public partial class AllergenAndQualities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergens",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qualities",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemAllergens",
                schema: "Menu",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    AllergenId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemAllergens", x => new { x.ItemId, x.AllergenId });
                    table.ForeignKey(
                        name: "FK_ItemAllergens_Allergens_AllergenId",
                        column: x => x.AllergenId,
                        principalSchema: "Menu",
                        principalTable: "Allergens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemAllergens_Items_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Menu",
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemQualities",
                schema: "Menu",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    QualityId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemQualities", x => new { x.ItemId, x.QualityId });
                    table.ForeignKey(
                        name: "FK_ItemQualities_Items_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "Menu",
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemQualities_Qualities_QualityId",
                        column: x => x.QualityId,
                        principalSchema: "Menu",
                        principalTable: "Qualities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Menu",
                table: "Allergens",
                columns: new[] { "Id", "Description", "ImageUpdateDate", "Name", "Order" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dairy", 0 },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eggs", 0 },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fish", 0 },
                    { 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gluten", 0 },
                    { 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Legumes", 0 },
                    { 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peanut", 0 },
                    { 7, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seeds", 0 },
                    { 8, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shellfish", 0 },
                    { 9, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Treenuts", 0 },
                    { 10, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corn", 0 }
                });

            migrationBuilder.InsertData(
                schema: "Menu",
                table: "Qualities",
                columns: new[] { "Id", "Description", "ImageUpdateDate", "Name", "Order" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bio", 0 },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "locally grown", 0 },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "vegan", 0 },
                    { 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "vegetarian", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemAllergens_AllergenId",
                schema: "Menu",
                table: "ItemAllergens",
                column: "AllergenId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemQualities_QualityId",
                schema: "Menu",
                table: "ItemQualities",
                column: "QualityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemAllergens",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "ItemQualities",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "Allergens",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "Qualities",
                schema: "Menu");
        }
    }
}
