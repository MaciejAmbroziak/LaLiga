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
        public int Id { get; set; }
        public int Seazon { get; set; }
        public League League { get; set; }
        public DateTime MatchDateTime { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public Referee Referee { get; set; }
        public int HalfTimeHomeGoals { get; set; }
        public int HalfTimeAwayGoals { get; set; }
        public int FullTimeHomeGoals { get; set; }
        public int FullTimeAwayGoals { get; set; }
        public int HomeOffSides { get; set; }
        public int AwayOffSides { get; set; }
        public int HomeFouls { get; set; }
        public int AwayFouls { get; set; }
        public int HomeShotsInsideBox { get; set; }
        public int AwayShotsInsideBox { get; set; }
        public int HomeShotsOutsideBox { get; set; }
        public int AwayShotsOutsideBox { get; set; }
        public int HomeShotsOnTarget { get; set; }
        public int AwayShotsOnTarget { get; set; }
        public int HomeShotsOffGoal { get; set; }
        public int AwayShotsOffGoal { get; set; }
        public int HomeTotalShots { get; set; }
        public int AwayTotalShots { get; set; }
        public int HomeBlockedShots { get; set; }
        public int AwayBlockedShots { get; set; }
        public int HomeCorners { get; set; }
        public int AwayCorners { get; set; }
        public int HomeYellowCards { get; set; }
        public int AwayYellowCards { get; set; }
        public int HomeRedCards { get; set; }
        public int AwayRedCards { get; set; }
        public int HomeBallPossession { get; set; }
        public int AwayBallPossession { get; set; }
        public int HomeGoalKeeperSaves { get; set; }
        public int AwayGoalKeeperSaves { get; set; }
        public int HomeTotalPasses { get; set; }
        public int AwayTotalPasses { get; set; }
        public int HomePassesAcurate { get; set; }
        public int AwayPassesAcurate { get; set; }

        public bool Equals(Match otherMatch)
        {
            if (HomeTeam == otherMatch.HomeTeam &&
                AwayTeam == otherMatch.AwayTeam &&
                League == otherMatch.League &&
                Seazon == otherMatch.Seazon)
            {
                return true;
            }
            return false;
        }
    }


}
