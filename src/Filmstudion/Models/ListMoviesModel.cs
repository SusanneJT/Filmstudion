using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Models
{
    public class ListMoviesModel
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public bool AvailableForLending { get; set; }
    }
}
