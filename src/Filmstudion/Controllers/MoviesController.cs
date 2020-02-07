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
        private readonly ILendedMovieRepository _lendedMovieRepository;

        public MoviesController(IMovieRepository movieRepository, ILendedMovieRepository lendedMovieRepository)
        {
            _movieRepository = movieRepository;
            _lendedMovieRepository = lendedMovieRepository;
        }

        // GET: api/Movies
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
            var results =  _movieRepository.GetAllMovies();
            return Ok(results);
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
        public IActionResult PatchUpdateMaxLendings(int id, int maxLendings)
        {
            _movieRepository.UpdateMaxLendings(id, maxLendings);
            return NoContent();
        }

        [HttpPost("{movieId:int}/Rating")]
        public ActionResult AddRating(Rating rating)
        {
            _movieRepository.AddRating(rating);
            return NoContent();
        }

        [HttpPost("{movieId:int}/Trivia")]
        public ActionResult AddTrivia(Trivia trivia)
        {
            _movieRepository.AddTrivia(trivia);
            return NoContent();
        }

        [HttpDelete("{movieId:int}/{triviaId:int}")]
        public ActionResult DeleteTrivia(int triviaId)
        {
            _movieRepository.DeleteTrivia(triviaId);
            return NoContent();
        }


    }
}
