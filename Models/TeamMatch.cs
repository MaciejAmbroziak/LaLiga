﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaLiga.Models
{
    public class TeamMatch
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int MatchId { get; set; }
        public Match Match { get; set; }
        public bool Home { get; set; }
    }
}
