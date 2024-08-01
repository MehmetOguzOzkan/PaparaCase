using WebApiCase1.Models;

namespace WebApiCase1.Repositories
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAllAsync();
        Task<Genre> GetByIdAsync(int id);
        Task<Genre> AddAsync(Genre genre);
        Task<Genre> UpdateAsync(Genre genre);
        Task DeleteAsync(int id);

    }
}
