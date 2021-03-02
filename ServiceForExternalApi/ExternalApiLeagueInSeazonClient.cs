using LaLiga.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LaLiga.ServiceForExternalApi
{
    public class ExternalApiLeagueInSeazonClient : Controller
    {
        HttpClient _httpClient;
        public ExternalLeagueInSeazon ExternalLeagueInSeazon { get; set; }

        public ExternalApiLeagueInSeazonClient(IHttpClientFactory myFactory)
        {
            _httpClient = myFactory.CreateClient("ApiFootballClient");
        }

       // public async Task<ActionResult<>>
        public async Task<ActionResult<ExternalLeagueInSeazon>> Get(int league, int seazon)
        {
            string httpRequest = $"https://v3.football.api-sports.io/fixtures?league={league}&season={seazon}";
            var response = await _httpClient.GetAsync(httpRequest);
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
