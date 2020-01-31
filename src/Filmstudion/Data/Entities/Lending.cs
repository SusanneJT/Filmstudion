using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Models
{
    public class Lending
    {
        public int LendingId { get; set; }
        public int MovieId { get; set; }
        public int FilmStudioId { get; set; }
    }
}
