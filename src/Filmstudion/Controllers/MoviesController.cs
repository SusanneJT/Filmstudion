﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Filmstudion.Data.Repository;
using Filmstudion.Models;
using AutoMapper;
using Filmstudion.Data;

namespace Filmstudion.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        private readonly ILendedMovieRepository _lendedMovieRepository;

        public MoviesController(IMovieRepository movieRepository, 
            IMapper mapper, ILendedMovieRepository lendedMovieRepository)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _lendedMovieRepository = lendedMovieRepository;
        }

        // GET: api/Movies
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
            //try
            //{
                var results =  _movieRepository.GetAllMovies();
                return Ok(results);
            //}
            //catch (Exception)
            //{
              //  return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            //}
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<MovieModel>> GetMovie(int id)
        {
            try
            {
                var movie =  _lendedMovieRepository.GetMovieById(id);

                if (movie == null)
                {
                    return NotFound();
                }

                return Ok(movie);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        // POST: api/Movies
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Movie> PostMovie(Movie movie)
        {
            _movieRepository.AddMovie(movie);

            return CreatedAtAction("GetMovie", new { id = movie.MovieId }, movie);
        }



           // PUT: api/Movies/5
           // To protect from overposting attacks, please enable the specific properties you want to bind to, for
           // more details see https://aka.ms/RazorPagesCRUD.
           [HttpPatch("{id}")]
           public async Task<IActionResult> PatchUpdateMaxLendings(int id, int maxLendings)
           {
               _movieRepository.UpdateMaxLendings(id, maxLendings);
               return NoContent();
           }

            /*
           // POST: api/Movies
           // To protect from overposting attacks, please enable the specific properties you want to bind to, for
           // more details see https://aka.ms/RazorPagesCRUD.
           [HttpPost]
           public async Task<ActionResult<Movie>> PostMovie(Movie movie)
           {
               _context.Movies.Add(movie);
               await _context.SaveChangesAsync();

               return CreatedAtAction("GetMovie", new { id = movie.MovieId }, movie);
           }

           // DELETE: api/Movies/5
           [HttpDelete("{id}")]
           public async Task<ActionResult<Movie>> DeleteMovie(int id)
           {
               var movie = await _context.Movies.FindAsync(id);
               if (movie == null)
               {
                   return NotFound();
               }

               _context.Movies.Remove(movie);
               await _context.SaveChangesAsync();

               return movie;
           }

           private bool MovieExists(int id)
           {
               return _context.Movies.Any(e => e.MovieId == id);
           }*/
    }
}
