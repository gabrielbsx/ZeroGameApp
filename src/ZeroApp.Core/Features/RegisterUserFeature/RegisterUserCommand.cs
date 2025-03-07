using ZeroApp.Core.Contracts;

namespace ZeroApp.Core.Features.RegisterUserFeature;

public class RegisterUserCommand : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
{
    public async Task<RegisterUserResponse> HandleAsync(RegisterUserRequest request)
    {
        return await Task.FromResult(new RegisterUserResponse("Testando"));
    }
}