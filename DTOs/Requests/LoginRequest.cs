using System.ComponentModel.DataAnnotations;

namespace WebApiCase1.DTOs.Requests
{
    public class LoginRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
