using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ZeroApp.Api.Handlers;

namespace ZeroApp.Api.Controllers;

[ApiController]
[Route("api/requests")]
internal class ActionHandlerController : ControllerBase
{
    [HttpPost]
    [Route("")]
    public async Task<IActionResult> Execute([FromForm] JsonElement unknownRequest)
    {
        var hasActionField = unknownRequest.TryGetProperty(
            "Action",
            out var actionElement
        );

        var isActionString = actionElement.ValueKind == JsonValueKind.String;

        var isValidAction = hasActionField && isActionString && !string.IsNullOrWhiteSpace(actionElement.GetString());

        if (!isValidAction)
        {
            return BadRequest("Action field is required.");
        }

        var action = actionElement.GetString()!;

        var handler = ActionHandlerRegistry.GetHandler(action);

        if (handler != null)
        {
            return await handler(unknownRequest);
        }

        return NotFound("Action not found");
    }
}