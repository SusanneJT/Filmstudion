using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Models
{
    public class Lending
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int FilmstudioId { get; set; }
        public Filmstudio Filmstudio { get; set; }
    }
}
