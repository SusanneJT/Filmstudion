using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Data
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string StoryLine { get; set; }
        public int MaxLendings { get; set; }

        public bool AvailableForLending { get; set; }

        //public List<Lending> ActiveLendings { get; set; }
        //public List<Rating> Ratings { get; set; }
        //public List<Trivia> Trivia { get; set; }   
    }
}
