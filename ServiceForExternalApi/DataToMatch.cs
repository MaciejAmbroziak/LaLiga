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
        ObjectsToNumber convert = new ObjectsToNumber();
        public Match Match { get; set; }
        DataToMatch(ExternalApiLeagueInSeazon externalApiLeagueInSeazon, ExternalApiMatch externalApiMatch, MyAppContext myAppContext)
        {
            _apiLeagueInSeazon = externalApiLeagueInSeazon;
            _apiMatch = externalApiMatch;
            _context = myAppContext;
        }

        public Match GenerateMatch(string home, string away, DateTime when)
        {
            var record = _apiLeagueInSeazon.MyObject.response.Where(p => p.teams.home.name == home && p.teams.away.name == away && p.fixture.date == when).FirstOrDefault();
            var refereeId = _context.Referees.Where(p => p.NameAndCountry == record.fixture.referee).FirstOrDefault();
            int fixtureId = record.fixture.id;
            ExternalApiMatch matchDeteiles = new ExternalApiMatch(fixtureId);
            matchDeteiles.MyObject.response[0].statistics[0].type
            if (record != null) 
            {
                Match.MatchDateTime = when;
                Match.HomeTeam.TeamName = home;
                Match.AwayTeam.TeamName = away;
                Match.RefereeId = refereeId.RefereeId;
                Match.HalfTimeHomeGoals = record.score.halftime.home;
                Match.HalfTimeAwayGoals = record.score.halftime.away;
                Match.FullTimeHomeGoals = record.score.fulltime.home;
                Match.FullTimeAwayGoals = record.score.fulltime.away;
                ResponseH2H homeValues = matchDeteiles.MyObject.response.Where(a => a.team.name == home).FirstOrDefault();
                Match.HomeCorners = convert.Convert(homeValues.statistics.First(a => a.type == "Corner kicks").value);
                Match.HomeBallPossession= convert.Convert(homeValues.statistics.First(a => a.type == "Corner kicks").value);
                Match.HomeBlockedShots;
                Match.HomeFouls;
                Match.HomeGoalKeeperSaves;
                Match.HomeOffSides;
                Match.HomeRedCards;
                Match.HomeShotsInsideBox;
                Match.HomeShotsOffGoal;
                Match.HomeShotsOnTarget;
                Match.HomeShotsOutsideBox;
                Match.HomeTotalShots;
                Match.HomeYellowCards;
            }
