﻿// <auto-generated />
using System;
using LaLiga.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LaLiga.Migrations
{
    [DbContext(typeof(MyAppContext))]
    [Migration("20210214214217_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LaLiga.Models.League", b =>
                {
                    b.Property<int>("LeagueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LeagueName")
                        .HasColumnType("int");

                    b.Property<DateTime>("LeagueSeazon")
                        .HasColumnType("datetime2");

                    b.HasKey("LeagueId");

                    b.HasIndex("LeagueName", "LeagueSeazon")
                        .IsUnique();

                    b.ToTable("League");
                });

            modelBuilder.Entity("LaLiga.Models.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AwayBallPossession")
                        .HasColumnType("int");

                    b.Property<int>("AwayBlockedShots")
                        .HasColumnType("int");

                    b.Property<int>("AwayCorners")
                        .HasColumnType("int");

                    b.Property<int>("AwayFouls")
                        .HasColumnType("int");

                    b.Property<int>("AwayGoalKeeperSaves")
                        .HasColumnType("int");

                    b.Property<int>("AwayOffSides")
                        .HasColumnType("int");

                    b.Property<int>("AwayRedCards")
                        .HasColumnType("int");

                    b.Property<int>("AwayShotsInsideBox")
                        .HasColumnType("int");

                    b.Property<int>("AwayShotsOffGoal")
                        .HasColumnType("int");

                    b.Property<int>("AwayShotsOnTarget")
                        .HasColumnType("int");

                    b.Property<int>("AwayShotsOutsideBox")
                        .HasColumnType("int");

                    b.Property<int?>("AwayTeamTeamId")
                        .HasColumnType("int");

                    b.Property<int>("AwayTotalShots")
                        .HasColumnType("int");

                    b.Property<int>("AwayYellowCards")
                        .HasColumnType("int");

                    b.Property<int>("FullTimeAwayGoals")
                        .HasColumnType("int");

                    b.Property<int>("FullTimeHomeGoals")
                        .HasColumnType("int");

                    b.Property<int>("HalfTimeAwayGoals")
                        .HasColumnType("int");

                    b.Property<int>("HalfTimeHomeGoals")
                        .HasColumnType("int");

                    b.Property<int>("HomeBallPossession")
                        .HasColumnType("int");

                    b.Property<int>("HomeBlockedShots")
                        .HasColumnType("int");

                    b.Property<int>("HomeCorners")
                        .HasColumnType("int");

                    b.Property<int>("HomeFouls")
                        .HasColumnType("int");

                    b.Property<int>("HomeGoalKeeperSaves")
                        .HasColumnType("int");

                    b.Property<int>("HomeOffSides")
                        .HasColumnType("int");

                    b.Property<int>("HomeRedCards")
                        .HasColumnType("int");

                    b.Property<int>("HomeShotsInsideBox")
                        .HasColumnType("int");

                    b.Property<int>("HomeShotsOffGoal")
                        .HasColumnType("int");

                    b.Property<int>("HomeShotsOnTarget")
                        .HasColumnType("int");

                    b.Property<int>("HomeShotsOutsideBox")
                        .HasColumnType("int");

                    b.Property<int?>("HomeTeamTeamId")
                        .HasColumnType("int");

                    b.Property<int>("HomeTotalShots")
                        .HasColumnType("int");

                    b.Property<int>("HomeYellowCards")
                        .HasColumnType("int");

                    b.Property<string>("League")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MatchDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PassesAcurate")
                        .HasColumnType("int");

                    b.Property<int>("RefereeId")
                        .HasColumnType("int");

                    b.Property<int?>("Referees")
                        .HasColumnType("int");

                    b.Property<int>("Seazon")
                        .HasColumnType("int");

                    b.Property<int>("TotalPasses")
                        .HasColumnType("int");

                    b.HasKey("MatchId");

                    b.HasIndex("AwayTeamTeamId");

                    b.HasIndex("HomeTeamTeamId");

                    b.HasIndex("Referees");

                    b.HasIndex("MatchDateTime", "RefereeId")
                        .IsUnique();

                    b.ToTable("Match");
                });

            modelBuilder.Entity("LaLiga.Models.Referee", b =>
                {
                    b.Property<int>("RefereeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameAndCountry")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Referee")
                        .HasColumnType("int");

                    b.HasKey("RefereeId");

                    b.HasIndex("NameAndCountry")
                        .IsUnique()
                        .HasFilter("[NameAndCountry] IS NOT NULL");

                    b.HasIndex("Referee");

                    b.ToTable("Referee");
                });

            modelBuilder.Entity("LaLiga.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Team")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.HasIndex("Team");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("LaLiga.Models.Match", b =>
                {
                    b.HasOne("LaLiga.Models.Team", "AwayTeam")
                        .WithMany("AwayMatches")
                        .HasForeignKey("AwayTeamTeamId");

                    b.HasOne("LaLiga.Models.Team", "HomeTeam")
                        .WithMany("HomeMatches")
                        .HasForeignKey("HomeTeamTeamId");

                    b.HasOne("LaLiga.Models.Referee", null)
                        .WithMany("Matches")
                        .HasForeignKey("Referees");
                });

            modelBuilder.Entity("LaLiga.Models.Referee", b =>
                {
                    b.HasOne("LaLiga.Models.League", "RefereeLeague")
                        .WithMany("Referees")
                        .HasForeignKey("Referee");
                });

            modelBuilder.Entity("LaLiga.Models.Team", b =>
                {
                    b.HasOne("LaLiga.Models.League", null)
                        .WithMany("Teams")
                        .HasForeignKey("Team");
                });
#pragma warning restore 612, 618
        }
    }
}
