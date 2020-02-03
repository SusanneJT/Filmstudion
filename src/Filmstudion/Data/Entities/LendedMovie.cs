﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Data
{
    public class LendedMovie
    {
        public int LendedMovieId { get; set; }
        public int LenderId { get; set; }
        public Filmstudio Lender { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public bool Active { get; set; }

    }
}
