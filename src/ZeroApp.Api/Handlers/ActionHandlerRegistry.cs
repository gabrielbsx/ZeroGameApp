using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ZeroApp.Core.Contracts;

namespace ZeroApp.Api.Handlers;

public static class ActionHandlerRegistry
{
    private static readonly Dictionary<string, Func<JsonElement, Task<IActionResult>>> ActionHandlers = new();

    public static void AddHandler<TRequest, TResponse, THandler>(
        string actionName,
        IValidator<TRequest> validator,
        THandler handler)
        where TRequest : class
        where THandler : IRequestHandler<TRequest, TResponse>
    {
        if (!ActionHandlers.ContainsKey(actionName))
        {
            ActionHandlers[actionName] = async requestData =>
                await ProcessRequest<TRequest, TResponse, THandler>(
                    requestData,
                    validator,
                    handler
                );
        }
    }

    public static Dictionary<string, Func<JsonElement, Task<IActionResult>>> GetHandlers()
    {
        return ActionHandlers;
    }

    public static Func<JsonElement, Task<IActionResult>>? GetHandler(string action)
    {
        return ActionHandlers.TryGetValue(
            action,
            out var handler
        )
            ? handler
            : null;
    }

    private static async Task<IActionResult> ProcessRequest<TRequest, TResponse, THandler>(
        JsonElement requestData,
        IValidator<TRequest> validator,
        THandler handler)
        where TRequest : class
        where THandler : IRequestHandler<TRequest, TResponse>
    {
        var request = JsonSerializer.Deserialize<TRequest>(requestData.GetRawText());
        if (request == null)
        {
            return new BadRequestObjectResult("Invalid request format.");
        }

        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return new BadRequestObjectResult(validationResult.Errors);
        }

        var response = await handler.HandleAsync(request);

        return response != null ? new OkObjectResult(response) : new StatusCodeResult(500);
    }
}