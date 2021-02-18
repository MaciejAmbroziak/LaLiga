using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LaLiga.ServiceForExternalApi
{
    public class ExternalApiMatchController : Controller
    {
        IHttpClientFactory factory;
        public ExternalMatch ExternalMatch { get; set; }

        public ExternalApiMatchController(IHttpClientFactory myFactory)
        {
            factory = myFactory;
        }

        [HttpGet("{fixture}")]
        public async Task<ActionResult<ExternalMatch>> Get(int fixture)
        {
            string httpRequest = $"https://v3.football.api-sports.io/fixtures/statistics?fixture={fixture}";
            var client = factory.CreateClient("ApiFootballClient");
            var response = await client.GetAsync(httpRequest);
            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                ExternalMatch = await JsonSerializer.DeserializeAsync<ExternalMatch>(responseStream);
                return ExternalMatch;
            }
            return default(ExternalMatch);
        }
    }
}
