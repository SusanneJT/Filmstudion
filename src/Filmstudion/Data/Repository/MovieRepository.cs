using Filmstudion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Data.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILendedMovieRepository _lendedMovieRepository;

        public MovieRepository(AppDbContext appDbContext, ILendedMovieRepository lendedMovieRepository)
        {
            _appDbContext = appDbContext;
            _lendedMovieRepository = lendedMovieRepository;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            var movies = _appDbContext.Movies;
            foreach (var movie in movies)
            {
                movie.AvailableForLending = _lendedMovieRepository.CheckavAilability(movie.MovieId, movie.MaxLendings);
            }

            return movies;
        }

        //reserv
        /*
        public async Task<Movie[]> GetAllMovies()
        {
            IQueryable<Movie> query = _appDbContext.Movies;

            return await query.ToArrayAsync().ConfigureAwait(false);
        }
        */
        
       /* public async Task<Movie> GetMovieById(int movieId)
        {
            var query = _appDbContext.Movies
                .Where(m => m.MovieId == movieId);


            return await query.FirstOrDefaultAsync();
        }*/
    }
}
