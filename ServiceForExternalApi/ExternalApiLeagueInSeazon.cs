using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaLiga.ServiceForExternalApi
{
    public class ExternalApiLeagueInSeazon : ExternalApiResponse<ExternalLeagueInSeazon>
    {
        private readonly int _league;
        public int League { get => _league; }
        private readonly int _seazon;
        public int Seazon { get => _seazon; }
        public override ExternalLeagueInSeazon MyObject { get => base.MyObject; set { base.MyObject = value; GetMatches(); } }
        public ExternalApiLeagueInSeazon(int league, int seazon) : base()
        {
            _league = league;
            _seazon = seazon;
        }
        public async void GetMatches()
        {
            string request = $"https://v3.football.api-sports.io/fixtures?league={_league}&season={_seazon}";
            await GetObject(request);
        }
    }
}
