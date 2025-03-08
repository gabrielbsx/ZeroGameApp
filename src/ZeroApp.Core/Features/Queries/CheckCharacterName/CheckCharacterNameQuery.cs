using MediatR;
using ZeroApp.Core.Features.Commands.CheckCharacterName;

namespace ZeroApp.Core.Features.Queries.CheckCharacterName;

public class CheckCharacterNameQuery : IRequestHandler<CheckCharacterNameRequest, CheckCharacterNameResponse>
{
    public async Task<CheckCharacterNameResponse> Handle(CheckCharacterNameRequest request,
        CancellationToken cancellationToken)
    {
        return await Task.FromResult(new CheckCharacterNameResponse());
    }
}