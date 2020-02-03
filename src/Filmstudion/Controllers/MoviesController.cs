using System;
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
        public async Task<ActionResult<ListMoviesModel[]>> GetMovies()
        {
            try
            {
                var results = await _movieRepository.GetAllMovies();
                return _mapper.Map<ListMoviesModel[]>(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
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



             /*   // PUT: api/Movies/5
                // To protect from overposting attacks, please enable the specific properties you want to bind to, for
                // more details see https://aka.ms/RazorPagesCRUD.
                [HttpPut("{id}")]
                public async Task<IActionResult> PutMovie(int id, Movie movie)
                {
                    if (id != movie.MovieId)
                    {
                        return BadRequest();
                    }

                    _context.Entry(movie).State = EntityState.Modified;

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MovieExists(id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }

                    return NoContent();
                }

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
