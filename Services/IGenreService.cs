using WebApiCase1.Models;

namespace WebApiCase1.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        Task<Genre> GetGenreByIdAsync(int id);
        Task<Genre> CreateGenreAsync(Genre genre);
        Task<Genre> UpdateGenreAsync(Genre genre);
        Task DeleteGenreAsync(int id);
    }
}
