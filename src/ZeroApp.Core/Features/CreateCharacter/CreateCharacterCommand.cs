using ZeroApp.Core.Contracts;

namespace ZeroApp.Core.Features.CreateCharacter;

public class CreateCharacterCommand : IRequestHandler<CreateCharacterRequest, CreateCharacterResponse>
{
    public static string Action = "createCharacter";
    
    public async Task<CreateCharacterResponse> HandleAsync(CreateCharacterRequest request)
    {
        return await Task.FromResult(new CreateCharacterResponse("Testando"));
    }
}