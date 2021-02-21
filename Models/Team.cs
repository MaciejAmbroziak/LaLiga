using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Media;

namespace LaLiga.Models
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public ICollection<SeazonLeague> SeazonLeague { get; set; }
        public ICollection<TeamMatch> Matches { get; set; }

        public bool Equals(Team otherTeam)
        {
            if (Name == otherTeam.Name && Logo == otherTeam.Logo)
            {
                return true;
            }
            return false;
        }
    }
}