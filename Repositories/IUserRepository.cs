using WebApiCase1.Models;

namespace WebApiCase1.Repositories
{
    // Interface defining the contract for user repository operations
    public interface IUserRepository
    {
        User GetByUsername(string username);
        User GetById(int id);
        void Add(User user);
        IEnumerable<User> GetAll();
    }
}
