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

        public void AddMovie(Movie movie)
        {
            _appDbContext.Movies.Add(movie);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            var movies = _appDbContext.Movies;
            foreach (var movie in movies)
            {
                movie.AvailableForLending = _lendedMovieRepository.CheckavAilability(movie.MovieId, movie.MaxLendings);
                if (movie.AvailableForLending == true)
                {
                    _appDbContext.Movies.FirstOrDefault(m => m.MovieId == movie.MovieId).AvailableForLending = true;
                }
                else
                {
                    _appDbContext.Movies.FirstOrDefault(m => m.MovieId == movie.MovieId).AvailableForLending = false;
                }
            }
            _appDbContext.SaveChanges();

            return movies;
        }

        public void UpdateMaxLendings(int id, int maxLendings)
        {

            _appDbContext.Movies.FirstOrDefault(m => m.MovieId == id).MaxLendings = maxLendings;
            _appDbContext.SaveChanges();

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
