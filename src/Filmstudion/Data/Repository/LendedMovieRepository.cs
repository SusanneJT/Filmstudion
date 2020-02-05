using AutoMapper;
using Filmstudion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Data.Repository
{
    public class LendedMovieRepository : ILendedMovieRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly List<LendedMovie> _lendedMovies;

        public LendedMovieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

            _lendedMovies = new List<LendedMovie>
            {
                new LendedMovie {LendedMovieId = 1, LenderId = 1, MovieId = 4, Active = true},
                new LendedMovie {LendedMovieId = 2, LenderId = 1, MovieId = 6, Active = true},
                new LendedMovie {LendedMovieId = 3, LenderId = 1, MovieId = 1, Active = false},
                new LendedMovie {LendedMovieId = 4, LenderId = 3, MovieId = 6, Active = true},
                new LendedMovie {LendedMovieId = 5, LenderId = 2, MovieId = 6, Active = true}
            };

            foreach (var lending in _lendedMovies)
            {
                lending.Lender = _appDbContext.Filmstudios.FirstOrDefault(f => f.FilmstudioId == lending.LenderId);
            }
        }


        public IEnumerable<LendedMovie> GetAllMoviesForLenderId(int filmstudioId,bool onlyActive = false)
        {
            if (onlyActive)
            {
                var lendedMovies = _lendedMovies
                    .Where(f => f.LenderId == filmstudioId && f.Active == true);

                foreach (var film in lendedMovies)
                {
                    film.Movie = _appDbContext.Movies.FirstOrDefault(m => m.MovieId == film.MovieId);
                    film.Lender = _appDbContext.Filmstudios.FirstOrDefault(f => f.FilmstudioId == filmstudioId);
                }
                return lendedMovies; 
            }
            else
            {
                var lendedMovies = _lendedMovies.Where(f => f.LenderId == filmstudioId);
                foreach (var film in lendedMovies)
                {
                    film.Movie = _appDbContext.Movies.FirstOrDefault(m => m.MovieId == film.MovieId);
                    film.Lender = _appDbContext.Filmstudios.FirstOrDefault(f => f.FilmstudioId == filmstudioId);
                }
                return lendedMovies;
            }   
        }

        public async Task<Movie[]> GetAllMovies()
        {
            IQueryable<Movie> query = _appDbContext.Movies;

            return await query.ToArrayAsync().ConfigureAwait(false);
        }

        public MovieModel GetMovieById(int movieId)
        {
            var movie = _appDbContext.Movies
                .FirstOrDefault(m => m.MovieId == movieId);

            MovieModel movieModel = new MovieModel
            {
                Movie = movie,
                Lendings = _lendedMovies.Where(l => l.MovieId == movieId && l.Active == true)
                
            };

            if (movie.MaxLendings <= movieModel.Lendings.Count())
                movieModel.AvailableForLending = false;
            else
                movieModel.AvailableForLending = true;

            movieModel.CurrentLendings = movieModel.Lendings.Count();

            foreach (var lending in movieModel.Lendings)
            {
                lending.Lender = _appDbContext.Filmstudios.FirstOrDefault(f => f.FilmstudioId == lending.LenderId);
            }
            
            return movieModel;
        }

        public bool CheckavAilability(int movieId, int maxLendings)
        {
            int activeLendings = _lendedMovies.Where(l => l.MovieId == movieId && l.Active == true).Count();
            
            if (activeLendings < maxLendings)
                return true;   
            else
                return false;       
        }

        public void LendMovieForLenderId(int lenderId, int movieId)
        {
            int maxLending = _appDbContext.Movies.FirstOrDefault(m => m.MovieId == movieId).MaxLendings;
            bool available = CheckavAilability(movieId, maxLending);

            if (available)
            {
                LendedMovie lendedMovie = new LendedMovie()
                {
                    LendedMovieId = _lendedMovies.Count(),
                    LenderId = lenderId,
                    MovieId = movieId
                };

                _lendedMovies.Add(lendedMovie);
            }
        }

        public void ReturnMovie(int lenderId, int movieId)
        {
            bool checkIfExists;

            if (_lendedMovies.FirstOrDefault(l => l.LenderId == lenderId && l.MovieId == movieId) != null)
                checkIfExists = true;
            else
                checkIfExists = false;


            if (checkIfExists)
                _lendedMovies.FirstOrDefault(l => l.LenderId == lenderId && l.MovieId == movieId).Active = false;

        }
    }
}
