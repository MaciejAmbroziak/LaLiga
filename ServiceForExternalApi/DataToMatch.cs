using LaLiga.Data;
using LaLiga.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//namespace LaLiga.ServiceForExternalApi
//{
//    public class DataToMatch : Controller
//    {
//        private readonly ExternalApiLeagueInSeazonController _apiLeagueInSeazon;
//        private readonly ExternalApiMatchController _apiMatch;
//        private readonly DataToTeam _apiTeam;
//        private readonly MyAppContext _context;
//        private StringToNumber convert = new StringToNumber();
//        public Match Match = new Match();
//        public Team homeTeam = new Team();
//        public Team awayTeam = new Team();
//        public League league = new League();
//        Referee referee = new Referee();
//        public DataToMatch(ExternalApiLeagueInSeazonController externalApiLeagueInSeazon,
//            ExternalApiMatchController externalApiMatchController,
//            MyAppContext myAppContext,
//            DataToTeam apiTeam)
//        {
//            _apiLeagueInSeazon = externalApiLeagueInSeazon;
//            _context = myAppContext;
//            _apiMatch = externalApiMatchController;
//            _apiTeam = apiTeam;
//        }

//        public async Task<ActionResult<Match>> GenerateMatch(string home, string away, int externalLeague, int externalSeazon)
//        {

//            //check if match exists in database
//            if (!_context.Matches.Where(a => a.HomeTeam.Team.Name == home && a.AwayTeam.Team.Name == away && a.League.Seazon == externalSeazon).Any())
//            {

//                var recordInLeague = _apiLeagueInSeazon.Get(externalLeague, externalSeazon).GetAwaiter().GetResult();
//                var leagueData = recordInLeague.Value.response.Where(p => p.teams.home.name == home && p.teams.away.name == away).FirstOrDefault();
//                Match.MatchDateTime = leagueData.fixture.date;
//                int fixtureId = leagueData.fixture.id;
//                if (leagueData != null && fixtureId != 0)
//                {

//                    //check if league exists
//                    if (!_context.Leagues.Where(a => a.Seazon == externalSeazon && a.Name == leagueData.league.name).Any())
//                    {
//                        league.Name = leagueData.league.name;
//                        league.Seazon = externalSeazon;
//                        Match.League = league;
//                    }
//                    else
//                    {
//                        Match.League = _context.Leagues.Where(a => a.Id == externalSeazon && a.Name == leagueData.league.name).FirstOrDefault();
//                    }
//                    //check if hometeam exists
//                    if (!IsThereInContext(home))
//                    {
//                        Match.HomeTeam = _apiTeam.Get(externalLeague, externalSeazon, home).GetAwaiter().GetResult().Value;
//                    }
//                    else
//                    {
//                        Match.HomeTeam = _context.Teams.Where(a => a.Name == home).FirstOrDefault();

//                    }

//                    //check if away team exists
//                    if (!IsThereInContext(away))
//                    {
//                        Match.AwayTeam = _apiTeam.Get(externalLeague, externalSeazon, away).GetAwaiter().GetResult().Value;
//                    }
//                    else
//                    {
//                        Match.AwayTeam = _context.Teams.Where(a => a.Name == away).FirstOrDefault();

//                    }
//                    //check if referee exists
//                    if (_context.Referees.Where(a => a.NameAndCountry == leagueData.fixture.referee).Any())
//                    {
//                        Match.Referee = _context.Referees.Where(a => a.NameAndCountry == leagueData.fixture.referee).FirstOrDefault();
//                    }
//                    else
//                    {
//                        referee.NameAndCountry = leagueData.fixture.referee;
//                        referee.RefereeLeague = Match.League;
//                        Match.Referee = referee;
//                        await _context.SaveChangesAsync();
//                    }
//                    Match.HalfTimeHomeGoals = leagueData.score.halftime.home ?? 0;
//                    Match.HalfTimeAwayGoals = leagueData.score.halftime.away ?? 0;
//                    Match.FullTimeHomeGoals = leagueData.score.fulltime.home ?? 0;
//                    Match.FullTimeAwayGoals = leagueData.score.fulltime.away ?? 0;


