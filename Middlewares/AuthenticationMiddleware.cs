using WebApiCase1.Services;

namespace WebApiCase1.Middlewares
{
    // Middleware to handle user authentication
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                var user = userService.GetAllUsers().FirstOrDefault(u => u.Id.ToString() == token);
                if (user != null)
                {
                    context.Items["User"] = user.Id;
                }
            }

            await _next(context);
        }
    }
}
