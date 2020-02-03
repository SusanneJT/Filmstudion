using Filmstudion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Data.Repository
{
    public class FilmstudioRepository : IFilmstudioRepository
    {
        private readonly AppDbContext _appDbContext;

        public FilmstudioRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<Filmstudio[]> GetAllFilmstudios()
        {
            IQueryable<Filmstudio> query = _appDbContext.Filmstudios;

            return await query.ToArrayAsync().ConfigureAwait(false);
        }

        public async Task<Filmstudio> GetFilmstudioByName(string studioName)
        {
            var query = _appDbContext.Filmstudios
                .Where(f => f.FilmstudioName == studioName);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Filmstudio> GetFilmstudioById(int studioId)
        {
            var query = _appDbContext.Filmstudios
                .Where(f => f.FilmstudioId == studioId);

            return await query.FirstOrDefaultAsync();
        }

    }
}
