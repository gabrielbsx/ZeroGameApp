using ZeroApp.Api.Helpers;

namespace ZeroApp.Api.Middlewares;

public class ActionValidationMiddleware
{
    private readonly RequestDelegate _next;

    public ActionValidationMiddleware(RequestDelegate next) => _next = next;

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path == "/api/actions/request" && context.Request.Method == "POST")
        {
            var form = await context.Request.ReadFormAsync();
            var action = form["action"].ToString();

            if (string.IsNullOrWhiteSpace(action) || !ActionMapping.Actions.ContainsKey(action))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid or missing action.");
                return;
            }
        }

        await _next(context);
    }
}