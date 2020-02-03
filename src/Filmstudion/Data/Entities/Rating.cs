using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int MovieId { get; set; }
        public int FilmstudioId { get; set; }
       
    }
}
