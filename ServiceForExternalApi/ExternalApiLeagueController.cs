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
    public class ExternalApiLeagueController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public ExternalMatch ExternalMatch { get; set; }
        
        public ExternalApiLeagueController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiFootballClient");
        }
        // GET: api/<ExternalLegueController>
        [HttpGet]
        public async Task<ActionResult<ExternalLeague>> Get()
        {
            var options = new JsonSerializerOptions
            {

            };
            CancellationTokenSource cancell = new CancellationTokenSource();     
            string httpRequestString = $"https://v3.football.api-sports.io/leagues";
            cancell.CancelAfter(100000);
            var httpResponse = await _httpClient.GetAsync(new Uri(httpRequestString), cancell.Token);
            if (httpResponse.IsSuccessStatusCode)
            {

                var responseStream = await httpResponse.Content.ReadAsStreamAsync(cancell.Token);
                return await JsonSerializer.DeserializeAsync<ExternalLeague>(responseStream, options, cancell.Token);
            }
            return default(ExternalLeague);
        }
    }
}
