using Filmstudion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Data.Repository
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();
        //Task<Movie[]> GetAllMovies();
        //Task<Movie> GetMovieById(int id);
    }
}
