using ZeroApp.Core.Requests;

namespace ZeroApp.Core.Features.RegisterUserFeature;

public sealed record RegisterUserRequest(
    string Name,
    string Email,
    string Password,
    string RegistrationSource,
    string RegistrationIp,
    bool CreateCharacter,
    string Gender,
    // Default Request Values
    string UserId,
    string UserSessionId,
    string ClientVersion,
    string Action
) : DefaultRequestValues(
    UserId,
    UserSessionId,
    ClientVersion,
    Action
);