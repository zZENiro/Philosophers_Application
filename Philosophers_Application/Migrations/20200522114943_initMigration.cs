using Microsoft.EntityFrameworkCore.Migrations;

namespace Philosophers_Application.Migrations
{
    public partial class initMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countries_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "directions_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectionName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_directions_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "philosophers_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhilosopherName = table.Column<string>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_philosophers_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_philosophers_tbl_countries_tbl_CountryId",
                        column: x => x.CountryId,
                        principalTable: "countries_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhilosopherDirection",
                columns: table => new
                {
                    PhilosopherId = table.Column<int>(nullable: false),
                    DirectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhilosopherDirection", x => new { x.DirectionId, x.PhilosopherId });
                    table.ForeignKey(
                        name: "FK_PhilosopherDirection_directions_tbl_DirectionId",
                        column: x => x.DirectionId,
                        principalTable: "directions_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhilosopherDirection_philosophers_tbl_PhilosopherId",
                        column: x => x.PhilosopherId,
                        principalTable: "philosophers_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhilosopherDirection_PhilosopherId",
                table: "PhilosopherDirection",
                column: "PhilosopherId");

            migrationBuilder.CreateIndex(
                name: "IX_philosophers_tbl_CountryId",
                table: "philosophers_tbl",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhilosopherDirection");

            migrationBuilder.DropTable(
                name: "directions_tbl");

            migrationBuilder.DropTable(
                name: "philosophers_tbl");

            migrationBuilder.DropTable(
                name: "countries_tbl");
        }
    }
}
