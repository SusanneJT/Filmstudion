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

        [HttpGet("{studioName}")]
        public async Task<ActionResult<FilmstudioModel>> GetStudio(string studioName)
        {
            try
            {
                var result = await _filmstudioRepository.GetFilmstudioByName(studioName);

                if (result == null) return NotFound();

                return _mapper.Map<FilmstudioModel>(result);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
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
        [HttpGet("{studioId:int}/LendedMovies")]
        public ActionResult<IEnumerable<LendedMovie>> GetLendedMovies(int studioId, bool onlyActive = false)
        {
            try
            {
                var result =  _lendedMovieRepository.GetAllMoviesForLenderId(studioId, onlyActive);

                if (result == null) return NotFound();

                return Ok(result);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        /*
        // GET: api/FilmStudios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmStudio>> GetFilmStudio(int id)
        {
            var filmStudio = await _filmStudioRepository.FilmStudios.FindAsync(id);

            if (filmStudio == null)
            {
                return NotFound();
            }

            return filmStudio;
        }

        // PUT: api/FilmStudios/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmStudio(int id, FilmStudio filmStudio)
        {
            if (id != filmStudio.FilmStudioId)
            {
                return BadRequest();
            }

            _filmStudioRepository.Entry(filmStudio).State = EntityState.Modified;

            try
            {
                await _filmStudioRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmStudioExists(id))
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

        // POST: api/FilmStudios
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<FilmStudio>> PostFilmStudio(FilmStudio filmStudio)
        {
            _filmStudioRepository.FilmStudios.Add(filmStudio);
            await _filmStudioRepository.SaveChangesAsync();

            return CreatedAtAction("GetFilmStudio", new { id = filmStudio.FilmStudioId }, filmStudio);
        }

        // DELETE: api/FilmStudios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FilmStudio>> DeleteFilmStudio(int id)
        {
            var filmStudio = await _filmStudioRepository.FilmStudios.FindAsync(id);
            if (filmStudio == null)
            {
                return NotFound();
            }

            _filmStudioRepository.FilmStudios.Remove(filmStudio);
            await _filmStudioRepository.SaveChangesAsync();

            return filmStudio;
        }

        private bool FilmStudioExists(int id)
        {
            return _filmStudioRepository.FilmStudios.Any(e => e.FilmStudioId == id);
        }
        */
    }
}
