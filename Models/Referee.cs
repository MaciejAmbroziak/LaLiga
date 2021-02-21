using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaLiga.Models
{
    public class Referee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NameAndCountry { get; set; }
        public SeazonLeague SeazonLeague { get; set; }
        public ICollection<Match> Matches { get; set; }
    }
}