using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ZeroApp.Api.ActionRegistry;

namespace ZeroApp.Api.Controllers;

[ApiController]
[Route("api/actions")]
public class ActionHandlerController : ControllerBase
{
    [HttpPost]
    [Route("request")]
    public async Task<IActionResult> Execute([FromForm] Dictionary<string, string> unknownRequestJson)
    {
        if (!unknownRequestJson.TryGetValue(
                "action",
                out var action
            ) || string.IsNullOrWhiteSpace(action))
        {
            return BadRequest("Action field is required.");
        }

        var json = JsonSerializer.Serialize(unknownRequestJson);
        var jsonDocument = JsonDocument.Parse(json);
        var unknownRequest = jsonDocument.RootElement;

        var handler = ActionHandlerRegistry.GetHandler(action);

        if (handler != null)
        {
            return await handler.Invoke(HttpContext.RequestServices, unknownRequest);
        }

        return NotFound("Action not found");
    }
}