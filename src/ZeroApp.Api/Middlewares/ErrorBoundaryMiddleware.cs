using System.Net;
using System.Text.Json;

namespace ZeroApp.Api.Middlewares;

public class ErrorBoundaryMiddleware
{
    private readonly RequestDelegate _next;
    
    public ErrorBoundaryMiddleware(RequestDelegate next)
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
            await HandleExceptionAsync(context, ex);
        }
    }
    
    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = new {
            data = (object)null!,
            error = exception.Message
        };
        
        var result = JsonSerializer.Serialize(response);
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.OK;
        
        return context.Response.WriteAsync(result);
    }
}