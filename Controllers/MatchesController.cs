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
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly MyAppContext _context;
        private readonly ExternalApiMatchController _apiMatch;

        public MatchesController(MyAppContext context, ExternalApiLeagueInSeazonClient externalApiLeagueInSeazonController, ExternalApiMatchController externalApiMatchController, DataToTeam dataToTeam)
        {
            _context = context;
            _apiMatch = externalApiMatchController;

        }
        

        [HttpGet]
        public IEnumerable<Match> Get()
        {
            return _context.Matches.ToList();
        }



        [HttpGet("{seazonleague}")]
        public IEnumerable<Match> Get(SeazonLeague seazonLeague)
        {
            return _context.Matches.Where(a => a.SeazonLeague == seazonLeague).ToList();
        }

        //[HttpGet("{seazon}/{league}/{match}")]
        //public Match Get(int seazon, int league, int matchId)
        //{
        //    return _context.Matches.Where(a => a.Seazon == seazon && a.League.Id == league && a.Id == matchId).FirstOrDefault();
        //}
        ////   [HttpPost("{seazon}/{league}/{match}")]
    }
}
