using LaLiga.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaLiga.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Referee> Referees { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().ToTable("Team")
                .HasKey(a=> new { a.TeamName, a.Logo});
            modelBuilder.Entity<Match>().ToTable("Match").
                HasIndex(a => new { a.MatchDateTime, a.RefereeId }).
                IsUnique();
            modelBuilder.Entity<Referee>().ToTable("Referee").
                HasIndex(a => new {a.NameAndCountry})
                .IsUnique();
            modelBuilder.Entity<League>().ToTable("League").
                HasIndex(a => new { a.LeagueName, a.LeagueSeazon}).
                IsUnique();

        }

    }
}

