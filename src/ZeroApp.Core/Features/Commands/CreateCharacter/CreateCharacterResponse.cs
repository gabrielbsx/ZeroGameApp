using ZeroApp.Core.Requests;

namespace ZeroApp.Core.Features.Commands.CreateCharacter;

public sealed record CreateCharacterResponse(
    string CharacterId
) : ActionResponse;