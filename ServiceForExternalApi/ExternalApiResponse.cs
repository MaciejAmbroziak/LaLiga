using LaLiga.Data;
using LaLiga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LaLiga.ServiceForExternalApi
{
    public class ExternalApiResponse<ExternalApiObject>
    {
        private readonly IHttpClientFactory _clientFactory;

        private ExternalApiObject _object;
        public virtual ExternalApiObject MyObject { get => _object; set => _object = value; }

        public ExternalApiResponse()
        {

        }
        public ExternalApiResponse(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
        }
        protected async Task GetObject(string httpRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, httpRequest);
            var client = _clientFactory.CreateClient("Data");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                MyObject = (ExternalApiObject) await JsonSerializer.DeserializeAsync<IEnumerable<ExternalApiObject>>(responseStream);
            }
            else
            {
                MyObject = default(ExternalApiObject);
            }
        }
    }
}
