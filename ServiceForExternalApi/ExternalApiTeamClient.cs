using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LaLiga.ServiceForExternalApi
{
    [Route("team")]
    [ApiController]
    public class ExternalApiTeamClient : ControllerBase
    {
        private readonly HttpClient _client;
        public ExternalTeam ExternalTeam { get; set; }

        public ExternalApiTeamClient(IHttpClientFactory myFactory)
        {
            _client = myFactory.CreateClient("ApiFootballClient");
        }
        public async Task<ActionResult<ExternalTeam>> Get(int seazon, int league)
        {
            string httpRequest = $"https://v3.football.api-sports.io/teams?league={league}&season={seazon}";
            var response = await _client.GetAsync(httpRequest);
            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                ExternalTeam = await JsonSerializer.DeserializeAsync<ExternalTeam>(responseStream);
                return ExternalTeam;
            }
            return default(ExternalTeam);

        }

    }
}
