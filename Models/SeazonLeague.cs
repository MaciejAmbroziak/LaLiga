using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LaLiga.Models
{
    public class SeazonLeague
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SeazonId { get; set; }
        public Seazon Seazon { get; set; }
        public int LeagueId { get; set; }
        public League League { get; set; }

        public bool Equals(SeazonLeague seazonLeague)
        {
            return Seazon.Id == seazonLeague.Id && LeagueId == seazonLeague.LeagueId;
        }

    }
}
