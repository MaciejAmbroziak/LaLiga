﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaLiga.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalApiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seazons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeazonYear = table.Column<int>(type: "int", nullable: false),
                    SezonBeginning = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeazonEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seazons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeagueId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeagueSeazon",
                columns: table => new
                {
                    LeagueId = table.Column<int>(type: "int", nullable: false),
                    SeazonsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueSeazon", x => new { x.LeagueId, x.SeazonsId });
                    table.ForeignKey(
                        name: "FK_LeagueSeazon_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeagueSeazon_Seazons_SeazonsId",
                        column: x => x.SeazonsId,
                        principalTable: "Seazons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeazonLeagues",
                columns: table => new
                {
                    SeazonId = table.Column<int>(type: "int", nullable: false),
                    LeagueId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeazonLeagues", x => new { x.SeazonId, x.LeagueId });
                    table.ForeignKey(
                        name: "FK_SeazonLeagues_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeazonLeagues_Seazons_SeazonId",
                        column: x => x.SeazonId,
                        principalTable: "Seazons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeazonLeagues_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Referees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAndCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeazonLeagueSeazonId = table.Column<int>(type: "int", nullable: true),
                    SeazonLeagueLeagueId = table.Column<int>(type: "int", nullable: true),
                    LeagueId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referees_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Referees_SeazonLeagues_SeazonLeagueSeazonId_SeazonLeagueLeagueId",
                        columns: x => new { x.SeazonLeagueSeazonId, x.SeazonLeagueLeagueId },
                        principalTable: "SeazonLeagues",
                        principalColumns: new[] { "SeazonId", "LeagueId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeazonLeagueSeazonId = table.Column<int>(type: "int", nullable: true),
                    SeazonLeagueLeagueId = table.Column<int>(type: "int", nullable: true),
                    MatchDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HomeTeamId = table.Column<int>(type: "int", nullable: true),
                    AwayTeamId = table.Column<int>(type: "int", nullable: true),
                    RefereeId = table.Column<int>(type: "int", nullable: true),
                    HalfTimeHomeGoals = table.Column<int>(type: "int", nullable: false),
                    HalfTimeAwayGoals = table.Column<int>(type: "int", nullable: false),
                    FullTimeHomeGoals = table.Column<int>(type: "int", nullable: false),
                    FullTimeAwayGoals = table.Column<int>(type: "int", nullable: false),
                    HomeOffSides = table.Column<int>(type: "int", nullable: false),
                    AwayOffSides = table.Column<int>(type: "int", nullable: false),
                    HomeFouls = table.Column<int>(type: "int", nullable: false),
                    AwayFouls = table.Column<int>(type: "int", nullable: false),
                    HomeShotsInsideBox = table.Column<int>(type: "int", nullable: false),
                    AwayShotsInsideBox = table.Column<int>(type: "int", nullable: false),
                    HomeShotsOutsideBox = table.Column<int>(type: "int", nullable: false),
                    AwayShotsOutsideBox = table.Column<int>(type: "int", nullable: false),
                    HomeShotsOnTarget = table.Column<int>(type: "int", nullable: false),
                    AwayShotsOnTarget = table.Column<int>(type: "int", nullable: false),
                    HomeShotsOffGoal = table.Column<int>(type: "int", nullable: false),
                    AwayShotsOffGoal = table.Column<int>(type: "int", nullable: false),
                    HomeTotalShots = table.Column<int>(type: "int", nullable: false),
                    AwayTotalShots = table.Column<int>(type: "int", nullable: false),
                    HomeBlockedShots = table.Column<int>(type: "int", nullable: false),
                    AwayBlockedShots = table.Column<int>(type: "int", nullable: false),
                    HomeCorners = table.Column<int>(type: "int", nullable: false),
                    AwayCorners = table.Column<int>(type: "int", nullable: false),
                    HomeYellowCards = table.Column<int>(type: "int", nullable: false),
                    AwayYellowCards = table.Column<int>(type: "int", nullable: false),
                    HomeRedCards = table.Column<int>(type: "int", nullable: false),
                    AwayRedCards = table.Column<int>(type: "int", nullable: false),
                    HomeBallPossession = table.Column<int>(type: "int", nullable: false),
                    AwayBallPossession = table.Column<int>(type: "int", nullable: false),
                    HomeGoalKeeperSaves = table.Column<int>(type: "int", nullable: false),
                    AwayGoalKeeperSaves = table.Column<int>(type: "int", nullable: false),
                    HomeTotalPasses = table.Column<int>(type: "int", nullable: false),
                    AwayTotalPasses = table.Column<int>(type: "int", nullable: false),
                    HomePassesAcurate = table.Column<int>(type: "int", nullable: false),
                    AwayPassesAcurate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Referees_RefereeId",
                        column: x => x.RefereeId,
                        principalTable: "Referees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_SeazonLeagues_SeazonLeagueSeazonId_SeazonLeagueLeagueId",
                        columns: x => new { x.SeazonLeagueSeazonId, x.SeazonLeagueLeagueId },
                        principalTable: "SeazonLeagues",
                        principalColumns: new[] { "SeazonId", "LeagueId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamMatch",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Home = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMatch", x => new { x.TeamId, x.MatchId });
                    table.ForeignKey(
                        name: "FK_TeamMatch_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMatch_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeagueSeazon_SeazonsId",
                table: "LeagueSeazon",
                column: "SeazonsId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayTeamId",
                table: "Matches",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeamId",
                table: "Matches",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_RefereeId",
                table: "Matches",
                column: "RefereeId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_SeazonLeagueSeazonId_SeazonLeagueLeagueId",
                table: "Matches",
                columns: new[] { "SeazonLeagueSeazonId", "SeazonLeagueLeagueId" });

            migrationBuilder.CreateIndex(
                name: "IX_Referees_LeagueId",
                table: "Referees",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Referees_SeazonLeagueSeazonId_SeazonLeagueLeagueId",
                table: "Referees",
                columns: new[] { "SeazonLeagueSeazonId", "SeazonLeagueLeagueId" });

            migrationBuilder.CreateIndex(
                name: "IX_SeazonLeagues_LeagueId",
                table: "SeazonLeagues",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_SeazonLeagues_TeamId",
                table: "SeazonLeagues",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMatch_MatchId",
                table: "TeamMatch",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams",
                column: "LeagueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeagueSeazon");

            migrationBuilder.DropTable(
                name: "TeamMatch");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Referees");

            migrationBuilder.DropTable(
                name: "SeazonLeagues");

            migrationBuilder.DropTable(
                name: "Seazons");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Leagues");
        }
    }
}
