using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaLiga.Models
{
    public class Seazon
    {
        public int Id { get; set; }
        public DateTime SezonBeginning { get; set; }
        public DateTime SeazonEnd { get; set; }
        public League League{ get; set; }
    }
}
