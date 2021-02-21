//using LaLiga.Data;
//using LaLiga.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace LaLiga.ServiceForExternalApi
//{
//    public class DataToTeam : Controller
//    {
//        private readonly ExternalApiTeamController _apiTeam;
//        private readonly MyAppContext _context;
//        public int TeamNumber { get; set; }
//        public List<Team> myTeams = new List<Team>();

//        public DataToTeam(ExternalApiTeamController externalApiTeamController, MyAppContext appContext)
//        {
//            _apiTeam = externalApiTeamController;
//            _context = appContext;
//        }

//        public DataToTeam(MyAppContext context, ExternalApiTeamController apiTeam)
//        {
//            _context = context;
//            _apiTeam = apiTeam;
//        }
//        public async Task<ActionResult<IEnumerable<Team>>> Get(int leagueId, int seazon)
//        {
//            var recordFromTeams = _apiTeam.Get(seazon, leagueId).GetAwaiter().GetResult();
//            var teamsData = recordFromTeams.Value;
//            foreach (var team in teamsData.response)
//            {
//                Team nextTeam = new Team();
//                nextTeam.Name = team.team.name;
//                nextTeam.Logo = team.team.logo;
//                myTeams.Add(nextTeam);
//                _context.Teams.Add(nextTeam);
//                await _context.SaveChangesAsync();
//            }
//            return myTeams;
//        }

//        public async Task<ActionResult<Team>> Get(int leagueId, int seazon, string name)
//        {
//            var recordFromTeams = _apiTeam.Get(seazon, leagueId).GetAwaiter().GetResult();
//            var teamData = recordFromTeams.Value.response.Where(a => a.team.name == name).FirstOrDefault();
//            Team team = new Team();
//            team.Name = teamData.team.name;
//            team.Logo = teamData.team.logo;
//            if (!_context.Teams.Where(a=>a.Name == name && team.Logo == teamData.team.logo).Any())
//            {
//                _context.Add(team);
//                await _context.SaveChangesAsync();
//            }
//            return team;
//        }
        
//    }
//}
