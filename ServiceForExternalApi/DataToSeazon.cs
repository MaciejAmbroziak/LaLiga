using LaLiga.Data;
using LaLiga.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaLiga.ServiceForExternalApi
{
    [Route("api")]
    public class DataToSeazon :Controller
    {
        private readonly MyAppContext _appContext;
        private readonly ExternalApiLeagueClient _externalApiLeagueClient;

        public DataToSeazon(MyAppContext appContext, ExternalApiLeagueClient externalApiLeagueClient)
        {
            _appContext = appContext;
            _externalApiLeagueClient = externalApiLeagueClient;
            Seazons = new List<Seazon>();
            SeazonLeagues = new List<SeazonLeague>();
        }
        public List<SeazonLeague> SeazonLeagues { get; set; }
        public List<Seazon> Seazons { get; set; }
        [HttpGet("seazons")]
        public async Task<ActionResult<IEnumerable<Seazon>>> Get()
        {
            if (_appContext.Seazons.Any())
            {
                return _appContext.Seazons.ToList();
            }
            else
            {
                DataToLeague dataToLeague = new DataToLeague(_externalApiLeagueClient, _appContext);
                var leaguesResponse = await dataToLeague.Get();
                var leagues = leaguesResponse.Value;
                var responseLeague = await _externalApiLeagueClient.Get();
                var cus = responseLeague.Value;
                foreach(var response in cus.response)
                {

                    var league = leagues.Where(a => a.ExternalApiId == response.league.id).FirstOrDefault();
                    foreach (var seazon in response.seasons)
                    {
                        SeazonLeague newSeazonLegue = new SeazonLeague();
                        League tempLeague = new League();
                        tempLeague = league;
                        Seazon newSeazon = new Seazon();
                        newSeazon.SeazonYear = seazon.year;
                        DateTime temp1 = DateTime.MinValue;
                        DateTime.TryParse(seazon.start, out temp1);
                        newSeazon.SezonBeginning = temp1;
                        DateTime temp2 = DateTime.MinValue;
                        DateTime.TryParse(seazon.end, out temp2);
                        newSeazon.SeazonEnd = temp2;
                        newSeazon.League.Add(tempLeague);
                        Seazons.Add(newSeazon);
                        newSeazonLegue.LeagueId = tempLeague.Id;
                        newSeazonLegue.League = tempLeague;
                        newSeazonLegue.SeazonId = newSeazon.Id;
                        newSeazonLegue.Seazon = newSeazon;
                        SeazonLeagues.Add(newSeazonLegue);
                    }
                    await _appContext.AddRangeAsync(SeazonLeagues);
                    await _appContext.SaveChangesAsync();
                    
                }
                await _appContext.AddRangeAsync(Seazons);
                await _appContext.SaveChangesAsync();
                return Seazons;
            }

        }
    }
}
