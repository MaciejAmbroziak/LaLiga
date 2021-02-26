//using LaLiga.Data;
//using LaLiga.Models;
//using LaLiga.ServiceForExternalApi;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace LaLiga.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LeagueController : ControllerBase
//    {

//        private readonly MyAppContext _context;
//        private readonly ExternalApiLeagueController _externalLeagueController;

//        public LeagueController(MyAppContext myAppContext, ExternalApiLeagueController leagueController)
//        {
//            _context = myAppContext;
//            _externalLeagueController = leagueController;
//        }


//        // GET: api/<LeagueController>
//        [HttpGet]
//        public IEnumerable<League> Get()
//        {
//            return _context.Leagues.ToList();
//        }

//        // GET api/<LeagueController>/5
//        [HttpGet("{id}")]
//        public League Get(int id)
//        {
//            return _context.Leagues.Where(a => a.Id == id).FirstOrDefault();
//        }

//        // POST api/<LeagueController>
//        [HttpPost]
//        //public async void Post()
//        //{
//        //    var leagueData = _externalLeagueController.Get();
//        //    //leagueData.GetAwaiter().GetResult().Value;
//            //foreach (var position in leagueList)
//            //{
//            //    League league = new League();
//            //    {
//            //        league.Name = position.league.name;
//            //        league.ExternalApiId = position.league.id;
//            //        _context.Add(league);
//            //        await _context.SaveChangesAsync();
//            //    }
//            //}
//        //}

//        //// PUT api/<LeagueController>/5
//        //[HttpPut("{id}")]
//        //public void Put(int id, [FromBody] string value)
//        //{ 
//        //}

//        //// DELETE api/<LeagueController>/5
//        //[HttpDelete("{id}")]
//        //public void Delete(int id)
//        //{
//        //}
//    //}
//}
