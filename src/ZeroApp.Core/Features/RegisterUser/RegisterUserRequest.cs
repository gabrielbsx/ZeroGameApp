using ZeroApp.Core.Requests;

namespace ZeroApp.Core.Features.RegisterUser;

public sealed record RegisterUserRequest(
    string Name,
    string Email,
    string Password,
    string RegistrationSource,
    string RegistrationIp,
    bool CreateCharacter,
    string Gender,
    // Default Request Values
    string Action,
    string UserId,
    string UserSessionId,
    string ClientVersion,
    int BuildNumber,
    string Auth,
    int Rct,
    bool KeepAlive,
    string DeviceType
) : DefaultRequestValues(
    Action,
    UserId,
    UserSessionId,
    ClientVersion,
    BuildNumber,
    Auth,
    Rct,
    KeepAlive,
    DeviceType
);