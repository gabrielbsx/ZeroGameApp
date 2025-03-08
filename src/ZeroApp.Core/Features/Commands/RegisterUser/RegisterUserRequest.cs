using ZeroApp.Core.Requests;

namespace ZeroApp.Core.Features.Commands.RegisterUser;

public sealed record RegisterUserRequest(
    string Name,
    string Email,
    string Password,
    string RegistrationSource,
    string RegistrationIp,
    bool CreateCharacter,
    string Gender
) : ActionRequest<RegisterUserResponse>("registerUser");