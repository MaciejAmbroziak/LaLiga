using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LaLiga.ServiceForExternalApi
{
    public class ExternalApiLeagueInSeazonController : Controller
    {
        private readonly ApiFootballClient _apiFootballClient;
        public ExternalLeagueInSeazon ExternalLeagueInSeazon { get; set; }
        public ExternalApiLeagueInSeazonController(ApiFootballClient apiFootballClient)
        {
            _apiFootballClient = apiFootballClient;
        }
        [HttpGet("{seazon}/{league}")]
        public async Task<ActionResult<ExternalLeagueInSeazon>> Get(int league, int seazon)
        {
            string httpRequest = $"https://v3.football.api-sports.io/fixtures?league={league}&season={seazon}";
            var response = await _apiFootballClient.Client.GetAsync(httpRequest);
            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                ExternalLeagueInSeazon = await JsonSerializer.DeserializeAsync<ExternalLeagueInSeazon>(responseStream);
                return ExternalLeagueInSeazon;
            }
            return default(ExternalLeagueInSeazon);
        }

    }
}
