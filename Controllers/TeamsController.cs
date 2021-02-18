using LaLiga.Data;
using LaLiga.Models;
using LaLiga.ServiceForExternalApi;
using Microsoft.AspNetCore.Mvc;
using System;
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
        private readonly ExternalApiTeamController _apiTeam;

        public TeamsController(MyAppContext myAppContext, ExternalApiTeamController apiTeamController)
        {
            _context = myAppContext;
            _apiTeam = apiTeamController;
        }
        // GET: api/<TeamsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //// GET api/<TeamsController>/5
        //[HttpGet("{league}/{Seazon}")]
        //public Task<ActionResult<IEnumerable<Team>>> Get(int league, int seazon)
        //{
        //    DataToTeam datafromService = new DataToTeam(_context, _apiTeam);
        //    datafromService.PrintTeams();
        //    var teams = datafromService.Get(league, seazon).Result.Value;
        //    return (Task<ActionResult<IEnumerable<Team>>>)teams;
        //}

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
