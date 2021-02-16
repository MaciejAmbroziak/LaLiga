//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using LaLiga.Data;
//using LaLiga.Models;
//using LaLiga.ServiceForExternalApi;

//namespace LaLiga.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class MatchesController : ControllerBase
//    {
//        private readonly MyAppContext _context;

//        public MatchesController(MyAppContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Matches
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Match>>> GetHomeMatches()
//        {
//            return await _context.HomeMatches.ToListAsync();
//        }

//        // GET: api/Matches/5
//        [HttpGet("{league}/{seazon}/{home}/{away}")]
//        public async Task<ActionResult<Match>> GetMatch(int league, int seazon, string home, string away)
//        {
//            ExternalApiLeagueInSeazonController mySeazon =  new ExternalApiLeagueInSeazonController(league, seazon);
//            DataToMatch data = new DataToMatch(mySeazon,_context);
//            await data.GenerateMatch(home, away);
//            Console.WriteLine(data.Match.RefereeId);
//            _context.Add(data.Match);
//            await _context.SaveChangesAsync();
//            int id = _context.AwayMatches.Where(a => a.HomeTeam.TeamName == home && a.AwayTeam.TeamName == away).FirstOrDefault().MatchId;
//            return await _context.HomeMatches.FindAsync(id);
//        }

//        // PUT: api/Matches/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutMatch(int id, Match match)
//        {
//            if (id != match.MatchId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(match).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!MatchExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Matches
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPost]
//        public async Task<ActionResult<Match>> PostMatch(Match match)
//        {
//            _context.HomeMatches.Add(match);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetMatch", new { id = match.MatchId }, match);
//        }
        

//        // DELETE: api/Matches/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<Match>> DeleteMatch(int id)
//        {
//            var match = await _context.HomeMatches.FindAsync(id);
//            if (match == null)
//            {
//                return NotFound();
//            }

//            _context.HomeMatches.Remove(match);
//            await _context.SaveChangesAsync();

//            return match;
//        }

//        private bool MatchExists(int id)
//        {
//            return _context.HomeMatches.Any(e => e.MatchId == id);
//        }
//    }
//}
