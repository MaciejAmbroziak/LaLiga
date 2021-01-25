﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Media;

namespace LaLiga.Models
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string Logo { get; set; }
        [InverseProperty("HomeTeam")]
        public ICollection<Match> HomeMatches { get; set; }
        [InverseProperty("AwayTeam")]
        public ICollection<Match> AwayMatches { get; set; }
    }
}