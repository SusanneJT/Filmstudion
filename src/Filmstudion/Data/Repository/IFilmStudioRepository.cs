
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Data.Repository
{
    public interface IFilmstudioRepository
    {
        Task<Filmstudio[]> GetAllFilmstudios();
        Task<Filmstudio> GetFilmstudioByName(string studioName);
        Task<Filmstudio> GetFilmstudioById(int studioId);

    }
}
