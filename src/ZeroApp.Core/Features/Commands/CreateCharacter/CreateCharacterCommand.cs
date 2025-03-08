using MediatR;

namespace ZeroApp.Core.Features.Commands.CreateCharacter;

public class CreateCharacterCommand : IRequestHandler<CreateCharacterRequest, CreateCharacterResponse>
{
    public async Task<CreateCharacterResponse> Handle(CreateCharacterRequest request,
        CancellationToken cancellationToken)
    {
        return await Task.FromResult(new CreateCharacterResponse("Character created"));
    }
}