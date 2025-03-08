using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ZeroApp.Core.Contracts;

namespace ZeroApp.Api.ActionRegistry;

public static class ActionHandlerRegistry
{
    private static readonly Dictionary<string, Func<IServiceProvider, JsonElement, Task<IActionResult>>>
        ActionHandlers = new();

    public static void AddHandler<TRequest, TResponse, THandler>(
        string actionName,
        THandler handler)
        where TRequest : class
        where THandler : IRequestHandler<TRequest, TResponse>
    {
        if (!ActionHandlers.ContainsKey(actionName))
        {
            ActionHandlers[actionName] = async (serviceProvider, requestData) =>
                await ProcessRequest<TRequest, TResponse, THandler>(
                    serviceProvider,
                    requestData,
                    handler
                );
        }
    }

    public static Dictionary<string, Func<IServiceProvider, JsonElement, Task<IActionResult>>> GetHandlers() =>
        ActionHandlers;

    public static Func<IServiceProvider, JsonElement, Task<IActionResult>>? GetHandler(string action) =>
        ActionHandlers.GetValueOrDefault(action);

    private static async Task<IActionResult> ProcessRequest<TRequest, TResponse, THandler>(
        IServiceProvider serviceProvider,
        JsonElement requestData,
        THandler handler)
        where TRequest : class
        where THandler : IRequestHandler<TRequest, TResponse>
    {
        var request = JsonSerializer.Deserialize<TRequest>(requestData.GetRawText());
        if (request == null)
        {
            return new BadRequestObjectResult("Invalid request format.");
        }

        var validator = serviceProvider.GetService<IValidator<TRequest>>();

        if (validator != null)
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult.Errors);
            }
        }

        var response = await handler.HandleAsync(request);

        return response != null ? new OkObjectResult(response) : new StatusCodeResult(500);
    }
}