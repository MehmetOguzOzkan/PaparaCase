using WebApiCase1.Data;
using WebApiCase1.Models;

namespace WebApiCase1.Repositories
{
    // Implementation of IUserRepository using Entity Framework Core
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieve a user by username
        public User GetByUsername(string username)
        {
            return _context.Users.SingleOrDefault(u => u.Username == username);
        }

        // Retrieve a user by ID
        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        // Add a new user to the database
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        // Retrieve all users from the database
        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
