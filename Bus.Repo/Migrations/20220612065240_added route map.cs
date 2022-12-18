using Microsoft.EntityFrameworkCore.Migrations;

namespace Bus.Repo.Migrations
{
    public partial class addedroutemap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RouteMapLink",
                table: "Routes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RouteMapLink",
                table: "Routes");
        }
    }
}
