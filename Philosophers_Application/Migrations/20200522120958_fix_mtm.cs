using Microsoft.EntityFrameworkCore.Migrations;

namespace Philosophers_Application.Migrations
{
    public partial class fix_mtm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PhilosopherDirection",
                table: "PhilosopherDirection");

            migrationBuilder.AddPrimaryKey(
                name: "Name",
                table: "PhilosopherDirection",
                columns: new[] { "DirectionId", "PhilosopherId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "Name",
                table: "PhilosopherDirection");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhilosopherDirection",
                table: "PhilosopherDirection",
                columns: new[] { "DirectionId", "PhilosopherId" });
        }
    }
}
