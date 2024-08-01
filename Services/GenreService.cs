using WebApiCase1.Models;
using WebApiCase1.Repositories;

namespace WebApiCase1.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            return await _genreRepository.GetAllAsync();
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            return await _genreRepository.GetByIdAsync(id);
        }

        public async Task<Genre> CreateGenreAsync(Genre genre)
        {
            return await _genreRepository.AddAsync(genre);
        }

        public async Task<Genre> UpdateGenreAsync(Genre genre)
        {
            return await _genreRepository.UpdateAsync(genre);
        }

        public async Task DeleteGenreAsync(int id)
        {
            await _genreRepository.DeleteAsync(id);
        }
    }
}
