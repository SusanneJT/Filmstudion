using Filmstudion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Data.Repository
{
    public interface IMovieRepository
    {
        public IEnumerable<Movie> GetAllMovies();
        public void AddMovie(Movie movie);
        public void UpdateMaxLendings(int id, int maxLendings);
        //Task<Movie[]> GetAllMovies();
        //Task<Movie> GetMovieById(int id);
    }
}
