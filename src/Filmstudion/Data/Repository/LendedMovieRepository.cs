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
                new LendedMovie {LendedMovieId = 3, LenderId = 1, MovieId = 1, Active = false}
            };
        }

        public Task<LendedMovie[]> GetAllLendersForMovieId(int movieId)
        {

            throw new NotImplementedException();
        }

        public IEnumerable<LendedMovie> GetAllMoviesForLenderId(int filmstudioId,bool onlyActive = false)
        {
            if (onlyActive)
            {
                IEnumerable<LendedMovie> lendedMovies = _lendedMovies
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
                IEnumerable<LendedMovie> lendedMovies = _lendedMovies.Where(f => f.LenderId == filmstudioId);
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
    }
}