//                    var recordInFixture = _apiMatch.Get(fixtureId).GetAwaiter().GetResult();
//                    if (Match.MatchDateTime < DateTime.Now)
//                    {
//                        ResponseH2H homeValues = recordInFixture.Value.response.Where(a => a.team.name == home).FirstOrDefault();
//                        Match.HomeCorners = convert.Convert((homeValues.statistics.First(a => a.type == "Corner Kicks").value ?? "0").ToString());
//                        Match.HomeBallPossession = convert.Convert((homeValues.statistics.First(a => a.type == "Ball Possession").value ?? "0").ToString());
//                        Match.HomeBlockedShots = convert.Convert((homeValues.statistics.First(a => a.type == "Blocked Shots").value ?? "0").ToString());
//                        Match.HomeFouls = convert.Convert((homeValues.statistics.First(a => a.type == "Fouls").value ?? "0").ToString());
//                        Match.HomeGoalKeeperSaves = convert.Convert((homeValues.statistics.First(a => a.type == "Goalkeeper Saves").value ?? "0").ToString());
//                        Match.HomeOffSides = convert.Convert((homeValues.statistics.First(a => a.type == "Offsides").value ?? "0").ToString());
//                        Match.HomeRedCards = convert.Convert((homeValues.statistics.First(a => a.type == "Red Cards").value ?? "0").ToString());
//                        Match.HomeShotsInsideBox = convert.Convert((homeValues.statistics.First(a => a.type == "Shots insidebox").value ?? "0").ToString());
//                        Match.HomeShotsOffGoal = convert.Convert((homeValues.statistics.First(a => a.type == "Shots off Goal").value ?? "0").ToString());

//                        Match.HomeShotsOnTarget = convert.Convert((homeValues.statistics.First(a => a.type == "Shots on Goal").value ?? "0").ToString());
//                        Match.HomeShotsOutsideBox = convert.Convert((homeValues.statistics.First(a => a.type == "Shots outsidebox").value ?? "0").ToString());
//                        Match.HomeTotalShots = convert.Convert((homeValues.statistics.First(a => a.type == "Total Shots").value ?? "0").ToString());
//                        Match.HomeYellowCards = convert.Convert((homeValues.statistics.First(a => a.type == "Yellow Cards").value ?? "0").ToString());
//                        Match.HomeTotalPasses = convert.Convert((homeValues.statistics.First(a => a.type == "Total passes").value ?? "0").ToString());
//                        Match.HomePassesAcurate = convert.Convert((homeValues.statistics.First(a => a.type == "Passes accurate").value ?? "0").ToString());

//                        ResponseH2H awayValues = recordInFixture.Value.response.Where(a => a.team.name == away).FirstOrDefault();
//                        Match.AwayCorners = convert.Convert((awayValues.statistics.First(a => a.type == "Corner Kicks").value ?? "0").ToString());
//                        Match.AwayBallPossession = convert.Convert((awayValues.statistics.First(a => a.type == "Ball Possession").value ?? "0").ToString());
//                        Match.AwayBlockedShots = convert.Convert((awayValues.statistics.First(a => a.type == "Blocked Shots").value ?? "0").ToString());
//                        Match.AwayFouls = convert.Convert((awayValues.statistics.First(a => a.type == "Fouls").value ?? "0").ToString());
//                        Match.AwayGoalKeeperSaves = convert.Convert((awayValues.statistics.First(a => a.type == "Goalkeeper Saves").value ?? "0").ToString());
//                        Match.AwayOffSides = convert.Convert((awayValues.statistics.First(a => a.type == "Offsides").value ?? "0").ToString());
//                        Match.AwayRedCards = convert.Convert((awayValues.statistics.First(a => a.type == "Red Cards").value ?? "0").ToString());
//                        Match.AwayShotsInsideBox = convert.Convert((awayValues.statistics.First(a => a.type == "Shots insidebox").value ?? "0").ToString());
//                        Match.AwayShotsOffGoal = convert.Convert((awayValues.statistics.First(a => a.type == "Shots off Goal").value ?? "0").ToString());
//                        Match.AwayShotsOnTarget = convert.Convert((awayValues.statistics.First(a => a.type == "Shots on Goal").value ?? "0").ToString());
//                        Match.AwayShotsOutsideBox = convert.Convert((awayValues.statistics.First(a => a.type == "Shots outsidebox").value ?? "0").ToString());
//                        Match.AwayTotalShots = convert.Convert((awayValues.statistics.First(a => a.type == "Total Shots").value ?? "0").ToString());
//                        Match.AwayYellowCards = convert.Convert((awayValues.statistics.First(a => a.type == "Yellow Cards").value ?? "0").ToString());
//                        Match.AwayTotalPasses = convert.Convert((awayValues.statistics.First(a => a.type == "Total passes").value ?? "0").ToString());
//                        Match.AwayPassesAcurate = convert.Convert((awayValues.statistics.First(a => a.type == "Passes accurate").value ?? "0").ToString());
//                    }
//                }
//                _context.Add(Match);
//                await _context.SaveChangesAsync();
//            }
//            else
//            {
//                Match = _context.Matches.Where(a => a.HomeTeam.Name == home && a.AwayTeam.Name == away && a.League.Seazon == externalSeazon).FirstOrDefault();
//            }
//            return Match;
//        }
//        private bool IsThereInContext(string name)
//        {
//            return _context.Teams.Where(a => a.Name == name).Any();
//        }
//    }
//}
