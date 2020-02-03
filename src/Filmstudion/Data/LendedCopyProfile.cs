using AutoMapper;
using Filmstudion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Data
{
    public class LendedCopyProfile : Profile
    {
        public LendedCopyProfile()
        {
            CreateMap<LendedMovie, LendedCopy>();

            /*CreateMap<LendedMovie, LendedMovieModel>()
             .ForMember(l => l.LendedMovieId, o => o.MapFrom(m => m.LendedMovieId))
             .ReverseMap();*/
        }
        
    }
}
