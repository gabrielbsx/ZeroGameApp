using ZeroApp.Core.Features.Commands.CreateCharacter;
using ZeroApp.Core.Features.Commands.RegisterUser;

namespace ZeroApp.Api.Helpers;

public static class ActionMapping
{
    public static readonly Dictionary<string, Type> Actions = new()
    {
        { "registerUser", typeof(RegisterUserRequest) },
        { "createCharacter", typeof(CreateCharacterRequest) }
    };
}