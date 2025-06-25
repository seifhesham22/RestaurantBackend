using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Restaurant.Core.Errors;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestaurantBackend.API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHadlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHadlingMiddleware> _logger;

        public ExceptionHadlingMiddleware(RequestDelegate next, ILogger<ExceptionHadlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "An unhandled exception occurred while processing request {Method} {Path}",
                    httpContext.Request.Method,
                    httpContext.Request.Path
                    );

                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var statusCode = exception switch
            {
                ArgumentNullException => StatusCodes.Status400BadRequest,
                ArgumentException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.StatusCode = statusCode;

            var response = JsonSerializer.Serialize(new
            {
                error = exception.Message,
                type = exception.GetType().Name
            });

            return context.Response.WriteAsync(response);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHadlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHadlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHadlingMiddleware>();
        }
    }
}
