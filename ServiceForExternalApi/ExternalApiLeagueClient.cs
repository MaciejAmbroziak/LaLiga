using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaLiga.ServiceForExternalApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalApiLeagueClient : ControllerBase
    {
        private readonly HttpClient _httpClient;       
        public ExternalApiLeagueClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiFootballClient");
        }
        // GET: api/<ExternalLegueController>
        [HttpGet]
        public async Task<ActionResult<ExternalLeague>> Get()
        {
            string httpRequestString = $"https://v3.football.api-sports.io/leagues";
            var httpResponse = await _httpClient.GetAsync(new Uri(httpRequestString));
            if (httpResponse.IsSuccessStatusCode)
            {

                var responseStream = await httpResponse.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<ExternalLeague>(responseStream);
            }
            return default(ExternalLeague);
        }
    }
}
