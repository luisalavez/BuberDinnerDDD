using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BuberDinner.Api.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            
            await HandleExpectionAsync(context, ex);
        }
    }

    private static Task HandleExpectionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = JsonSerializer.Serialize(new {error = "An error ocurred while processing your request."});
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }
}