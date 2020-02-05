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

        public void AddFilmstudio(Filmstudio filmstudio)
        {
            _appDbContext.Filmstudios.Add(filmstudio);
            _appDbContext.SaveChanges();
        }

        public void DeleteFilmstudio(int filmstudioId)
        {
            var filmStudio =  _appDbContext.Filmstudios.Find(filmstudioId);
            if (filmStudio == null)
            {
                
            }
            else
            {
                _appDbContext.Filmstudios.Remove(filmStudio);
                _appDbContext.SaveChanges();
            }

        }

        public void UpdateFilmstudio(int filmstudioId, string filmstudioName, string city)
        {
            if (_appDbContext.Filmstudios.Find(filmstudioId) != null)
            {
                _appDbContext.Filmstudios.Find(filmstudioId).FilmstudioName = filmstudioName;
                _appDbContext.Filmstudios.Find(filmstudioId).City = city;
                _appDbContext.SaveChanges();
            }
        }


    }
}
