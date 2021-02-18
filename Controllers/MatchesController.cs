using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaLiga.Data;
using LaLiga.Models;
using LaLiga.ServiceForExternalApi;

namespace LaLiga.Controllers
{
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly MyAppContext _context;
        private readonly ExternalApiLeagueInSeazonController _apiLeagueInSeazon;
        private readonly ExternalApiMatchController _apiMatch;

        public MatchesController(MyAppContext context, ExternalApiLeagueInSeazonController externalApiLeagueInSeazonController, ExternalApiMatchController externalApiMatchController)
        {
            _context = context;
            _apiLeagueInSeazon = externalApiLeagueInSeazonController;
            _apiMatch = externalApiMatchController;

        }


        // GET: api/Matches/5
        [HttpGet("{seazon}/{league}/{home}/{away}")]
        public async Task<ActionResult<Match>> Get(int league, int seazon, string home, string away)
        {
            DataToMatch dataFromService = new DataToMatch(_apiLeagueInSeazon, _apiMatch, _context);
            //var match = _context.Matches.Where(a => a.HomeTeam.TeamName == home && a.AwayTeam.TeamName == away && a.Seazon == 0).FirstOrDefault();
            //if (match != null)
            //{
               var match = dataFromService.GenerateMatch(home, away, league, seazon).Result.Value;
            //}
            if (match == null)
            {
                return default(Match);
            }
            return match;
        }
    }
}
