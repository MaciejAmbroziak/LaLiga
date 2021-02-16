using LaLiga.Data;
using LaLiga.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaLiga.ServiceForExternalApi
{
    public class DataToMatch : Controller
    {
        private readonly ExternalApiLeagueInSeazonController _apiLeagueInSeazon;
        private readonly ExternalApiMatchController _apiMatch;
        private readonly MyAppContext _context;
        private StringToNumber convert = new StringToNumber();
        public Match Match = new Match();
        public DataToMatch(ExternalApiLeagueInSeazonController externalApiLeagueInSeazon, ExternalApiMatchController externalApiMatchController, MyAppContext myAppContext)
        {
            _apiLeagueInSeazon = externalApiLeagueInSeazon;
            _context = myAppContext;
            _apiMatch = externalApiMatchController;
        }
        [HttpGet("{seazon}/{league}/{home}/{away}")]
        public async Task<ActionResult<Match>> GenerateMatch(string home, string away, int league, int seazon)
        {
            var recordInLeague =  _apiLeagueInSeazon.Get(league,seazon).GetAwaiter().GetResult();
            var leagueData = recordInLeague.Value.response.Where(p => p.teams.home.name == home && p.teams.away.name == away).FirstOrDefault();
            int fixtureId = leagueData.fixture.id;
            if (leagueData != null)
            {
                Match.MatchDateTime = leagueData.fixture.date;
 //               Match.HomeTeam.TeamName = home;
   //             Match.AwayTeam.TeamName = away;
                Match.RefereeId = 1;
                Match.HalfTimeHomeGoals = leagueData.score.halftime.home ?? 0;
                Match.HalfTimeAwayGoals = leagueData.score.halftime.away ?? 0;
                Match.FullTimeHomeGoals = leagueData.score.fulltime.home ?? 0;
                Match.FullTimeAwayGoals = leagueData.score.fulltime.away ?? 0;


                var recordInFixture = _apiMatch.Get(fixtureId).GetAwaiter().GetResult();

                ResponseH2H homeValues = recordInFixture.Value.response.Where(a => a.team.name == home).FirstOrDefault();
                Match.HomeCorners = convert.Convert((homeValues.statistics.First(a => a.type == "Corner Kicks").value ?? "0").ToString());
                Match.HomeBallPossession = convert.Convert((homeValues.statistics.First(a => a.type == "Ball Possession").value ?? "0").ToString());
                Match.HomeBlockedShots = convert.Convert((homeValues.statistics.First(a => a.type == "Blocked Shots").value ?? "0").ToString());
                Match.HomeFouls = convert.Convert((homeValues.statistics.First(a => a.type == "Fouls").value ?? "0").ToString());
                Match.HomeGoalKeeperSaves = convert.Convert((homeValues.statistics.First(a => a.type == "Goalkeeper Saves").value ?? "0").ToString());
                Match.HomeOffSides = convert.Convert((homeValues.statistics.First(a => a.type == "Offsides").value ?? "0").ToString());
                Match.HomeRedCards = convert.Convert((homeValues.statistics.First(a => a.type == "Red Cards").value ?? "0").ToString());
                Match.HomeShotsInsideBox = convert.Convert((homeValues.statistics.First(a => a.type == "Shots insidebox").value ?? "0").ToString());
                Match.HomeShotsOffGoal = convert.Convert((homeValues.statistics.First(a => a.type == "Shots off Goal").value ?? "0").ToString());
                
                Match.HomeShotsOnTarget = convert.Convert((homeValues.statistics.First(a => a.type == "Shots on Goal").value ?? "0").ToString());
                Match.HomeShotsOutsideBox = convert.Convert((homeValues.statistics.First(a => a.type == "Shots outsidebox").value ?? "0").ToString());
                Match.HomeTotalShots = convert.Convert((homeValues.statistics.First(a => a.type == "Total Shots").value ?? "0").ToString());
                Match.HomeYellowCards = convert.Convert((homeValues.statistics.First(a => a.type == "Yellow Cards").value ?? "0").ToString());
                Match.HomeTotalPasses = convert.Convert((homeValues.statistics.First(a => a.type == "Total passes").value ?? "0").ToString());
                Match.HomePassesAcurate = convert.Convert((homeValues.statistics.First(a => a.type == "Passes accurate").value ?? "0").ToString());

                ResponseH2H awayValues = recordInFixture.Value.response.Where(a => a.team.name == away).FirstOrDefault();
                Match.AwayCorners = convert.Convert((awayValues.statistics.First(a => a.type == "Corner Kicks").value ?? "0").ToString());
                Match.AwayBallPossession = convert.Convert((awayValues.statistics.First(a => a.type == "Ball Possession").value ?? "0").ToString());
                Match.AwayBlockedShots = convert.Convert((awayValues.statistics.First(a => a.type == "Blocked Shots").value ?? "0").ToString());
                Match.AwayFouls = convert.Convert((awayValues.statistics.First(a => a.type == "Fouls").value ?? "0").ToString());
                Match.AwayGoalKeeperSaves = convert.Convert((awayValues.statistics.First(a => a.type == "Goalkeeper Saves").value ?? "0").ToString());
                Match.AwayOffSides = convert.Convert((awayValues.statistics.First(a => a.type == "Offsides").value ?? "0").ToString());
                Match.AwayRedCards = convert.Convert((awayValues.statistics.First(a => a.type == "Red Cards").value ?? "0").ToString());
                Match.AwayShotsInsideBox = convert.Convert((awayValues.statistics.First(a => a.type == "Shots insidebox").value ?? "0").ToString());
                Match.AwayShotsOffGoal = convert.Convert((awayValues.statistics.First(a => a.type == "Shots off Goal").value ?? "0").ToString());
                Match.AwayShotsOnTarget = convert.Convert((awayValues.statistics.First(a => a.type == "Shots on Goal").value ?? "0").ToString());
                Match.AwayShotsOutsideBox = convert.Convert((awayValues.statistics.First(a => a.type == "Shots outsidebox").value ?? "0").ToString());
                Match.AwayTotalShots = convert.Convert((awayValues.statistics.First(a => a.type == "Total Shots").value ?? "0").ToString());
                Match.AwayYellowCards = convert.Convert((awayValues.statistics.First(a => a.type == "Yellow Cards").value ?? "0").ToString());
                Match.AwayTotalPasses = convert.Convert((awayValues.statistics.First(a => a.type == "Total passes").value ?? "0").ToString());
                Match.AwayPassesAcurate = convert.Convert((awayValues.statistics.First(a => a.type == "Passes accurate").value ?? "0").ToString());
            }
            _context.Add(Match);
            await _context.SaveChangesAsync();
            return Match;
        }
    }
}
