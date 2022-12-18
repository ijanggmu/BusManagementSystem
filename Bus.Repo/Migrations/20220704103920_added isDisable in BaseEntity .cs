using Microsoft.EntityFrameworkCore.Migrations;

namespace Bus.Repo.Migrations
{
    public partial class addedisDisableinBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDisable",
                table: "Routes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDisable",
                table: "BusDetails",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDisable",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "isDisable",
                table: "BusDetails");
        }
    }
}
