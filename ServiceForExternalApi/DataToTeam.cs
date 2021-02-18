using LaLiga.Data;
using LaLiga.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaLiga.ServiceForExternalApi
{
    [Route("api/in/")]
    [ApiController]
    public class DataToTeam : Controller
    {
        private readonly ExternalApiTeamController _apiTeam;
        private readonly MyAppContext _context;
        public int TeamNumber { get; set; }
        public List<Team> myTeams = new List<Team>();

        public DataToTeam(ExternalApiTeamController externalApiTeamController, MyAppContext appContext)
        {
            _apiTeam = externalApiTeamController;
            _context = appContext;
        }

        public DataToTeam(MyAppContext context, ExternalApiTeamController apiTeam)
        {
            _context = context;
            _apiTeam = apiTeam;
        }
        [HttpGet("{seazon}/{leagueId}")]
        public async Task<ActionResult<IEnumerable<Team>>> Get(int leagueId, int seazon)
        {
            var recordFromTeams = _apiTeam.Get(seazon, leagueId).GetAwaiter().GetResult();
            var teamData = recordFromTeams.Value;
            int numberOfTeams = teamData.response.Count();
            foreach (var team in teamData.response)
            {
                Team nextTeam = new Team();
                nextTeam.TeamName = team.team.name;
                nextTeam.Logo = team.team.logo;
                myTeams.Add(nextTeam);
                _context.Teams.Add(nextTeam);
                await _context.SaveChangesAsync();
            }
            return myTeams;
        }
        public bool ExistsInDatabase(string teamName)
        {
            return _context.Teams.Where(a => a.TeamName== teamName).Any();
        }

        public int NumberOfTeams()
        {
            return _context.Teams.Count();
        }
        public void PrintTeams()
        {
            foreach(var team in _context.Teams)
            {
                Console.WriteLine(team.TeamName + " " + team.Logo);
            }
        }
    }
}
