﻿using LaLiga.Data;
using LaLiga.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LaLiga.ServiceForExternalApi
{
    public class ExternalApiResponseController<ExternalApiObject> : Controller
    {
        public ApiFootballClient _client;

        private ExternalApiObject _object;
        public virtual ExternalApiObject MyObject { get => _object; set => _object = value; }

        public ExternalApiResponseController(ApiFootballClient apiFootballClient)
        {
            _client = apiFootballClient;
        }

        public ExternalApiResponseController()
        {
        }

        protected async Task<ExternalApiObject> GetObject(string httpRequest)
        {
            var response = await _client.Client.GetAsync(httpRequest);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                MyObject = (ExternalApiObject)await JsonSerializer.DeserializeAsync<IEnumerable<ExternalApiObject>>(responseStream);
            }
            else
            {
                MyObject = default(ExternalApiObject);
            }
            return MyObject;
        }
    }
}