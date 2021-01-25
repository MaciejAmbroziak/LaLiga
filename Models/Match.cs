using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LaLiga.Models
{
    public class Match
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchId { get; set; }
        public int Seazon { get; set; }
        public string League { get; set; }
        public DateTime MatchDateTime { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public int RefereeId { get; set; }
        public int HalfTimeHomeGoals { get; set; }
        public int HalfTimeAwayGoals { get; set; }
        public int FullTimeHomeGoals { get; set; }
        public int FullTimeAwayGoals { get; set; }
        public int HomeFouls { get; set; }
        public int AwayFouls { get; set; }
        public int HomeShots { get; set; }
        public int AwayShots { get; set; }
        public int HomeShotsOnTarget { get; set; }
        public int AwayShotsOnTarget { get; set; }
        public int HomeCorners { get; set; }
        public int AwayCorners { get; set; }
        public int HomeYellowCards { get; set; }
        public int AwayYellowCards { get; set; }
        public int HomeRedCards { get; set; }
        public int AwayRedCards { get; set; }

    }
}
