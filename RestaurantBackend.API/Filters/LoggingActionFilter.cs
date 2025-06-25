using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace RestaurantBackend.API.Filters
{
    public class LoggingActionFilter : IActionFilter
    {
        private readonly ILogger<LoggingActionFilter> _logger;

        public LoggingActionFilter(ILogger<LoggingActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.ActionDescriptor.RouteValues["controller"];
            var method = context.ActionDescriptor.RouteValues["action"];

            var parameters = context.ActionArguments
                .Select(a => $"{a.Key}: {a.Value}")
                .ToList();

            var parameterString = parameters.Count > 0
                ?string.Join(", ", parameters)
                : "(no parameters)";

            _logger.LogInformation("Executing {Controller}.{Action} with parameters: {Parameters}",
           controller, method, parameterString);
        }
    }
}
