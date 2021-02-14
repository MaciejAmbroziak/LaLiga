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
        public DbSet<TeamH2H> Teams { get; set; }
        public DbSet<Match> HomeMatches { get; set; }
        public DbSet<Match> AwayMatches { get; set; }
        public DbSet<League> Leagues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamH2H>().ToTable("Team");
            modelBuilder.Entity<Match>().ToTable("Match").
                HasIndex(a => new { a.MatchDateTime, a.RefereeId}).
                IsUnique();
            modelBuilder.Entity<Referee>().ToTable("Referee");
            modelBuilder.Entity<League>().ToTable("League").
                HasIndex(a => new { a.LeagueName, a.LeagueSeazon}).
                IsUnique();

        }

    }
}

