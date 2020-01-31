using Filmstudion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filmstudion.Data.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<FilmStudio> FilmStudios { get; set; }
        public DbSet<Movie> Movies { get; set; }
        //public DbSet<Lending> Lendings { get; set; }
        //public DbSet<Rating> Ratings { get; set; }
        //public DbSet<Trivia> Trivia { get; set; }
    }
}
