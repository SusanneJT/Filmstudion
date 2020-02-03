using Filmstudion.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Models
{
    public class MovieModel
    {
        /*public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string StoryLine { get; set; }
        public int MaxLendings { get; set; }*/
        public Movie Movie { get; set; } 
        public IEnumerable<LendedMovie> Lendings { get; set; }
        public bool AvailableForLending { get; set; }
        public int CurrentLendings { get; set; }
 
    }
}
