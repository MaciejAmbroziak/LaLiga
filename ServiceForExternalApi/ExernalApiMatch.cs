using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LaLiga.ServiceForExternalApi
{ 
    public class ExternalApiMatch : ExternalApiResponse<ExternalMatch>
    {
        private readonly int _fixture;
        public int Fixture { get => _fixture; }
        public override ExternalMatch MyObject { get => base.MyObject; set { base.MyObject = value; GetMatch(); } }
        public ExternalApiMatch(int fixture) :base()
        {
            _fixture = fixture;
        }
        public async void GetMatch()
        {
            string request = $"https://v3.football.api-sports.io/fixtures/statistics?fixture={_fixture}";
            await GetObject(request);
        }
    }
}
