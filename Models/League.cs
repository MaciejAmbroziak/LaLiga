using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LaLiga.Models
{
    public class League
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeagueId { get; set; }
        public int LeagueName { get; set; }
        public DateTime LeagueSeazon { get; set; }

        [ForeignKey("Team")]        
        public ICollection<Team> Teams { get; set; }
        [ForeignKey("Referee")]
        public ICollection<Referee> Referees { get; set; }
    }
}
