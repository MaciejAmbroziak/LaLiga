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
        private readonly HttpClient _httpClient;

        public ExternalApiMatchController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ActionResult<ExternalMatch>> Get(int fixture)
        {
            string httpRequest = $"https://v3.football.api-sports.io/fixtures/statistics?fixture={fixture}";
            var httpResponse = await _httpClient.GetAsync(httpRequest);
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseStream = await httpResponse.Content.ReadAsStreamAsync();
                var ExternalMatch = await JsonSerializer.DeserializeAsync<ExternalMatch>(responseStream);
                return ExternalMatch;
            }
            return default(ExternalMatch);
        }
    }
}
