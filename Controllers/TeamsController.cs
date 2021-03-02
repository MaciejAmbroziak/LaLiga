using LaLiga.Data;
using LaLiga.Models;
using LaLiga.ServiceForExternalApi;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaLiga.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly MyAppContext _context;
        private readonly ExternalApiTeamClient _apiTeam;
        private DataToTeam dataToTeam { get; set; }
        public TeamsController(MyAppContext myAppContext, ExternalApiTeamClient apiTeamController)
        {
            _context = myAppContext;
            _apiTeam = apiTeamController;
            dataToTeam = new DataToTeam(myAppContext, apiTeamController);
        }



        // GET: api/<TeamsController>
        [HttpGet]
        public IEnumerable<Team> Get()
        {
             return _context.Teams.ToList();
        }
  

        [HttpGet("{leagueId}/{SeazonId}")]
        public IEnumerable<Team> Get(int seazonId,int leagueId)
        {
            var seazonLeague = _context.SeazonLeagues.Where(a => a.LeagueId == leagueId && a.SeazonId == seazonId).FirstOrDefault();
            return _context.Teams.Where(a => a.Equals(seazonLeague)).ToList();
        }


        //// GET api/<TeamsController>/5
        //[HttpGet("")]
        //public async Task<ActionResult<IEnumerable<Team>>> Get(int league, int seazon)
        //{
        //    DataToTeam datafromService = new DataToTeam(_context, _apiTeam);
        //    var teams = datafromService.Get(league, seazon).Result.Value;
        //    return teams;
        //}

        [HttpGet("{seazon}/{league}/{team}")]

        public async Task<ActionResult<Team>> Get(int league, int seazon, Team newTeam)
        {
            Team team;
            if (_context.Teams.Where(a => a.Name == newTeam.Name && a.Logo == newTeam.Logo).Any())
            {
                team = _context.Teams.Where(a => a.Name == newTeam.Name && a.Logo == newTeam.Logo).FirstOrDefault();
            }
            else
            {
                DataToTeam datafromService = new DataToTeam(_context, _apiTeam);
                team = datafromService.Get(league, seazon).Result.Value.Where(a => a.Name == newTeam.Name).FirstOrDefault();
                _context.Teams.Add(team);
                await _context.SaveChangesAsync();
            }
            return team;
        }

        // POST api/<TeamsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TeamsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TeamsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}