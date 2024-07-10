using WebApiCase1.Models;
using WebApiCase1.Repositories;

namespace WebApiCase1.Services
{
    // Implementation of IUserService
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Authenticate a user by username and password
        public User Authenticate(string username, string password)
        {
            var user = _userRepository.GetByUsername(username);
            if (user == null || user.Password != password)
            {
                return null;
            }
            return user;
        }

        // Register a new user
        public User Register(User user)
        {
            _userRepository.Add(user);
            return user;
        }

        // Retrieve all users
        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }
    }
}
