namespace WebApiCase1.Middlewares
{
    public static class MiddlewareExtensions
    {
        // Extension method for adding custom middlewares
        public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<LoggingMiddleware>();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<AuthenticationMiddleware>();
            return app;
        }
    }
}
