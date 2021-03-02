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
    [Route("api/[controller]")]
    [ApiController]
    public class SeazonLeagueController : ControllerBase
    {
        private readonly MyAppContext _context;
        private readonly DataToLeagueSeazon _dataToLeagueSeazon;

        public SeazonLeagueController(MyAppContext context, DataToLeagueSeazon dataToLeagueSeazon)
        {
            _context = context;
            _dataToLeagueSeazon = dataToLeagueSeazon;
        }



        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<SeazonLeague> Get()
        {
            return _context.SeazonLeagues.ToList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{seazonLeagueId}")]
        public IEnumerable<SeazonLeague> Get(int id)
        {
            return _context.SeazonLeagues.Where(a => a.Id == id).ToList();
        }

 //       [HttpGet("oneSeazonLeague/{seazonId/leagueId}")]
        public SeazonLeague Get(int seazonId, int leagueId)
        {
            return _context.SeazonLeagues.Where(a => a.LeagueId == leagueId && a.SeazonId == seazonId).FirstOrDefault();
        }




        // POST api/<ValuesController>
        [HttpPost]
        public void Post(SeazonLeague seazonLeague)
        {
            if (_context.Leagues.Where(a => a.Equals(seazonLeague)).Any())
            {
                return;
            }
            else
            {
               // if(_dataToLeagueSeazon.Get()))
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
