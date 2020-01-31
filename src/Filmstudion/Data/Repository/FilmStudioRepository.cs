using Filmstudion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Data.Repository
{
    public class FilmStudioRepository : IFilmStudioRepository
    {
        private readonly AppDbContext _appDbContext;

        public FilmStudioRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<FilmStudio[]> GetAllFilmStudios()
        {
            IQueryable<FilmStudio> query = _appDbContext.FilmStudios;

            return await query.ToArrayAsync().ConfigureAwait(false);
        }
    }
}
