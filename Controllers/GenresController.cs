using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiCase1.DTOs.Requests;
using WebApiCase1.DTOs.Responses;
using WebApiCase1.Models;
using WebApiCase1.Services;

namespace WebApiCase1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenresController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await _genreService.GetAllGenresAsync();
            var response = _mapper.Map<IEnumerable<GenreResponse>>(genres);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById(int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);
            if (genre == null)
            {
                return NotFound();
            }
            var response = _mapper.Map<GenreResponse>(genre);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody] GenreRequest request)
        {
            var genre = _mapper.Map<Genre>(request);
            var createdGenre = await _genreService.CreateGenreAsync(genre);
            var response = _mapper.Map<GenreResponse>(createdGenre);
            return CreatedAtAction(nameof(GetGenreById), new { id = createdGenre.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(int id, [FromBody] GenreRequest request)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);
            if (genre == null)
            {
                return NotFound();
            }
            _mapper.Map(request, genre);
            await _genreService.UpdateGenreAsync(genre);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);
            if (genre == null)
            {
                return NotFound();
            }
            await _genreService.DeleteGenreAsync(id);
            return NoContent();
        }
    }
}
