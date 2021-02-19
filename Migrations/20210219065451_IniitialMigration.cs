using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaLiga.Migrations
{
    public partial class IniitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "League",
                columns: table => new
                {
                    LeagueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeagueName = table.Column<string>(nullable: true),
                    LeagueSeazon = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_League", x => x.LeagueId);
                });

            migrationBuilder.CreateTable(
                name: "Referee",
                columns: table => new
                {
                    RefereeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAndCountry = table.Column<string>(nullable: true),
                    Referee = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referee", x => x.RefereeId);
                    table.ForeignKey(
                        name: "FK_Referee_League_Referee",
                        column: x => x.Referee,
                        principalTable: "League",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamName = table.Column<string>(nullable: false),
                    Logo = table.Column<string>(nullable: false),
                    TeamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Team = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => new { x.TeamName, x.Logo });
                    table.ForeignKey(
                        name: "FK_Team_League_Team",
                        column: x => x.Team,
                        principalTable: "League",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    MatchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seazon = table.Column<int>(nullable: false),
                    LeagueId = table.Column<int>(nullable: true),
                    MatchDateTime = table.Column<DateTime>(nullable: false),
                    HomeTeamTeamName = table.Column<string>(nullable: true),
                    HomeTeamLogo = table.Column<string>(nullable: true),
                    AwayTeamTeamName = table.Column<string>(nullable: true),
                    AwayTeamLogo = table.Column<string>(nullable: true),
                    RefereeId = table.Column<int>(nullable: false),
                    HalfTimeHomeGoals = table.Column<int>(nullable: false),
                    HalfTimeAwayGoals = table.Column<int>(nullable: false),
                    FullTimeHomeGoals = table.Column<int>(nullable: false),
                    FullTimeAwayGoals = table.Column<int>(nullable: false),
                    HomeOffSides = table.Column<int>(nullable: false),
                    AwayOffSides = table.Column<int>(nullable: false),
                    HomeFouls = table.Column<int>(nullable: false),
                    AwayFouls = table.Column<int>(nullable: false),
                    HomeShotsInsideBox = table.Column<int>(nullable: false),
                    AwayShotsInsideBox = table.Column<int>(nullable: false),
                    HomeShotsOutsideBox = table.Column<int>(nullable: false),
                    AwayShotsOutsideBox = table.Column<int>(nullable: false),
                    HomeShotsOnTarget = table.Column<int>(nullable: false),
                    AwayShotsOnTarget = table.Column<int>(nullable: false),
                    HomeShotsOffGoal = table.Column<int>(nullable: false),
                    AwayShotsOffGoal = table.Column<int>(nullable: false),
                    HomeTotalShots = table.Column<int>(nullable: false),
                    AwayTotalShots = table.Column<int>(nullable: false),
                    HomeBlockedShots = table.Column<int>(nullable: false),
                    AwayBlockedShots = table.Column<int>(nullable: false),
                    HomeCorners = table.Column<int>(nullable: false),
                    AwayCorners = table.Column<int>(nullable: false),
                    HomeYellowCards = table.Column<int>(nullable: false),
                    AwayYellowCards = table.Column<int>(nullable: false),
                    HomeRedCards = table.Column<int>(nullable: false),
                    AwayRedCards = table.Column<int>(nullable: false),
                    HomeBallPossession = table.Column<int>(nullable: false),
                    AwayBallPossession = table.Column<int>(nullable: false),
                    HomeGoalKeeperSaves = table.Column<int>(nullable: false),
                    AwayGoalKeeperSaves = table.Column<int>(nullable: false),
                    HomeTotalPasses = table.Column<int>(nullable: false),
                    AwayTotalPasses = table.Column<int>(nullable: false),
                    HomePassesAcurate = table.Column<int>(nullable: false),
                    AwayPassesAcurate = table.Column<int>(nullable: false),
                    Referees = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Match_League_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "League",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Referee_Referees",
                        column: x => x.Referees,
                        principalTable: "Referee",
                        principalColumn: "RefereeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Team_AwayTeamTeamName_AwayTeamLogo",
                        columns: x => new { x.AwayTeamTeamName, x.AwayTeamLogo },
                        principalTable: "Team",
                        principalColumns: new[] { "TeamName", "Logo" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Team_HomeTeamTeamName_HomeTeamLogo",
                        columns: x => new { x.HomeTeamTeamName, x.HomeTeamLogo },
                        principalTable: "Team",
                        principalColumns: new[] { "TeamName", "Logo" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_League_LeagueSeazon",
                table: "League",
                column: "LeagueSeazon",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Match_LeagueId",
                table: "Match",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_Referees",
                table: "Match",
                column: "Referees");

            migrationBuilder.CreateIndex(
                name: "IX_Match_AwayTeamTeamName_AwayTeamLogo",
                table: "Match",
                columns: new[] { "AwayTeamTeamName", "AwayTeamLogo" });

            migrationBuilder.CreateIndex(
                name: "IX_Match_HomeTeamTeamName_HomeTeamLogo",
                table: "Match",
                columns: new[] { "HomeTeamTeamName", "HomeTeamLogo" });

            migrationBuilder.CreateIndex(
                name: "IX_Match_MatchDateTime_RefereeId",
                table: "Match",
                columns: new[] { "MatchDateTime", "RefereeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Referee_NameAndCountry",
                table: "Referee",
                column: "NameAndCountry",
                unique: true,
                filter: "[NameAndCountry] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Referee_Referee",
                table: "Referee",
                column: "Referee");

            migrationBuilder.CreateIndex(
                name: "IX_Team_Team",
                table: "Team",
                column: "Team");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Referee");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "League");
        }
    }
}
