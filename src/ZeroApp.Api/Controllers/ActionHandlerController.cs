using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZeroApp.Api.Helpers;

namespace ZeroApp.Api.Controllers;

[ApiController]
[Route("api/actions")]
public class ActionHandlerController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public ActionHandlerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("request")]
    public async Task<IActionResult> Execute([FromForm] Dictionary<string, string> unknownFormData)
    {
        var request = ActionValidateAndConvert.ValidateAndConvert(unknownFormData);
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}