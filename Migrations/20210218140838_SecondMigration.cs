using Microsoft.EntityFrameworkCore.Migrations;

namespace LaLiga.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_AwayTeamTeamId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_HomeTeamTeamId",
                table: "Match");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Match_AwayTeamTeamId",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_HomeTeamTeamId",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "AwayTeamTeamId",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "HomeTeamTeamId",
                table: "Match");

            migrationBuilder.AlterColumn<string>(
                name: "TeamName",
                table: "Team",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "Team",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AwayTeamLogo",
                table: "Match",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AwayTeamTeamName",
                table: "Match",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeTeamLogo",
                table: "Match",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeTeamTeamName",
                table: "Match",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                table: "Team",
                columns: new[] { "TeamName", "Logo" });

            migrationBuilder.CreateIndex(
                name: "IX_Match_AwayTeamTeamName_AwayTeamLogo",
                table: "Match",
                columns: new[] { "AwayTeamTeamName", "AwayTeamLogo" });

            migrationBuilder.CreateIndex(
                name: "IX_Match_HomeTeamTeamName_HomeTeamLogo",
                table: "Match",
                columns: new[] { "HomeTeamTeamName", "HomeTeamLogo" });

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_AwayTeamTeamName_AwayTeamLogo",
                table: "Match",
                columns: new[] { "AwayTeamTeamName", "AwayTeamLogo" },
                principalTable: "Team",
                principalColumns: new[] { "TeamName", "Logo" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_HomeTeamTeamName_HomeTeamLogo",
                table: "Match",
                columns: new[] { "HomeTeamTeamName", "HomeTeamLogo" },
                principalTable: "Team",
                principalColumns: new[] { "TeamName", "Logo" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_AwayTeamTeamName_AwayTeamLogo",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_HomeTeamTeamName_HomeTeamLogo",
                table: "Match");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Match_AwayTeamTeamName_AwayTeamLogo",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_HomeTeamTeamName_HomeTeamLogo",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "AwayTeamLogo",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "AwayTeamTeamName",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "HomeTeamLogo",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "HomeTeamTeamName",
                table: "Match");

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "Team",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "TeamName",
                table: "Team",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "AwayTeamTeamId",
                table: "Match",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeTeamTeamId",
                table: "Match",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                table: "Team",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_AwayTeamTeamId",
                table: "Match",
                column: "AwayTeamTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_HomeTeamTeamId",
                table: "Match",
                column: "HomeTeamTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_AwayTeamTeamId",
                table: "Match",
                column: "AwayTeamTeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_HomeTeamTeamId",
                table: "Match",
                column: "HomeTeamTeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
