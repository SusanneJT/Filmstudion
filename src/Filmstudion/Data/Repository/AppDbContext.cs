﻿using Filmstudion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filmstudion.Data;

namespace Filmstudion.Data.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Filmstudio> Filmstudios { get; set; }
        public DbSet<Movie> Movies { get; set; }
        //public DbSet<LendedMovie> LendedMovies { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Trivia> Trivia { get; set; }

    }
}
