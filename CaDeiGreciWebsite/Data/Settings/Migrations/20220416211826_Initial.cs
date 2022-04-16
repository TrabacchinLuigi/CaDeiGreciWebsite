using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaDeiGreciWebsite.Data.Settings.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Settings");

            migrationBuilder.CreateTable(
                name: "Openings",
                schema: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDayOfWeek = table.Column<int>(type: "int", nullable: false),
                    EndDayOfWeek = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Openings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Openings",
                schema: "Settings");
        }
    }
}
