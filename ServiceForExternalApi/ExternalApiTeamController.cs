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
    public class ExternalApiTeamController : ControllerBase
    {
        IHttpClientFactory factory;
        public ExternalTeam ExternalTeam { get; set; }

        public ExternalApiTeamController(IHttpClientFactory myFactory)
        {
            factory = myFactory;
        }

        [HttpGet("{seazon}/{league}")]
        public async Task<ActionResult<ExternalTeam>> Get(int seazon, int league)
        {
            string httpRequest = $"https://v3.football.api-sports.io/teams?league={league}&season={seazon}";
            var client = factory.CreateClient("ApiFootballClient");
            var response = await client.GetAsync(httpRequest);
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
