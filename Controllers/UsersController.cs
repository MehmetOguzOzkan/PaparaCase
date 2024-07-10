using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiCase1.DTOs.Requests;
using WebApiCase1.Models;
using WebApiCase1.Services;

namespace WebApiCase1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // Endpoint for user registration
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            var user = new User
            {
                Username = request.Username,
                Password = request.Password,
                Email = request.Email
            };

            var registeredUser = _userService.Register(user);
            return Ok(registeredUser);
        }

        // Endpoint for user login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _userService.Authenticate(request.Username, request.Password);
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok(user);
        }

        // Endpoint to get all users (requires authorization)
        [HttpGet("all")]
        [Authorize]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
    }
}
