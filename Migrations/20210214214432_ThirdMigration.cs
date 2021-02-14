using Microsoft.EntityFrameworkCore.Migrations;

namespace LaLiga.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassesAcurate",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "TotalPasses",
                table: "Match");

            migrationBuilder.AddColumn<int>(
                name: "AwayPassesAcurate",
                table: "Match",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AwayTotalPasses",
                table: "Match",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomePassesAcurate",
                table: "Match",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeTotalPasses",
                table: "Match",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwayPassesAcurate",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "AwayTotalPasses",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "HomePassesAcurate",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "HomeTotalPasses",
                table: "Match");

            migrationBuilder.AddColumn<int>(
                name: "PassesAcurate",
                table: "Match",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPasses",
                table: "Match",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
