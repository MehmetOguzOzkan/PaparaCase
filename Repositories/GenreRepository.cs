using Microsoft.EntityFrameworkCore;
using WebApiCase1.Data;
using WebApiCase1.Models;

namespace WebApiCase1.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task<Genre> AddAsync(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre> UpdateAsync(Genre genre)
        {
            _context.Entry(genre).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task DeleteAsync(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                await _context.SaveChangesAsync();
            }
        }
    }
}
