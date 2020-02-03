using AutoMapper;
using Filmstudion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Data
{
    public class LendedMoviesProfile : Profile
    {
        public LendedMoviesProfile()
        {
            CreateMap<LendedMovie, LendedMovieModel>();
        }
        
    }
}
