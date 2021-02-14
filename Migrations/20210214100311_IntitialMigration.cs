using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaLiga.Migrations
{
    public partial class IntitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "League",
                columns: table => new
                {
                    LeagueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeagueName = table.Column<int>(nullable: false),
                    LeagueSeazon = table.Column<DateTime>(nullable: false)
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
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    RefereeLeagueLeagueId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referee", x => x.RefereeId);
                    table.ForeignKey(
                        name: "FK_Referee_League_RefereeLeagueLeagueId",
                        column: x => x.RefereeLeagueLeagueId,
                        principalTable: "League",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Team = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
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
                    League = table.Column<string>(nullable: true),
                    MatchDateTime = table.Column<DateTime>(nullable: false),
                    HomeTeamTeamId = table.Column<int>(nullable: true),
                    AwayTeamTeamId = table.Column<int>(nullable: true),
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
                    Referees = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Match_Team_AwayTeamTeamId",
                        column: x => x.AwayTeamTeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Team_HomeTeamTeamId",
                        column: x => x.HomeTeamTeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Referee_Referees",
                        column: x => x.Referees,
                        principalTable: "Referee",
                        principalColumn: "RefereeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_League_LeagueName_LeagueSeazon",
                table: "League",
                columns: new[] { "LeagueName", "LeagueSeazon" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Match_AwayTeamTeamId",
                table: "Match",
                column: "AwayTeamTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_HomeTeamTeamId",
                table: "Match",
                column: "HomeTeamTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_Referees",
                table: "Match",
                column: "Referees");

            migrationBuilder.CreateIndex(
                name: "IX_Match_MatchDateTime_RefereeId",
                table: "Match",
                columns: new[] { "MatchDateTime", "RefereeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Referee_RefereeLeagueLeagueId",
                table: "Referee",
                column: "RefereeLeagueLeagueId");

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
                name: "Team");

            migrationBuilder.DropTable(
                name: "Referee");

            migrationBuilder.DropTable(
                name: "League");
        }
    }
}
