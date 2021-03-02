using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaLiga.Models
{
    public class Seazon
    {
        public int Id { get; set; }
        public int SeazonYear { get; set; }
        public DateTime SezonBeginning { get; set; }
        public DateTime SeazonEnd { get; set; }
        public ICollection<League> League{ get; set; }

        public Seazon()
        {
            League = new List<League>();
        }

        public bool Equals(Seazon seazon)
        {
            return seazon.Id == Id && seazon.SeazonYear == SeazonYear;
        }
    }
}
