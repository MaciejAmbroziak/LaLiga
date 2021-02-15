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
        private readonly ExternalApiLeagueInSeazon _apiLeagueInSeazon;
        private readonly MyAppContext _context;
        private ObjectsToNumber convert = new ObjectsToNumber();
        public Match Match { get; set; }
        public DataToMatch(ExternalApiLeagueInSeazon externalApiLeagueInSeazon, MyAppContext myAppContext)
        {
            _apiLeagueInSeazon = externalApiLeagueInSeazon;
            _context = myAppContext;
        }

        public async Task GenerateMatch(string home, string away)
        {
            var record = _apiLeagueInSeazon.MyObject.response.Where(p => p.teams.home.name == home && p.teams.away.name == away).FirstOrDefault();
            var refereeId = _context.Referees.Where(p => p.NameAndCountry == record.fixture.referee).FirstOrDefault();
            int fixtureId = record.fixture.id;
            ExternalApiMatch matchDeteiles = new ExternalApiMatch(fixtureId);
            if (record != null)
            {
                Match.MatchDateTime = record.fixture.date;
                Match.HomeTeam.TeamName = home;
                Match.AwayTeam.TeamName = away;
                Match.RefereeId = refereeId.RefereeId;
                Match.HalfTimeHomeGoals = record.score.halftime.home;
                Match.HalfTimeAwayGoals = record.score.halftime.away;
                Match.FullTimeHomeGoals = record.score.fulltime.home;
                Match.FullTimeAwayGoals = record.score.fulltime.away;
                ResponseH2H homeValues = matchDeteiles.MyObject.response.Where(a => a.team.name == home).FirstOrDefault();
                Match.HomeCorners = convert.Convert(homeValues.statistics.First(a => a.type == "Corner kicks").value);
                Match.HomeBallPossession = convert.Convert(homeValues.statistics.First(a => a.type == "Ball Possession").value);
                Match.HomeBlockedShots = convert.Convert(homeValues.statistics.First(a => a.type == "Blocked Shots").value);
                Match.HomeFouls = convert.Convert(homeValues.statistics.First(a => a.type == "Fouls").value);
                Match.HomeGoalKeeperSaves = convert.Convert(homeValues.statistics.First(a => a.type == "Goalkeeper Saves").value);
                Match.HomeOffSides = convert.Convert(homeValues.statistics.First(a => a.type == "Offsides").value);
                Match.HomeRedCards = convert.Convert(homeValues.statistics.First(a => a.type == "Red Cards").value);
                Match.HomeShotsInsideBox = convert.Convert(homeValues.statistics.First(a => a.type == "Shots insidebox").value);
                Match.HomeShotsOffGoal = convert.Convert(homeValues.statistics.First(a => a.type == "Shots off Goal").value);
                Match.HomeShotsOnTarget = convert.Convert(homeValues.statistics.First(a => a.type == "Shots on Goal").value);
                Match.HomeShotsOutsideBox = convert.Convert(homeValues.statistics.First(a => a.type == "Shots outsidebox").value);
                Match.HomeTotalShots = convert.Convert(homeValues.statistics.First(a => a.type == "Total Shots").value);
                Match.HomeYellowCards = convert.Convert(homeValues.statistics.First(a => a.type == "Yellow Cards").value);
                Match.HomeTotalPasses = convert.Convert(homeValues.statistics.First(a => a.type == "Total passes").value);
                Match.HomePassesAcurate = convert.Convert(homeValues.statistics.First(a => a.type == "Passes accurate").value);

                ResponseH2H awayValues = matchDeteiles.MyObject.response.Where(a => a.team.name == away).FirstOrDefault();
                Match.HomeCorners = convert.Convert(awayValues.statistics.First(a => a.type == "Corner kicks").value);
                Match.HomeBallPossession = convert.Convert(awayValues.statistics.First(a => a.type == "Ball Possession").value);
                Match.HomeBlockedShots = convert.Convert(awayValues.statistics.First(a => a.type == "Blocked Shots").value);
                Match.HomeFouls = convert.Convert(awayValues.statistics.First(a => a.type == "Fouls").value);
                Match.HomeGoalKeeperSaves = convert.Convert(awayValues.statistics.First(a => a.type == "Goalkeeper Saves").value);
                Match.HomeOffSides = convert.Convert(awayValues.statistics.First(a => a.type == "Offsides").value);
                Match.HomeRedCards = convert.Convert(awayValues.statistics.First(a => a.type == "Red Cards").value);
                Match.HomeShotsInsideBox = convert.Convert(awayValues.statistics.First(a => a.type == "Shots insidebox").value);
                Match.HomeShotsOffGoal = convert.Convert(awayValues.statistics.First(a => a.type == "Shots off Goal").value);
                Match.HomeShotsOnTarget = convert.Convert(awayValues.statistics.First(a => a.type == "Shots on Goal").value);
                Match.HomeShotsOutsideBox = convert.Convert(awayValues.statistics.First(a => a.type == "Shots outsidebox").value);
                Match.HomeTotalShots = convert.Convert(awayValues.statistics.First(a => a.type == "Total Shots").value);
                Match.HomeYellowCards = convert.Convert(awayValues.statistics.First(a => a.type == "Yellow Cards").value);
                Match.HomeTotalPasses = convert.Convert(awayValues.statistics.First(a => a.type == "Total passes").value);
                Match.HomePassesAcurate = convert.Convert(awayValues.statistics.First(a => a.type == "Passes accurate").value);
            }
        }
    }
}
