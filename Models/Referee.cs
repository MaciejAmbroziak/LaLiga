using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaLiga.Models
{
    public class Referee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RefereeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public League RefereeLeague { get; set; }
        [ForeignKey("Referees")]
        public ICollection<Match> Matches { get; set; }
    }
}