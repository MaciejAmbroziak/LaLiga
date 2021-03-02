using LaLiga.Data;
using LaLiga.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaLiga.ServiceForExternalApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataToLeagueSeazon : ControllerBase
    {
        private readonly ExternalApiLeagueClient _externalApiLeagueClient;
        
        private readonly MyAppContext _appContext;

        private DataToLeague _dataToLeague { get; set; }
        // GET: api/<DataToLeagueSeazon>
        [HttpGet]
        //public async Task<IEnumerable<SeazonLeague>> Get(int seazon, int leagueId)
        //{
        //    SeazonLeague seazonLeague = new SeazonLeague();
        //    var leagueData = await _dataToLeague.Get();
        //    var seazonsRecord = await _externalApiSeazons.Get();
        //    var seazons = seazonsRecord.Value;
        //    if (seazons.response.Where(a => a == seazon).Any())
        //    {
        //        seazonLeague.SeazonId = seazon;
        //    }            
        //    seazonLeague.League = leagueData.Value.Where(a => a.ExternalApiId == leagueId).FirstOrDefault();
        //    return default(SeazonLeague);
        //}

        // GET api/<DataToLeagueSeazon>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DataToLeagueSeazon>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DataToLeagueSeazon>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DataToLeagueSeazon>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
