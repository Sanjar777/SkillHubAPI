namespace SkillHubAPI.Middleware;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionMiddleware> _logger = logger;
    private readonly IHostEnvironment _env = env;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context); // call the next middleware
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            var response = _env.IsDevelopment()
                ? new { status = 500, message = ex.Message, details = ex.StackTrace?.ToString() }
                : new { status = 500, message = "Internal Server Error", details = (string?)null };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}