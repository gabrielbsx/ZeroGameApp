using ZeroApp.Core.Requests;

namespace ZeroApp.Core.Features.Commands.RegisterUser;

public sealed record RegisterUserResponse(
    string UserId
) : ActionResponse;