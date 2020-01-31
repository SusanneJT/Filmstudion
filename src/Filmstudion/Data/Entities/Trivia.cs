using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Models
{
    public class Trivia
    {
        public int TriviaId { get; set; }
        public int MovieId { get; set; }
        public string TriviaContent { get; set; }


    }
}
