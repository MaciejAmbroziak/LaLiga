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
    public class LeagueController : ControllerBase
    {

        private readonly MyAppContext _context;
        private readonly ExternalApiLeagueClient _externalLeagueController;
        private DataToLeague dataToLeague { get; set; }
        public LeagueController(MyAppContext myAppContext, ExternalApiLeagueClient leagueController)
        {
            _context = myAppContext;
            _externalLeagueController = leagueController;
            dataToLeague = new DataToLeague(leagueController, myAppContext);
        }


        // GET: api/<LeagueController>
        [HttpGet]
        public IEnumerable<League> Get()
        {
            return _context.Leagues.ToList();
        }

        // GET api/<LeagueController>/5
        [HttpGet("{id}")]
        public League Get(int id)
        {
            return _context.Leagues.Where(a => a.Id == id).FirstOrDefault();
        }

        // POST api/<LeagueController>
        [HttpPost]
        public async void Post(League league)
        {
            if(Get().ToList().Where(a => a.Id == league.Id).Any())
            {
                return;
            }
            else
            {
                if(dataToLeague.Get().Result.Value.Where(a => a.Id == league.Id && a.Name == league.Name && a.Country == league.Country).Any())
                {
                    await _context.AddAsync(league);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("There is no such league");
                }
                
            }
        }

        // PUT api/<LeagueController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LeagueController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
