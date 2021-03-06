﻿using Filmstudion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Data.Repository
{
    public interface ILendedMovieRepository
    {
        public IEnumerable<LendedMovie> GetAllMoviesForLender(string filmstudioName, bool onlyActive = false);
        public MovieModel GetMovieById(int movieId);
        public bool CheckavAilability(int movieId, int maxLendings);

        public void LendMovieForStudioName(string studioName, int movieId);
        public void ReturnMovie(int lenderId, int movieId);

    }
}
