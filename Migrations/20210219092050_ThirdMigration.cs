using Microsoft.EntityFrameworkCore.Migrations;

namespace LaLiga.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Match_MatchDateTime_RefereeId",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "RefereeId",
                table: "Match");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RefereeId",
                table: "Match",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Match_MatchDateTime_RefereeId",
                table: "Match",
                columns: new[] { "MatchDateTime", "RefereeId" },
                unique: true);
        }
    }
}
