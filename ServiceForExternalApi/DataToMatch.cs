using LaLiga.Data;
using LaLiga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaLiga.ServiceForExternalApi
{
    public class DataToMatch
    {
        private readonly ExternalApiMatch _apiMatch;
        private readonly ExternalApiLeagueInSeazon _apiLeagueInSeazon;
        private readonly MyAppContext _context;

        public Match Match { get; set; }
        DataToMatch(ExternalApiLeagueInSeazon externalApiLeagueInSeazon, ExternalApiMatch externalApiMatch, MyAppContext myAppContext)
        {
            _apiLeagueInSeazon = externalApiLeagueInSeazon;
            _apiMatch = externalApiMatch;
            _context = myAppContext;
        }

        public Match GenerateMatch(string home, string away, DateTime when, Referee referee)
        {
            var record = _apiLeagueInSeazon.MyObject.response.Where(p => p.teams.home.name == home && p.teams.away.name == away && p.fixture.date == when).FirstOrDefault();
            if (record != null) 
            {
                Match.MatchDateTime = when;
                Match.HomeTeam.TeamName = home;
                Match.AwayTeam.TeamName = away;
                Match.HalfTimeHomeGoals = record.score.halftime.home;
                Match.HalfTimeAwayGoals = record.score.halftime.away;
                Match.FullTimeHomeGoals = record.score.fulltime.home;
            }
            return Match;
        }

    }
}
