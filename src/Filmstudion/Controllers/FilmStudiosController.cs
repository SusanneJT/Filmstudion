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
    [Route("api/[controller]")]
    [ApiController]
    public class FilmstudiosController : ControllerBase
    {
        private readonly IFilmstudioRepository _filmstudioRepository;
        private readonly IMapper _mapper;
        private readonly ILendedMovieRepository _lendedMovieRepository;

        public FilmstudiosController(IFilmstudioRepository filmstudioRepository, 
            IMapper mapper, ILendedMovieRepository lendedMovieRepository)
        {
            _filmstudioRepository = filmstudioRepository;
            _mapper = mapper;
            _lendedMovieRepository = lendedMovieRepository;
        }

        // GET: api/FilmStudios
        [HttpGet]
        public async Task<ActionResult<FilmstudioModel[]>> GetFilmStudios()
        {
            //return await _filmStudioRepository.GetAllFilmStudios();
            try
            {
                var results = await _filmstudioRepository.GetAllFilmstudios();
                return _mapper.Map<FilmstudioModel[]>(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        // POST: api/FilmStudios
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Filmstudio> PostFilmStudio(Filmstudio filmstudio)
        {
            _filmstudioRepository.AddFilmstudio(filmstudio);
            //return CreatedAtAction("GetFilmStudio", new { id = filmstudio.FilmstudioId }, filmstudio);
            return Ok(filmstudio);
        }


        [HttpGet("{studioId:int}")]
        public async Task<ActionResult<FilmstudioModel>> GetStudio(int studioId)
        {
            try
            {
                var result = await _filmstudioRepository.GetFilmstudioById(studioId);

                if (result == null) return NotFound();

                return _mapper.Map<FilmstudioModel>(result);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        // PUT: api/FilmStudios/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPatch("{id}")]
        public IActionResult ChangeFilmstudio(int filmstudioId, string filmstudioName, string city)
        {
            _filmstudioRepository.UpdateFilmstudio(filmstudioId, filmstudioName, city);

            return NoContent();
        }

        // DELETE: api/FilmStudios/5
        [HttpDelete("{id}")]
        public ActionResult<Filmstudio> DeleteFilmStudio(int id)
        {
            _filmstudioRepository.DeleteFilmstudio(id);
            return NoContent();
        }



        //Gets all lended movies for a filmstudio
        [HttpGet("LendedMovies")]
        public ActionResult<IEnumerable<LendedMovie>> GetLendedMovies(string filmstudioName, bool onlyActive = false)
        {
            try
            {
                var result = _lendedMovieRepository.GetAllMoviesForLender(filmstudioName, onlyActive);

                if (result == null) return NotFound();

                return Ok(result);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        //Adds an active lending if the movie is available
        [HttpPost("LendedMovies")]
        public ActionResult<LendedMovie> AddLendedMovie(string studioName, int movieId)
        {
            try
            {
                _lendedMovieRepository.LendMovieForStudioName(studioName, movieId);
                return NoContent();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        //Returns a lended movie, makes the lending not active
        [HttpPatch("{studioId:int}/LendedMovies")]
        public ActionResult<LendedMovie> ReturnLendedMovie(int studioId, int movieId)
        {
            _lendedMovieRepository.ReturnMovie(studioId, movieId);
            return NoContent();
        }

    }
}
