using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaLiga.Models
{
    public class SeazonLeague
    {
        public int Id { get; set; }
        public int SeazonId { get; set; }
        public Seazon Seazon { get; set; }
        public int LeagueId { get; set; }
        public League League { get; set; }

    }
}
