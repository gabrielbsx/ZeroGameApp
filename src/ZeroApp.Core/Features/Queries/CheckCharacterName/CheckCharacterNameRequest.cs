using ZeroApp.Core.Features.Commands.CheckCharacterName;
using ZeroApp.Core.Requests;

namespace ZeroApp.Core.Features.Queries.CheckCharacterName;

public sealed record CheckCharacterNameRequest(
    string Name
) : ActionRequest<CheckCharacterNameResponse>("checkCharacterName");