namespace Jala.Custom.Middleware.API.Middlewares;

public class QueryStringMiddleware
{
    private readonly RequestDelegate _next;

    public QueryStringMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        var id = context.Request.Query["id"].FirstOrDefault();
        if (!string.IsNullOrEmpty(id))
            context.Items["Id"] = id;
        await _next(context);
    }
}

public static class QueryStringMiddlewareExtension
{
    public static IApplicationBuilder UseQueryStringMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<QueryStringMiddleware>();
    }
}