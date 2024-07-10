using WebApiCase1.Models;

namespace WebApiCase1.Services
{
    // Interface defining the contract for user service operations
    public interface IUserService
    {
        User Authenticate(string username, string password);
        User Register(User user);
        IEnumerable<User> GetAllUsers();
    }
}
