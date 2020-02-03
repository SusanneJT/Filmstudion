using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Data.Repository
{
    public interface ILendedMovieRepository
    {
        IEnumerable<LendedMovie> GetAllMoviesForLenderId(int filmstudioId, bool onlyActive = false);
        Task<LendedMovie[]> GetAllLendersForMovieId(int movieId);

    }
}
