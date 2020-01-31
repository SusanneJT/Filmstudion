﻿using AutoMapper;
using Filmstudion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Data
{
    public class FilmStudioProfile : Profile
    {
        public FilmStudioProfile()
        {
            CreateMap<FilmStudio, FilmStudioModel>();
        }
        
    }
}
