using AutoMapper;
using Filmstudion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Data
{
    public class ListMoviesProfile : Profile
    {
        public ListMoviesProfile()
        {
            CreateMap<Movie, ListMoviesModel>();

        }
        
    }
}
