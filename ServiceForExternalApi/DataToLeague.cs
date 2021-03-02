using LaLiga.Data;
using LaLiga.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaLiga.ServiceForExternalApi
{
    [ApiController]
    [Route("api")]
    public class DataToLeague: Controller
    {
        private readonly ExternalApiLeagueClient _externalApiLeague;
        private readonly MyAppContext _appContext;

        public int LeagueNumber { get; set ; }
        public List<League> myLeagues { get; set; }

        public DataToLeague(ExternalApiLeagueClient externalApiLeague, MyAppContext appContext)
        {
            _externalApiLeague = externalApiLeague;
            _appContext = appContext;
            myLeagues = new List<League>();
        }
        [HttpGet("leagues")]
        public async Task<ActionResult<IEnumerable<League>>> Get()
        {
            var leagues = await _externalApiLeague.Get();
            foreach (var league in leagues.Value.response)
            {
                League newLeague = new League();
                newLeague.Name = league.league.name;
                newLeague.Country = league.country.name;
                newLeague.ExternalApiId = league.league.id;
                myLeagues.Add(newLeague);            
            }
            await _appContext.AddRangeAsync(myLeagues);
            await _appContext.SaveChangesAsync();
            return myLeagues;
        }
    }
}
