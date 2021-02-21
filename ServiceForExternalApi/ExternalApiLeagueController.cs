using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaLiga.ServiceForExternalApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalApiLeagueController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public ExternalMatch ExternalMatch { get; set; }

        public ExternalApiLeagueController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        // GET: api/<ExternalLegueController>
        [HttpGet]
        public async Task<ActionResult<ExternalLeague>> Get()
        {
            string httpRequest = $"https://v3.football.api-sports.io/leagues";
            var response = await _httpClient.GetAsync(httpRequest);
            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var externalLeague = await JsonSerializer.DeserializeAsync<ExternalLeague>(responseStream);
                return externalLeague;
            }
            return default(ExternalLeague);
        }
    }
}
