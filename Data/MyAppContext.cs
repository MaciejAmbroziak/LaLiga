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
        public DbSet<SeazonLeague> SeazonLeagues { get; set; }
        public DbSet<Seazon> Seazons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamMatch>().HasKey(a => new { a.TeamId, a.MatchId });
            modelBuilder.Entity<SeazonLeague>().HasKey(a => new { a.SeazonId, a.LeagueId });
        }

    }
}

