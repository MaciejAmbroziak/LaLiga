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
        public League()
        {
            Teams = new List<Team>();
            Referees = new List<Referee>();
            Seazons = new List<Seazon>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExternalApiId { get; set; }
        public ICollection<Seazon> Seazons { get; set; }
        public ICollection<Team> Teams { get; set; }
        public ICollection<Referee> Referees { get; set; }
    }
}
